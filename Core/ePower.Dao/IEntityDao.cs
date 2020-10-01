using System;
using System.Collections.Generic;
using System.Text;
using ePower.Core;
using ePower.Core.Entity;
using System.Data;


namespace ePower.Dao
{
	public interface IEntityDao<EntityType>
	{
		#region Base Functions
		int Insert(EntityType entity);
        int Insert(string sql, bool getId, EntityType entity);

		EntityType Update(EntityType entity);
        int Update(string sql, EntityType entity);

		int Delete(int Id);
        int Delete(string sql, DbParameter[] p, CommandType commandType);

		EntityType FindByKey(int Id);

		IList<EntityType> FindAll();

		/// <summary>
		/// Find EntityType
		/// </summary>
		/// <param name="sql">string query</param>
		/// <param name="p">parameter</param>
		/// <param name="commandType">command type</param>
		/// <returns></returns>
		EntityType FindEntity(string sql, DbParameter[] p, CommandType commandType);
		
		/// <summary>
		/// Find list EntityType
		/// </summary>
		/// <param name="sql">string query</param>
		/// <param name="p">parameter</param>
		/// <param name="commandType">command type</param>
		/// <returns></returns>
		IList<EntityType> FindList(string sql, DbParameter[] p, CommandType commandType);

        /// <summary>
        /// Find list EntityType
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        IList<EntityType> FindList(string sql, CommandType commandType);
		#endregion
	}
}
