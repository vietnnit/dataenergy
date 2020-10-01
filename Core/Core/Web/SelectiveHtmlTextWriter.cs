using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;


namespace ePower.Core.Web
{
	public class SelectiveHtmlTextWriter : HtmlTextWriter
	{
		public SelectiveHtmlTextWriter(HtmlTextWriter writer)
			: base(writer.InnerWriter)
		{
		}

		public event SubstituteValueEventHandler WritingAttribute;

		public override void WriteAttribute(string name, string value, bool fEncode)
		{
			string valToWrite = value;
			SubstituteValueEventArgs args = new SubstituteValueEventArgs(name, value);
			if (WritingAttribute != null)
			{
				WritingAttribute(this, args);

				if (args.Cancel == false)
					valToWrite = args.NewValue;
			}

			if (args.Cancel == false)
				base.WriteAttribute(name, valToWrite, fEncode);
		}
	}
}
