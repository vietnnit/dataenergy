using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

namespace ePower.Dao
{
	/// <summary>
	/// A factory for OleDb data base items
	/// </summary>
	public sealed class DbSingletonFactoryOleDb : IDbFactory
	{
		// Singleton design pattern

		private static readonly DbSingletonFactoryOleDb instance = new DbSingletonFactoryOleDb();

		private DbSingletonFactoryOleDb()
		{
			// Private contructor
		}

		public static DbSingletonFactoryOleDb Instance
		{
			get 
			{
				return instance; 
			}
		}

		// Create Oledb specific ADO.NET objects

		public System.Data.IDbConnection CreateConnection()
		{
			return new OleDbConnection();
		}

		public System.Data.IDbCommand CreateCommand()
		{
			return new OleDbCommand();
		}

        public IDbDataParameter CreateParameter()
        {
            return new OleDbParameter();
        }

		public System.Data.IDataReader CreateDataReader(IDbCommand command)
		{
			return (command as OleDbCommand).ExecuteReader();
		}

		public System.Data.IDbDataAdapter CreateDataAdapter()
		{
			return new OleDbDataAdapter();
		}
	}
}
