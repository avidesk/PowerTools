#region Header

// File: Avidesk.PowerTools\Avidesk.PowerTools.String\StringExtensions.cs
// Date Created: 05/15/2019 3:46 PM
// 
// Last Code Cleanup: 05/17/2019 9:20 PM
// Last Cleaned By: Andrew Johnson (andrewjohnson)

#endregion

#region Using Directives

using System;
using System.Text;

#endregion

namespace Avidesk.PowerTools.String
{
    public static class StringExtensions
    {
        #region Static Methods

        public static bool Contains(this string source, string containsValue, StringComparison stringComparison)
        {
            return source?.IndexOf(containsValue, stringComparison) >= 0;
        }

        public static string DecodeBase64(this string input, Encoding encoding)
        {
            return StringEncoding.DecodeBase64(input, encoding);
        }

        public static string DecodeBase64(this string input)
        {
            return StringEncoding.DecodeBase64(input);
        }

        public static string EncodeBase64(this string input, Encoding encoding)
        {
            return StringEncoding.EncodeBase64(input, encoding);
        }

        public static string EncodeBase64(this string input)
        {
            return StringEncoding.EncodeBase64(input);
        }

        #endregion
    }
}