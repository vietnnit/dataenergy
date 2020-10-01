using System;

namespace ePower.Core
{
	/// <summary>
	/// Interface used to automatically update UpdateDate and InsertDate fields
	/// of an entity using nhibernate interceptor.
	/// </summary>
	public interface IAudit
	{
		/// <summary>
		/// Gets or sets the insert date (updated when the entity is first insert in the database).
		/// </summary>
		DateTime InsertDate { get; set; }

		/// <summary>
		/// Gets or sets the update date (updated each time the entity is updated).
		/// </summary>
		DateTime UpdateDate { get; set; }
	}

	/// <summary>
	/// Property name constants defined.
	/// </summary>
	public static class AuditableProperties
	{
		/// <summary>
		/// Insert date property name.
		/// </summary>
		public const string INSERT_DATE = "InsertDate";

		/// <summary>
		/// Update date property name.
		/// </summary>
		public const string UPDATE_DATE = "UpdateDate";
	}
}
