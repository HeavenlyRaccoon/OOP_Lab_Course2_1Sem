using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4
{
    class String
    {
        char[] str;
        int strLength;

        public String(int length = 5)
        {
            str = new char[length];
            strLength = length;
        }

        public char this[int index]//индексатор
        {
            get { return str[index]; }
            set { str[index] = value; }
        }

        public char[] STR
        {
            get { return str; }
            set { str = value; }
        }

        public int Len
        {
            get { return strLength; }
            set { strLength = value; }
        }

        public void setString()
        {
            for (int i = 0; i < strLength; i++)
            {
                str[i] = (char)Console.Read();
            }
        }

        public void getString()
        {
            for (int i = 0; i < strLength; i++)
            {
                Console.Write(str[i]);
            }
        }
        public void show()
        {
            Console.Write(this.str);
        }
        public static bool operator >(String len1, String len2)
        {
            return len1.strLength > len2.strLength;
        }

        public static bool operator <(String len1, String len2)
        {
            return len1.strLength < len2.strLength;
        }

        public static char[] operator +(String str, int number)
        {
            int len = str.strLength;
            int timeNumber = number;
            do
            {
                len++;
                timeNumber = timeNumber / 10;
            } while (timeNumber != 0);
            char[] newStr = new char[len];
            for (int i = 0; i < str.strLength; i++)
            {
                newStr[i] = str.str[i];
            }
            for (int i = str.strLength, numLen = len - str.strLength; i < len; i++, numLen--)
            {
                newStr[i] = (number / (int)(Math.Pow(10, numLen - 1))).ToString()[0];
                number = number % (int)(Math.Pow(10, numLen - 1));
            }
            str.strLength = len;
            return newStr;
        }

        public static char[] operator -(String str)
        {
            int len = str.strLength - 1;
            char[] newStr = new char[len];
            for (int i = 0; i < len; i++)
            {
                newStr[i] = str.str[i];
            }
            str.strLength = len;
            return newStr;
        }

        public static char[] operator *(String str, char symbol)
        {
            char[] newStr = new char[str.strLength];
            for (int i = 0; i < str.strLength; i++)
            {
                newStr[i] = symbol;
            }
            return newStr;
        }

        
        public class Owner
        {
            int Id;
            string Name;
            string NameCompany;

            public Owner(int id = 3376711, string name = "Vladimir", string nameCompany = "MTZ_Corparation")
            {
                Id = id;
                Name = name;
                NameCompany = nameCompany;

            }

            public int ID
            {
                get { return Id; }
                set { Id = value; }
            }

            public string NAME
            {
                get { return Name; }
                set { Name = value; }
            }

            public string NAMECOMPANY
            {
                get { return NameCompany; }
                set { NameCompany = value; }
            }
        }

        class Date
        {
            int year;
            int month;
            int day;

            public Date(int Year = 2020, int Month = 01, int Day = 23)
            {
                year = Year;
                month = Month;
                day = Day;
            }

            public Date()
            {
                year = DateTime.Now.Year;
                month = DateTime.Now.Month;
                day = DateTime.Now.Day;
            }

            public int YEAR
            {
                get { return year; }
            }

            public int MONTH
            {
                get { return month; }
            }

            public int DAY
            {
                get { return day; }
            }
        }
    }
}
