using System;
using System.Web;
using System.Web.UI;

namespace ePower.Core.Web
{
	public class FrontController : IHttpModule
	{

		public void Dispose()
		{
			// no clean-up required
		}

		public void Init(HttpApplication context)
		{
			// register a handler for the event you want to handle
			context.PreRequestHandlerExecute += MyPreRequestHandler;
		}

		/// <summary>
		/// use features of the request (user, browser, IP address, etc.)
		/// to decide how to handle the request, and which page to show
		/// this example looks for specific items in the query string
		/// that indicate the required target (such as "CustomerList")
		/// using a dictionary of values loaded from an XML disk file
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MyPreRequestHandler(Object sender, EventArgs e)
		{
			// get Singleton list of transfer URLs 
			TransferUrlList urlList = TransferUrlList.GetInstance();
			// get the current request query string
			String reqTarget = HttpContext.Current.Request.QueryString["target"];
			if (reqTarget != null && reqTarget != String.Empty)
			{
				// see if target value matches a transfer URL
				// by querying the list of transfer URLs
				// method returns the original value if no match 
				String transferTo = urlList.GetTransferUrl(reqTarget);
				try
				{
					// transfer to the specified URL
					HttpContext.Current.Server.Transfer(transferTo, true);
				}
				catch { }
			}
		}
	}
}
