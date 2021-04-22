using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4
{
    class Program
    {
        static void Main(string[] args)
        {
            String str1 = new String(4);
            String str2 = new String(5);
            str1.setString();
            str2.setString();
            str1.STR = str1 + 25;
            Console.WriteLine(str1.STR);
            str1.STR = -str1;
            Console.WriteLine(str1.STR);
            str1.STR = str1 * 'v';
            Console.WriteLine(str1.STR);
            String.Owner owner = new String.Owner();

            Console.WriteLine("Сумма длин: "+StatisticOperation.Sum(str1, str2));
            Console.WriteLine("Разница длин: " + StatisticOperation.Res(str1, str2));
            Console.WriteLine("Длина строки: " + StatisticOperation.Len(str1));

            string test = "Woooow&";
            Console.WriteLine("Сожержит ли строка служебные символы? " + test.isContain(4));
            String str3 = str2.removeDot();
            Console.WriteLine("Строка без знаков препинания: ");
            str3.show();
            Console.ReadLine();
        }
    }

    

    static class StatisticOperation
    {
        static public int Sum(String str1, String str2)
        {
            return str1.STR.Length + str2.STR.Length;
        }

        static public int Res(String str1, String str2)
        {
            return Math.Abs(str1.STR.Length - str2.STR.Length);
        }

        static public int Len(String str)
        {
            return str.STR.Length;
        }

        public static bool isContain(this string str, int A)
         {
             string symbols = "+!^&";
             bool isContain = false;
             for(int i = 0; i < str.Length; i++)
             {
                 for(int j = 0; j < symbols.Length; j++)
                 {
                     if (str[i] == symbols[j])
                     {
                         isContain = true;
                     }
                 }
             }
             return isContain;
         }

        public static String removeDot(this String str)
         {
             char[] symbols = { '!', ',', '.', '?' };
             int len = str.Len;
             for (int i = 0; i < str.STR.Length; i++)
             {
                 for (int j = 0; j < symbols.Length; j++)
                 {
                     if (str[i] == symbols[j])
                     {
                         len--;
                     }
                 }
             }
             String str2 = new String(len);
             str2.Len = len;
             bool isContain = true;
             for (int i = 0,k=0; i < str.STR.Length; i++)
             {
                isContain = true;
                 for (int j = 0; j < symbols.Length; j++)
                 {
                     if (str[i] == symbols[j])
                     {
                         isContain = false;
                     }
                 }
                 if (isContain)
                 {
                     str2.STR[k] = str.STR[i];
                     k++;
                 }
             }

             return str2;
         }
    }
}
