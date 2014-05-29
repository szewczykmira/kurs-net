using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NExample
{
    public class COsoba
    {
        public string Imie;
        public string Nazwisko;

        public COsoba(string Imie, string Nazwisko)
        {
            this.Imie = Imie;
            this.Nazwisko = Nazwisko;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", Nazwisko, Imie);
        }
    }
}
