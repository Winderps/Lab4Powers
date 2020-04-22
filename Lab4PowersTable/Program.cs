using System;
using System.ComponentModel.Design;
using System.Net.NetworkInformation;

namespace Lab4PowersTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Learn your squares and cubes!");
            Console.WriteLine(RepeatCharacter('=', Console.WindowWidth / 2));

            bool cont = true;
            while(cont)
            {
                double input = GetUserDouble("Please enter a number: ");
                Console.WriteLine(Prettify("Number", "Squared", "Cubed"));
                Console.WriteLine(Prettify("======", "=======", "====="));

                for (double i = 1; i <= input; i++)
                {
                    Console.WriteLine(Prettify(i.ToString(), PowerOf(i, 2).ToString(), PowerOf(i, 3).ToString()));
                }

                Console.Write("Enter y(es) to continue or anything else to exit: ");
                cont = Console.ReadLine().ToLower().StartsWith('y');
            }
        }

        static double GetUserDouble(string prompt)
        {
            double? ret = null;

            while (!ret.HasValue)
            {
                Console.Write(prompt);
                try
                {
                    ret = double.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Input was not valid, try again");
                }
            }

            return ret.Value;
        }

        static double PowerOf(double orig, double power)
        {
            double ret = 1;

            if (power == 0)
                return ret;

            for (double i = 0; i < power; i++)
                ret *= orig;

            return ret;
        }

        static string Prettify(params string [] contents)
        {
            string ret = "";

            int width = Console.WindowWidth / 2;
            int tabWidth = width / contents.Length;

            for (int i = 0; i < contents.Length; i++)
            {
                ret += contents[i] + RepeatCharacter(' ', tabWidth - contents[i].Length);
            }

            return ret;
        }

        static string RepeatCharacter(char c, int times)
        {
            string ret = "";

            for (int i = 0; i < times; i++)
                ret += c;

            return ret;
        }
    }
}
