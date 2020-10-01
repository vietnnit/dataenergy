using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Text;
using System.Text.RegularExpressions;
using Sgml;

namespace ePower.Core
{
	/// <summary>
	/// Formats HTML text.
	/// </summary>
	public static class Formatter
	{
		private static readonly string EVENTS = ",onclick,onmousedown,onmouseover,onmouseout,onmouseup,";
		private static readonly Regex TAG_REGX = new Regex(@"</?([-\w]+)(\s*[^>]+)?>", RegexOptions.Compiled);
		private static readonly Regex EVENT_REGX = new Regex("\\s*([-\\w]+)(=(\"[^\"]*\"|'[^']*'|(#|_)?\\w+))?", RegexOptions.Compiled);

		#region "public methods"
		/// <summary>
		/// Converts Html Codes to Html Characters.
		/// </summary>
		/// <param name="input">A <c>string</c> of Html Codes.</param>
		/// <returns>A <c>string</c> of Html Characters.</returns>
		public static string HtmlCodesToHtmlSymbols(string input)
		{
			if (input == null) return string.Empty;
			//
			bool begin = false; int ich; char chr;
			StringBuilder sb = new StringBuilder();
			StringBuilder str = new StringBuilder();
			foreach (char ch in input)
			{
				switch (ch)
				{
					case '&':
						sb.Append(str);
						str.Length = 0; str.Append('&');
						begin = true;
						break;

					case ';':
						if (!begin) sb.Append(ch);
						else
						{
							str.Append(ch);
							if ((str.Length > 2) && (str[1] == '#') && (str[2] != ';'))
							{
								ich = int.Parse(str.ToString(2, str.Length - 3), NumberStyles.Integer, null);
								chr = ((ich < 0 || ich > 0xffff) ? chr = char.MaxValue : (char)ich);
								str.Length = 0; str.Append(chr);
							}
							//
							sb.Append(str.ToString()); str.Length = 0;
							begin = false;
						}
						break;

					default:
						if (begin) str.Append(ch);
						else sb.Append(ch);
						break;
				}
			}
			return sb.Append(str.ToString()).ToString();
		}

		/// <summary>
		/// Converts Html Symbols to their respective Html Codes.
		/// </summary>
		/// <param name="input">A <c>string</c> of Html Symbols.</param>
		/// <returns>A <c>string</c> of Html Codes.</returns>
		public static string HtmlSymbolsToHtmlCodes(string input)
		{
			if (input == null) return string.Empty;
			//
			StringBuilder sb = new StringBuilder();
			foreach (char ch in input)
			{
				if (ch > '\x80') sb.Append("&#").Append(((int)ch)).Append(';');
				else sb.Append(ch);
			}
			return sb.ToString();
		}

		/// <summary>
		/// Uses <see cref="SgmlReader"/> to convert HTML to well-formed XHTML.
		/// </summary>
		/// <param name="input">The text to convert.</param>
		/// <returns>A <c>string</c> of well-formed XHTML.</returns>
		public static string HtmlToXhtml(string input)
		{
			if (input == null) return string.Empty;
			try
			{
				input = "<html>" + input + "</html>";
				//
				SgmlReader reader = new SgmlReader();
				reader.DocType = "HTML";
				reader.InputStream = new StringReader(input);
				reader.CaseFolding = CaseFolding.ToLower;
				reader.WhitespaceHandling = WhitespaceHandling.None;
				//
				StringWriter sw = new StringWriter(new StringBuilder(), null);
				XmlTextWriter writer = new XmlTextWriter(sw);
				writer.Formatting = Formatting.Indented;
				writer.IndentChar = '\t';
				while (!reader.EOF) writer.WriteNode(reader, true);
				writer.Close();
				//
				string buff = sw.ToString();
				// remove <html> tag
				return buff.Substring(6, buff.Length - 13);
			}
			catch (Exception ex)
			{
				return "Error converting HTML to XHTML: " + ex.Message;
			}
		}

		/// <summary>
		/// Removes JavaScript events from tags.
		/// </summary>
		public static string RemoveJavaScriptEventsFromTags(string input)
		{
			if (input == null) return string.Empty;
			return TAG_REGX.Replace(input, new MatchEvaluator(Formatter.FixTag));
		}

		private static string FixTag(Match tagMatch)
		{
			if (tagMatch == null || tagMatch.Value == null) return string.Empty;
			//
			string val = tagMatch.Value;
			if (val.IndexOf("</") == 0) return val.ToLower(CultureInfo.InvariantCulture);
			//
			StringBuilder tag = new StringBuilder('<');
			tag.Append(tagMatch.Groups[1].Value.ToLower(CultureInfo.InvariantCulture));
			//
			MatchCollection matches = EVENT_REGX.Matches(val);
			foreach (Match match in matches)
			{
				string item = match.Groups[1].Value;
				if (EVENTS.IndexOf(',' + item + ',', StringComparison.InvariantCultureIgnoreCase) < 0)
					tag.Append(' ').Append(item.ToLower(CultureInfo.InvariantCulture)).Append("=\"")
						.Append(match.Groups[3].Value.TrimStart('"').TrimEnd('"')).Append('"');
			}
			return tag.Append('>').ToString();
		}

		/// <summary>
		/// Removes the script name from bookmarks (#mark).
		/// </summary>
		public static string RemoveScriptNameFromBookmarks(string input, string href)
		{
			if (input == null) return string.Empty; if (href == null) return input;
			//
			input = Regex.Replace(input, "href=\"" + href, "href=\"", RegexOptions.IgnoreCase);
			input = Regex.Replace(input, "href=" + href, "href=", RegexOptions.IgnoreCase);
			return input;
		}

		/// <summary>
		/// Removes &lt;script&gt; tags.
		/// </summary>
		public static string RemoveScriptTags(string input)
		{
			if (input == null) return string.Empty;
			return Regex.Replace(input, @"<script(.|\n)+</script>", "",
				RegexOptions.Compiled | RegexOptions.IgnoreCase);
		}

		/// <summary>
		/// Removes the local servername from A and IMG tags.
		/// </summary>
		public static string RemoveServerNameFromUrls(string input, string serverPath)
		{
			if (input == null) return string.Empty; if (serverPath == null) return input;
			//
			input = Regex.Replace(input, "href=" + serverPath, "href=", RegexOptions.IgnoreCase);
			input = Regex.Replace(input, "href=\"" + serverPath, "href=\"", RegexOptions.IgnoreCase);
			input = Regex.Replace(input, "src=" + serverPath, "src=", RegexOptions.IgnoreCase);
			input = Regex.Replace(input, "src=\"" + serverPath, "src=\"", RegexOptions.IgnoreCase);
			return input;
		}

		/// <summary>
		/// Removes unneeded white spaces (spaces and breaks).
		/// </summary>
		public static string RemoveWhiteSpace(string input)
		{
			if (input == null) return string.Empty;
			input = input.Replace('\n', ' ').Replace('\r', ' ').Replace('\t', ' ');
			while (input.IndexOf("  ") > -1) input = input.Replace("  ", " ");
			return input;
		}
		#endregion
	}
}
