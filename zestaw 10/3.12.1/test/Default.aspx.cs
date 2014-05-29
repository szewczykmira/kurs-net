using System;
using System.Web;
using System.Web.UI;

namespace test
{
	public partial class Default : System.Web.UI.Page
	{
		
		public virtual void button1Clicked (object sender, EventArgs args)
		{
			button1.Text = "You clicked me";
		}	
		
		
		protected void Application_BeginRequest(object sender, EventArgs args)
		{
			HttpRequest request = base.Request;
			
			string address = request.UserHostAddress;
			
			base.Response.Write (address);
						
		}
	}
}

