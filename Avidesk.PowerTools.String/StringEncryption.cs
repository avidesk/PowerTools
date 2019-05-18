#region Header

// File: Avidesk.PowerTools\Avidesk.PowerTools.String\StringEncryption.cs
// Date Created: 05/17/2019 9:14 PM
// 
// Last Code Cleanup: 05/17/2019 9:26 PM
// Last Cleaned By: Andrew Johnson (andrewjohnson)

#endregion

#region Using Directives

using System;
using System.Security.Cryptography;
using System.Text;

#endregion

namespace Avidesk.PowerTools.String
{
    public class StringEncryption
    {
        #region Static Methods

        public static string Decrypt(string input, string securityKey, bool useHashing = false)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            var inputBytes = Convert.FromBase64String(input);
            var keyBytes = useHashing ? GetMd5HashBytes(securityKey) : Encoding.UTF8.GetBytes(securityKey);

            var serviceProvider = new TripleDESCryptoServiceProvider
            {
                Key = keyBytes,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            var cryptoTransform = serviceProvider.CreateDecryptor();

            var bytes = cryptoTransform.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

            serviceProvider.Clear();

            return Encoding.UTF8.GetString(bytes);
        }

        public static string Encrypt(string input, string securityKey, bool useHashing = false)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            var inputBytes = Encoding.UTF8.GetBytes(input);
            var keyBytes = useHashing ? GetMd5HashBytes(securityKey) : Encoding.UTF8.GetBytes(securityKey);

            var serviceProvider = new TripleDESCryptoServiceProvider
            {
                Key = keyBytes,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            var cryptoTransform = serviceProvider.CreateEncryptor();

            var bytes = cryptoTransform.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

            serviceProvider.Clear();

            return Convert.ToBase64String(bytes, 0, bytes.Length);
        }

        public static string EncryptSha256(string input, string salt = null)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Input string cannot be null, empty, or whitespace.");
            }

            if (string.IsNullOrWhiteSpace(salt))
            {
                input = $"{input}{salt}";
            }

            var sha256 = new SHA256Managed();
            var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input), 0, Encoding.UTF8.GetByteCount(input));

            var hash = new StringBuilder();
            foreach (var hashByte in hashBytes)
            {
                hash.Append(hashByte.ToString("x2"));
            }

            return hash.ToString();
        }

        private static byte[] GetMd5HashBytes(string key)
        {
            var md5Hash = new MD5CryptoServiceProvider();
            var hashBytes = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(key));

            md5Hash.Clear();

            return hashBytes;
        }

        #endregion
    }
}