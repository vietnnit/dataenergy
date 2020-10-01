using System;

namespace ePower.Core
{
	/// <summary>
	/// The interface used to define the permissions associated for a given entity.
	/// Not all the permissions can be used for all entities.
	/// For example the InsertPermissions is not used for FileAttach.
	/// Each property can contains a set of roles separated by a comma ','.
	/// There are 2 special roles: '*' indicates authenticated users and '?' indicates all users.
	/// </summary>
	public interface IAccessControl
	{
		/// <summary>
		/// Read permissions string.
		/// </summary>
		string ReadPermissions { get; }

		/// <summary>
		/// Insert permissions string.
		/// </summary>
		string InsertPermissions { get; }

		/// <summary>
		/// Edit permissions string.
		/// </summary>
		string EditPermissions { get; }

		/// <summary>
		/// Delete permissions string.
		/// </summary>
		string DeletePermissions { get; }
	}
}
