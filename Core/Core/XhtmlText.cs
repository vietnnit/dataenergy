using System;
using System.IO;
using System.Xml;
using System.Web;
using System.Text;
using System.Collections.Generic;
using System.Globalization;

using log4net;

namespace ePower.Core
{
	/// <summary>
	/// Class to format and validate an XHTML valid snippet of text.
	/// </summary>
	public sealed class XhtmlText
	{
		private XmlDocument _xmlDoc;
		private static string[] VALID_TAGS;
		private static string[] INVALID_TAGS;
		//
		private static readonly ILog log = LogManager.GetLogger(typeof(XhtmlText));

		/// <summary>
		/// Initialize a new instance of XhtmlText class with load an XHTML snippet.
		/// </summary>
		public XhtmlText(string xhtml)
		{
			if (xhtml == null) throw new ArgumentNullException("xhtml");
			//
			StringBuilder sb = new StringBuilder(xhtml);
			// not append <div> tag if found !
			if (!xhtml.StartsWith("<div", StringComparison.InvariantCultureIgnoreCase)
				|| !xhtml.EndsWith("</div>", StringComparison.InvariantCultureIgnoreCase))
			{
				sb.Insert(0, "<div>").Append("</div>");
			}

			this._xmlDoc = new XmlDocument();
			this._xmlDoc.LoadXml(sb.ToString());
		}

		#region "public static methods"
		/// <summary>
		/// Convert a plain text to an XHTML valid text.
		/// </summary>
		public static string FromPlainText(string plainText, PlainTextMode mode)
		{
			if (plainText == null) throw new ArgumentNullException("plainText");
			//
			if (mode == PlainTextMode.CSSPlainText)
			{
				StringBuilder sb = new StringBuilder("<div class=\"plainText\">");
				sb.Append(HttpUtility.HtmlEncode(plainText)).Append("</div>");

				return sb.ToString();
			}
			else if (mode == PlainTextMode.XHtmlConversion)
			{
				return Formatter.HtmlToXhtml(plainText);
			}
			else throw new NotSupportedException("Plain text mode is not valid.");
		}
		#endregion

		#region "public methods"
		/// <summary>
		/// Check if the html is a valid text using the XML document validator.
		/// </summary>
		public bool IsValid(XHtmlMode mode)
		{
			try
			{
				this.CheckElements(this._xmlDoc, mode);
				return true;
			}
			catch (Exception ex) { log.Error("Exception occur:", ex); }
			return false;
		}

		private void CheckStrictValidation(XmlElement element)
		{
			if (VALID_TAGS == null)
			{
				VALID_TAGS = ("a,b,p,pre,img,i,br,sub,sup," +
					"cite,strong,dfn,em,kbd,blockquote,address," +
					"div,span," +
					"h1,h2,h3,h4,h5,h6," +
					"big,small," +
					"ul,li,ol," +
					"code,samp," +
					"table,td,tbody,tr,th,thead,tfoot,caption,colgroup," +
					"label,hr," +
					"map,area," +
					"form,input,button,fieldset,select,option,optgroup,legend,textarea," +
					"object,param," +
					"iframe").Split(',');
				Array.Sort(VALID_TAGS);
			}

			string tag = element.Name.ToLower(CultureInfo.InvariantCulture);
			int index = Array.BinarySearch(VALID_TAGS, tag);
			if (index < 0) throw new NotSupportedException("Tag '" + element.Name + "' is not valid.");
		}

		private void CheckBasicValidation(XmlElement element)
		{
			if (INVALID_TAGS == null)
			{
				INVALID_TAGS = "html,body,head,script".Split(',');
				Array.Sort(INVALID_TAGS);
			}

			string tag = element.Name.ToLower(CultureInfo.InvariantCulture);
			int index = Array.BinarySearch(INVALID_TAGS, tag);
			if (index >= 0) throw new NotSupportedException("Tag '" + element.Name + "' is invalid.");
		}

		private void CheckElements(XmlDocument doc, XHtmlMode mode)
		{
			if (mode == XHtmlMode.None) return;

			// select all the nodes
			XmlNodeList list = doc.SelectNodes("//*");
			foreach (XmlElement element in list)
			{
				if (mode == XHtmlMode.StrictValidation)
					this.CheckStrictValidation(element);
				else if (mode == XHtmlMode.BasicValidation)
					this.CheckBasicValidation(element);
				else
					throw new ArgumentException("XHtmlMode not supported", "mode");
			}
		}

		/// <summary>
		/// Search for a div element with the TOC id and insert inside this element the TOC content.
		/// Returns true if the TOC element is presend otherwise false.
		/// </summary>
		public bool InsertTOC(string TOC)
		{
			if (TOC == null) throw new ArgumentNullException("TOC");
			if (this._xmlDoc == null) return false;
			//
			XmlNode tocNode = this._xmlDoc.SelectSingleNode("//div[@id='TOC']");

			if (tocNode != null)
			{
				tocNode.InnerXml = TOC;
				return true;
			}
			else return false;
		}

		/// <summary>
		/// Delegate method used to replace the links.
		/// </summary>
		public delegate void ReplaceLinkHandler(string oldUrl, out string newUrl);

		/// <summary>
		/// Replace the links searching for any anchor (a) or image (img) element.
		/// The delegate (callback method) passed is used to generate the new link based on the previous value.
		/// </summary>
		public void ReplaceLinks(ReplaceLinkHandler replaceMethod)
		{
			if (this._xmlDoc == null) throw new ArgumentNullException("xmlDoc");
			if (replaceMethod == null) throw new ArgumentNullException("replaceMethod");
			//
			XmlNodeList anchors = this._xmlDoc.SelectNodes("//a");
			XmlNodeList images = this._xmlDoc.SelectNodes("//img");

			string href, newUrl;
			if (anchors != null)
			{
				foreach (XmlElement element in anchors)
				{
					href = element.GetAttribute("href");
					replaceMethod(href, out newUrl);
					element.SetAttribute("href", newUrl);
				}
			}

			if (images != null)
			{
				foreach (XmlElement element in images)
				{
					href = element.GetAttribute("src");
					replaceMethod(href, out newUrl);
					element.SetAttribute("src", newUrl);
				}
			}
		}

		/// <summary>
		/// Delegate method used to replace the image tags.
		/// </summary>
		public delegate void ReplaceImageHandler(XmlElement imgTag);

		/// <summary>
		/// Replace the tags searching for any image (img) element.
		/// The delegate (callback method) passed is used to generate the new tag based on the previous value.
		/// </summary>
		public void ReplaceImages(ReplaceImageHandler replaceMethod)
		{
			if (this._xmlDoc == null) throw new ArgumentNullException("xmlDoc");
			if (replaceMethod == null) throw new ArgumentNullException("replaceMethod");
			//
			XmlNodeList images = this._xmlDoc.SelectNodes("//img");

			if (images != null)
			{
				foreach (XmlElement element in images) replaceMethod(element);
			}
		}
		#endregion

		#region "properties"
		/// <summary>
		/// Automatically create the table of contents,
		/// insert the ID attribute for the heading tag if not found.
		/// </summary>
		/// <exception cref="OutOfMemoryException">There is insufficient memory to allocate a buffer for the returned string.</exception>
		/// <exception cref="IOException">An I/O error occurs.</exception>
		public string TOC
		{
			get { return HtmlHeadingParser.GenerateTOC(this._xmlDoc); }
		}

		/// <summary>
		/// Return the text without XHTML tags.
		/// </summary>
		public string RenderText
		{
			get { return (this._xmlDoc == null) ? null : this._xmlDoc.InnerText; }
		}

		/// <summary>
		/// Return the text complete with XHTML tags.
		/// </summary>
		public string RenderHTML
		{
			get { return (this._xmlDoc == null) ? null : this._xmlDoc.InnerXml; }
		}

		/// <summary>
		/// Return the XHTML completed with the tags and well indented.
		/// </summary>
		/// <exception cref="OutOfMemoryException">There is insufficient memory to allocate a buffer for the returned string.</exception>
		/// <exception cref="IOException">An I/O error occurs.</exception>
		public string XHTML
		{
			get
			{
				if (this._xmlDoc == null) return null;
				//
				using (MemoryStream stream = new MemoryStream())
				{
					XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8);
					writer.Formatting = Formatting.Indented;
					this._xmlDoc.DocumentElement.WriteContentTo(writer);
					writer.Flush();

					stream.Seek(0, SeekOrigin.Begin);
					StreamReader reader = new StreamReader(stream, Encoding.UTF8);

					return reader.ReadToEnd();
				}
			}
		}
		#endregion
	}

	/// <summary>
	/// Class used to parse an XHTML snippet and construct a TOC based on the heading tags.
	/// </summary>
	internal static class HtmlHeadingParser
	{
		private static string[] TAG_HEADINGS = new string[] { "h1", "h2", "h3", "h4", "h5", "h6" };

		#region "public methods"
		/// <summary>
		/// Automatically create the table of contents for the specified document.
		/// Insert an ID in the document if the heading doesn't have it.
		/// Returns the XHTML for the TOC.
		/// </summary>
		public static string GenerateTOC(XmlDocument doc)
		{
			if (doc == null) return null;
			//
			XmlNodeList headings = doc.SelectNodes("//*");

			Heading root = new Heading("ROOT", null, 0);
			int index = 0;
			GenerateHeadings(headings, root, ref index);

			using (MemoryStream stream = new MemoryStream())
			{
				XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8);
				writer.WriteStartElement("div");
				root.WriteChildrenToXml(writer);
				writer.WriteEndElement();
				writer.Flush();

				stream.Seek(0, SeekOrigin.Begin);
				StreamReader reader = new StreamReader(stream, Encoding.UTF8);

				return reader.ReadToEnd();
			}
		}
		#endregion

		#region "helper methods"
		private static void GenerateHeadings(XmlNodeList headings, Heading parent, ref int index)
		{
			while (index < headings.Count)
			{
				int headingLevel = GetHeadingLevel(headings[index].Name);

				if (headingLevel == 0)
				{
					// not an heading -> skip
					index++;
				}
				else if (headingLevel <= parent.Level)
				{
					return;
				}
				else if (headingLevel > parent.Level)
				{
					// generate the header only for heading with ID attribute
					string id = CheckForId(parent, (XmlElement)headings[index]);
					Heading subHead = new Heading(headings[index].InnerText, id, headingLevel);
					parent.AddChild(subHead);

					index++;	// read next

					GenerateHeadings(headings, subHead, ref index);
				}
				else throw new ArgumentOutOfRangeException("index");
			}
		}

		private static string CheckForId(Heading parent, XmlElement element)
		{
			string id = element.GetAttribute("id");
			if (id == null || id.Length == 0)
			{
				StringBuilder sb = new StringBuilder();
				foreach (char c in element.InnerText)
				{
					if (char.IsLetterOrDigit(c)) sb.Append(c);
					else if (char.IsWhiteSpace(c))
					{
						// don't consider whitespace
					}
					else sb.Append('_');

					if (sb.Length >= 100) break;
				}
				id = sb.ToString();

				// add the parent id
				if (!parent.IsRoot) id = parent.Id + "_" + id;

				element.SetAttribute("id", id);
			}

			return id;
		}

		private static int GetHeadingLevel(string element)
		{
			int index = Array.BinarySearch(TAG_HEADINGS, element.ToLower(CultureInfo.InvariantCulture));
			if (index < 0) return 0;
			else return index + 1;
		}
		#endregion

		#region "nested classes"
		private class Heading
		{
			public string Id;
			public string Text;
			public int Level;

			private IList<Heading> _children = new List<Heading>();
			public static readonly Heading ROOT = new Heading(null, null, 0);

			public bool IsRoot
			{
				get { return this.Level == 0; }
			}

			public Heading(string text, string id, int level)
			{
				this.Text = text;
				this.Level = level;
				this.Id = id;
			}

			public void AddChild(Heading child)
			{
				this._children.Add(child);
			}

			public void WriteToXml(XmlTextWriter writer)
			{
				writer.WriteStartElement("li");

				writer.WriteStartElement("a");
				writer.WriteAttributeString("href", "#" + this.Id);
				writer.WriteString(this.Text);
				writer.WriteEndElement();

				if (this._children.Count > 0)
				{
					this.WriteChildrenToXml(writer);
				}

				writer.WriteEndElement();
			}

			public void WriteChildrenToXml(XmlTextWriter writer)
			{
				writer.WriteStartElement("ul");

				foreach (Heading subHead in _children)
				{
					subHead.WriteToXml(writer);
				}

				writer.WriteEndElement();
			}
		}
		#endregion
	}
}
