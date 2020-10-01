using System;
using System.Data;

namespace ePower.Dao
{
	/// <summary>
	/// IDbFactory - interface to vendor agnostic ADO.NET objects
	/// </summary>
	public interface IDbFactory
	{
		IDbConnection CreateConnection();
		IDbCommand CreateCommand();
        IDbDataParameter CreateParameter();
		IDataReader CreateDataReader(IDbCommand command);
		IDbDataAdapter CreateDataAdapter();
	}
}
