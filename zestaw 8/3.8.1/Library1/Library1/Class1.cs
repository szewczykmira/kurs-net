using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library1
{
    public class Class1
    {
        public static int potega(int pod, int wyk)
        {
            int n = 1;
            while (wyk-- > 0) n *= pod;
            return n;
        }
    }
}
