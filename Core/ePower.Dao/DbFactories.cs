using System;

namespace ePower.Dao
{
    /// <summary>
    /// DbFactories 
    /// </summary>
    public class DbFactories
    {
        // Return a singleton instance of a vendor specific db factory
        // Abstract factory design pattern.
        public static IDbFactory GetFactory(DbFactoryType factoryType)
        {
            switch (factoryType)
            {
                case DbFactoryType.SqlClient:
                    {
                        return DbSingletonFactorySqlClient.Instance;
                    }
                case DbFactoryType.Oracle:
                    {
                        return DbSingletonFactoryOracle.Instance;
                    }
                case DbFactoryType.Odbc:
                    {
                        return DbSingletonFactoryOdbc.Instance;
                    }
                case DbFactoryType.OleDb:
                    {
                        return DbSingletonFactoryOleDb.Instance;
                    }
                case DbFactoryType.MySql:
                    {
                        return DbSingletonFactoryMySql.Instance;
                    }
            }
            return null;
        }
    }
}
