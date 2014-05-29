using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3._13._1
{    
    class Program
    {
        private static class Osoba
        {            
            public static string imie;
            public static string nazwisko;            
        }

        public static void SetMethodFields()
        {
            Osoba.imie = "maruisz";
            Osoba.nazwisko = "ktos";
        }
        
        static void Main(string[] args)
        {
            SetMethodFields();
            Console.WriteLine(Osoba.imie);

        }
    }
}
