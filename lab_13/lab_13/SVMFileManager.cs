using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace lab_13
{
    public static class SVMFileManager
    {
        public static void WriteInFile()
        {
            string[] NumOfFiles = new string[50];
            string[] NumOfDir = new string[50];
            DirectoryInfo dir = new DirectoryInfo(@"C:\");
            Directory.CreateDirectory(@"C:\Users\User\Desktop\ООТП\test\SVMInspect");
            StreamWriter dirfile = new StreamWriter(@"C:\Users\User\Desktop\ООТП\test\SVMInspect\SVMdirinfo.txt", true);
            dirfile.WriteLine("-----------Files-----------:");
            foreach (var x in dir.GetFiles())
            {
                dirfile.WriteLine($"{x}");
            }
            dirfile.WriteLine("\n-----------Directories-----------");
            foreach (var y in dir.GetDirectories())
            {
                dirfile.WriteLine($"{y}");
            }
            dirfile.Close();
            Console.WriteLine("File SVMdirinfo.txt is created");
            SVMLog.OpenFile();

            SVMLog.OpenFile().WriteLine($"{DateTime.Now}\nCreating SVMdirinfo.txt\nPath: {dir.FullName}\n@");
        }

        public static void CopyAndRenameFile()
        {
            File.Copy(@"C:\Users\User\Desktop\ООТП\test\SVMInspect\SVMdirinfo.txt", @"C:\Users\User\Desktop\ООТП\test\SVMInspect\SVMdirinfoNew.txt");
            Console.WriteLine("File SVMdirinfo.txt is copied and renamed");

            SVMLog.OpenFile().WriteLine($"{DateTime.Now}\nCopying and renaming SVMdirinfo.txt\nPath: C:\\Users\\User\\Desktop\\ООТП\\test\\SVMInspect\\SVMdirinfo.txt@");
        }

        public static void DeleteOldFile()
        {
            File.Delete(@"C:\Users\User\Desktop\ООТП\test\SVMInspect\SVMdirinfo.txt");
            Console.WriteLine("File SVMdirinfo.txt is deleted");
            Console.WriteLine();

            SVMLog.OpenFile().WriteLine($"{DateTime.Now}\nDeleting old SVMdirinfo.txt\nPath: C:\\Users\\User\\Desktop\\ООТП\\test\\SVMInspect\\SVMdirinfo.txt@");
        }

        public static void NewDir()
        {
            Directory.CreateDirectory(@"C:\Users\User\Desktop\ООТП\test\SVMFiles");
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\User\Desktop\ООТП\test\OOP_Lab13");
            foreach (var x in dir.GetFiles())
            {
                if (Equals(x.Extension, ".sln"))
                {
                    File.Copy(@"C:\Users\User\Desktop\ООТП\test\OOP_Lab13\" + x.Name, @"C:\Users\User\Desktop\ООТП\test\SVMFiles\" + x.Name);
                }
            }
            Console.WriteLine("New directory SVMFiles is created");

            SVMLog.OpenFile().WriteLine($"{DateTime.Now}\nCreating directory SVMFiles\nPath: {dir.FullName}\n@");
        }

        public static void MoveNewDir()
        {
            Directory.Move(@"C:\Users\User\Desktop\ООТП\test\SVMFiles", @"C:\Users\User\Desktop\ООТП\test\SVMInspect\SVMFilesNEW");
            Console.WriteLine("New directory SVMFiles is moved");

            SVMLog.OpenFile().WriteLine($"{DateTime.Now}\nMoving directory SVMFiles\nPath: C:\\Users\\User\\Desktop\\ООТП\test\\SVMInspect\\SVMFiles");
        }

        public static void Zip()
        {
            ZipFile.CreateFromDirectory(@"C:\Users\User\Desktop\ООТП\test\SVMInspect\SVMFilesNEW", @"C:\Users\User\Desktop\ООТП\test\SVMInspect\Archive.rar");
            Console.WriteLine("Zip Archive.rar is created");

            SVMLog.OpenFile().WriteLine($"{DateTime.Now}\nCreating Zip Archive.rar\nPath: C:\\Users\\User\\Desktop\\ООТП\test\\SVMInspect\\SVMFiles\n@");
        }

        public static void Unzip()
        {
            ZipFile.ExtractToDirectory(@"C:\Users\User\Desktop\ООТП\test\SVMInspect\Archive.rar", @"C:\Users\User\Desktop\ООТП\test");
            Console.WriteLine("Unzipping is successful");

            SVMLog.OpenFile().WriteLine($"{DateTime.Now}\nUnzipping Archive.rar\nPath:  C:\\Users\\User\\Desktop\\ООТП\\test\\SVMInspect\n@");
        }

        public static void PrintFileManager()
        {
            WriteInFile();
            CopyAndRenameFile();
            DeleteOldFile();
            NewDir();
            MoveNewDir();
            Zip();
            Unzip();
        }
    }
}
