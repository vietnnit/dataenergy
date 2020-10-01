using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;

namespace DAO
{
    public class BaseDAO
    {
        public BaseDAO()
        {
            //Constructor
        }
        #region GetConnection
        public SqlConnection GetConnection()
        {
            SqlConnection sqlConnection = new SqlConnection();
            string sConnection = "";

            string sStrServer = WebConfigurationManager.ConnectionStrings["ServerName"].ConnectionString;
            string sStrDatabase = WebConfigurationManager.ConnectionStrings["DatabaseName"].ConnectionString;
            string sStrUser = WebConfigurationManager.ConnectionStrings["UserID"].ConnectionString;
            string sStrPass = WebConfigurationManager.ConnectionStrings["Password"].ConnectionString;

            sConnection += "Data Source=" + sStrServer + ";";
            sConnection += " Initial Catalog=" + sStrDatabase + ";" ;
            sConnection += " User=" + sStrUser + ";" ;
            sConnection += " Password=" + sStrPass + ";";

            sqlConnection.ConnectionString = sConnection;
            return sqlConnection;

        }
 

     
        //public SqlConnection GetConnection2()
        //{
        //    SqlConnection sqlConnection = new SqlConnection();
        //    string sConnection = "";

        //    string sStrServer = WebConfigurationManager.ConnectionStrings["ServerName2"].ConnectionString;
        //    string sStrDatabase = WebConfigurationManager.ConnectionStrings["DatabaseName2"].ConnectionString;
        //    string sStrUser = WebConfigurationManager.ConnectionStrings["UserID2"].ConnectionString;
        //    string sStrPass = WebConfigurationManager.ConnectionStrings["Password2"].ConnectionString;

        //    sConnection += "Data Source=" + sStrServer + ";";
        //    sConnection += " Initial Catalog=" + sStrDatabase + ";";
        //    sConnection += " User=" + sStrUser + ";";
        //    sConnection += " Password=" + sStrPass + ";";

        //    sqlConnection.ConnectionString = sConnection;
        //    return sqlConnection;

        //}
        //#endregion

        //#region GetConnection3
        //public SqlConnection GetConnection3()
        //{
        //    SqlConnection sqlConnection = new SqlConnection();
        //    string sConnection = "";

        //    string sStrServer = WebConfigurationManager.ConnectionStrings["ServerName3"].ConnectionString;
        //    string sStrDatabase = WebConfigurationManager.ConnectionStrings["DatabaseName3"].ConnectionString;
        //    string sStrUser = WebConfigurationManager.ConnectionStrings["UserID3"].ConnectionString;
        //    string sStrPass = WebConfigurationManager.ConnectionStrings["Password3"].ConnectionString;

        //    sConnection += "Data Source=" + sStrServer + ";";
        //    sConnection += " Initial Catalog=" + sStrDatabase + ";";
        //    sConnection += " User=" + sStrUser + ";";
        //    sConnection += " Password=" + sStrPass + ";";

        //    sqlConnection.ConnectionString = sConnection;
        //    return sqlConnection;

        //}
        //#endregion

        //#region GetConnection4
        //public SqlConnection GetConnection4()
        //{
        //    SqlConnection sqlConnection = new SqlConnection();
        //    string sConnection = "";

        //    string sStrServer = WebConfigurationManager.ConnectionStrings["ServerName4"].ConnectionString;
        //    string sStrDatabase = WebConfigurationManager.ConnectionStrings["DatabaseName4"].ConnectionString;
        //    string sStrUser = WebConfigurationManager.ConnectionStrings["UserID4"].ConnectionString;
        //    string sStrPass = WebConfigurationManager.ConnectionStrings["Password4"].ConnectionString;

        //    sConnection += "Data Source=" + sStrServer + ";";
        //    sConnection += " Initial Catalog=" + sStrDatabase + ";";
        //    sConnection += " User=" + sStrUser + ";";
        //    sConnection += " Password=" + sStrPass + ";";

        //    sqlConnection.ConnectionString = sConnection;
        //    return sqlConnection;

        //}
        #endregion
       
    }
}