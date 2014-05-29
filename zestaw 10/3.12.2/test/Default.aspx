<%@ Page Language="C#" Inherits="test.Default" %>
<%@ import Namespace="System.IO" %>
<%@ import Namespace="System.Linq" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">

<!--http://stackoverflow.com/questions/5231845/c-sharp-linq-group-by-on-multiple-columns-->

<html>
    <script language="C#" runat=server>
 
        void Page_Load(Object Src, EventArgs E) 
		{
			
		    HttpRequest request = base.Request;			
			
			string address = request.UserHostAddress;
		
          	Message.InnerHtml = "Statystyka odwiedzin strony: \n";
		
			// odwiedziny zapisuje do pliku
			string FilePath = Server.MapPath("/") + "plik.txt";
			FileStream fs = new FileStream(FilePath, FileMode.Append, FileAccess.Write);
			StreamWriter sw = new StreamWriter(fs);
			
			DateTime time = DateTime.Now;
			string format = "yyyy-MM-dd hh:mm:ss";
			sw.WriteLine(time.ToString(format) + " " + address);
			sw.Close();
			fs.Close();
		
			 /**/
			
          
			var query = 						
					from wiersz in File.ReadAllLines("plik.txt")
					let w = wiersz.Split(' ')
					group w by new
					{					
						//IP = wiersz.Split(' ')[2],
						IP = w[2],
						DATA = w[0]
						//DATA = wiersz[1]
						//CZAS = wiersz.Split(' ')[2]
			
					} into g
					orderby g.Key descending
					select new { IP = g.Key.IP, DATA = g.Key.DATA, ILE = g.Count()};					
		
		
			foreach (var i in query)
				Message.InnerHtml = i.IP + " " + i.ILE + " " + i.DATA;				
					
        }
 
    </script>
 
    <body>

          <span id="Message" runat=server></span>
       
    </body>
 </html>