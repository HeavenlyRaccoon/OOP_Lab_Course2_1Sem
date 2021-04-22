using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_11
{
    class Time
    {
        int hours, minutes, seconds;
        string type;
        public int week = 1;
        static float error;
        static int countObj = 0;
        readonly int ID;
        const int year = 2020;
        private Time(int resultr) { } //закрытый конструктор

        static Time()
        {
            error = 0.001f;
        }

        public Time()
        {
            Hours = 23;
            Minutes = 33;
            Seconds = 4;
            ID = hours * minutes - seconds + seconds * seconds;
            countObj++;
        }

        public Time(int h, int m, int s)
        {
            Hours = h;
            Minutes = m;
            Seconds = s;
            ID = hours * minutes - seconds + seconds * seconds;
            if (h > 3 && h <= 11) type = "Утро";
            else if (h > 11 && h <= 16) type = "День";
            else if (h > 16 && h <= 23) type = "Вечер";
            else type = "Ночь";
            countObj++;
        }

        public Time(int h = 3, int m = 23)
        {
            Hours = h;
            Minutes = m;
            Seconds = 45;
            ID = hours * minutes - seconds + seconds * seconds;
            countObj++;
        }   

        public string Type { get { return type; } }

        public int Hours
        {
            get
            {
                return hours;
            }
            set
            {
                if (value >= 0 && value < 24)
                {
                    hours = value;
                }
                else
                {
                    throw new System.ArgumentException("Invalid input");
                }

            }
        }

        public int Minutes
        {
            get
            {
                return minutes;
            }
            set
            {
                if (value >= 0 && value < 60)
                {
                    minutes = value;
                }
                else
                {
                    throw new System.ArgumentException("Invalid input");
                }
            }
        }

        public int Seconds
        {
            get
            {
                return seconds;
            }
            set
            {
                if (value >= 0 && value < 60)
                {
                    seconds = value;
                }
                else
                {
                    throw new System.ArgumentException("Invalid input");
                }
            }
        }

        public void ShowTime()
        {
            Console.WriteLine("Часы: " + hours + " \tМинуты: " + minutes + " \tСекунды:  " + seconds + " \tID: " + ID);
        }

        public void ChangeHour(ref int week, int newWeek)
        {
            week = newWeek;
        }

        public static void ShowInfo()
        {
            Console.WriteLine("Создано объектов: " + Time.countObj);
        }

        public bool CompareHour(int compareHour)
        {
            if (compareHour == Hours)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(object obj)
        {
            Time time = (Time)obj;
            return (this.Hours == time.Hours && this.Minutes == time.Minutes && this.Seconds == time.Seconds);
        }

        public override int GetHashCode()
        {
            return this.ID;
        }
    }
}
