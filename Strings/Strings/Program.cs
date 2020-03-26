using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace norm
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
           // {
                Console.WriteLine("Для ввода данных из файла введите 1, а для ввода из консоли, введите 2");
                int ch = Convert.ToInt32(Console.ReadLine());
                if (ch == 1)
                {
                    fromFile();
                }
                else if (ch == 2)
                {
                    fromConsole();
                }
                else
                {
                    Console.WriteLine("Возможно вы ввели неверное значение1");
                    Main(args);
                }
            //}
            //catch
            //{
            //    Console.WriteLine("Возможно вы ввели неверное значение2");
            //    Main(args);
            //}
                
            Console.ReadLine();
        }

        static void fromFile()
        {
            
            string [] lines = File.ReadAllLines("Inlet.in");
            int k;
            k = Convert.ToInt32(lines[lines.Length - 2]);
            char sym = lines[lines.Length - 1][0];
            int sum = 0;
            for (int i = 0; i < lines.Length - 2; i++)
            {
                string[] strs = lines[i].Split(' ');
                foreach (string str in strs)
                {
                    int num = 0;
                    foreach (char a in str)
                    {
                        if (a == sym)
                            num++;
                    }
                    double res = Convert.ToDouble(num) / Convert.ToDouble(str.Length);
                    if (res * 100.0 >= Convert.ToDouble(k))
                        sum++;
                }
            }
            File.WriteAllText("Outlet.out", sum == 0 ? "-1" : sum.ToString());
            Console.WriteLine("Число слов подходящих по условию: " + (sum == 0 ? "-1" : sum.ToString()));

            foreach (string e in lines)
            {
                Console.WriteLine(e);
            }
        }

        static void fromConsole()
        {
            Console.WriteLine("Введите символ");
            char sym = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Введите процент");
            int k = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите в консоль данные в порядке: Текстовая строка процент символ");
            string args = Console.ReadLine();
            while (args.Contains("  "))
            {
                args = args.Replace("  ", " ");
                
            }
            string[] lines = args.Split(' ');

            int sum = 0;
            for (int i = 0; i < lines.Length - 2; i++)
            {
                string[] strs = lines[i].Split(' ');
                foreach (string str in strs)
                {
                    int num = 0;
                    foreach (char a in str)
                    {
                        if (a == sym)
                            num++;
                    }
                    double res = Convert.ToDouble(num) / Convert.ToDouble(str.Length);
                    if (res * 100.0 >= Convert.ToDouble(k))
                        sum++;
                }
            }
            File.WriteAllText("Outlet.out", sum == 0 ? "-1" : sum.ToString());
            Console.WriteLine("Число слов подходящих по условию: " + (sum == 0 ? "-1" : sum.ToString()));

        }
      
    }
}
