using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab_13
{
    public static class SVMDiskInfo
    {
        public static void FreeSpace()
        {
            DriveInfo[] driveinfo = DriveInfo.GetDrives();

            foreach (var item in driveinfo)
            {
                Console.WriteLine("Drive {0}", item.Name);
                if (item.IsReady == true)
                {
                    Console.WriteLine("  Available space to current user:{0, 15} bytes", item.AvailableFreeSpace);
                    Console.WriteLine("  Total available space:          {0, 15} bytes", item.TotalFreeSpace);
                    Console.WriteLine("  Total size of drive:            {0, 15} bytes ", item.TotalSize);
                }
            }
            SVMLog.OpenFile().WriteLine($"{DateTime.Now}\nScan free drive space\n@");
            Console.WriteLine();
        }

        public static void FileSystemInfo()
        {
            DriveInfo[] driveinfo = DriveInfo.GetDrives();

            foreach (DriveInfo item in driveinfo)
            {
                Console.WriteLine("Drive {0}", item.Name);
                if (item.IsReady == true)
                    Console.WriteLine("  File system: {0}", item.DriveFormat);
            }

            SVMLog.OpenFile().WriteLine($"{DateTime.Now}\nScan file system\n@");
            Console.WriteLine();
        }

        public static void DefaultInfo()
        {
            DriveInfo[] driveinfo = DriveInfo.GetDrives();

            foreach (DriveInfo item in driveinfo)
            {
                Console.WriteLine("Drive {0}", item.Name);
                if (item.IsReady == true)
                {
                    Console.WriteLine("  Total size of drive:            {0, 15} bytes ", item.TotalSize);
                    Console.WriteLine("  Available space to current user:{0, 15} bytes", item.AvailableFreeSpace);
                }
            }

            SVMLog.OpenFile().WriteLine($"{DateTime.Now}\nScan total, available space and volume label of drive\n@");
            Console.WriteLine();
        }

        public static void PrintDiskInfo()
        {
            FreeSpace();
            FileSystemInfo();
            DefaultInfo();
        }
    }
}
