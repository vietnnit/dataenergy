using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ETO;
using System.Web.Configuration;

namespace DAO
{
   public class LinhVucDAO
    {
       public DataTable LinhVucGetAllPaging(int PageSize, int CurrentPage)
       {
           DataTable datatable = new DataTable();
           using (SqlConnection connection = GetConnection())
           {
               SqlCommand command = new SqlCommand("_LinhVucGetAllPaging", connection);
               command.CommandType = CommandType.StoredProcedure;
               command.Parameters.AddWithValue("@CurrentPage", CurrentPage);
               command.Parameters.AddWithValue("@PageSize", PageSize);
               connection.Open();
               using (SqlDataAdapter adapter = new SqlDataAdapter(command))
               {
                   adapter.Fill(datatable);
                   command.Dispose();
               }
           }
           return datatable;
       }
       public DataTable LinhVucbylist(string lst)
       {
           DataTable datatable = new DataTable();
           using (SqlConnection connection = GetConnection())
           {
               using (SqlCommand cmd = new SqlCommand())
               {
                   cmd.CommandType = CommandType.Text;
                  cmd.CommandText="select * from tbLinhVuc where Id in("+lst+")";
                  cmd.Connection = connection;
                  connection.Open();
                  using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                  {
                      adapter.Fill(datatable);
                      cmd.Dispose();
                  }
               }
              
               
           }
           return datatable;
       }
       public DataTable LinhVucGetAll()
       {
           DataTable datatable = new DataTable();
           using (SqlConnection connection = GetConnection())
           {
               string sqltext = "select * from tbLinhVuc where IsStatus =1";
               SqlCommand command = new SqlCommand(sqltext, connection);
               command.CommandType = CommandType.Text;
               connection.Open();
               using (SqlDataAdapter adapter = new SqlDataAdapter(command))
               {
                   adapter.Fill(datatable);
                   command.Dispose();
               }
           }
           return datatable;
       }
       public SqlConnection GetConnection()
       {
           SqlConnection sqlConnection = new SqlConnection();
           string sConnection = "";

           string sStrServer = WebConfigurationManager.ConnectionStrings["ServerName"].ConnectionString;
           string sStrDatabase = WebConfigurationManager.ConnectionStrings["DatabaseName"].ConnectionString;
           string sStrUser = WebConfigurationManager.ConnectionStrings["UserID"].ConnectionString;
           string sStrPass = WebConfigurationManager.ConnectionStrings["Password"].ConnectionString;

           sConnection += "Data Source=" + sStrServer + ";";
           sConnection += " Initial Catalog=" + sStrDatabase + ";";
           sConnection += " User=" + sStrUser + ";";
           sConnection += " Password=" + sStrPass + ";";

           sqlConnection.ConnectionString = sConnection;
           return sqlConnection;

       }
    }
}
