using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace FileChangeAlert
{
    class FileHandling
    {
        public static void WriteToFile(String filepath, String thingsToWrite)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@filepath, true))
                {
                    writer.WriteLine(thingsToWrite);
                }
            }
            catch (FileNotFoundException)
            {
                Console.Write("File Not Found");
            }
            catch (IOException)
            {
                Console.Write("IOException");
            }
        }

        public static void WriteToFileWithoutLine(String filepath, String thingsToWrite)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@filepath, true))
                {
                    writer.Write(thingsToWrite);
                }
            }
            catch (FileNotFoundException)
            {
                Console.Write("File Not Found");
            }
            catch (IOException)
            {
                Console.Write("IOException");
            }
        }

        public static String ReadFromFile(String filepath)
        {
            string text;
            var fileStream = new FileStream(@filepath, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                text = streamReader.ReadToEnd();
            }
            return text;
        }

        public static DateTime getCreationDateForLog(String filepath)
        {
            DateTime creation = File.GetCreationTime(@filepath);
            return creation;
        }

        public static DateTime getModifiedDateForLog(String filepath)
        {
            DateTime modification = File.GetLastWriteTime(@filepath);
            return modification;
        }

        public static Boolean fileExists(String filepath)
        {
            Boolean exist;
            if (File.Exists(@filepath))
            {
                exist = true;
            }
            else
            {
                exist = false;
            }
            return exist;
        }

        public static void RemoveFile(String filepath)
        {
            FileIOPermission fileIOPerm1;
            fileIOPerm1 = new FileIOPermission(FileIOPermissionAccess.AllAccess, @"C:\Windows\System32\drivers\etc");
            File.Delete(@filepath);
        }

        public static bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }

        public static String[] ReadFromFileEachLine(String path)
        {
            string[] lines = File.ReadAllLines(@path);
            return lines;
        }
    }
}
