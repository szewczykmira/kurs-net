using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _3._3._4
{
    class Program
    {
        static void Main(string[] args)
        {            
            var anagrams = (from slowo in File.ReadAllLines("dane.txt")
                           group slowo by
                            // kryterium grupowania - norma anagramu
                           new string(
                               // dzielimy slowa na litery
                               (from letter in slowo.ToLower().ToCharArray()
                                // sortujemy litery
                                orderby letter
                                select letter).ToArray())
                                // anagramy to grupy indeksowane przez normę anagramu
                            into anagramy
                            // porzadkujemy te grupe, wiec najwieksza grupa jest pierwsza
                        orderby anagramy.Count() descending
                        select anagramy.ToArray()).First();

            Console.WriteLine("Najwieksza grupa anagramów:\n");
            foreach (var a in anagrams) 
                Console.WriteLine("- " + a);

            Console.WriteLine();

        }

        
    }
}
