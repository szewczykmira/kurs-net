using System;
using System.Xml;
using System.Linq;
using System.Xml.Linq;

//http://msdn.microsoft.com/en-us/library/system.xml.linq.xdocument.aspx
//http://www.hookedonlinq.com/LINQtoXML5MinuteOverview.ashx
//http://msdn.microsoft.com/en-us/library/system.xml.linq.xdocument.aspx
//http://msdn.microsoft.com/en-us/library/bb397927.aspx


namespace _3._10._7
{
    class Program
    {
        static void Main(string[] args)
        {

            XDocument doc = XDocument.Load("studenci.xml");

            string poczatekNazwiska = "P";
            
            while (true)
            {
                poczatekNazwiska = Console.ReadLine();
                if (poczatekNazwiska.Length == 0) break;

                var q = from c in doc.Descendants("Student")
                        where ((string)c.Attribute("nazwisko")).StartsWith(poczatekNazwiska)
                        select (string)c.Attribute("imie") + " " +
                                (string)c.Attribute("nazwisko") + " " +
                                (string)c.Attribute("data_ur") + " " +
                                (string)c.Attribute("rok");
                
                Console.WriteLine("Dopasowanie:");                
                foreach (string name in q)
                    Console.WriteLine("\t{0}", name);
                

            }            
        }
    }
}
