using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab_8
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] buffArray = new int[5] { 1, 2, 3, 4, 5 };
            Number<int> number = new Number<int>(buffArray.Length,buffArray );
            number.Show();
            number.Add(6);
            number.Show();
            number.Delete(3);
            number.Show();
            number.SaveData();
        }
    }

    interface IOperate<T>
    {
        void Add(T value);
        void Delete(T value);
        void Show();
    }

    class Number<T> : IOperate<T> where T : struct
    {
        T[] array;
        public int arraySize { get; set; }
        
        public Number(int size)
        {
            this.arraySize = size;
        }

        public Number(int size, T[] arr)
        {
            this.arraySize = size;
            array = new T[size];
            for(int i = 0; i < size; i++)
            {
                array[i] = arr[i];
            }
        }

        public T this [int index]
        {
            get { return array[index]; }
            set
            {
                array[index] = value;
            }
        }

        public void Add(T value)
        {
            T[] buff = new T[this.arraySize + 1];
            for (int i = 0; i < this.arraySize; i++)
            {
                buff[i] = array[i];
            }
            this.arraySize++;
            buff[this.arraySize - 1] = value;
            array = new T[this.arraySize];
            for (int i = 0; i < this.arraySize; i++)
            {
                array[i] = buff[i];
            }
        }

        public void Delete(T value)
        {
            List<T> buff = new List<T>();
            for(int i = 0; i < arraySize; i++)
            {
                if (!array[i].Equals(value))
                {
                    buff.Add(array[i]);
                }
            }
            arraySize--;
            array = buff.ToArray();
        }

        public void Show()
        {
            foreach(T i in array)
            {
                Console.Write(i.ToString() + " ");
            }
            Console.WriteLine();
        }

        //public override string ToString()
        //{
        //    return this.array.ToString();
        //}

        public void SaveData()
        {
            string path = @"..\save.txt";
            FileStream file = new FileStream(path, FileMode.OpenOrCreate);
            StreamWriter writer = new StreamWriter(file);

            for (int i = 0; i < arraySize; i++)
            {
                writer.Write(array[i].ToString() + " ");
            }

            Console.WriteLine("Save");

            //file.Close();
            writer.Close();
        }
    }
   

}
