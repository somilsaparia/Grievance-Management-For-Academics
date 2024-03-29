using GrievanceSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StaffLoginDetailENT
/// </summary>
namespace GrievanceSystem.DAL
{
    public class StaffLoginDetailDAL : DatabaseConfig
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
        public StaffLoginDetailDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(StaffLoginDetailENT entStaffLoginDetail)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_StaffLoginDetail_Insert";
                        objCmd.Parameters.Add("@StaffLoginDetailID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@StaffPassword", SqlDbType.VarChar).Value = entStaffLoginDetail.StaffPassword;
                        objCmd.Parameters.Add("@StaffID", SqlDbType.Int).Value = entStaffLoginDetail.StaffID;
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        if (objCmd.Parameters["@StaffLoginDetailID"] != null)
                            entStaffLoginDetail.StaffLoginDetailID = Convert.ToInt32(objCmd.Parameters["@StaffLoginDetailID"].Value);

                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message.ToString();
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message.ToString();
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion Insert Operation

        #region UpdateByStaffID Operation
        public Boolean UpdateByStaffID(StaffLoginDetailENT entStaffLoginDetail)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_StaffLoginDetail_UpdateByStaffID";
                        objCmd.Parameters.AddWithValue("@StaffPassword", entStaffLoginDetail.StaffPassword);
                        objCmd.Parameters.AddWithValue("@StaffID", entStaffLoginDetail.StaffID);
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message.ToString();
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion UpdateByStaffID Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 StaffID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                try
                {
                    objConn.Open();
                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_StaffLoginDetail_DeleteByStaffID";
                        objCmd.Parameters.AddWithValue("@StaffID", StaffID);
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        return true;
                    }
                }
                catch (SqlException sqlex)
                {
                    Message = sqlex.InnerException.Message.ToString();
                    return false;
                }
                catch (Exception ex)
                {
                    Message = ex.InnerException.Message.ToString();
                    return false;
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }
        #endregion Delete Operation

        #region Select Operation

        #region SelectByStaffID
        public StaffLoginDetailENT SelectByStaffID(SqlInt32 StaffID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_StaffLoginDetail_SelectByStaffID";
                        objCmd.Parameters.AddWithValue("@StaffID", StaffID);
                        #endregion Prepare Command

                        #region PrepareDate and Set Controls
                        StaffLoginDetailENT entStaffLoginDetail = new StaffLoginDetailENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["StaffPassword"].Equals(DBNull.Value))
                                    entStaffLoginDetail.StaffPassword = Convert.ToString(objSDR["StaffPassword"]);
                            }
                        }
                        return entStaffLoginDetail;
                        #endregion Prepare Data and Set Controls
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
        #endregion SelectByStaffID

        #region SelectByStaffCodePassword
        public StaffLoginDetailENT SelectByStaffCodePassword(SqlString StaffCode, SqlString StaffPassword)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Create Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_StaffLoginDetail_SelectByStaffCodePassword";
                        objCmd.Parameters.AddWithValue("@StaffCode", StaffCode);
                        objCmd.Parameters.AddWithValue("@StaffPassword", StaffPassword);
                        #endregion Create Command

                        #region PrepareDate and Set Controls
                        StaffLoginDetailENT entStaffLoginDetail = new StaffLoginDetailENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["StaffLoginDetailID"].Equals(DBNull.Value))
                                    entStaffLoginDetail.StaffLoginDetailID = Convert.ToInt32(objSDR["StaffLoginDetailID"]);

                                if (!objSDR["StaffCode"].Equals(DBNull.Value))
                                    entStaffLoginDetail.StaffCode = Convert.ToString(objSDR["StaffCode"]);

                                if (!objSDR["StaffID"].Equals(DBNull.Value))
                                    entStaffLoginDetail.StaffID = Convert.ToInt32(objSDR["StaffID"]);
                            }
                        }
                        return entStaffLoginDetail;
                        #endregion Prepare Data and Set Controls
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
        #endregion SelectByStaffCodePassword

        #endregion Select Operation
    }
}