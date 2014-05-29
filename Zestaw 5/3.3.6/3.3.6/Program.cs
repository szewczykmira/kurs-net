using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _3._3._6
{
    class Program
    {
        static void Main(string[] args)
        {   
            var values = from dane1 in File.ReadAllLines("dane1.txt")
                         join c in File.ReadAllLines("dane2.txt") on
                            dane1.Split(' ')[2] equals c.Split(' ')[0]
                         select new
                         {
                             Imie = dane1.Split(' ')[0],
                             Nazwisko = dane1.Split(' ')[1],
                             Pesel = dane1.Split(' ')[2],
                             Nr_konta = c.Split(' ')[1]

                         };                     

            foreach (var i in values) 
                Console.WriteLine(i.Imie + " " + i.Nazwisko + " " + i.Pesel + " " + i.Nr_konta);
            Console.ReadLine();
        }
    }
}
