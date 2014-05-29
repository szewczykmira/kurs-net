using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Zad362
{
    class Kodowanie
    {
        static void Main(string[] args)
        {
            string naszPlik = File.ReadAllLines("dane1.txt");

            Encoding ascii = Encoding.ASCII;
            Encoding utf8 = Encoding.UTF8;
            Encding utf7 = Encoding.UTF7;

        }
    }
}
