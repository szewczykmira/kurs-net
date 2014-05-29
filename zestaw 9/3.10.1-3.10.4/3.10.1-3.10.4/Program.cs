using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Xml.Serialization;


//http://msdn.microsoft.com/en-us/library/x6c1kb0s(v=vs.71).aspx
//http://www.liquid-technologies.com/Tutorials/XmlSchemas/XsdTutorial_04.aspx

namespace _3._10._1_3._10._4
{
    [Serializable, XmlRoot("Studenci")]
    public class Studenci
    {        
        [XmlElement("Student")]
        public Student[] Student { get; set; }
    }

    public class Student
    {

        public Student() { }
        [XmlAttribute("imie")]
        public string Imie { get; set; }

        [XmlAttribute("nazwisko")]
        public string Nazwisko { get; set; }

        [XmlAttribute("data_ur")]
        public string Data_Ur { get; set; }

        [XmlAttribute("rok")]
        public string Rok { get; set; }

        [XmlElement("Adres_Tymczasowy")]
        public Adres Adres_tm { get; set; }

        [XmlElement("Adres_Staly")]
        public Adres Adres_st { get; set; }

        [XmlElement("Przedmiot")]
        public Przedmiot[] Przedmiot { get; set; }

    }

    public class Adres
    {

        public Adres() { }

        [XmlAttribute("miejscowosc")]
        public string Miejscowosc { get; set; }

        [XmlAttribute("ulica")]
        public string Ulica { get; set; }

        [XmlAttribute("kod")]
        public string Kod { get; set; }
    }

    public class Przedmiot
    {

        public Przedmiot() { }

        [XmlAttribute("nazwa")]
        public string Nazwa { get; set; }

        [XmlAttribute("prowadzacy")]
        public string Prowadzacy { get; set; }

        [XmlElement("Ocena")]
        public int Ocena { get; set; }
    }

    class Program
    {        
        static void Main(string[] args)
        {
            bool valid = true;

            try 
            {                                
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add(null,"studenci.xsd");						
				
                settings.ValidationType = ValidationType.Schema;
				
                XmlReader reader = XmlReader.Create ("studenci.xml",settings);
                XmlDocument document = new XmlDocument();
                document.Load (reader);
				
                ValidationEventHandler eventHandler = new ValidationEventHandler(
                    ValidationEventHandler);
				
                // Symulacja błędu walidacji
                XPathNavigator navigator = document.CreateNavigator();
                navigator.MoveToFollowing("price", "cos");
                XmlWriter writer = navigator.InsertAfter ();
                writer.WriteStartElement("anotherNode", "cos");
				
                writer.WriteEndElement();
                writer.Close();
				
				reader.Close ();
														
			}
			catch (Exception ex) 
			{ 
				valid = false;
				Console.WriteLine ("1. Plik nie przeszedł walidacji:\n"); 				
				Console.WriteLine ("\t" + ex.Message); 				
			}
			
			if (valid)
			{
				Console.WriteLine ("1. Plik popranie przeszedł walidacje!");
												
				try 
				{							
											
	                // Deserializacja - zapis do pliku				
					XmlSerializer xS = new XmlSerializer(typeof(Studenci));
					FileStream fs = new FileStream("studenci.xml", FileMode.Open);														
					Studenci st = (Studenci)xS.Deserialize (fs);
					
					fs.Close ();

                    Console.WriteLine("\n2. Deserializacja z pliku wykonana pomyślnie!\n");
					
					
				}
				catch (Exception ex) { Console.WriteLine (ex.InnerException.Message); }
								
			}
            Console.ReadLine();
		}	
		
		static void ValidationEventHandler(object sender, ValidationEventArgs e) 
		{
			switch (e.Severity) 
			{
			case XmlSeverityType.Error:
				Console.WriteLine ("Błąd: {0}", e.Message);
				break;
			case XmlSeverityType.Warning:
				Console.WriteLine ("Otrzeżenie: {0}", e.Message);
				break;
			}
		}   
        
    }
}
