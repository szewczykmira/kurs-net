using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

/* Dla zadanego pliku zwraca sume dlugosci plików w nich zawartych */
namespace _3._3._5
{
    class Program
    {
        static void Main(string[] args)
        {
            
            DirectoryInfo di = new DirectoryInfo("c:/Python33");

            var sum = di.GetFiles().Aggregate(
                (long)0,
                (acc, i) => acc + i.Length
                );
                    
            Console.WriteLine(sum);
            Console.ReadLine();         
        }
    }
}
