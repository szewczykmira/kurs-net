using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _3._3._3
{
    class Program
    {
        static void Main(string[] args)
        {
            var query =
                    from wiersz in File.ReadAllLines("data.txt")
                    group wiersz by wiersz[0] into g    // grupuje wczytane elementy za pomoca pierwszego znaku
                    let znakPoczatkowy = g.Key                                          // uzyskuje pierwszy znak wiersza
                    orderby znakPoczatkowy                                              // sortuje rosnaco
                    select new
                    {
                        Znak = g.Key,                                                   // za pomoca klucza (pierwszy znak imienia) tworze pole Znak w obiekcie query
                    };
                    

            foreach (var grp in query)
            {
                Console.Write(grp.Znak + " ");
            }
            
            Console.WriteLine("\n");
            Console.ReadLine();
        }
    }
}
