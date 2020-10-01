using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ePower.Core.Entity
{
	/// <summary>
	/// Object <see cref="EntityFieldInfo"/>
	/// </summary>
    public class EntityFieldInfo
    {
        private readonly PropertyInfo propertyInfo;
		private readonly string fieldName;
		private readonly FieldAccessMode fieldAccessMode;
        private readonly FieldType fieldType;

		/// <summary>
		/// Constructor for <see cref="EntityFieldInfo"/> object
		/// </summary>
		/// <param name="propertyInfo">property info</param>
		/// <param name="fieldName">field name</param>
		/// <param name="fieldAccessMode">access mode</param>
		/// <param name="fieldType">field type</param>
        public EntityFieldInfo(PropertyInfo propertyInfo, string fieldName, FieldAccessMode fieldAccessMode, FieldType fieldType)
		{
            this.propertyInfo = propertyInfo;
			this.fieldName = fieldName;
			this.fieldAccessMode = fieldAccessMode;
            this.fieldType = fieldType;
		}

        public PropertyInfo PropertyInfo
		{
            get { return propertyInfo; }
		}
		
		public string FieldName
		{
			get { return fieldName; }
		}
		
		public FieldAccessMode FieldAccessMode
		{
			get { return fieldAccessMode; }
		}
        
        public FieldType FieldType
        {
            get { return fieldType; }
        }
    }
}
