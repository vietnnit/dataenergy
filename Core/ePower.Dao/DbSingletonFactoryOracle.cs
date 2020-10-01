using System;
using System.Data;
using System.Data.OracleClient;
using System.Configuration;

namespace ePower.Dao
{
	/// <summary>
	/// A factory for Oracle data base items
	/// </summary>
	public sealed class DbSingletonFactoryOracle : IDbFactory
	{

		// Singleton design pattern

		private static readonly DbSingletonFactoryOracle instance = new DbSingletonFactoryOracle();

		private DbSingletonFactoryOracle()
		{
			// Private contructor
		}

		public static DbSingletonFactoryOracle Instance
		{
			get 
			{
				return instance; 
			}
		}

		// Create Oracle specific ADO.NET objects

		public IDbConnection CreateConnection()
		{
			return new OracleConnection();
		}

		public IDbCommand CreateCommand()
		{
			return new OracleCommand();
		}

        public IDbDataParameter CreateParameter()
        {
            return new OracleParameter();
        }

		public IDataReader CreateDataReader(IDbCommand command)
		{
			return (command as OracleCommand).ExecuteReader();
		}

		public IDbDataAdapter CreateDataAdapter()
		{
			return new OracleDataAdapter();
		}
	}
}
