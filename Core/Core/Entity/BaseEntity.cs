/*Base entity*/
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Reflection;

namespace ePower.Core.Entity
{
    [Serializable]
	public class BaseEntity
	{
		protected readonly bool enableSmartUpdate;
		protected readonly StringCollection dirtyFlags = new StringCollection();
		private int id;
		private string _tableName;

		#region Contructors
		public BaseEntity() : this(true) { }

		/// <summary>
		/// Contruct an entity with enabling or diabling smart update mode
		/// </summary>
		/// <param name="enableSmartUpdate"></param>
		public BaseEntity(bool enableSmartUpdate)
		{
			this.enableSmartUpdate = enableSmartUpdate;
		}
		#endregion

		#region Table Name Property
		public virtual string TableName
		{
			get { return _tableName; }
			set { this._tableName = value; }
		}
		#endregion

		#region Smart Update Functions
		/// <summary>
		/// Set dirty for current property
		/// </summary>
		protected void SetDirty()
		{
			if (!enableSmartUpdate) return;
			StackFrame aboveFrame = new StackFrame(1);
			MethodBase callMethod = aboveFrame.GetMethod();
			if (callMethod.IsSpecialName && callMethod.Name.StartsWith("set_"))
				SetDirty(callMethod.Name.Substring(4));
		}

		/// <summary>
		/// Set dirty for an property
		/// </summary>
		/// <param name="propertyName"></param>
		protected void SetDirty(string propertyName)
		{
			if (!dirtyFlags.Contains(propertyName)) dirtyFlags.Add(propertyName);
		}

		/// <summary>
		/// Clear the dirty flag
		/// </summary>
		public void ClearDirtyFlag()
		{
			dirtyFlags.Clear();
		}

		/// <summary>
		/// Properties that was dirty
		/// </summary>
		public StringCollection DirtyProperties
		{
			get { return dirtyFlags; }
		}

		#endregion

		#region Base Properties
		/// <summary>
		/// Id of list item
		/// </summary>
		[FieldName("id", FieldAccessMode.ReadOnly,FieldType.Int)]
		public virtual int Id
		{
			get { return id; }
			set
			{
				id = value;
			}
		}
		#endregion
	}
}
