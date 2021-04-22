using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab_13
{
   public static class SVMLog
    {
        private static string path = @"C:\Users\User\Desktop\ООТП\test\SVMlogfile.txt";
        public static StreamWriter file = new StreamWriter(path);
        public static string GetPath
        {
            get => path;
        }

        public static string SetPath
        {
            set => path = value;
        }

        public static StreamWriter OpenFile() => file;
        public static void CloseFile()
        {
            if (file != null)
                file.Close();
        }

        public static void ADSWrite()
        {
            int num = 0;
            StreamReader file = new StreamReader(@"C:\Users\User\Desktop\ООТП\test\SVMlogfile.txt");
            for (int i = 0; i < 100; i++)
            {
                if (Equals(file.ReadLine(), "@"))
                {
                    num++;
                }
            }
            for (int i = 1; i < 100; i++)
            {
                if (file.ReadLine() != null)
                    if (file.ReadLine().Contains("Path"))
                    {
                        while (!Equals(file.ReadLine(), "@"))
                        {
                            i--;
                        }
                        while (Equals(file.ReadLine(), "@"))
                        {
                            Console.WriteLine(file.ReadLine());
                            i++;
                        }

                    }
            }
            file.Close();
            Console.WriteLine();
            Console.WriteLine("Количество записей: " + num);
        }

        public static void ADSDeletePartOfFile(int line)
        {
            StreamReader file = new StreamReader(@"C:\Users\User\Desktop\ООТП\test\SVMlogfile.txt");
            StreamWriter tempfile = new StreamWriter(@"C:\Users\User\Desktop\ООТП\test\SVMlogfileTemp.txt");

            for (int i = 0; i < line; i++)
            {
                tempfile.WriteLine(file.ReadLine());
            }
            file.Close();
            tempfile.Close();
            File.Delete(@"C:\Users\User\Desktop\ООТП\test\SVMlogfile.txt");
            File.Move(@"C:\Users\User\Desktop\ООТП\test\SVMlogfileTemp.txt", @"C:\Users\User\Desktop\ООТП\test\SVMlogfile.txt");

            Console.WriteLine();
            Console.WriteLine($"ADSlogfile.txt частично очищен");
        }
    }
}
