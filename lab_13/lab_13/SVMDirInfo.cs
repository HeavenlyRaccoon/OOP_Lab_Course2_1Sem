using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab_13
{
    public static class SVMDirInfo
    {
        public static void Files(DirectoryInfo dir)
        {
            int num = 0;
            foreach (var x in dir.GetFiles())
            {
                num++;
            }
            Console.WriteLine($"Number of files: {num}");
            SVMLog.OpenFile().WriteLine($"{DateTime.Now}\nChecking number if files in directory\nPath: {dir.FullName}\n@");
            Console.WriteLine();
        }

        public static void Time(DirectoryInfo dir)
        {
            Console.WriteLine($"Creation time: {dir.CreationTime}");
            SVMLog.OpenFile().WriteLine($"{DateTime.Now}\nChecking directory creation time\nPath: {dir.FullName}\n@");
            Console.WriteLine();
        }

        public static void SubDir(DirectoryInfo dir)
        {
            int num = 0;
            foreach (var x in dir.GetDirectories())
            {
                num++;
            }
            Console.WriteLine($"Number of subdirectories: {num}");
            SVMLog.OpenFile().WriteLine($"{DateTime.Now}\nChecking number of subdirectories\nPath: {dir.FullName}\n@");
            Console.WriteLine();
        }

        public static void ParentDir(DirectoryInfo dir)
        {
            Console.WriteLine($"Parent directory: {dir.Parent}");
            SVMLog.OpenFile().WriteLine($"{DateTime.Now}\nChecking parent directory\nPath: {dir.FullName}\n@");
            Console.WriteLine();
        }

        public static void PrintDirInfo(DirectoryInfo dir)
        {
            Files(dir);
            Time(dir);
            SubDir(dir);
            ParentDir(dir);
        }
    }
}
