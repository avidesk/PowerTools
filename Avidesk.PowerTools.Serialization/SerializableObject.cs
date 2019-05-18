#region Header

// File: Avidesk.PowerTools\Avidesk.PowerTools.Common\SerializableObject.cs
// Date Created: 05/15/2019 3:25 PM
// 
// Last Code Cleanup: 05/15/2019 3:29 PM
// Last Cleaned By: Andrew Johnson (andrewjohnson)

#endregion

#region Using Directives

using System.IO;

#endregion

namespace Avidesk.PowerTools.Serialization
{
    public class SerializableObject
    {
        #region Static Methods

        public static T Load<T>(string filename, ISerializer serializer) where T : new()
        {
            return serializer.Deserialize<T>(filename);
        }

        public static void Save(object saveObject, string filename, ISerializer serializer)
        {
            FileSystem.Path path = filename;
            var saveDirectory = path.Directory;

            if (!Directory.Exists(saveDirectory))
            {
                Directory.CreateDirectory(saveDirectory);
            }

            serializer.Serialize(saveObject, filename);
        }

        #endregion

        #region Public Methods

        public void Save(string filename, ISerializer serializer)
        {
            Save(this, filename, serializer);
        }

        #endregion
    }
}