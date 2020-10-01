using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ePower.Dao
{
    /// <summary>
    /// A factory for MySql data base items
    /// </summary>
    public sealed class DbSingletonFactoryMySql : IDbFactory
    {
        // Singleton design pattern
        private static readonly DbSingletonFactoryMySql instance = new DbSingletonFactoryMySql();

        private DbSingletonFactoryMySql()
        {
            // Empty: Private contructor
        }

        public static DbSingletonFactoryMySql Instance
        {
            get
            {
                return instance;
            }
        }

        // Create MySql Server ADO.NET objects
        public IDbConnection CreateConnection()
        {
            return new MySqlConnection();
        }

        public IDbCommand CreateCommand()
        {
            return new MySqlCommand();
        }
        
		public IDbDataParameter CreateParameter()
        {
            return new MySqlParameter();
        }
        
		public IDataReader CreateDataReader(IDbCommand command)
        {
            return (command as MySqlCommand).ExecuteReader();
        }
		
		public IDbDataAdapter CreateDataAdapter()
        {
            return new MySqlDataAdapter();
        }
		
    }
}
