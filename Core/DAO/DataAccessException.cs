using System;

namespace DAO
{
    public class DataAccessException : Exception
    {
        public DataAccessException(string message)
            : base(message)
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
