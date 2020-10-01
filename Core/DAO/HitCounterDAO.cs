using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
namespace DAO
{
    public class HitCounterDAO : BaseDAO
    {
        public HitCounterDAO() 
        {
            //contrustor
        }

        #region HitCounterReader
        private HitCounter HitCounterReader(SqlDataReader reader) 
        {
            HitCounter hitcounter = new HitCounter();
            hitcounter.SiteHitCounter = (long) reader["HitCounter"];
            return hitcounter;
        }
        #endregion

        #region UpdateHitCounter
        public void UpdateHitCounter(long hitcounter) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_HitCounter",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@HitCounter",hitcounter);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Khong cap nhat duoc hitcounter");
                else
                    command.Dispose();
            }
        }
        #endregion

        #region GetHitCounter
        public HitCounter GetHitCounter() 
        {
            HitCounter hitcounter = null;
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_HitCounterGet",connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                using(SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                        hitcounter = HitCounterReader(reader);
                    else
                        throw new DataAccessException("khong tim thay gia tri hitcoutter nao");
                    command.Dispose();
                }
            }
            return hitcounter;
        }
        #endregion
    }
}
