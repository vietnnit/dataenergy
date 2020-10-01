using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Collections.Generic;

using log4net;

namespace ePower.Core
{
	/// <summary>
	/// Declare utility functions to process string type.
	/// </summary>
	public static class StringUtil
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(StringUtil));

		#region "constants"
		/// <summary>
		/// Return a Regular Expressions to validate a user name string.
		/// </summary>
		public static readonly Regex USERNAME_REGX = new Regex(@"^[\w\-\.]+$", RegexOptions.Compiled);

		/// <summary>
		/// Return a Regular Expressions to validate a e-mail string.
		/// </summary>
		public static readonly Regex EMAIL_REGX = new Regex(@"^\w+([\-\+\.]\w+)*@\w+([\-\.]\w+)*\.\w+([\-\.]\w+)*$",
			RegexOptions.Compiled | RegexOptions.ExplicitCapture);

		/// <summary>
		/// Return a Regular Expressions to validate a Hexa string.
		/// </summary>
		public static readonly Regex HEXA_REGX = new Regex(@"^[0-9a-fA-F]+$", RegexOptions.Compiled);

		/// <summary>
		/// Return a Regular Expressions to validate a mobile number string.
		/// </summary>
		public static readonly Regex MOBILE_REGX = new Regex(@"^(0|\+[1-9])[0-9]+$", RegexOptions.Compiled | RegexOptions.ExplicitCapture);

		/// <summary>
		/// Returns a Regular Expressions to validate an absolute URL string.
		/// </summary>
		public static readonly Regex URL_REGX = new Regex(@"^((ht|f)tp(s?)\:\/\/)?([\w]+:\w+@)?([a-zA-Z]{1}([\w\-]+\.?)+([\w]{2,5})?|(2[0-4]\d|25[0-5]|[01]?\d\d?)\.(2[0-4]\d|25[0-5]|[01]?\d\d?)\.(2[0-4]\d|25[0-5]|[01]?\d\d?)\.(2[0-4]\d|25[0-5]|[01]?\d\d?))(:[\d]{1,5})?((/[\w,%\-]+)*/?)([\w%\-]+\.[\w]{3,4})?(\?\w+=[\w%]+(&\w+=[\w%]+)*|\?\w+)?(\#[\w,%\-]*)?$",
			RegexOptions.Compiled | RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase);

		/// <summary>
		/// Returns a Regular Expressions to validate a relative URL string.
		/// </summary>
		public static readonly Regex RELURL_REGX = new Regex(@"^((\~|\.*)\/)?([\w,%\-]+\/)*([\w%\-]+\.\w+)?(\?\w+=[\w%]+(&\w+=[\w%]+)*|\?\w+)?(\#[\w,%\-]*)?$",
			RegexOptions.Compiled | RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase);

		/// <summary>
		/// Returns a Regular Expressions to validate a half-size string.
		/// </summary>
		public static readonly Regex HALFSIZE_REGX = new Regex("^[ -\xFE]+$", RegexOptions.Compiled);

		/// <summary>
		/// Returns an array of countries code (two-letter code defined in ISO 3166 for the country/region).
		/// </summary>
		public static readonly string[] COUNTRIES_CODE = "AD,AE,AF,AG,AI,AL,AM,AN,AO,AQ,AR,AS,AT,AU,AW,AX,AZ,BA,BB,BD,BE,BF,BG,BH,BI,BJ,BM,BN,BO,BR,BS,BT,BV,BW,BY,BZ,CA,CC,CD,CF,CG,CH,CI,CK,CL,CM,CN,CO,CR,CS,CU,CV,CX,CY,CZ,DE,DJ,DK,DM,DO,DZ,EC,EE,EG,EH,ER,ES,ET,FI,FJ,FK,FM,FO,FR,FX,GA,GB,GD,GE,GF,GH,GI,GL,GM,GN,GP,GQ,GR,GS,GT,GU,GW,GY,HK,HM,HN,HR,HT,HU,ID,IE,IL,IN,IO,IQ,IR,IS,IT,JM,JO,JP,KE,KG,KH,KI,KM,KN,KP,KR,KW,KY,KZ,LA,LB,LC,LI,LK,LR,LS,LT,LU,LV,LY,MA,MC,MD,MG,MH,MK,ML,MM,MN,MO,MP,MQ,MR,MS,MT,MU,MV,MW,MX,MY,MZ,NA,NC,NE,NF,NG,NI,NL,NO,NP,NR,NU,NZ,OM,PA,PE,PF,PG,PH,PK,PL,PM,PN,PR,PS,PT,PW,PY,QA,RE,RO,RU,RW,SA,SB,SC,SD,SE,SG,SH,SI,SJ,SK,SL,SM,SN,SO,SR,ST,SU,SV,SY,SZ,TC,TD,TF,TG,TH,TJ,TK,TL,TM,TN,TO,TP,TR,TT,TV,TW,TZ,UA,UG,UK,UM,US,UY,UZ,VA,VC,VE,VG,VI,VN,VU,WF,WS,YE,YT,YU,ZA,ZM,ZR,ZW".Split(',');

		/// <summary>
		/// Returns a Regular Expressions to validate a IP string.
		/// </summary>
		public static readonly Regex IP_REGX = new Regex(@"^(?<First>2[0-4]\d|25[0-5]|[01]?\d\d?)\.(?<Second>2[0-4]\d|25[0-5]|[01]?\d\d?)\.(?<Third>2[0-4]\d|25[0-5]|[01]?\d\d?)\.(?<Fourth>2[0-4]\d|25[0-5]|[01]?\d\d?)$",
			RegexOptions.Compiled | RegexOptions.ExplicitCapture);

		/// <summary>
		/// Return a Regular Expressions to validate a 'Order by' clause in a HSQL string.
		/// </summary>
		public static readonly Regex ORDERBY_REGX = new Regex(@"^[\w\-\{\}]+\.[\w\-\{\}]+(\s+(asc|desc))?(,[\w\-\{\}]+\.[\w\-\{\}]+(\s+(asc|desc))?)*$",
			RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);
		#endregion

		#region "validate patterns"
		/// <summary>
		/// Return a Regular Expressions to validate a positive number.
		/// </summary>
		public static readonly Regex P_NUMBER_REGX = new Regex("^[1-9][0-9]*$", RegexOptions.Compiled);
		/// <summary>
		/// Return a Regular Expressions to validate a non-negative number.
		/// </summary>
		public static readonly Regex NN_NUMBER_REGX = new Regex("^[0-9]+$", RegexOptions.Compiled);
		/// <summary>
		/// Return a Regular Expressions to validate a integer number.
		/// </summary>
		public static readonly Regex INTEGER_REGX = new Regex(@"^(\-|\+)?[0-9]+$", RegexOptions.Compiled | RegexOptions.ExplicitCapture);
		#endregion

		/// <summary>
		/// Escape a value in a HSQL (ex: LIKE '%\%' ESCAPE '\').
		/// </summary>
		/// <param name="str">String value to escape.</param>
		/// <returns>An escaped string.</returns>
		public static string EscapeInHSQL(string str)
		{
			if (str == null) throw new ArgumentNullException("str");
			if (log.IsDebugEnabled)	// DEBUG
				log.Debug(">> str='" + str + "'.");

			str = str
				.Replace("\\_", "_")
				.Replace("_", "\\_")
				.Replace("\\%", "%")
				.Replace("%", "\\%")
				.Replace("?", "_")
				.Replace("*", "%");
			if (log.IsDebugEnabled)	// DEBUG
				log.Debug("<< '" + str + "'.");
			return str;
		}

		/// <summary>
		/// Shorten a sentence by maximum length.
		/// </summary>
		/// <param name="sentence"></param>
		/// <param name="len"></param>
		/// <returns>A short sentence (padded by '...').</returns>
		public static string ShortenByWord(string sentence, int len)
		{
			if (sentence == null) return string.Empty;
			if (sentence.Length > len)
			{
				sentence = sentence.Substring(0, len);
				// cut a word
				int pos = sentence.LastIndexOf(' ');
				if (pos > 0) sentence = sentence.Substring(0, pos);
				return sentence + "...";
			}
			return sentence;
		}

		/// <summary>
		/// Compares two objects for equivalence, ignoring the case of strings.
		/// </summary>
		[Serializable]
		public class CaseInsensitiveComparer<T> : IComparer<T>
		{
			private CompareInfo _compareInfo;
			private static CaseInsensitiveComparer<T> _invariantCaseInsensitiveComparer;

			/// <summary>
			/// Initializes a new instance of the CaseInsensitiveComparer class using the CurrentCulture of the current thread.
			/// </summary>
			public CaseInsensitiveComparer() : this(CultureInfo.CurrentCulture) { }

			/// <summary>
			/// Initializes a new instance of the CaseInsensitiveComparer class using the specified <see cref="CultureInfo" />.
			/// </summary>
			/// <param name="culture">The <see cref="CultureInfo" /> to use for the new CaseInsensitiveComparer.</param>
			/// <exception cref="ArgumentNullException">culture is null.</exception>
			public CaseInsensitiveComparer(CultureInfo culture)
			{
				if (culture == null) throw new ArgumentNullException("culture");
				this._compareInfo = culture.CompareInfo;
			}

			/// <summary>
			/// Performs a case-insensitive comparison of two objects of the same type and returns a value indicating whether
			/// one is less than, equal to or greater than the other.
			/// </summary>
			/// <returns>Value Condition Less than zero x is less than y, with casing ignored.
			/// Zero x equals y, with casing ignored. Greater than zero x is greater than y, with casing ignored.</returns>
			/// <param name="x">The first object to compare.</param>
			/// <param name="y">The second object to compare.</param>
			/// <exception cref="ArgumentException">Neither x nor y implements the <see cref="IComparable" /> interface.
			/// -or- x and y are of different types.</exception>
			public int Compare(T x, T y)
			{
				string str = x as string, str2 = y as string;
				if ((str != null) && (str2 != null)) return this._compareInfo.Compare(str, str2, CompareOptions.IgnoreCase);
				return Comparer<T>.Default.Compare(x, y);
			}

			/// <summary>
			/// Gets an instance of CaseInsensitiveComparer that is associated with the CurrentCulture of the current thread
			/// and that is always available.</summary>
			/// <returns>An instance of CaseInsensitiveComparer that is associated with the CurrentCulture of the current thread.</returns>
			public static CaseInsensitiveComparer<T> Default
			{
				get { return new CaseInsensitiveComparer<T>(); }
			}

			/// <summary>
			/// Gets an instance of CaseInsensitiveComparer that is associated with InvariantCulture and that is always available.
			/// </summary>
			/// <returns>An instance of CaseInsensitiveComparer that is associated with InvariantCulture.</returns>
			public static CaseInsensitiveComparer<T> DefaultInvariant
			{
				get
				{
					if (_invariantCaseInsensitiveComparer == null)
						_invariantCaseInsensitiveComparer = new CaseInsensitiveComparer<T>(CultureInfo.InvariantCulture);
					return _invariantCaseInsensitiveComparer;
				}
			}
		}
	}
}
