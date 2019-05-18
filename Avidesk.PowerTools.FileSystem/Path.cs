#region Header

// File: Avidesk.PowerTools\Avidesk.PowerTools.FileSystem\Path.cs
// Date Created: 05/15/2019 3:52 PM
// 
// Last Code Cleanup: 05/17/2019 9:03 PM
// Last Cleaned By: Andrew Johnson (andrewjohnson)

#endregion

#region Using Directives

using System;
using System.IO;

#endregion

namespace Avidesk.PowerTools.FileSystem
{
    public class Path
    {
        #region Fields

        private string _directory;

        private string _extension;

        #endregion

        #region Properties

        public Path Directory
        {
            get => IsFile ? _directory : System.IO.Path.GetDirectoryName(_directory);
            set => _directory = value.ToString().TrimEnd('\\');
        }

        public string DirectoryShort => System.IO.Path.GetFileName(_directory);

        public string FilenameWithoutExtension { get; set; }

        public string Extension
        {
            get => _extension;
            set => _extension = value.StartsWith(".") ? value : $".{value}";
        }

        public string Filename
        {
            get => FilenameWithoutExtension + _extension;
            set
            {
                var filename = value;
                FilenameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(filename);
                _extension = System.IO.Path.GetExtension(filename);
            }
        }

        public bool IsFile => !string.IsNullOrWhiteSpace(Filename);

        public bool Exists => IsFile ? File.Exists(this) : System.IO.Directory.Exists(this);

        #endregion

        #region Static Methods

        public static implicit operator string(Path path)
        {
            return path?.ToString();
        }

        public static implicit operator Path(string path)
        {
            return new Path(path);
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return string.IsNullOrEmpty(FilenameWithoutExtension)
                ? _directory
                : System.IO.Path.Combine(_directory, $"{FilenameWithoutExtension}{_extension}");
        }

        #endregion

        #region Constructor

        public enum PathType
        {
            AutoDetect,
            File,
            Directory
        }

        public Path()
        {
        }

        public Path(string path, PathType pathType = PathType.AutoDetect)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new Exception("Path parameter cannot be null.");
            }

            bool isFile;

            // Check if path is to a file or folder
            if (pathType == PathType.AutoDetect)
            {
                isFile = System.IO.Path.GetFileName(path).Contains(".");
            }
            else
            {
                isFile = pathType == PathType.File;
            }

            if (isFile)
            {
                _directory = System.IO.Path.GetDirectoryName(path);
                FilenameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(path);
                _extension = System.IO.Path.GetExtension(path);
            }
            else
            {
                _directory = path;
                FilenameWithoutExtension = string.Empty;
                _extension = string.Empty;
            }
        }

        public Path(string directory, string filename)
        {
            _directory = directory;
            FilenameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(filename);
            _extension = System.IO.Path.GetExtension(filename);
        }

        public Path(string directory, string filenameWithoutExtension, string extension)
        {
            _directory = directory;
            FilenameWithoutExtension = filenameWithoutExtension;
            Extension = extension;
        }

        #endregion
    }
}