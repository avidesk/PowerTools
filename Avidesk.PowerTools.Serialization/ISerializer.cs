#region Header
// File: Avidesk.PowerTools\Avidesk.PowerTools.Serialization\ISerializer.cs
// Date Created: // 
// 
// Last Code Cleanup: 05/15/2019 4:04 PM
// Last Cleaned By: Andrew Johnson (andrewjohnson)
#endregion
namespace Avidesk.PowerTools.Serialization
{
    public interface ISerializer
    {
        void Serialize(object input, string filename);
        T Deserialize<T>(string filename) where T : new();
    }
}