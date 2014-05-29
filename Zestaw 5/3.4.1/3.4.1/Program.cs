using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3._4._1
{
    class Program
    {
        static int Foo(int x, int y)
        {
            int suma = 0;
            for (int i = x; i < y; i++)
                suma += i;
            return suma;
        }

        dynamic Foo(dynamic x, dynamic y)
        {
            dynamic suma = 0;
            for (dynamic i = x; i < y; i++)
                suma += i;
            return suma;
        }

        static void Main(string[] args)
        {
            int x = 10, y = 10000;
            int LiczbaProb = 100000;
            DateTime start, end;
            int wynikStatic;

            start = DateTime.Now;
            for (int proba = 0; proba < LiczbaProb; proba++) 
                wynikStatic = Foo(x,y);
            end = DateTime.Now;
            Console.WriteLine("Czas statycznego wywolania: " + (end.Subtract(start)).Milliseconds);

            dynamic wynikDynamic;
            start = DateTime.Now;            
            for (int proba = 0; proba < LiczbaProb; proba++) 
                wynikDynamic = Foo(x, y);
            end = DateTime.Now;
            Console.WriteLine("Czas dynamicznego wywolania: " + (end.Subtract(start)).Milliseconds);

            Console.WriteLine();

        }
    }
}
