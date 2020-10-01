using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace ePower.Core.Web
{
	public class UserControlBase : System.Web.UI.UserControl
	{
		public new PageControllerBase Page
		{
			get { return (PageControllerBase) base.Page; }
		}

		public virtual CultureInfo UserCulture
		{
			get { return Page.UserCulture; }
		}
	}
}
