using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ePower.Core
{
	/// <summary>
	/// Static class with some helper methods for split text, useful for search field.
	/// </summary>
	public static class SplitHelper
	{
		/// <summary>
		/// Split a classic search text using space as separator but considering values inside double quote as a single block.
		/// </summary>
		/// <param name="searchText"></param>
		/// <returns></returns>
		public static IList<string> SplitSearchText(string searchText)
		{
			return SplitQuoted(searchText, " ");
		}

		/// <summary>
		/// Split the text using the separator specified without considering string inside double quoted.
		/// Thanks to William Stacey for this code (founded on google groups).
		/// </summary>
		/// <param name="text"></param>
		/// <param name="seperators"></param>
		/// <returns></returns>
        public static IList<string> SplitQuoted(string text, string seperators)
		{
			// "([^"\\]*(\\.[^"\\]*)*)"
			// |
			// ([^\s,]+)
			// Default seperators is a space and tab (e.g. " \t").
			// All seperators not inside quote pair are ignored.
			// Default quotes pair is two double quotes ( e.g. '""' ).
			if (text == null) throw new ArgumentNullException("text");
			if (string.IsNullOrEmpty(seperators)) throw new ArgumentNullException("seperators");

			//if (quotes == null || quotes.Length < 1) quotes = "\"\"";
			IList<string> res = new List<string>();

			// Get the open and close chars, escape them for use in regular expressions.
			//   string openChar = Regex.Escape(quotes[0].ToString());
			//   string closeChar = Regex.Escape(quotes[quotes.Length - 1].ToString());
			// Build the pattern that searches for both quoted and unquoted elements
			// notice that the quoted element is defined by group #2
			// and the unquoted element is defined by group #3.
			//| \s*("([^"]*)"|([^,]+))\s* |
			// match any spaces upto first quote. that does not contain zero or more " chars
			// ending in a quote OR not one or more commas
			//   string pattern = @"\s*(" + openChar + "([^" + closeChar + "]*)" + closeChar + @"|([^" + seperators + @"]+))\s*";

			//"([^"\\]*[\\.[^"\\]*]*)" //Note quotes at either end are required.
			//|
			//([^\s,]+)
			//string[] sa = Regex.Split("my string", "pattern");
			string pattern = @"""([^""\\]*[\\.[^""\\]*]*)""" + "|" + @"([^" + seperators + @"]+)";

			// search the string.
			foreach (Match m in Regex.Matches(text, pattern))
			{
				//string g0 = m.Groups[0].Value;
				string g1 = m.Groups[1].Value;
				string g2 = m.Groups[2].Value;
				// get the quoted string, but without the quotes in g1;
				if (g2 != null && g2.Length > 0) res.Add(g2);
				else res.Add(g1);
			}
			return res;
		}
	}
}
