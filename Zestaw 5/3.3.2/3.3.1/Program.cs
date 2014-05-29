using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

/*
 * Różnica między parametrami operatorów where/orderby, a parametrami funkcji Where, OrderBy
 * jest taka, że te pierwsze to słowa kluczowe mające jakieś znaczenia, a te drugie to wyrażenia 
 * lambda (które zwracają enumeratory) 
 * - te pierwsze po kompilacji są konwertowane do wyrażen lambda (tych drugich funkcji).
 */

namespace _3._3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            var query1 =
                    from wiersz in File.ReadAllLines("data.txt")                    
                    let liczba = int.Parse(wiersz)
                    where liczba > 100
                    orderby liczba descending
                    select liczba;

            Console.WriteLine("Wyrażenie linq: ");
            foreach (var liczba in query1) Console.WriteLine(liczba);

            var query2 =
                File.ReadAllLines("data.txt")
                    .Where(row => int.Parse(row) > 100)
                        .OrderByDescending(a => a);

            Console.WriteLine("\nCiag wywołań Linq to objects: ");
            foreach (var liczba in query2) Console.WriteLine(liczba);

            Console.WriteLine("\n");
            Console.ReadLine();
        }
    }
}
