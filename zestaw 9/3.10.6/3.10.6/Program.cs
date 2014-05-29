using System;
using System.Xml;

//http://www.c-sharpcorner.com/UploadFile/mahesh/ReadWriteXMLTutMellli2111282005041517AM/ReadWriteXMLTutMellli21.aspx


namespace _3._10._6
{
    class Program
    {
        static void odstep(int ile)
        {
            for (int i = 0; i < ile; ++i) Console.Write(" ");
        }

        static void Main(string[] args)
        {
            int iTab = 0;
            using (XmlTextReader reader = new XmlTextReader("studenci.xml"))
            {
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            odstep(iTab++);
                            Console.Write("<" + reader.Name);

                            while (reader.MoveToNextAttribute())
                                Console.Write(" {0}=\"{1}\"", reader.Name, reader.Value);
                            Console.WriteLine(">");
                            break;

                        case XmlNodeType.Text:
                            odstep(iTab);
                            Console.WriteLine("{0}", reader.Value);
                            break;

                        case XmlNodeType.EndElement:
                            odstep(--iTab);
                            Console.WriteLine("</{0}>", reader.Name);
                            break;
                    }
                }
            }
        }
    }
}
