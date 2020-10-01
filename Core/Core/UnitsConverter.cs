using System;

using log4net;

namespace ePower.Core
{
	/// <summary>
	/// Provide all units converter methods.
	/// </summary>
	public static class UnitsConverter
	{
		/// <summary>
		/// Parse a unit string type to a type of <see cref="CSSUnits"/>.
		/// </summary>
		/// <param name="unit"></param>
		/// <returns></returns>
		public static CSSUnits ParseUnit(string unit)
		{
			if (unit == null) throw new ArgumentNullException("unit");
			//
			unit = unit.Trim().ToLowerInvariant();
			switch (unit)
			{
				case "%": return CSSUnits.Percent;
				case "in": return CSSUnits.In;
				case "cm": return CSSUnits.Cm;
				case "mm": return CSSUnits.Mm;
				case "em": return CSSUnits.Em;
				case "ex": return CSSUnits.Ex;
				case "pt": return CSSUnits.Pt;
				case "pc": return CSSUnits.Pc;
				default: return CSSUnits.Px;
			}
		}

		/// <summary>
		/// Convert a distance in specified unit type to the pixel unit.
		/// </summary>
		/// <param name="distance"></param>
		/// <param name="unit"></param>
		/// <returns>A distance in pixels.</returns>
		public static int ToPixelUnit(int distance, CSSUnits unit)
		{
			int ptDist = (int)Math.Round((double)distance * 4 / 3);
			//
			switch (unit)
			{
				case CSSUnits.In: return ptDist * 72;
				case CSSUnits.Cm: return (int)Math.Round((double)ptDist * 72 / 2.54);
				case CSSUnits.Mm: return (int)Math.Round((double)ptDist * 72 / 25.4);
				case CSSUnits.Pt: return ptDist;
				case CSSUnits.Pc: return ptDist * 12;
				case CSSUnits.Px: return distance;
				default: throw new NotSupportedException("Specified unit type is not supported.");
			}
		}

		/// <summary>
		/// Convert a distance in specified unit type string to the pixel unit.
		/// </summary>
		/// <param name="distance"></param>
		/// <param name="unit"></param>
		/// <returns>A distance in pixels.</returns>
		public static int ToPixelUnit(int distance, string unit)
		{
			return ToPixelUnit(distance, ParseUnit(unit));
		}
	}

	/// <summary>
	/// CSS Units.
	/// </summary>
	public enum CSSUnits
	{
		/// <summary>
		/// Percentage (%).
		/// </summary>
		Percent,
		/// <summary>
		/// Inch.
		/// </summary>
		In,
		/// <summary>
		/// Centimeter
		/// </summary>
		Cm,
		/// <summary>
		/// Millimeter.
		/// </summary>
		Mm,
		/// <summary>
		/// 1em is equal to the current font size.
		/// 2em means 2 times the size of the current font.
		/// E.g., if an element is displayed with a font of 12 pt, then '2em' is 24 pt.
		/// The 'em' is a very useful unit in CSS, since it can adapt automatically to the font that the reader uses.
		/// </summary>
		Em,
		/// <summary>
		/// One ex is the x-height of a font (x-height is usually about half the font-size).
		/// </summary>
		Ex,
		/// <summary>
		/// Point (1 pt is the same as 1/72 inch).
		/// </summary>
		Pt,
		/// <summary>
		/// Pica (1 pc is the same as 12 points).
		/// </summary>
		Pc,
		/// <summary>
		/// Pixels (a dot on the computer screen).
		/// </summary>
		Px
	}
}
