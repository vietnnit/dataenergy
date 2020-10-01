using System;
using System.Data;
using System.Data.Odbc;
using System.Configuration;

namespace ePower.Dao
{
	/// <summary>
	/// DbSingletonFactoryOdbc
	/// </summary>
	public sealed class DbSingletonFactoryOdbc : IDbFactory
	{
		// Singleton design pattern

		private static readonly DbSingletonFactoryOdbc instance = new DbSingletonFactoryOdbc();

		private DbSingletonFactoryOdbc()
		{
			// Private contructor
		}

		public static DbSingletonFactoryOdbc Instance
		{
			get 
			{
				return instance; 
			}
		}

		// Create ODBC specific ADO.NET objects

		public IDbConnection CreateConnection()
		{
			return new OdbcConnection();
		}

		public IDbCommand CreateCommand()
		{
			return new OdbcCommand();
		}
        public IDbDataParameter CreateParameter()
        {
            return new OdbcParameter();
        }

		public IDataReader CreateDataReader(IDbCommand command)
		{
			return (command as OdbcCommand).ExecuteReader();
		}

		public IDbDataAdapter CreateDataAdapter()
		{
			return new OdbcDataAdapter();
		}
	}
}
