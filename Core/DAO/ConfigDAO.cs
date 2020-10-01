using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;

namespace DAO
{
    public class ConfigDAO:BaseDAO
    {
        public ConfigDAO() 
        {
            //constructor
        }

        #region ConfigReader
        private Config ConfigReader(SqlDataReader reader) 
        {
            Config config = new Config();
            config.Titleweb = (string)reader["titleweb"];
            config.Google = (string)reader["google"];
            config.Introduction = (string)reader["introduction"];
            config.Infocompany = (string)reader["infocompany"];

            config.New_icon_w = (string)reader["new_icon_w"];
            config.New_icon_h = (string)reader["new_icon_h"];
            config.New_thumb_w = (string)reader["new_thumb_w"];
            config.New_thumb_h = (string)reader["new_thumb_h"];
            config.New_large_w = (string)reader["new_large_w"];
            config.New_large_h = (string)reader["new_large_h"];

            config.Product_icon_w = (string)reader["product_icon_w"];
            config.Product_icon_h = (string)reader["product_icon_h"];
            config.Product_thumb_w = (string)reader["product_thumb_w"];
            config.Product_thumb_h = (string)reader["product_thumb_h"];
            config.Product_large_w = (string)reader["product_large_w"];
            config.Product_large_h = (string)reader["product_large_h"];

            config.ProductNo = (string)reader["productNo"];
            config.ProductNoPage = (string)reader["productNoPage"];

            config.Currency = (string)reader["currency"];
            config.Status = (bool)reader["status"];
            config.Closecomment = (string)reader["closecomment"];
            config.Language = (string)reader["language"];

            config.Support = (string)reader["support"];
            config.Contact = (string)reader["contact"];
            config.Intro_desc = (string)reader["intro_desc"];
            config.Email_from = (string)reader["email_from"];
            config.Email_to = (string)reader["email_to"];
            config.Counter = (string)reader["counter"];
            config.Info1 = (string)reader["info1"];
            config.Info2 = (string)reader["info2"];

            config.WebName = (string)reader["WebName"];
            config.WebServerIP = (string)reader["WebServerIP"];
            config.WebMailServer = (string)reader["WebMailServer"];
            config.WebDomain = (string)reader["WebDomain"];

            config.IsPopup = (bool)reader["IsPopup"];
            config.Popup = (string)reader["Popup"];
            config.Popup2 = (string)reader["Popup2"];

            return config;
        }
        #endregion

        #region GetAllConfig
        public Config GetAllConfig(string language) 
        {
            Config config = null;
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_ConfigGetAll", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Language",language);
                connection.Open();
                using(SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                  while(reader.Read())
                  {
                    config = ConfigReader(reader);
                  }
                  command.Dispose();
                }
               return config;
            } 
            
        }
        #endregion

        #region UpdateConfig
        public void UpdateConfig(Config config) 
        {
            using(SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("_ConfigUpdate",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Titleweb",config.Titleweb);
                command.Parameters.AddWithValue("@Google", config.Google);
                command.Parameters.AddWithValue("@Introduction", config.Introduction);
                command.Parameters.AddWithValue("@Infocompany", config.Infocompany);
                command.Parameters.AddWithValue("@New_icon_w", config.New_icon_w);
                command.Parameters.AddWithValue("@New_icon_h", config.New_icon_h);
                command.Parameters.AddWithValue("@New_thumb_w", config.New_thumb_w);
                command.Parameters.AddWithValue("@New_thumb_h", config.New_thumb_h);
                command.Parameters.AddWithValue("@New_large_w", config.New_large_w);
                command.Parameters.AddWithValue("@New_large_h", config.New_large_h);
                command.Parameters.AddWithValue("@Product_icon_w", config.Product_icon_w);
                command.Parameters.AddWithValue("@Product_icon_h", config.Product_icon_h);
                command.Parameters.AddWithValue("@Product_thumb_w", config.Product_thumb_w);
                command.Parameters.AddWithValue("@Product_thumb_h", config.Product_thumb_h);
                command.Parameters.AddWithValue("@Product_large_w", config.Product_large_w);
                command.Parameters.AddWithValue("@Product_large_h", config.Product_large_h);
                command.Parameters.AddWithValue("@ProductNo", config.ProductNo);
                command.Parameters.AddWithValue("@ProductNoPage", config.ProductNoPage);
                command.Parameters.AddWithValue("@Currency", config.Currency);
                command.Parameters.AddWithValue("@Status", config.Status);
                command.Parameters.AddWithValue("@Closecomment", config.Closecomment);
                command.Parameters.AddWithValue("@Language", config.Language);
                command.Parameters.AddWithValue("@Support", config.Support);
                command.Parameters.AddWithValue("@Contact", config.Contact);
                command.Parameters.AddWithValue("@Intro_desc", config.Intro_desc);
                command.Parameters.AddWithValue("@email_from", config.Email_from);
                command.Parameters.AddWithValue("@email_to", config.Email_to);
                command.Parameters.AddWithValue("@counter", config.Counter);
                command.Parameters.AddWithValue("@info1", config.Info1);
                command.Parameters.AddWithValue("@info2", config.Info2);

                command.Parameters.AddWithValue("@WebName", config.WebName);
                command.Parameters.AddWithValue("@WebServerIP", config.WebServerIP);
                command.Parameters.AddWithValue("@WebMailServer", config.WebMailServer);
                command.Parameters.AddWithValue("@WebDomain", config.WebDomain);

                command.Parameters.AddWithValue("@IsPopup", config.IsPopup);
                command.Parameters.AddWithValue("@Popup", config.Popup);
                command.Parameters.AddWithValue("@Popup2", config.Popup2);



                connection.Open();
                if(command.ExecuteNonQuery() <= 0)
                    throw new DataAccessException("Loi cap nhat config");
                else
                command.Dispose();

            }
        }
        #endregion


    }
}
