using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;
using System.IO;
//korzysta z algorytmu standardowego dla bezstratnej kompresji i dekompresji
namespace Zad364
{
    class Program
    {
        public static void Kompresuj(string fileName, string value)
        {
            //wrzuca stringa do tymczasowego pliku
            string temp = Path.GetTempFileName();
            File.WriteAllText(temp, value);

            byte[] b;
            using (FileStream f = new FileStream(temp, FileMode.Open))
            {
                b = new byte[f.Length];
                f.Read(b, 0, (int)f.Length);
            }

            // Use GZipStream to write compressed bytes to target file.
            using (FileStream f2 = new FileStream(fileName, FileMode.Create))
            using (GZipStream gz = new GZipStream(f2, CompressionMode.Compress, false))
            {
                gz.Write(b, 0, b.Length);
            }
        }

            
        static void Main(string[] args)
        {
            string cos = File.ReadAllText("plik.txt");
            Kompresuj("plik.gz", cos);
        }
    }
}
