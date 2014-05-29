using System;
using System.IO;
using System.Xml;

namespace _3._10._5
{
    class Program
    {
        static void odstep(int ile)
        {
            for (int i = 0; i < ile; i++)   Console.Write(" ");
        }        

        static void Main(string[] args)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load("studenci.xml");
            
            XmlNodeList nodelist = xml.DocumentElement.ChildNodes;
            Console.WriteLine("<" + xml.DocumentElement.Name + ">");            
            foreach (XmlNode zewNode in nodelist)
            {
                odstep(2);
                Console.Write("<" + zewNode.Name);
                foreach (XmlAttribute nodeAttr in zewNode.Attributes)
                {
                    Console.Write(" {0}=\"{1}\"", nodeAttr.Name, nodeAttr.Value);
                }
                Console.WriteLine(">");

                foreach (XmlNode wewNode in zewNode.ChildNodes)
                {                    
                    odstep(4); 
                    Console.Write("<" + wewNode.Name);
                    foreach (XmlAttribute nodeAttr in wewNode.Attributes)
                    {
                        Console.Write(" {0}=\"{1}\"",nodeAttr.Name, nodeAttr.Value);
                    }
                    Console.WriteLine(">");

                    foreach (XmlNode wew2Node in wewNode.ChildNodes)
                    {
                        odstep(7); 
                        Console.WriteLine("<{0}>{1}</{2}>", wew2Node.Name, wew2Node.InnerText, wew2Node.Name);                        
                    }
                }
            }

            Console.WriteLine("</" + xml.DocumentElement.Name + ">");            
    
        }
    }
}
