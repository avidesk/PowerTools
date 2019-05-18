#region Header
// File: Avidesk.PowerTools\Avidesk.PowerTools.Serialization\XmlSerializer.cs
// Date Created: // 
// 
// Last Code Cleanup: 05/15/2019 4:04 PM
// Last Cleaned By: Andrew Johnson (andrewjohnson)
#endregion

using System.IO;

namespace Avidesk.PowerTools.Serialization
{
    public class XmlSerializer : ISerializer
    {
        public void Serialize(object input, string filename)
        {
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(input.GetType());
            using (var writer = new StreamWriter(filename))
            {
                xmlSerializer.Serialize(writer, input);
            }
        }

        public T Deserialize<T>(string filename) where T : new()
        {
            var result = new T();

            FileSystem.Path path = filename;
            if (path.Exists)
            {
                var type = typeof(T);
                var xmlSerializer = new System.Xml.Serialization.XmlSerializer(type);
                using (var reader = new StreamReader(path))
                {
                    result = (T) xmlSerializer.Deserialize(reader);
                }
            }

            return result;
        }
    }
}