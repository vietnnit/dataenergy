using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using log4net;

namespace ePower.Core.Entity
{
	public class EntityMapper<EntityType> where EntityType : BaseEntity
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(EntityMapper<EntityType>));
		#region Base Functions
		/// <summary>
		/// Return an entity instance from the type. Override for customization.
		/// </summary>
		/// <returns>Entity instance</returns>
		protected virtual EntityType NewEntity()
		{
			return EntityReflector<EntityType>.CreateInstance();
		}
		/// <summary>
		/// Return an entity from an datarow. List fields an entity propeties are mapping together.
		/// </summary>
		/// <param name="dr">Data Row</param>
		/// <returns>Entity instance</returns>
		public virtual EntityType MapItem(DataRow dr)
		{
			EntityType entity = NewEntity();
			// Mapping data from data row to EntityType
			foreach (EntityFieldInfo fieldInfo in EntityFieldInfoCache<EntityType>.GetEntityFieldInfos())
			{
				try
				{
					// if data row don't contain fieldName
					if (Convert.IsDBNull(dr[fieldInfo.FieldName]))
					log.Debug("DataRow don't contain column " + fieldInfo.FieldName);
					object value = dr[fieldInfo.FieldName];
					if (fieldInfo.FieldType != FieldType.Automatic) value = DataConverter.ToEntityPropertyData(fieldInfo.FieldType, value);
					EntityReflector<EntityType>.SetValueToField(entity, fieldInfo, value);
				}
				catch (Exception ex)
				{
					log.Fatal(String.Format("Error occured while mapping list field to '{0}' property", fieldInfo.FieldName), ex);
				}
			}
			// Clear dirty flag in IDictionary
			entity.ClearDirtyFlag();
			return entity;
		}

		/// <summary>
		/// Set values for a list item from an entity instance.
		/// </summary>
		/// <param name="listItem">List item</param>
		/// <param name="entity">Entity instance</param>
		public virtual EntityType MapItem(DataRow dr, EntityType entity)
		{
			foreach (EntityFieldInfo fieldInfo in EntityFieldInfoCache<EntityType>.GetEntityFieldInfos())
			{
				// if data row don't contain fieldName
				if (Convert.IsDBNull(dr[fieldInfo.FieldName]))
					log.Debug("DataRow don't contain column " + fieldInfo.FieldName);
				// && (entity.DirtyProperties.Contains(fieldInfo.PropertyInfo.Name)
				if (fieldInfo.FieldAccessMode == FieldAccessMode.ReadWrite)
				{
					try
					{
						object value = EntityReflector<EntityType>.GetValueFromField(entity, fieldInfo);
						if (fieldInfo.FieldType != FieldType.Automatic) value = DataConverter.ToDataRowData(fieldInfo.FieldType, value);
					}
					catch (Exception ex)
					{
						throw new Exception(String.Format("Error occured while getting '{0}' property from data row.", fieldInfo.FieldName), ex);
					}
				}
			}
			return entity;
		}
		#endregion
	}
}
