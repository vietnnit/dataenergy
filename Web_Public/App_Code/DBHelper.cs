using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
/// <summary>
/// Summary description for DBHelper
/// </summary>
/// 
//------------------------------------------
//Lấy 1 DataTable bằng lệnh SQL - hàm getDataTable
//DataTable tblInfo = db.getDataTable("Select * From Account Where AccountName=@AccountName", new SqlParameter("@AccountName", AccountName));

//------------------------------------------
//Lấy 1 DataTable bằng lệnh SP  - hàm getDataTableSP
//DataTable tblInfo = db.getDataTableSP("GetMoney", new SqlParameter("@AccountName", AccountName.ToUpper()));

//------------------------------------------
//Lấy 1 giá trị  bằng lệnh SQL   -  hàm ExecuteScalar
//int result = (int)db.ExecuteScalar("Select AccountID From Account_Block Where AccountName=@AccountName", new SqlParameter("@AccountName", AccountName));

//------------------------------------------
//Lấy 1 giá trị  bằng lệnh SP   -  hàm ExecuteScalarSP
//int result =  (int)db.ExecuteScalarSP("InsertAccount", new SqlParameter("@AccountName", AccountName), new SqlParameter("@PassLevel2", PassLevel2), new SqlParameter("@QuestionID", QuestionID), new SqlParameter("@Answer", Answer));

//------------------------------------------
//Chạy lệnh SQL không cần giá trị trả về   -  hàm db.ExecuteNonQuery
//db.ExecuteNonQuery("UPDATE Account SET PassLevel2=@Passlvl2 WHERE AccountID=@AccountID", new SqlParameter("@AccountID", AccountID), new SqlParameter("@PassLvl2", PassLvl2));

//------------------------------------------

    public class DBHelper
    {
        private string _cnnString = "";
        public string cnnString
        {
            get
            {
                return _cnnString;
            }
            set
            {
                _cnnString = value;
            }
        }
        public string FixCNN(string connStr, bool Pooling)
        {
            string[] aconnStr = connStr.Split(';');
            string sTemp = "";

            for (int i = 0; i < aconnStr.Length; i++)
            {
                if (
                    !aconnStr[i].ToLower().StartsWith("pooling=")
                    && !aconnStr[i].ToLower().StartsWith("min pool size=")
                    && !aconnStr[i].ToLower().StartsWith("max pool size=")
                    && !aconnStr[i].ToLower().StartsWith("connect timeout=")
                    && !aconnStr[i].Equals("")
                    )
                {
                    sTemp += aconnStr[i] + ";";
                }
            }

            if (Pooling)
            {
                sTemp += "Pooling=true;Min Pool Size=1;Max Pool Size=15;Connect Timeout=2;Connection Reset = True;Connection Lifetime = 600;";
            }
            else
            {
                sTemp += "Pooling=false;Connect Timeout=45;";
            }
            return sTemp;

        }

        public DBHelper()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DBHelper(string connStr)
        {
            _cnnString = connStr;
        }
        private SqlConnection _ConnectionToDB = null;
        public SqlConnection ConnectionToDB
        {
            get { return _ConnectionToDB; }
            set { _ConnectionToDB = value; }
        }
        public void Open()
        {
            if (_cnnString == "")
            {
                throw new Exception("Connection String can not null");
            }
            //_ConnectionToDB = OpenConnection();
        }
        public void Close()
        {
            CloseConnection(_ConnectionToDB);
        }
        /// <summary>
        /// return an Open SqlConnection
        /// </summary>

        public SqlConnection OpenConnection(string connectionString)
        {
            try
            {
                _cnnString = connectionString;
                return OpenConnection();
            }
            catch (SqlException myException)
            {
                throw (new Exception(myException.Message));
            }
        }
        /// <summary>
        /// return an Open SqlConnection
        /// </summary>
        public SqlConnection OpenConnection()
        {
            if (_cnnString == "")
            {
                throw new Exception("Connection String can not null");
            }
            SqlConnection mySqlConnection;

            try
            {
                mySqlConnection = new SqlConnection(FixCNN(_cnnString, true));
                mySqlConnection.Open();
                return mySqlConnection;
            }
            catch (Exception)
            {
                // De phong truong hop bi max pool thi se fix lai connection string pooling=false
                mySqlConnection = new SqlConnection(FixCNN(_cnnString, false));
                mySqlConnection.Open();
                return mySqlConnection;
                // throw (new Exception(myException.Message));
            }


        }

        /// <summary>
        /// close an SqlConnection
        /// </summary>
        public void CloseConnection(SqlConnection mySqlConnection)
        {
            try
            {
                if (mySqlConnection != null)
                {
                    if (mySqlConnection.State == ConnectionState.Open)
                    {
                        mySqlConnection.Close();
                    }
                }
            }
            catch (SqlException myException)
            {
                throw (new Exception(myException.Message));
            }
        }
        # region Get DataTable
        public DataTable getDataTable(SqlCommand sqlCommand)
        {
            SqlConnection conn = null;
            try
            {

                if (_ConnectionToDB == null)
                {
                    conn = OpenConnection();
                    sqlCommand.Connection = conn;
                }
                else
                {
                    sqlCommand.Connection = _ConnectionToDB;
                }
                SqlDataAdapter myDataAdapter = new SqlDataAdapter(sqlCommand);
                DataSet myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet);
                return myDataSet.Tables[0];
            }
            catch (SqlException myException)
            {
                throw (new Exception(myException.Message));
            }
            finally
            {
                if (conn != null)
                {
                    CloseConnection(conn);
                }
            }
        }
        public DataTable getDataTable(SqlCommand sqlCommand, params SqlParameter[] Parameters)
        {
            try
            {
                foreach (SqlParameter par in Parameters)
                {
                    sqlCommand.Parameters.Add(par);
                }
                return getDataTable(sqlCommand);
            }
            catch (Exception myException)
            {
                throw (new Exception(myException.Message));
            }
        }
        public DataTable getDataTable(string strSQL)
        {
            SqlCommand sqlCommand = new SqlCommand(strSQL);
            return getDataTable(sqlCommand);
        }
        public DataTable getDataTable(string strSQL, params SqlParameter[] Parameters)
        {
            SqlCommand sqlCommand = new SqlCommand(strSQL);
            return getDataTable(sqlCommand, Parameters);
        }
        #endregion
        # region ExecuteScalar
        public object ExecuteScalar(SqlCommand sqlCommand)
        {
            SqlConnection conn = null;
            try
            {
                if (_ConnectionToDB == null)
                {
                    conn = OpenConnection();
                    sqlCommand.Connection = conn;
                }
                else
                {
                    sqlCommand.Connection = _ConnectionToDB;
                }
                return sqlCommand.ExecuteScalar();
            }
            catch (SqlException myException)
            {
                throw (new Exception(myException.Message));
            }
            finally
            {
                if (conn != null)
                {
                    CloseConnection(conn);
                }
            }
        }
        public object ExecuteScalar(SqlCommand sqlCommand, params SqlParameter[] Parameters)
        {
            try
            {
                foreach (SqlParameter par in Parameters)
                {
                    sqlCommand.Parameters.Add(par);
                }
                return ExecuteScalar(sqlCommand);
            }
            catch (Exception myException)
            {
                throw (new Exception(myException.Message));
            }
        }
        public object ExecuteScalar(string strSQL)
        {
            SqlCommand sqlCommand = new SqlCommand(strSQL);
            return ExecuteScalar(sqlCommand);
        }
        public object ExecuteScalar(string strSQL, params SqlParameter[] Parameters)
        {
            SqlCommand sqlCommand = new SqlCommand(strSQL);
            return ExecuteScalar(sqlCommand, Parameters);
        }
        #endregion
        # region ExecuteNonQuery
        public int ExecuteNonQuery(SqlCommand sqlCommand)
        {
            SqlConnection conn = null;
            try
            {
                if (_ConnectionToDB == null)
                {
                    conn = OpenConnection();
                    sqlCommand.Connection = conn;
                }
                else
                {
                    sqlCommand.Connection = _ConnectionToDB;
                }
                return sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException myException)
            {
                throw (new Exception(myException.Message));
            }
            finally
            {
                if (conn != null)
                {
                    CloseConnection(conn);
                }
            }
        }
        public int ExecuteNonQuery(SqlCommand sqlCommand, params SqlParameter[] Parameters)
        {
            try
            {
                foreach (SqlParameter par in Parameters)
                {
                    sqlCommand.Parameters.Add(par);
                }
                return ExecuteNonQuery(sqlCommand);
            }
            catch (Exception myException)
            {
                throw (new Exception(myException.Message));
            }
        }
        public int ExecuteNonQuery(string strSQL)
        {
            SqlCommand sqlCommand = new SqlCommand(strSQL);
            return ExecuteNonQuery(sqlCommand);
        }
        public int ExecuteNonQuery(string strSQL, params SqlParameter[] Parameters)
        {
            SqlCommand sqlCommand = new SqlCommand(strSQL);
            return ExecuteNonQuery(sqlCommand, Parameters);
        }
        #endregion
        #region ExecuteScalarSP
        public object ExecuteScalarSP(string SPName)
        {
            SqlCommand sqlCommand = new SqlCommand(SPName);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            return ExecuteScalar(sqlCommand);
        }
        public object ExecuteScalarSP(string SPName, params SqlParameter[] Parameters)
        {
            SqlCommand sqlCommand = new SqlCommand(SPName);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            return ExecuteScalar(sqlCommand, Parameters);
        }
        #endregion
        #region ExecuteSP
        public int ExecuteSP(string SPName)
        {
            SqlCommand sqlCommand = new SqlCommand(SPName);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter ReturnValue = new SqlParameter("@ReturnValue", SqlDbType.Int);
            ReturnValue.Direction = ParameterDirection.ReturnValue;
            sqlCommand.Parameters.Add(ReturnValue);
            ExecuteNonQuery(sqlCommand);
            return (int)sqlCommand.Parameters["@ReturnValue"].Value;
        }
        public int ExecuteSP(string SPName, params SqlParameter[] Parameters)
        {
            SqlCommand sqlCommand = new SqlCommand(SPName);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter ReturnValue = new SqlParameter("@ReturnValue", SqlDbType.Int);
            ReturnValue.Direction = ParameterDirection.ReturnValue;
            sqlCommand.Parameters.Add(ReturnValue);
            ExecuteNonQuery(sqlCommand, Parameters);
            return (int)sqlCommand.Parameters["@ReturnValue"].Value;
        }
        #endregion
        #region getDataTableSP
        public DataTable getDataTableSP(string SPName)
        {
            SqlCommand sqlCommand = new SqlCommand(SPName);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            return getDataTable(sqlCommand);
        }
        public DataTable getDataTableSP(string SPName, params SqlParameter[] Parameters)
        {
            SqlCommand sqlCommand = new SqlCommand(SPName);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            return getDataTable(sqlCommand, Parameters);
        }
        #endregion

        // GetDataReader
        public SqlDataReader GetDataReader(SqlCommand sqlCommand)
        {
            SqlConnection conn = null;
            try
            {

                if (_ConnectionToDB == null)
                {
                    conn = OpenConnection();
                    sqlCommand.Connection = conn;
                }
                else
                {
                    sqlCommand.Connection = _ConnectionToDB;
                }
                SqlDataReader dr = sqlCommand.ExecuteReader();
                return dr;
            }
            catch (SqlException myException)
            {
                throw (new Exception(myException.Message));
            }
            finally
            {
                if (conn != null)
                {
                    CloseConnection(conn);
                }
            }
        }

        public SqlDataReader GetDataReader(SqlCommand sqlCommand, params SqlParameter[] Parameters)
        {
            try
            {
                foreach (SqlParameter par in Parameters)
                {
                    sqlCommand.Parameters.Add(par);
                }
                return GetDataReader(sqlCommand);
            }
            catch (Exception myException)
            {
                throw (new Exception(myException.Message));
            }
        }

        public SqlDataReader GetDataReader(string strSQL)
        {
            SqlCommand sqlCommand = new SqlCommand(strSQL);
            return GetDataReader(sqlCommand);
        }

        public SqlDataReader GetDataReader(string strSQL, params SqlParameter[] Parameters)
        {
            SqlCommand sqlCommand = new SqlCommand(strSQL);
            return GetDataReader(sqlCommand, Parameters);
        }

    }
