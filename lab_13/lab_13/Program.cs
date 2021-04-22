using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab_13
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Directory.Delete(@"C:\Users\User\Desktop\ООТП\test\SVMInspect", true);
                File.Delete(@"C:\Users\User\Desktop\ООТП\test\OOP_Lab13.sln");
                File.Delete(@"C:\Users\User\Desktop\ООТП\test\SVMlogfile.txt");
            }
            catch
            { }

            SVMDiskInfo.PrintDiskInfo();
            SVMFileInfo.PrintFileInfo(@"C:\Users\User\Desktop\ООТП\test\new.txt");
            SVMDirInfo.PrintDirInfo(new DirectoryInfo(@"C:\Users\User\Desktop\ООТП"));
            SVMFileManager.PrintFileManager();
            SVMLog.CloseFile();

            //для 6(шестого) задания
            SVMLog.ADSWrite();
            SVMLog.ADSDeletePartOfFile(1000);
        }
    }
}
