using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3._11._4
{
    class Account
    {
        private int accId;
        private string imię;
        private string nazwisko;
        private DateTime data;
        private Int64 pesel;

        public virtual int AccId
        {
            get { return accId; }
            set { accId = value; }
        }

        public virtual string Imię
        {
            get { return imię; }
            set { imię = value; }
        }

        public virtual string Nazwisko
        {
            get { return nazwisko; }
            set { nazwisko = value; }
        }

        public virtual DateTime DataUrodzenia
        {
            get { return data; }
            set { data = value; }
        }

        public virtual Int64 Pesel
        {
            get { return pesel; }
            set { pesel = value; }
        }
    }
}
