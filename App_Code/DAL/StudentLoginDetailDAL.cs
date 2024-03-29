using GrievanceSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StudentLoginDetailENT
/// </summary>
namespace GrievanceSystem.DAL
{
    public class StudentLoginDetailDAL : DatabaseConfig
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
        public StudentLoginDetailDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(StudentLoginDetailENT entStudentLoginDetail)
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
                        objCmd.CommandText = "PR_StudentLoginDetail_Insert";
                        objCmd.Parameters.Add("@StudentLoginDetailID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@StudentPassword", SqlDbType.VarChar).Value = entStudentLoginDetail.StudentPassword;
                        objCmd.Parameters.Add("@StudentID", SqlDbType.Int).Value = entStudentLoginDetail.StudentID;
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        if (objCmd.Parameters["@StudentLoginDetailID"] != null)
                            entStudentLoginDetail.StudentLoginDetailID = Convert.ToInt32(objCmd.Parameters["@StudentLoginDetailID"].Value);

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

        #region UpdateByStudentID Operation
        public Boolean UpdateByStudentID(StudentLoginDetailENT entStudentLoginDetail)
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
                        objCmd.CommandText = "PR_StudentLoginDetail_UpdateByStudentID";
                        objCmd.Parameters.AddWithValue("@StudentPassword", entStudentLoginDetail.StudentPassword);
                        objCmd.Parameters.AddWithValue("@StudentID", entStudentLoginDetail.StudentID);
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
        #endregion UpdateByStudentID Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 StudentID)
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
                        objCmd.CommandText = "PR_StudentLoginDetail_DeleteByStudentID";
                        objCmd.Parameters.AddWithValue("@StudentID", StudentID);
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

        #region SelectByStudentID
        public StudentLoginDetailENT SelectByStudentID(SqlInt32 StudentID)
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
                        objCmd.CommandText = "PR_StudentLoginDetail_SelectByStudentID";
                        objCmd.Parameters.AddWithValue("@StudentID", StudentID);
                        #endregion Prepare Command

                        #region PrepareDate and Set Controls
                        StudentLoginDetailENT entStudentLoginDetail = new StudentLoginDetailENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["StudentPassword"].Equals(DBNull.Value))
                                    entStudentLoginDetail.StudentPassword = Convert.ToString(objSDR["StudentPassword"]);
                            }
                        }
                        return entStudentLoginDetail;
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
        #endregion SelectByStudentID

        #region SelectByEnrollmentNumberPassword
        public StudentLoginDetailENT SelectByEnrollmentNumberPassword(SqlString StudentEnrollmentNumber, SqlString StudentPassword)
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
                        objCmd.CommandText = "PR_StudentLoginDetail_SelectByEnrollmentNumberPassword";
                        objCmd.Parameters.AddWithValue("@StudentEnrollmentNumber", StudentEnrollmentNumber);
                        objCmd.Parameters.AddWithValue("@StudentPassword", StudentPassword);
                        #endregion Create Command

                        #region PrepareDate and Set Controls
                        StudentLoginDetailENT entStudentLoginDetail = new StudentLoginDetailENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["StudentLoginDetailID"].Equals(DBNull.Value))
                                    entStudentLoginDetail.StudentLoginDetailID = Convert.ToInt32(objSDR["StudentLoginDetailID"]);

                                if (!objSDR["StudentEnrollmentNumber"].Equals(DBNull.Value))
                                    entStudentLoginDetail.StudentEnrollmentNumber = Convert.ToString(objSDR["StudentEnrollmentNumber"]);

                                if (!objSDR["StudentID"].Equals(DBNull.Value))
                                    entStudentLoginDetail.StudentID = Convert.ToInt32(objSDR["StudentID"]);
                            }
                        }
                        return entStudentLoginDetail;
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
        #endregion SelectByEnrollmentNumberPassword

        #endregion Select Operation
    }
}