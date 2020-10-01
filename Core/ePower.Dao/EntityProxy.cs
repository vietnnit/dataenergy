using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ePower.Core.Entity;
using System.Data;


namespace ePower.Dao
{
	/// <summary>
	/// Base proxy entity
	/// </summary>
	public class EntityProxy<EntityType, ParrentEntity> : IEnumerable
		where EntityType : BaseEntity
		where ParrentEntity : BaseEntity
	{
		private bool initialized = false;
		private List<EntityType> list = new List<EntityType>();
		private ParrentEntity parrent;
		private string foreignKey;
		EntityMapper<EntityType> mapper = new EntityMapper<EntityType>();

		#region Constructor
		public EntityProxy()
		{ }
		#endregion


		/// <summary>
		/// Add entity child to list
		/// </summary>
		/// <param name="entity">entity</param>
		public void AddChild(EntityType entity)
		{
			LazyLoad();
			list.Add(entity);
		}
		/// <summary>
		/// Remove child from list
		/// </summary>
		/// <param name="entity">entity</param>
		public void RemoveChild(EntityType entity)
		{
			LazyLoad();
			list.Remove(entity);
		}


		public virtual ParrentEntity Parrent
		{
			get { return parrent; }
			set { parrent = value; }
		}

		public virtual string ForeignKey
		{
			get { return foreignKey; }
			set { foreignKey = value; }
		}
		/// <summary>
		/// Lazy load childs: only get them when needed
		/// </summary>
		public IList<EntityType> Childs
		{
			get
			{
				LazyLoad();
				return list;
			}
			set { list = value as List<EntityType>; }
		}
		/// <summary>
		/// Lazy load method
		/// </summary>
		public void LazyLoad()
		{
			if (!initialized)
			{
				EntityType entity1 = EntityReflector<EntityType>.CreateInstance();
				StringBuilder sb = new StringBuilder();
				sb.Append("SELECT * FROM ").Append(entity1.TableName).Append(" WHERE ").Append(ForeignKey).Append("=@").Append(ForeignKey);
				DbParameter param = new DbParameter("@" + this.ForeignKey, Parrent.Id);
				Db db = new Db();
				DataTable dt = db.GetDataTable(sb.ToString(), param, CommandType.Text);
				if (dt != null)
				{
					foreach (DataRow row in dt.Rows)
					{
						EntityType entity = EntityReflector<EntityType>.CreateInstance();
						entity = mapper.MapItem(row);
						list.Add(entity);
					}
				}
			}
			initialized = true;
		}

		/// <summary>
		/// Get enumerator to iterate over orders
		/// Iterator design pattern
		/// </summary>
		/// <returns></returns>
		public IEnumerator GetEnumerator()
		{
			LazyLoad();
			return list.GetEnumerator();
		}
	}
}
