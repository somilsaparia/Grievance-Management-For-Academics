using GrievanceSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AdminLoginDetailDAL
/// </summary>
namespace GrievanceSystem.DAL
{
    public class AdminLoginDetailDAL : DatabaseConfig
    {
        #region Local Variables
        protected string _Message;

        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }
        #endregion Local Variables

        #region Constructor
        public AdminLoginDetailDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Select Operation

        #region SelectByUserNamePassword
        public AdminLoginDetailENT SelectByUserNamePassword(SqlString AdminUserName, SqlString AdminPassword)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Create Command
                        objCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_AdminLoginDetail_SelectByUserNamePassword";
                        objCmd.Parameters.AddWithValue("@AdminUserName", AdminUserName);
                        objCmd.Parameters.AddWithValue("@AdminPassword", AdminPassword);
                        #endregion Create Command

                        #region Prepare and Set Controls
                        AdminLoginDetailENT entAdminLoginDetail = new AdminLoginDetailENT();

                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["AdminLoginDetailID"].Equals(DBNull.Value))
                                    entAdminLoginDetail.AdminLoginDetailID = Convert.ToInt32(objSDR["AdminLoginDetailID"]);

                                if (!objSDR["AdminUserName"].Equals(DBNull.Value))
                                    entAdminLoginDetail.AdminUserName = Convert.ToString(objSDR["AdminUserName"]);
                            }
                        }
                        return entAdminLoginDetail;
                        #endregion Prepare and Set Controls
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message.ToString();
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion SelectByUserNamePassword

        #endregion Select Operation
    }
}