using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Library1;
using Library2;

namespace _3._5._2
{
    class Program
    {        
        [DllImport("3.5.dll")]
        public static extern int iloczyn(int a, int b);

        static void Main(string[] args)
        {
            int a, b;

            Console.Write("Wpisz a: ");
            if (!Int32.TryParse(Console.ReadLine(), out a)) return;

            Console.Write("Wpisz b: ");
            if (!Int32.TryParse(Console.ReadLine(), out b)) return;

            //Console.WriteLine(iloczyn(a, b));                        
        }
    }
}
