using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Principal;
using System.Text.RegularExpressions;

namespace ePower.Core
{
	/// <summary>
	/// Static class with some helper methods to check security properties of an entity.
	/// This class is used to check the permissions defined in the entity category.
	/// See the MatchPermissions method for informations about the syntax.
	/// </summary>
	public static class PermissionHelper
	{
		#region "constants"
		/// <summary>
		/// All users (*).
		/// </summary>
		public const string ALL_USERS = "*";

		/// <summary>
		/// Authenticated users (?).
		/// </summary>
		public const string AUTH_USERS = "?";

		/// <summary>
		/// Negative permissions (!).
		/// </summary>
		public const string NEGATIVE = "!";

		/// <summary>
		/// None permissions.
		/// </summary>
		public const string NONE = "";

		/// <summary>
		/// Returns a Regular Expressions to validate a string of permissions sets.
		/// </summary>
		public static readonly Regex PERMISSIONS_REGX = new Regex(@"^\!?(\*|\?|([\w\-\.]+(,\!?[\w\-\.]+)*))$",
			RegexOptions.Compiled | RegexOptions.ExplicitCapture);
		#endregion

		#region "helper methods"
		private static bool MatchRole(IPrincipal user, string role)
		{
			if (ALL_USERS.Equals(role)) return true;
			else if (AUTH_USERS.Equals(role)) return user.Identity.IsAuthenticated;
			else return user.IsInRole(role);
		}

		/// <summary>
		/// Returns an array of roles without the ! character and trimmed.
		/// </summary>
		public static IEnumerable<string> GetPositiveRoles(string permissions)
		{
			string[] roles = permissions.Split(',');
			for (int i = 0, len = roles.Length; i < len; i++)
			{
				string role = roles[i].Trim();
				if (role.Length > 0 && !role.StartsWith(NEGATIVE))
					yield return role;
			}
		}

		/// <summary>
		/// Returns an array of roles with the ! character and trimmed.
		/// </summary>
		public static IEnumerable<string> GetNegativeRoles(string permissions)
		{
			string[] roles = permissions.Split(',');
			for (int i = 0, len = roles.Length; i < len; i++)
			{
				string role = roles[i].Trim();
				// return the role with the ! character and trimmed
				if (role.Length > 1 && role.StartsWith(NEGATIVE))
					yield return role.Substring(1).Trim();
			}
		}
		#endregion

		#region "matching methods"
		/// <summary>
		/// A generic method to check a predefined permission string. The permission string can contains a list
		/// of roles or some common constants like * to define authenticated users or ? for all users.
		/// You can also deny a specific role using the prefix !. Each role must be separated by a comma.
		/// </summary>
		public static bool MatchPermissions(IPrincipal user, string permissions)
		{
			if (user == null) throw new ArgumentNullException("user");
			if (permissions == null || permissions.Length < 1) return false;

			// match negative roles
			foreach (string role in GetNegativeRoles(permissions))
			{
				if (MatchRole(user, role)) return false;
			}

			// match positive roles
			foreach (string role in GetPositiveRoles(permissions))
			{
				if (MatchRole(user, role)) return true;
			}

			return false;
		}

		/// <summary>
		/// Check specified user is owner of specified entity or not?
		/// </summary>
		public static bool MatchUser(IPrincipal user, IOwner entity)
		{
			return (entity != null && MatchUser(user, entity.Owner));
		}

		/// <summary>
		/// Check specified user has name equals to owner or not?
		/// </summary>
		public static bool MatchUser(IPrincipal user, string owner)
		{
			if (user == null) throw new ArgumentNullException("user");
			return (string.Compare(user.Identity.Name, owner, true, CultureInfo.InvariantCulture) == 0);
		}
		#endregion

		#region "checking methods"
		/// <summary>
		/// Verify specified user can delete a specified entity or not?
		/// </summary>
		public static bool CanDelete(IPrincipal user, IAccessControl accessControl, IOwner entity)
		{
			if (MatchUser(user, entity)) return true;
			else if (accessControl != null) return MatchPermissions(user, accessControl.DeletePermissions);
			return true;
		}

		/// <summary>
		/// Verify specified user can edit a specified entity or not?
		/// </summary>
		public static bool CanEdit(IPrincipal user, IAccessControl accessControl, IOwner entity)
		{
			if (MatchUser(user, entity)) return true;
			else if (accessControl != null) return MatchPermissions(user, accessControl.EditPermissions);
			return true;
		}

		/// <summary>
		/// Verify specified user can read a specified entity or not?
		/// </summary>
		public static bool CanRead(IPrincipal user, IAccessControl accessControl, IOwner entity)
		{
			if (MatchUser(user, entity)) return true;
			else if (accessControl != null) return MatchPermissions(user, accessControl.ReadPermissions);
			return true;
		}

		/// <summary>
		/// Verify specified user can insert a specified entity or not?
		/// </summary>
		public static bool CanInsert(IPrincipal user, IAccessControl accessControl)
		{
			if (accessControl != null) return MatchPermissions(user, accessControl.InsertPermissions);
			return true;
		}
		#endregion
	}
}
