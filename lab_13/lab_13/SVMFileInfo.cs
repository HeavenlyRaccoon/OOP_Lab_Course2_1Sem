using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab_13
{
    public static class SVMFileInfo
    {
        public static void FilePath(string path)
        {
            var FullPath = Path.GetFullPath(path);

            Console.WriteLine($"{FullPath}");
            Console.WriteLine();

            SVMLog.OpenFile().WriteLine($"{DateTime.Now}\nChecking path to file\nFile name: {path}\nPath: {FullPath}\n@");
        }

        public static void SizeExtensionName(string path)
        {
            var fileSize = path.Length;
            var fileExtension = Path.GetExtension(path);
            var fileName = Path.GetFileNameWithoutExtension(path);

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File size: {fileSize}");
            Console.WriteLine($"File extension: {fileExtension}");
            Console.WriteLine();

            SVMLog.OpenFile().WriteLine($"{DateTime.Now}\nChecking file size, extension and name\nFile name: {fileName}\nPath: {path}\n@");
        }

        public static void TimeInfo(string str)
        {
            Console.WriteLine("File created: " + File.GetCreationTime(str));
            Console.WriteLine("File changed: " + File.GetLastAccessTime(str));
            Console.WriteLine();

            SVMLog.OpenFile().WriteLine($"{DateTime.Now}\nChecking file creation time\nFile name: {Path.GetFileNameWithoutExtension(str)}\nPath: {str}\n@");
        }

        public static void PrintFileInfo(string str)
        {
            FilePath(str);
            SizeExtensionName(str);
            TimeInfo(str);
        }
    }
}
