using System;
using System.Data;
using System.Data.SqlClient;

namespace ePower.Dao
{
    /// <summary>
    /// A factory for Sql Server data base items
    /// </summary>
    public sealed class DbSingletonFactorySqlClient : IDbFactory
    {
        // Singleton design pattern

        private static readonly DbSingletonFactorySqlClient instance = new DbSingletonFactorySqlClient();

        private DbSingletonFactorySqlClient()
        {
            // Empty: Private contructor
        }

        public static DbSingletonFactorySqlClient Instance
        {
            get
            {
                return instance;
            }
        }

        // Create Sql Server specific ADO.NET objects

        public IDbConnection CreateConnection()
        {
            return new SqlConnection();
        }

        public IDbCommand CreateCommand()
        {
            return new SqlCommand();
        }

        public IDbDataParameter CreateParameter()
        {
            return new SqlParameter();
        }

        public IDataReader CreateDataReader(IDbCommand command)
        {
            return (command as SqlCommand).ExecuteReader();
        }

        public IDbDataAdapter CreateDataAdapter()
        {
            return new SqlDataAdapter();
        }

    }
}
