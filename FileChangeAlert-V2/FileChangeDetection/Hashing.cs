using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FileChangeDetection
{
    /// <summary>
    /// OBSOLETE CLASS NO LONGER IN USE
    /// 20 June 2018 METHOD
    /// </summary>
    class Hashing
    {
        /// <summary>
        /// OBSOLETE METHOD: This method is to MD5 hash of a specified file
        /// </summary>
        /// <param name="filepath">the path to the file to be hased</param>
        /// <returns>the hash value derived from the file</returns>
        public static String MD5Hash(String filepath)
        {
            using (var md5 = MD5.Create())
            {
                using (var filestream = File.OpenRead(filepath))
                {
                    return BitConverter.ToString(md5.ComputeHash(filestream)).Replace("-", String.Empty);
                }
            }
        }

        /// <summary>
        /// OBSOLETE METHOD: This method is to SHA256 hash of a specified file
        /// </summary>
        /// <param name="filepath">the path to the file to be hased</param>
        /// <returns>the hash value derived from the file</returns>
        public static String SHA256Hash(String filepath)
        {
            using (FileStream stream = File.OpenRead(filepath))
            {
                SHA256Managed sha256 = new SHA256Managed();
                byte[] hashed = sha256.ComputeHash(stream);
                return BitConverter.ToString(hashed).Replace("-", String.Empty);
            }
        }

        /// <summary>
        /// OBSOLETE METHOD: This method is to SHA512 hash of a specified file
        /// </summary>
        /// <param name="filepath">the path to the file to be hased</param>
        /// <returns>the hash value derived from the file</returns>
        public static String SHA512Hash(String filepath)
        {
            using (FileStream stream = File.OpenRead(filepath))
            {
                SHA512Managed sha512 = new SHA512Managed();
                byte[] hashed = sha512.ComputeHash(stream);
                return BitConverter.ToString(hashed).Replace("-", String.Empty);
            }
        }

        /// <summary>
        /// OBSOLETE METHOD: This method was to create a SHA512 hash from a string
        /// </summary>
        /// <param name="inputString">the string to be hashed</param>
        /// <returns>the byte array derived from the string</returns>
        public static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = SHA512.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        /// <summary>
        /// OBSOLETE METHOD:  This method was to create a hash from a string
        /// </summary>
        /// <param name="inputString">the string to be hashed</param>
        /// <returns>the hash derived from the string</returns>
        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        /// <summary>
        /// OBSOLETE METHOD: This method is to SHA1 hash of a specified file
        /// </summary>
        /// <param name="filepath">the path to the file to be hased</param>
        /// <returns>the hash value derived from the file</returns>
        public static String SHA1Hash(String filepath)
        {
            using (FileStream stream = File.OpenRead(filepath))
            {
                SHA1Managed sha1 = new SHA1Managed();
                byte[] hashed = sha1.ComputeHash(stream);
                return BitConverter.ToString(hashed).Replace("-", String.Empty);
            }
        }
    }
}
