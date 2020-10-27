using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileChangeDetection
{
    class CleaningInput
    {
        /// <summary>
        /// Method to remove any whitespaces in the string, potentially when retrieving data from the database
        /// </summary>
        /// <param name="s">The input to remove white spaces from</param>
        /// <returns>The input that is formatted without white space</returns>
        public static string RemoveWhiteSpaces(string s)
        {
            return string.Join(" ", s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }

        /// <summary>
        /// Input Sanitization for SQL Injection
        /// Using a list of unacceptable or potentially dangerous special characters and to remove them
        /// </summary>
        /// <param name="phrase">The phase to be checked for dangerous characters and to be removed from</param>
        /// <returns>The "Cleaned" input</returns>
        public static string cleanUpInput(string phrase)
        {
            string cleanedInput = Regex.Replace(phrase, @"[^0-9a-zA-Z ///@/:/./,]+", "");
            return cleanedInput;
        }
    }
}
