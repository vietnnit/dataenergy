using System;
using System.Collections.Generic;
using System.Text;

namespace ePower.Core.Entity
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class FieldNameAttribute : Attribute
    {
        private readonly string name;
        private readonly FieldAccessMode fieldAccessMode;
        private readonly FieldType fieldType;

        public FieldNameAttribute(string name, FieldAccessMode fieldAccessMode) : this(name, fieldAccessMode, FieldType.Automatic)
        {
        }

        public FieldNameAttribute(string name, FieldAccessMode fieldAccessMode, FieldType fieldType)
        {
            this.name = name;
            this.fieldAccessMode = fieldAccessMode;
            this.fieldType = fieldType;
        }
        
        public string Name
        {
            get { return name; }
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
