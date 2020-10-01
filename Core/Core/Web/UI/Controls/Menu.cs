using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Collections;

namespace ePower.Core.Web.UI.Controls
{
	/// <summary>
	/// Menu control
	/// </summary>
	[DefaultProperty("Text"), ToolboxData("<{0}:Menu runat=server></{0}:Menu>")]
	public class Menu : System.Web.UI.WebControls.WebControl
	{
		private string text;

		[Bindable(true),
			Category("Appearance"),
			DefaultValue("")]
		public string Text
		{
			get
			{
				return text;
			}

			set
			{
				text = value;
			}
		}

		/// <summary> 
		/// Render this control to the output parameter specified.
		/// </summary>
		/// <param name="output"> The HTML writer to write out to </param>
		protected override void Render(HtmlTextWriter output)
		{

		}

		// Recursive render method
		private void DisplayMenu(HtmlTextWriter output, ArrayList menuitems, int depth)
		{

		}

		// Stores information about a single menuitem with optional children
		// Composite design pattern
		internal class MenuItem
		{
		}
	}
}
