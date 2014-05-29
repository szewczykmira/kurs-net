using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _3._3._7
{
    class Program
    {
        static void Main(string[] args)
        {            

            var query = File.ReadAllLines("dane.txt")
                            .GroupBy(x => x.Split(' ')[1])
                                .OrderByDescending(x => x.Count())
                                    .Select(z => new {IP = z.Key, ILE = z.Count()})
                                        .Take(3);                                  
                     

            foreach (var i in query) Console.WriteLine(i.IP + " " + i.ILE);
            Console.ReadLine();
        }
    }
}
