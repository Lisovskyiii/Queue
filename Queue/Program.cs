using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace _5_лаба_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = Convert.ToDouble(Console.ReadLine());
            double b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Первой задание:");
            Zadanie_1(a, b);
            Console.WriteLine("\nВторой заданиие:");
            Regex vowels = new Regex(@"^[кнгшщзхфвпрлдчсмтжб]", RegexOptions.IgnoreCase);
            Regex consonants = new Regex(@"^[уеыаоэяиюё]", RegexOptions.IgnoreCase);
            string file_2 = "text_2.txt";
            Zadanie_2(consonants,vowels, file_2);
            Console.WriteLine("\nТретье заданиие:");
            string file_3 = "text_3.txt";
            Regex upper = new Regex(@"^[A-ZА-Я]");
            Regex lower = new Regex(@"^[a-zа-я]");
            Zadanie_2(upper, lower, file_3);
            Regex young = new Regex(@"^[1][8-9]$|^[2][0-9]$");
            Regex old = new Regex(@"^[3-7][0-9]$");
            Console.WriteLine("\nЧетвёртое задание:");
            Zadanie_4(young,old);
        }
        public static void Zadanie_1(double a, double b)
        {
            StreamReader reader = new StreamReader("text_1.txt");
            string[] mas = reader.ReadToEnd().Split(' ', ',');
            Queue<double> numbers = new Queue<double>();
            for (int i = 0; i < mas.Length; i++)
            {
                if (a <= Convert.ToDouble(mas[i]) & Convert.ToDouble(mas[i]) <= b)
                {
                    numbers.Enqueue(Convert.ToDouble(mas[i]));
                }
            }
            for (int i = 0; i < mas.Length; i++)
            {
                if (a > Convert.ToDouble(mas[i]))
                {
                    numbers.Enqueue(Convert.ToDouble(mas[i]));
                }
            }
            for (int i = 0; i < mas.Length; i++)
            {
                if (Convert.ToDouble(mas[i]) > b)
                {
                    numbers.Enqueue(Convert.ToDouble(mas[i]));
                }
            }
          
           
            foreach (var i in numbers)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            reader.Close();
        }
        public static void Zadanie_2(Regex regex1, Regex regex2, string file )
        {
            StreamReader reader = new StreamReader(file);
            string[] mas = reader.ReadToEnd().Split(' ', ',');
            Queue<string> words = new Queue<string>();
            for (int i = 0; i < mas.Length; i++)
            {
                if (regex1.IsMatch(mas[i]))
                {
                    words.Enqueue(mas[i]);
                }

            }
            for (int i = 0; i < mas.Length; i++)
            {
                if (regex2.IsMatch(mas[i]))
                {
                    words.Enqueue(mas[i]);
                }

            }
            foreach (var i in words)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            reader.Close();
        }
        public static void Zadanie_4(Regex young, Regex old)
        {
            StreamReader reader = new StreamReader("text_4.txt");
            string[] people = reader.ReadToEnd().Split("\n");
            Queue<string> queue = new Queue<string>();
            for(int i=0; i < people.Length; i++)
            {
                string[] info = people[i].Split(',');
                for (int k = 0; k < info.Length; k++)
                {
                    if (young.IsMatch(info[k].Trim()))
                    {
                        queue.Enqueue(people[i]);
                    }
                }
            }
            for (int i = 0; i < people.Length; i++)
            {
                string[] info = people[i].Split(',');
                for (int k = 0; k < info.Length; k++)
                {
                    if (old.IsMatch(info[k].Trim()))
                    {
                        queue.Enqueue(people[i]);
                    }
                }
            }
            foreach (string i in queue)
            {
                Console.WriteLine(i);
            }
            reader.Close();
        }
    }
}
