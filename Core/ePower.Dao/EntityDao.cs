using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using log4net;

using ePower.Core;
using ePower.Core.Entity;
using System.Collections;


namespace ePower.Dao
{
    public class EntityDao<EntityType> : IEntityDao<EntityType> where EntityType : BaseEntity
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(EntityDao<EntityType>));
        #region Constructors
        EntityMapper<EntityType> mapper = new EntityMapper<EntityType>();
        public EntityDao()
        {
        }

        #endregion

        #region Base Functions
        /// <summary>
        /// Insert base <see cref="EntityType"/> to database
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>A object of <see cref="EntityType"/> when success, <b>null</b> when error</returns>
        public virtual int Insert(EntityType entity)
        {
            Db db = new Db();
            // string buider query insert
            StringBuilder sb = new StringBuilder();
            // string builder values to insert
            StringBuilder sbValues = new StringBuilder();
            // append entity table name
            sb.Append("INSERT INTO ").Append(entity.TableName).Append(" (");
            sbValues.Append(" VALUES (");
            DbParameter[] param = new DbParameter[EntityFieldInfoCache<EntityType>.GetEntityFieldInfos().Count];
            int i = 0;
            // build insert query and parameter
            foreach (EntityFieldInfo fieldInfo in EntityFieldInfoCache<EntityType>.GetEntityFieldInfos())
            {
                if (fieldInfo.FieldAccessMode == FieldAccessMode.ReadWrite)
                {
                    try
                    {
                        // retrive entity value
                        object value = EntityReflector<EntityType>.GetValueFromField(entity, fieldInfo);
                        // add data parameter
                        if (value != null)
                        {
                            if (fieldInfo.FieldType == FieldType.DateTime && Convert.ToDateTime(value).ToString("dd/MM/yyyy") == "01/01/0001")
                                continue;
                            if (fieldInfo.FieldType == FieldType.String && value.ToString() == string.Empty)
                                continue;
                            param[i] = new DbParameter("@" + fieldInfo.FieldName, value);
                            // append to query
                            sb.Append(fieldInfo.FieldName).Append(", ");
                            sbValues.Append("@").Append(fieldInfo.FieldName).Append(", ");
                            i++;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(String.Format("Error occured while getting '{0}' property from data row.", fieldInfo.FieldName), ex);
                    }
                }
                //else
                //{
                //    param[i] = new DbParameter("@" + fieldInfo.FieldName, entity.Id);
                //    i++;
                //}

            }
            DbParameter[] param2 = new DbParameter[i];
            for (int j = 0; j < i; j++)
            { param2[j] = new DbParameter(param[j].ParameterName, param[j].Value); }
            // fix string builder value
            sb.Remove(sb.Length - 2, 2); sbValues.Remove(sbValues.Length - 2, 2);
            sb.Append(")").Append(sbValues).Append(")");
            // execute insert query
            return db.Insert(sb.ToString(), true, param2, CommandType.Text);
        }

        /// <summary>
        /// Insert base <see cref="EntityType"/> to database
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="p"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public virtual int Insert(string sql, bool getId, EntityType entity)
        {
            int returnValue = 0;
            Db db = new Db();
            DbParameter[] param = new DbParameter[EntityFieldInfoCache<EntityType>.GetEntityFieldInfos().Count - 1];
            int i = 0;
            // build insert query and parameter
            foreach (EntityFieldInfo fieldInfo in EntityFieldInfoCache<EntityType>.GetEntityFieldInfos())
            {
                if (fieldInfo.FieldAccessMode == FieldAccessMode.ReadWrite)
                {
                    try
                    {
                        // retrive entity value
                        object value = EntityReflector<EntityType>.GetValueFromField(entity, fieldInfo);
                        // add data parameter
                        if (value != null)
                        {
                            if (fieldInfo.FieldType == FieldType.DateTime && Convert.ToDateTime(value).ToString("dd/MM/yyyy") == "01/01/0001")
                                continue;
                            if (fieldInfo.FieldType == FieldType.String && value.ToString() == string.Empty)
                                continue;
                            param[i] = new DbParameter("@" + fieldInfo.FieldName, value);
                            i++;
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Fatal("Error occured while getting '{0}' property from data row: ", ex);
                        throw new Exception(String.Format("Error occured while getting '{0}' property from data row.", fieldInfo.FieldName), ex);
                    }
                }

            }
            DbParameter[] param2 = new DbParameter[i];
            for (int j = 0; j < i; j++)
            { param2[j] = new DbParameter(param[j].ParameterName, param[j].Value); }
            try
            {
                returnValue = db.Insert(sql, getId, param2, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                log.Fatal("Insert entity has an exception: ", ex);
            }
            return returnValue;
        }

        /// <summary>
        /// Update base <see cref="EntityType"/> to database
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>A object of <see cref="EntityType"/> when success, <b>null</b> when error</returns>
        public virtual EntityType Update(EntityType entity)
        {
            Db db = new Db();
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE ").Append(entity.TableName).Append(" SET ");
            DbParameter[] param = new DbParameter[EntityFieldInfoCache<EntityType>.GetEntityFieldInfos().Count];
            // build update query and parameter
            int i = 0;
            foreach (EntityFieldInfo fieldInfo in EntityFieldInfoCache<EntityType>.GetEntityFieldInfos())
            {
                if (fieldInfo.FieldAccessMode == FieldAccessMode.ReadWrite)
                {
                    try
                    {
                        object value = EntityReflector<EntityType>.GetValueFromField(entity, fieldInfo);

                        if (value != null)
                        {
                            if (fieldInfo.FieldType == FieldType.DateTime && DateTime.Compare(Convert.ToDateTime(value), new DateTime(1, 1, 1)) == 0)
                                continue;
                            param[i] = new DbParameter("@" + fieldInfo.FieldName, value);
                            sb.Append(fieldInfo.FieldName).Append("=@").Append(fieldInfo.FieldName).Append(", ");
                            i++;
                        }

                    }
                    catch (Exception ex)
                    {
                        log.Fatal("Error occured while getting '{0}' property from data row: ", ex);
                        throw new Exception(String.Format("Error occured while getting '{0}' property from data row.", fieldInfo.FieldName), ex);
                    }
                }
                else
                {
                    param[i] = new DbParameter("@" + fieldInfo.FieldName, entity.Id);
                    i++;
                }

            }
            DbParameter[] param2 = new DbParameter[i];
            for (int j = 0; j < i; j++)
            {
                param2[j] = new DbParameter(param[j].ParameterName, param[j].Value);
                log.Info(param[j].ParameterName + ":" + param[j].Value);
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append(" WHERE id=@id");

            return (db.Update(sb.ToString(), param2, CommandType.Text) > 0) ? entity : null;
        }

        /// <summary>
        /// Update base <see cref="EntityType"/> to database
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="p"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public virtual int Update(string sql, EntityType entity)
        {
            int returnValue = 0;
            Db db = new Db();
            DbParameter[] param = new DbParameter[EntityFieldInfoCache<EntityType>.GetEntityFieldInfos().Count];

            int i = 0;
            // build insert query and parameter
            foreach (EntityFieldInfo fieldInfo in EntityFieldInfoCache<EntityType>.GetEntityFieldInfos())
            {
                if (fieldInfo.FieldAccessMode == FieldAccessMode.ReadWrite)
                {
                    try
                    {
                        // retrive entity value
                        object value = EntityReflector<EntityType>.GetValueFromField(entity, fieldInfo);
                        // add data parameter
                        if (value != null)
                        {
                            if (fieldInfo.FieldType == FieldType.DateTime && Convert.ToDateTime(value).ToString("dd/MM/yyyy") == "01/01/0001")
                                continue;

                            param[i] = new DbParameter("@" + fieldInfo.FieldName, value);
                            i++;
                        }

                    }
                    catch (Exception ex)
                    {
                        throw new Exception(String.Format("Error occured while getting '{0}' property from data row.", fieldInfo.FieldName), ex);
                    }
                }
                else
                {
                    param[i] = new DbParameter("@" + fieldInfo.FieldName, entity.Id);
                    i++;
                }

            }
            DbParameter[] param2 = new DbParameter[i];
            for (int j = 0; j < i; j++)
            { param2[j] = new DbParameter(param[j].ParameterName, param[j].Value); }
            try
            {
                returnValue = db.Update(sql, param2, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                log.Fatal("Update entity has an exception: ", ex);
            }
            return returnValue;
        }

        /// <summary>
        /// Delete base <see cref="EntityType"/> specified by entity id
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns></returns>
        public virtual int Delete(int id)
        {
            EntityType entity = EntityReflector<EntityType>.CreateInstance();
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM ").Append(entity.TableName).Append(" WHERE id=@id");
            Db db = new Db();
            int ret = db.Delete(sb.ToString(), new DbParameter("@id", id), CommandType.Text);
            return ret;
        }

        public virtual int Delete(string sql, DbParameter[] p, CommandType commandType)
        {
            int returnValue = 0;
            Db db = new Db();
            try
            {
                returnValue = db.Delete(sql, p, commandType);
            }
            catch (Exception ex)
            {
                log.Fatal("Delete entity has an exception: ", ex);
            }
            return returnValue;
        }
        /// <summary>
        /// Find object <see cref="EntityType"/> specified by id
        /// </summary>
        /// <param name="id">Entity Id</param>
        /// <returns>A object of <see cref="EntityType"/> when success, <b>null</b> when error or not found </returns>
        public virtual EntityType FindByKey(int id)
        {
            EntityType entity = EntityReflector<EntityType>.CreateInstance();
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * FROM ").Append(entity.TableName).Append(" WHERE id=@id");
                Db db = new Db();
                DataRow row = db.GetDataRow(sb.ToString(), new DbParameter("@id", id), CommandType.Text);
                if (row != null)
                    entity = mapper.MapItem(row);
            }
            catch (Exception ex)
            {
                log.Fatal("Find entity has an exception: ", ex);
                return null;
            }
            return entity;
        }

        public virtual IList<EntityType> FindAll()
        {
            EntityType entity1 = EntityReflector<EntityType>.CreateInstance();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM ").Append(entity1.TableName);
            Db db = new Db();
            DataTable dt = db.GetDataTable(sb.ToString(), CommandType.Text);

            List<EntityType> list = new List<EntityType>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    EntityType entity = EntityReflector<EntityType>.CreateInstance();
                    entity = mapper.MapItem(row);
                    list.Add(entity);
                }
            }
            return list;
        }
        /// <summary>
        /// Find EntityType
        /// </summary>
        /// <param name="sql">string query</param>
        /// <param name="p">parameter</param>
        /// <param name="commandType">command type</param>
        /// <returns></returns>
        public virtual EntityType FindEntity(string sql, DbParameter[] p, CommandType commandType)
        {
            Db db = new Db();
            EntityType entity = EntityReflector<EntityType>.CreateInstance();
            try
            {
                DataRow row = db.GetDataRow(sql, p, commandType);
                if (row != null)
                    entity = mapper.MapItem(row);
            }
            catch (Exception ex)
            {
                log.Fatal("Find entity has an exception: ", ex);
                return null;
            }
            return entity;
        }
        /// <summary>
        /// Find list EntityType
        /// </summary>
        /// <param name="sql">string query</param>
        /// <param name="p">parameter</param>
        /// <param name="commandType">command type</param>
        /// <returns></returns>
        public virtual IList<EntityType> FindList(string sql, DbParameter[] p, CommandType commandType)
        {
            Db db = new Db();
            DataTable dt = db.GetDataTable(sql, p, commandType);

            List<EntityType> list = new List<EntityType>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    EntityType entity = EntityReflector<EntityType>.CreateInstance();
                    entity = mapper.MapItem(row);
                    list.Add(entity);
                }
            }
            return list;
        }

        /// <summary>
        /// Find list EntityType
        /// </summary>
        /// <param name="sql">string query</param>
        /// <param name="commandType">command type</param>
        /// <returns></returns>
        public virtual IList<EntityType> FindList(string sql, CommandType commandType)
        {
            Db db = new Db();
            DataTable dt = db.GetDataTable(sql, commandType);

            List<EntityType> list = new List<EntityType>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    EntityType entity = EntityReflector<EntityType>.CreateInstance();
                    entity = mapper.MapItem(row);
                    list.Add(entity);
                }
            }
            return list;
        }

        #endregion
    }
}
