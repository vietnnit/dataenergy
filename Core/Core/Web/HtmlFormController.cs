using System;
using System.Web;
using System.Web.UI;


namespace ePower.Core.Web
{
	/// <summary>
	/// Rewrite html form to set actual action url
	/// </summary>
	public class HtmlFormController : System.Web.UI.HtmlControls.HtmlForm
	{
		private string action = null;
		private bool removeAction = false;
		public HtmlFormController()
            : base()
        {
        }
		public string Action
		{
			get { return action; }
			set { action = value; }
		}
		public bool RemoveAction
		{
			get { return removeAction; }
			set { removeAction = value; }
		}
		protected override void RenderAttributes(System.Web.UI.HtmlTextWriter writer)
		{

			SelectiveHtmlTextWriter customWriter = new SelectiveHtmlTextWriter(writer);
			customWriter.WritingAttribute +=
				new SubstituteValueEventHandler(customWriter_WritingAttribute);
			base.RenderAttributes(customWriter);
		}
		void customWriter_WritingAttribute(object sender, SubstituteValueEventArgs e)
		{
			if (e.Name == "action")
			{
				//use action attribute only if one is explicitly provided
				if (action != null)
					e.NewValue = action;
				else if (removeAction == true)
					e.Cancel = true;
				else
				{
					e.NewValue = Context.Request.RawUrl;
				}
			}
		}
	}
}
