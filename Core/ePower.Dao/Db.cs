using System;
using System.Data;
using System.Configuration;
using System.Web;
using log4net;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;

namespace ePower.Dao
{
    /// <summary>
    /// Db - db access class
    /// </summary>
    public class Db
    {
        public static string connectionString;
        private static readonly IDbFactory factory;
        private static readonly ILog log = LogManager.GetLogger(typeof(Db));

        //httpCo
        #region Constructor
        /// <summary>
        /// Static constructor
        /// Could be done more generically, but this explains it well
        /// </summary>
        static Db()
        {
            //string provider = ConfigurationSettings.AppSettings.Get("Provider");
            string provider = "SqlClient";
            switch (provider)
            {
                case "SqlClient":
                    {
                        connectionString = ConfigurationSettings.AppSettings["ConnectString"];

                        factory = DbFactories.GetFactory(DbFactoryType.SqlClient);
                        break;
                    }
                case "OleDb":
                    {
                        connectionString = ConfigurationSettings.AppSettings.Get("OleDbConnectionString");
                        factory = DbFactories.GetFactory(DbFactoryType.OleDb);
                        break;
                    }
                case "Oracle":
                    {
                        connectionString = ConfigurationSettings.AppSettings.Get("OracleConnectionString");
                        factory = DbFactories.GetFactory(DbFactoryType.Oracle);
                        break;
                    }
                case "MySql":
                    {
                        connectionString = ConfigurationSettings.AppSettings.Get("MySqlConnectionString");
                        factory = DbFactories.GetFactory(DbFactoryType.MySql);
                        break;
                    }
                case "Odbc":
                default:
                    {
                        connectionString = ConfigurationSettings.AppSettings.Get("OdbcConnectionString");
                        factory = DbFactories.GetFactory(DbFactoryType.Odbc);
                        break;
                    }
            }
        }

        #endregion

        #region Handling INSERT, UPDATE, DELETE

        // Use for sql updates
        public int Update(string sql, CommandType commandType)
        {
            IDbConnection connection = factory.CreateConnection();
            try
            {
                connection.ConnectionString = connectionString;
                IDbCommand command = factory.CreateCommand();
                command.Connection = connection;
                command.CommandType = commandType;
                command.CommandText = sql;

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                log.Fatal(ex);
                return 0;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        // Use for sql updates with parameter
        public int Update(string sql, DbParameter p, CommandType commandType)
        {
            IDbConnection connection = factory.CreateConnection();
            try
            {
                connection.ConnectionString = connectionString;
                IDbCommand command = factory.CreateCommand();
                command.Connection = connection;
                command.CommandType = commandType;
                command.CommandText = sql;

                IDataParameter param = factory.CreateParameter();
                param.ParameterName = p.ParameterName;
                param.Value = p.Value;
                command.Parameters.Add(param);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                log.Fatal(ex);
                return 0;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        // Use for sql updates with parameter
        public int Delete(string sql, DbParameter p, CommandType commandType)
        {
            IDbConnection connection = factory.CreateConnection();
            try
            {
                connection.ConnectionString = connectionString;
                IDbCommand command = factory.CreateCommand();
                command.Connection = connection;
                command.CommandType = commandType;
                command.CommandText = sql;

                IDataParameter param = factory.CreateParameter();
                param.ParameterName = p.ParameterName;
                param.Value = p.Value;

                command.Parameters.Add(param);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                log.Fatal(ex);
                return 0;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        // Use for sql updates with parameter
        public int Delete(string sql, DbParameter[] p, CommandType commandType)
        {
            IDbConnection connection = factory.CreateConnection();
            try
            {
                connection.ConnectionString = connectionString;
                IDbCommand command = factory.CreateCommand();
                command.Connection = connection;
                command.CommandType = commandType;
                command.CommandText = sql;

                for (int i = 0; i < p.Length; i++)
                {
                    IDataParameter param = factory.CreateParameter();
                    if (p[i].NText)
                    {
                        param.ParameterName = p[i].ParameterName;
                        param.Value = p[i].Value;
                        param.DbType = DbType.String;
                        command.Parameters.Add(param);
                    }
                    else
                    {
                        param.ParameterName = p[i].ParameterName;
                        param.Value = p[i].Value;
                        command.Parameters.Add(param);
                    }
                }

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                log.Fatal(ex);
                return 0;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        // Use for sql updates with list parameter
        public int Update(string sql, DbParameter[] p, CommandType commandType)
        {
            IDbConnection connection = factory.CreateConnection();
            try
            {
                connection.ConnectionString = connectionString;
                IDbCommand command = factory.CreateCommand();
                command.Connection = connection;
                command.CommandType = commandType;
                command.CommandText = sql;

                for (int i = 0; i < p.Length; i++)
                {
                    IDataParameter param = factory.CreateParameter();
                    if (p[i].NText)
                    {
                        param.ParameterName = p[i].ParameterName;
                        param.Value = p[i].Value;
                        param.DbType = DbType.String;
                        command.Parameters.Add(param);
                    }
                    else
                    {
                        param.ParameterName = p[i].ParameterName;
                        param.Value = p[i].Value;
                        command.Parameters.Add(param);
                    }
                }

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                log.Fatal(ex);
                return 0;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        // Use for sql inserts where no identity is required
        public void Insert(string sql, CommandType commandType)
        {
            Insert(sql, false, commandType);
        }

        // Use for sql inserts where new identity is required
        public int Insert(string sql, bool getId, CommandType commandType)
        {
            IDbConnection connection = factory.CreateConnection();
            try
            {
                int id = -1;
                connection.ConnectionString = connectionString;

                IDbCommand command = factory.CreateCommand();
                command.Connection = connection;
                command.CommandType = commandType;
                command.CommandText = sql;

                connection.Open();
                //command.ExecuteNonQuery();
                if (getId)
                {
                    // This is different depending on database
                    //command.CommandText = "SELECT SCOPE_IDENTITY() ";
                    // SELECT @@IDENTITY -- for MS ACCESS
                    // SELECT xyz.NEXTVAL FROM DUAL -- for ORACLE
                    id = int.Parse(command.ExecuteScalar().ToString());
                }
                else
                {
                    command.ExecuteNonQuery();
                }
                return id;
            }
            catch (Exception ex)
            {
                log.Fatal(ex);
                return 0;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        // Use for sql inserts with parameter where new identity is required
        public int Insert(string sql, bool getId, DbParameter p, CommandType commandType)
        {
            IDbConnection connection = factory.CreateConnection();
            try
            {
                int id = -1;
                connection.ConnectionString = connectionString;

                IDbCommand command = factory.CreateCommand();
                command.Connection = connection;
                command.CommandType = commandType;

                command.CommandText = sql;

                IDataParameter param = factory.CreateParameter();
                param.ParameterName = p.ParameterName;
                param.Value = p.Value;

                command.Parameters.Add(param);

                connection.Open();
                //command.ExecuteNonQuery();
                if (getId)
                {
                    IDataParameter output = factory.CreateParameter();
                    output.ParameterName = "@Id";
                    output.Value = 0;
                    output.Direction = ParameterDirection.Output;
                    // This is different depending on database
                    //	command.CommandText = "SELECT SCOPE_IDENTITY() ";
                    // SELECT @@IDENTITY -- for MS ACCESS
                    // SELECT xyz.NEXTVAL FROM DUAL -- for ORACLE

                    ///insert record and output key 
                    //id = long.Parse(command.ExecuteScalar().ToString());
                    command.ExecuteNonQuery();
                    id = Convert.ToInt32(output.Value);

                }
                else
                    id = command.ExecuteNonQuery();
                return id;
            }
            catch (Exception ex)
            {
                log.Fatal(ex);
                return 0;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        // Use for sql inserts with parameter list  where new identity is required
        public int Insert(string sql, bool getId, DbParameter[] p, CommandType commandType)
        {
            IDbConnection connection = factory.CreateConnection();
            try
            {
                int id = -1;
                connection.ConnectionString = connectionString;

                IDbCommand command = factory.CreateCommand();
                command.Connection = connection;
                command.CommandType = commandType;

                command.CommandText = sql;

                for (int i = 0; i < p.Length; i++)
                {
                    IDataParameter param = factory.CreateParameter();
                    if (p[i].NText)
                    {
                        param.ParameterName = p[i].ParameterName;
                        param.Value = p[i].Value;
                        param.DbType = DbType.String;
                        command.Parameters.Add(param);
                    }
                    else
                    {
                        param.ParameterName = p[i].ParameterName;
                        param.Value = p[i].Value;
                        command.Parameters.Add(param);
                    }
                }
                connection.Open();
                //command.ExecuteNonQuery();
                if (getId)
                {
                    IDataParameter output = factory.CreateParameter();
                    output.ParameterName = "@Id";
                    output.Value = 0;
                    output.Direction = ParameterDirection.Output;
                    command.Parameters.Add(output);
                    // This is different depending on database
                    command.CommandText = command.CommandText + " SELECT @Id =SCOPE_IDENTITY() ";
                    // SELECT @@IDENTITY -- for MS ACCESS
                    // SELECT xyz.NEXTVAL FROM DUAL -- for ORACLE

                    ///insert record and output key 
                    //id = long.Parse(command.ExecuteScalar().ToString());
                    command.ExecuteNonQuery();
                    id = Convert.ToInt32(output.Value);
                }
                else
                    id = command.ExecuteNonQuery();

                return id;
            }
            catch (Exception ex)
            {
                log.Fatal(ex);
                return 0;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        #endregion

        #region Get List Object
        /// <summary>
        /// Get List object from command
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        public List<T> GetList<T>(IDbCommand command)
        {

            IDbConnection connection = factory.CreateConnection();
            try
            {
                connection.ConnectionString = connectionString;
                command.Connection = connection;
                connection.Open();
                IDataReader dr = command.ExecuteReader();
                if (dr == null || dr.FieldCount == 0)
                    return null;
                int fCount = dr.FieldCount;
                Type m_Type = typeof(T);
                PropertyInfo[] l_Property = m_Type.GetProperties();
                object obj;
                List<T> m_List = new List<T>();
                string pName;
                while (dr.Read())
                {
                    obj = Activator.CreateInstance(m_Type);
                    for (int i = 0; i < fCount; i++)
                    {
                        pName = dr.GetName(i);
                        if (l_Property.Where(a => a.Name == pName).Select(a => a.Name).Count() > 0)
                        {
                            if (dr[i] != System.DBNull.Value)
                            {
                                m_Type.GetProperty(pName).SetValue(obj, dr[i], null);
                            }
                            else
                            {
                                m_Type.GetProperty(pName).SetValue(obj, null, null);
                            }
                        }
                    }
                    m_List.Add((T)obj);
                }
                dr.Close();
                return m_List;
            }
            catch (Exception ex)
            {
                log.Fatal(ex);
                return null;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        /// <summary>
        /// GetList object from database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strSQL"></param>
        /// <param name="pars"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public List<T> GetList<T>(string strSQL, DbParameter[] pars, CommandType commandType)
        {


            //IDbCommand command = factory.CreateCommand();
            //command.CommandText = strSQL;
            //command.CommandType = commandType;
            //try
            //{
            //    foreach (DbParameter par in pars)
            //    {
            //        IDataParameter param = factory.CreateParameter();
            //        param.ParameterName = par.ParameterName;
            //        param.Value = par.Value;
            //        //param.Direction = par.Direction;
            //        command.Parameters.Add(param);                    
            //    }
            //    return GetList<T>(command);
            //}
            //catch (Exception myException)
            //{
            //    throw (new Exception(myException.Message));
            //}
            Type m_Type = typeof(T);
            PropertyInfo[] l_Property = m_Type.GetProperties();
            object obj;
            List<T> m_List = new List<T>();
            DataTable dt = new Db().GetDataTable(strSQL, pars, commandType);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    obj = Activator.CreateInstance(m_Type);
                    for (int i = 0; i < l_Property.Count(); i++)
                    {
                        try
                        {
                            if (row[l_Property[i].Name] != System.DBNull.Value)
                                m_Type.GetProperty(l_Property[i].Name).SetValue(obj, row[l_Property[i].Name], null);
                            else
                            {
                                m_Type.GetProperty(l_Property[i].Name).SetValue(obj, null, null);
                            }
                        }
                        catch (Exception ex) { log.Fatal(ex); }
                    }
                    m_List.Add((T)obj);
                }
            }
            return m_List;

        }
        #endregion

        #region Handling SELECTs

        // Return a dataset based on sql select
        public DataSet GetDataSet(string sql, CommandType commandType)
        {
            try
            {
                IDbConnection connection = factory.CreateConnection();
                connection.ConnectionString = connectionString;

                IDbCommand command = factory.CreateCommand();
                command.CommandType = commandType;
                command.Connection = connection;
                command.CommandText = sql;

                IDbDataAdapter adapter = factory.CreateDataAdapter();
                adapter.SelectCommand = command;

                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                log.Fatal(ex);
                return null;
            }

        }
        public DataSet GetDataSet(string sql, CommandType commandType, string _connectString)
        {
            try
            {
                IDbConnection connection = factory.CreateConnection();
                connection.ConnectionString = _connectString;

                IDbCommand command = factory.CreateCommand();
                command.CommandType = commandType;
                command.Connection = connection;
                command.CommandText = sql;

                IDbDataAdapter adapter = factory.CreateDataAdapter();
                adapter.SelectCommand = command;

                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                log.Fatal(ex);
                return null;
            }

        }
        // Return a dataset based on sql select with data parameter
        public DataSet GetDataSet(string sql, DbParameter p, CommandType commandType)
        {
            try
            {
                IDbConnection connection = factory.CreateConnection();
                connection.ConnectionString = connectionString;

                IDbCommand command = factory.CreateCommand();
                command.CommandType = commandType;

                IDataParameter param = factory.CreateParameter();
                param.ParameterName = p.ParameterName;
                param.Value = p.Value;

                command.Parameters.Add(param);
                command.Connection = connection;
                command.CommandText = sql;

                IDbDataAdapter adapter = factory.CreateDataAdapter();
                adapter.SelectCommand = command;

                DataSet ds = new DataSet();
                adapter.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                log.Fatal(ex);
                return null;
            }
        }
        // Return a dataset based on sql select with list data parameter
        public DataSet GetDataSet(string sql, DbParameter[] p, CommandType commandType)
        {
            try
            {
                IDbConnection connection = factory.CreateConnection();
                connection.ConnectionString = connectionString;

                IDbCommand command = factory.CreateCommand();
                command.CommandType = commandType;
                for (int i = 0; i < p.Length; i++)
                {
                    IDataParameter param = factory.CreateParameter();
                    if (p[i].NText)
                    {
                        param.ParameterName = p[i].ParameterName;
                        param.Value = p[i].Value;
                        param.DbType = DbType.String;
                        command.Parameters.Add(param);
                    }
                    else
                    {
                        param.ParameterName = p[i].ParameterName;
                        param.Value = p[i].Value;
                        command.Parameters.Add(param);
                    }
                }
                command.Connection = connection;
                command.CommandText = sql;

                IDbDataAdapter adapter = factory.CreateDataAdapter();
                adapter.SelectCommand = command;

                DataSet ds = new DataSet();
                adapter.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                log.Fatal(ex);
                return null;
            }
        }
        // Return a datatable based on sql select


        // Return a dataset based on sql select with list data parameter
        public DataSet GetDataSet(string sql, DbParameter[] p, CommandType commandType, string _connectionString)
        {
            try
            {
                IDbConnection connection = factory.CreateConnection();
                connection.ConnectionString = _connectionString;

                IDbCommand command = factory.CreateCommand();
                command.CommandType = commandType;
                for (int i = 0; i < p.Length; i++)
                {
                    IDataParameter param = factory.CreateParameter();
                    if (p[i].NText)
                    {
                        param.ParameterName = p[i].ParameterName;
                        param.Value = p[i].Value;
                        param.DbType = DbType.String;
                        command.Parameters.Add(param);
                    }
                    else
                    {
                        param.ParameterName = p[i].ParameterName;
                        param.Value = p[i].Value;
                        command.Parameters.Add(param);
                    }
                }
                command.Connection = connection;
                command.CommandText = sql;

                IDbDataAdapter adapter = factory.CreateDataAdapter();
                adapter.SelectCommand = command;

                DataSet ds = new DataSet();
                adapter.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                log.Fatal(ex);
                return null;
            }
        }
        public DataTable GetDataTable(string sql, CommandType commandType)
        {
            return GetDataSet(sql, commandType).Tables[0];
        }
        // Return a datatable based on sql select
        public DataTable GetDataTable(string sql, CommandType commandType, string connectString)
        {
            DataSet ds = new DataSet();
            ds = GetDataSet(sql, commandType, connectString);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
            return null;

        }
        // Return a datatable based on sql select
        public DataTable GetDataTable(string sql, DbParameter p, CommandType commandType)
        {
            return GetDataSet(sql, p, commandType).Tables[0];
        }

        // Return a datatable based on sql select
        public DataTable GetDataTable(string sql, DbParameter[] p, CommandType commandType)
        {            
            DataSet dset=GetDataSet(sql, p, commandType);
            if (dset != null && dset.Tables.Count > 0)
                return dset.Tables[0];
            else return null;
        }
        public DataTable GetDataTable(string sql, DbParameter[] p, CommandType commandType, string connectString)
        {
            DataSet dt = GetDataSet(sql, p, commandType, connectString);
            if (dt.Tables.Count > 0)
            {
                return dt.Tables[0];
            }
            else
            {
                return null;
            }
        }
        // Return a datarow based on sql
        public DataRow GetDataRow(string sql, CommandType commandType)
        {
            DataTable dt = GetDataTable(sql, commandType);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            // when not found
            return null;
        }

        // Return a datarow based on sql with parameter
        public DataRow GetDataRow(string sql, DbParameter p, CommandType commandType)
        {
            DataTable dt = GetDataTable(sql, p, commandType);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            // when not found
            return null;
        }

        /// <summary>
        /// Get data row table
        /// </summary>
        /// <param name="sql">string query</param>
        /// <param name="p">list data parameter</param>
        /// <param name="commandType">command type</param>
        /// <returns>A object <see cref="DataRow"/> when success or null when not found</returns>
        public DataRow GetDataRow(string sql, DbParameter[] p, CommandType commandType)
        {
            DataTable dt = GetDataTable(sql, p, commandType);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            // when not found
            return null;
        }

        // Return a scalar value based on sql select
        public object GetScalar(string sql)
        {
            IDbConnection connection = factory.CreateConnection();
            try
            {
                connection.ConnectionString = connectionString;

                IDbCommand command = factory.CreateCommand();
                command.Connection = connection;
                command.CommandText = sql;

                connection.Open();
                object o = command.ExecuteScalar();
                return o;
            }
            catch (Exception ex)
            {
                log.Fatal(ex);
                return null;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        #endregion

        #region Utility methods

        // Quote and escape all characters in a string
        private string Escape(string s)
        {
            if (s == null || s == "")
                return "NULL";
            else
                return "'" + s.Trim().Replace("'", "''") + "'";
        }

        // Quote, escape all characters in a string.
        // Also trim at max length.
        private string Escape(string s, int maxLength)
        {
            if (s == null || s == "")
                return "NULL";
            else
            {
                s = s.Trim();
                if (s.Length > maxLength) s = s.Substring(0, maxLength - 1);
                return "'" + s.Trim().Replace("'", "''") + "'";
            }
        }

        #endregion
    }
}
