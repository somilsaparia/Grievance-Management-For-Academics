using GrievanceSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StaffDAL
/// </summary>
namespace GrievanceSystem.DAL
{
    public class StaffDAL : DatabaseConfig
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
        public StaffDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(StaffENT entStaff)
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
                        objCmd.CommandText = "PR_Staff_Insert";
                        objCmd.Parameters.Add("@StaffID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@StaffFirstName", SqlDbType.VarChar).Value = entStaff.StaffFirstName;
                        objCmd.Parameters.Add("@StaffMiddleName", SqlDbType.VarChar).Value = entStaff.StaffMiddleName;
                        objCmd.Parameters.Add("@StaffLastName", SqlDbType.VarChar).Value = entStaff.StaffLastName;
                        objCmd.Parameters.Add("@StaffCode", SqlDbType.VarChar).Value = entStaff.StaffCode;
                        objCmd.Parameters.Add("@StaffMobileNumber", SqlDbType.VarChar).Value = entStaff.StaffMobileNumber;
                        objCmd.Parameters.Add("@StaffPersonalEmailAddress", SqlDbType.VarChar).Value = entStaff.StaffPersonalEmailAddress;
                        objCmd.Parameters.Add("@StaffCollegeEmailAddress", SqlDbType.VarChar).Value = entStaff.StaffCollegeEmailAddress;
                        objCmd.Parameters.Add("@StaffJoiningYear", SqlDbType.Int).Value = entStaff.StaffJoiningYear;
                        objCmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = entStaff.DepartmentID;
                        objCmd.Parameters.Add("@CourseID", SqlDbType.Int).Value = entStaff.CourseID;
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        if (objCmd.Parameters["@StaffID"] != null)
                            entStaff.StaffID = Convert.ToInt32(objCmd.Parameters["@StaffID"].Value);

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

        #region Update Operation
        public Boolean Update(StaffENT entStaff)
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
                        objCmd.CommandText = "PR_Staff_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@StaffID", entStaff.StaffID);
                        objCmd.Parameters.AddWithValue("@StaffFirstName", entStaff.StaffFirstName);
                        objCmd.Parameters.AddWithValue("@StaffMiddleName", entStaff.StaffMiddleName);
                        objCmd.Parameters.AddWithValue("@StaffLastName", entStaff.StaffLastName);
                        objCmd.Parameters.AddWithValue("@StaffCode", entStaff.StaffCode);
                        objCmd.Parameters.AddWithValue("@StaffMobileNumber", entStaff.StaffMobileNumber);
                        objCmd.Parameters.AddWithValue("@StaffPersonalEmailAddress", entStaff.StaffPersonalEmailAddress);
                        objCmd.Parameters.AddWithValue("@StaffCollegeEmailAddress", entStaff.StaffCollegeEmailAddress);
                        objCmd.Parameters.AddWithValue("@StaffJoiningYear", entStaff.StaffJoiningYear);
                        objCmd.Parameters.AddWithValue("@CourseID", entStaff.CourseID);
                        objCmd.Parameters.AddWithValue("@DepartmentID", entStaff.DepartmentID);
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
        #endregion Update Operation

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
                        objCmd.CommandText = "PR_Staff_DeleteByPK";
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

        #region SelectAll
        public DataTable SelectAll()
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
                        objCmd.CommandText = "PR_Staff_SelectAll";
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion ReadData and Set Controls
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
        #endregion SelectAll

        #region SelectForDropDownList
        public DataTable SelectForDropDownList()
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
                        objCmd.CommandText = "PR_Staff_SelectForDropDownList";
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion ReadData and Set Controls
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
        #endregion SelectForDropDownList

        #region SelectByPK
        public StaffENT SelectByPK(SqlInt32 StaffID)
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
                        objCmd.CommandText = "PR_Staff_SelectByPK";
                        objCmd.Parameters.AddWithValue("@StaffID", StaffID);
                        #endregion Prepare Command

                        #region PrepareDate and Set Controls
                        StaffENT entStaff = new StaffENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["StaffID"].Equals(DBNull.Value))
                                    entStaff.StaffID = Convert.ToInt32(objSDR["StaffID"]);

                                if (!objSDR["StaffFirstName"].Equals(DBNull.Value))
                                    entStaff.StaffFirstName = Convert.ToString(objSDR["StaffFirstName"]);

                                if (!objSDR["StaffMiddleName"].Equals(DBNull.Value))
                                    entStaff.StaffMiddleName = Convert.ToString(objSDR["StaffMiddleName"]);

                                if (!objSDR["StaffLastName"].Equals(DBNull.Value))
                                    entStaff.StaffLastName = Convert.ToString(objSDR["StaffLastName"]);

                                if (!objSDR["StaffCode"].Equals(DBNull.Value))
                                    entStaff.StaffCode = Convert.ToString(objSDR["StaffCode"]);

                                if (!objSDR["StaffMobileNumber"].Equals(DBNull.Value))
                                    entStaff.StaffMobileNumber = Convert.ToString(objSDR["StaffMobileNumber"]);

                                if (!objSDR["StaffPersonalEmailAddress"].Equals(DBNull.Value))
                                    entStaff.StaffPersonalEmailAddress = Convert.ToString(objSDR["StaffPersonalEmailAddress"]);

                                if (!objSDR["StaffCollegeEmailAddress"].Equals(DBNull.Value))
                                    entStaff.StaffCollegeEmailAddress = Convert.ToString(objSDR["StaffCollegeEmailAddress"]);

                                if (!objSDR["StaffJoiningYear"].Equals(DBNull.Value))
                                    entStaff.StaffJoiningYear = Convert.ToInt32(objSDR["StaffJoiningYear"]);

                                if (!objSDR["CourseID"].Equals(DBNull.Value))
                                    entStaff.CourseID = Convert.ToInt32(objSDR["CourseID"]);

                                if (!objSDR["DepartmentID"].Equals(DBNull.Value))
                                    entStaff.DepartmentID = Convert.ToInt32(objSDR["DepartmentID"]);
                            }
                        }
                        return entStaff;
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
        #endregion SelectByPK

        #region Count
        public Int32 Count()
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
                        objCmd.CommandText = "PR_Staff_Count";
                        int Count = Convert.ToInt32(objCmd.ExecuteScalar());

                        return Count;
                        #endregion Prepare Command
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message.ToString();
                        return 0;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
                        return 0;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion Count

        #endregion Select Operation
    }
}