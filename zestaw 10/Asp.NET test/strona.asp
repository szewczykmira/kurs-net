<%@ Page Language="C#" %>
<%@ import Namespace="NExample" %>
<HTML>
<HEAD><TITLE>Witam w ASP.NET</TITLE></HEAD>
<BODY>

<%
COsoba osoba = new COsoba("Jan","Kowalski");
int i ;
string s = string.Empty;

for (i = 1; i <= 5; i++)
{
	s = s+String.Format(
		"<FONT size={0}>{1}</FONT><br>", i, osoba);
}

Message.InnerHtml = s;
%>

<SPAN id="Message" runat=server/>
</BODY>
</HTML>