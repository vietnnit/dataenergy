using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace ePower.Core.Entity
{
    /// <summary>
    /// internal class for data converter
    /// </summary>
    internal class DataConverter
    {
        public static object ToDataRowData(FieldType fieldType, object propertyValue)
        {
            if (propertyValue == null) return null;
            //if (fieldType == FieldType.Automatic) 
            return propertyValue;

            throw new Exception(String.Format("Not supported converting list field type '{0}'.", fieldType.ToString()));
        }

        public static object ToEntityPropertyData(FieldType fieldType, object fieldValue)
        {
            if (fieldValue == null) return null;            
            return fieldValue;
            throw new Exception(String.Format("Not supported mapping to entity field type '{0}'.", fieldType.ToString()));
        }
    }
}
