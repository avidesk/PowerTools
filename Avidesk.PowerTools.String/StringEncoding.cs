#region Header

// File: Avidesk.PowerTools\Avidesk.PowerTools.String\StringEncoding.cs
// Date Created: 05/17/2019 9:13 PM
// 
// Last Code Cleanup: 05/17/2019 9:19 PM
// Last Cleaned By: Andrew Johnson (andrewjohnson)

#endregion

#region Using Directives

using System;
using System.Text;

#endregion

namespace Avidesk.PowerTools.String
{
    public class StringEncoding
    {
        #region Static Methods

        public static string DecodeBase64(string input)
        {
            return DecodeBase64(input, Encoding.UTF8);
        }

        public static string DecodeBase64(string input, Encoding encoding)
        {
            var bytes = Convert.FromBase64String(input);

            return encoding.GetString(bytes);
        }

        public static string EncodeBase64(string input)
        {
            return EncodeBase64(input, Encoding.UTF8);
        }

        public static string EncodeBase64(string input, Encoding encoding)
        {
            var bytes = encoding.GetBytes(input);

            return Convert.ToBase64String(bytes);
        }

        #endregion
    }
}