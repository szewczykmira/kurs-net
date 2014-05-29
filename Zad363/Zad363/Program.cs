using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Zad363
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList set = new ArrayList();
            Console.WriteLine("Jaką liczbę chcesz wrzucić do zbioru?\n");
            Console.WriteLine("Wpisz ja a nastepnie wcisnij enter. Aby zakonczyc podawanie liczb wpisz 0\n");
            int intTemp;
            do
            {
                intTemp = Convert.ToInt32(Console.ReadLine());
                if (set.Contains(intTemp) == false)
                {
                    set.Add(intTemp);
                }
            } while (intTemp != 0);
        }
    }
}
