using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace ePower.Core.Entity
{
    public class EntityReflector<EntityType> where EntityType : BaseEntity
    {
        public static EntityType CreateInstance()
        {
            return Activator.CreateInstance<EntityType>();
        }

        public static IList<EntityFieldInfo> GetFieldInfo()
        {
            IList<EntityFieldInfo> result = new List<EntityFieldInfo>();
            PropertyInfo[] infoList = typeof(EntityType).GetProperties();
            
            // Go through all properties in the entity
            foreach (PropertyInfo propertyInfo in infoList)
            {
                foreach(FieldNameAttribute fieldNameAtt in propertyInfo.GetCustomAttributes(typeof(FieldNameAttribute), false))
                    result.Add(new EntityFieldInfo(propertyInfo, fieldNameAtt.Name, fieldNameAtt.FieldAccessMode, fieldNameAtt.FieldType));
            }
            return result;
        }

        public static void SetValueToField(EntityType entity, EntityFieldInfo entityFieldInfo, object objectValue)
        {
            entityFieldInfo.PropertyInfo.SetValue(entity, objectValue, BindingFlags.SetProperty, null, null, CultureInfo.CurrentCulture);
        }

        public static object GetValueFromField(EntityType entity, EntityFieldInfo entityFieldInfo)
        {
            return entityFieldInfo.PropertyInfo.GetValue(entity, BindingFlags.GetProperty, null, null, CultureInfo.CurrentCulture);
        }
    }
}
