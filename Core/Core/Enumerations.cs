using System;

namespace ePower.Core
{
	/// <summary>
	/// Enum to define the validation mode for the XHTML snippets.
	/// </summary>
	public enum XHtmlMode : byte
	{
		/// <summary>
		/// No validation.
		/// </summary>
		None = 0,
		/// <summary>
		/// Basic validation only. Check if not supported tags are present (like body, html, head, script, ...).
		/// See the XHTMLText for the full list.
		/// </summary>
		BasicValidation = 1,
		/// <summary>
		/// Strict validation. Only permits certain tags (p, a, br, table, h1, h2, ...).
		/// See the XHTMLText for the full list.
		/// </summary>
		StrictValidation = 2
	}

	/// <summary>
	/// Enum to define the backup mode used for wiki articles.
	/// </summary>
	public enum WikiBackupMode : byte
	{
		/// <summary>
		/// Backup always.
		/// </summary>
		Always = 0,
		/// <summary>
		/// Backup only if requested.
		/// </summary>
		Request = 1,
		/// <summary>
		/// Backup disabled.
		/// </summary>
		Never = 2
	}

	/// <summary>
	/// Enum to define the plain text mode used to format and validate an XHTML text.
	/// </summary>
	public enum PlainTextMode
	{
		/// <summary>
		/// CSS plain text.
		/// </summary>
		CSSPlainText = 1,
		/// <summary>
		/// XHTML conversion.
		/// </summary>
		XHtmlConversion = 2
	}

	/// <summary>
	/// Enum to define the profile type used for members manager.
	/// </summary>
	public enum ProfileType : byte
	{
		/// <summary>
		/// Is anonymous.
		/// </summary>
		Anonymous = 1,
		/// <summary>
		/// Is authenticated.
		/// </summary>
		Authenticated = 2
	}
}
