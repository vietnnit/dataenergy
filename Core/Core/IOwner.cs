using System;

namespace ePower.Core
{
	/// <summary>
	/// Use this interface to define an entity with an owner (user).
	/// </summary>
	public interface IOwner
	{
		/// <summary>
		/// User name that owner the entity.
		/// </summary>
		string Owner { get; }
	}
}
