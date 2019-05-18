#region Header
// File: Avidesk.PowerTools\Avidesk.PowerTools.Serialization\JsonSerializer.cs
// Date Created: // 
// 
// Last Code Cleanup: 05/15/2019 4:05 PM
// Last Cleaned By: Andrew Johnson (andrewjohnson)
#endregion
namespace Avidesk.PowerTools.Serialization
{
    public class JsonSerializer : ISerializer
    {
        public void Serialize(object input, string filename)
        {
            throw new System.NotImplementedException();
        }

        public T Deserialize<T>(string filename) where T : new()
        {
            throw new System.NotImplementedException();
        }
    }
}