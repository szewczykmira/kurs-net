<%@ Page Language="C#" Inherits="test.Default" %>
<%@ import Namespace="System.IO" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">

<html>
    <script language="C#" runat=server>
 
        void Page_Load(Object Src, EventArgs E) 
		{
			
			HttpRequest request = base.Request;			
			
			string address = request.UserHostAddress;
		
          	Message.InnerHtml = "IP: " + address + ", Czas: " + DateTime.Now;
		
			// odwiedziny zapisuje do pliku
			string FilePath = Server.MapPath("/") + "plik.txt";
			FileStream fs = new FileStream(FilePath, FileMode.Append, FileAccess.Write);
			StreamWriter sw = new StreamWriter(fs);
			sw.WriteLine("Data: " + DateTime.Now + ", IP: " + address);
			sw.Close();
			fs.Close();
        }
 
    </script>
 
    <body>

          <span id="Message" runat=server></span>
       
    </body>
 </html>