using GrievanceSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StudentGrievanceDAL
/// </summary>
namespace GrievanceSystem.DAL
{
    public class StudentGrievanceDAL : DatabaseConfig
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
        public StudentGrievanceDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(StudentGrievanceENT entStudentGrievance)
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
                        objCmd.CommandText = "PR_StudentGrievance_Insert";
                        objCmd.Parameters.Add("@StudentGrievanceID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@StudentID", SqlDbType.Int).Value = entStudentGrievance.StudentID;
                        objCmd.Parameters.Add("@GrievanceID", SqlDbType.Int).Value = entStudentGrievance.GrievanceID;
                        objCmd.Parameters.Add("@GrievanceDescription", SqlDbType.VarChar).Value = entStudentGrievance.GrievanceDescription;
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        if (objCmd.Parameters["@StudentGrievanceID"] != null)
                            entStudentGrievance.StudentGrievanceID = Convert.ToInt32(objCmd.Parameters["@StudentGrievanceID"].Value);

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

        #region UpdateByPK
        public Boolean UpdateByPK(StudentGrievanceENT entStudentGrievance)
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
                        objCmd.CommandText = "PR_StudentGrievance_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@StudentGrievanceID", entStudentGrievance.StudentGrievanceID);
                        objCmd.Parameters.AddWithValue("@GrievanceID", entStudentGrievance.GrievanceID);
                        objCmd.Parameters.AddWithValue("@GrievanceDescription", entStudentGrievance.GrievanceDescription);
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

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
        #endregion UpdateByPK

        #region UpdateStatusByPK
        public Boolean UpdateStatusByPK(StudentGrievanceENT entStudentGrievance)
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
                        objCmd.CommandText = "PR_StudentGrievance_UpdateStatusByPK";
                        objCmd.Parameters.AddWithValue("@StudentGrievanceID", entStudentGrievance.StudentGrievanceID);
                        objCmd.Parameters.AddWithValue("@GrievanceStatus", entStudentGrievance.GrievanceStatus);
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
        #endregion UpdateStatusByPK

        #region UpdateStatusToInProgress
        public Boolean UpdateStatusToInProgress(SqlInt32 StudentGrievanceID)
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
                        objCmd.CommandText = "PR_StudentGrievance_UpdateStatusToInProgress";
                        objCmd.Parameters.AddWithValue("@StudentGrievanceID", StudentGrievanceID);
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
        #endregion UpdateStatusToInProgress

        #region UpdateStatusToRejected
        public Boolean UpdateStatusToRejected(SqlInt32 StudentGrievanceID)
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
                        objCmd.CommandText = "PR_StudentGrievance_UpdateStatusToRejected";
                        objCmd.Parameters.AddWithValue("@StudentGrievanceID", StudentGrievanceID);
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
        #endregion UpdateStatusToRejected

        #region UpdateStatusToResolve
        public Boolean UpdateStatusToResolve(SqlInt32 StudentGrievanceID)
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
                        objCmd.CommandText = "PR_StudentGrievance_UpdateStatusToResolve";
                        objCmd.Parameters.AddWithValue("@StudentGrievanceID", StudentGrievanceID);
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
        #endregion UpdateStatusToResolve

        #region UpdateGrievanceByPK
        public Boolean UpdateGrievanceByPK(StudentGrievanceENT entStudentGrievance)
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
                        objCmd.CommandText = "PR_StudentGrievance_UpdateDescriptionByPK";
                        objCmd.Parameters.AddWithValue("@StudentGrievanceID", entStudentGrievance.StudentGrievanceID);
                        objCmd.Parameters.AddWithValue("@GrievanceDescription", entStudentGrievance.GrievanceDescription);
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
        #endregion UpdateGrievanceByPK

        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 StudentGrievanceID)
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
                        objCmd.CommandText = "PR_StudentGrievance_DeleteByPK";
                        objCmd.Parameters.AddWithValue("@StudentGrievanceID", StudentGrievanceID);
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
                        objCmd.CommandText = "PR_StudentGrievance_SelectAll";
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

        #region SelectAllByStudentID
        public DataTable SelectAllByStudentID(SqlInt32 StudentID)
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
                        objCmd.CommandText = "PR_StudentGrievance_SelectAllByStudentID";
                        objCmd.Parameters.AddWithValue("@StudentID", StudentID);
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
        #endregion SelectAllByStudentID

        #region SelectRegisteredByStudentID
        public DataTable SelectRegisteredByStudentID(SqlInt32 StudentID)
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
                        objCmd.CommandText = "PR_StudentGrievance_SelectRegisteredByStudentID";
                        objCmd.Parameters.AddWithValue("@StudentID", StudentID);
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
        #endregion SelectRegisteredByStudentID

        #region SelectInProgressByStudentID
        public DataTable SelectInProgressByStudentID(SqlInt32 StudentID)
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
                        objCmd.CommandText = "PR_StudentGrievance_SelectInProgressByStudentID";
                        objCmd.Parameters.AddWithValue("@StudentID", StudentID);
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
        #endregion SelectInProgressByStudentID

        #region SelectResolveByStudentID
        public DataTable SelectResolveByStudentID(SqlInt32 StudentID)
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
                        objCmd.CommandText = "PR_StudentGrievance_SelectResolveByStudentID";
                        objCmd.Parameters.AddWithValue("@StudentID", StudentID);
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
        #endregion SelectResolveByStudentID

        #region SelectRejectedByStudentID
        public DataTable SelectRejectedByStudentID(SqlInt32 StudentID)
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
                        objCmd.CommandText = "PR_StudentGrievance_SelectRejectedByStudentID";
                        objCmd.Parameters.AddWithValue("@StudentID", StudentID);
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
        #endregion SelectRejectedByStudentIDf

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
                        objCmd.CommandText = "PR_StudentGrievance_SelectForDropDownList";
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
        public StudentGrievanceENT SelectByPK(SqlInt32 StudentGrievanceID)
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
                        objCmd.CommandText = "PR_StudentGrievance_SelectByPK";
                        objCmd.Parameters.AddWithValue("@StudentGrievanceID", StudentGrievanceID);
                        #endregion Prepare Command

                        #region PrepareDate and Set Controls
                        StudentGrievanceENT entStudentGrievance = new StudentGrievanceENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["StudentGrievanceID"].Equals(DBNull.Value))
                                    entStudentGrievance.StudentGrievanceID = Convert.ToInt32(objSDR["StudentGrievanceID"]);

                                if (!objSDR["StudentID"].Equals(DBNull.Value))
                                    entStudentGrievance.StudentID = Convert.ToInt32(objSDR["StudentID"]);

                                if (!objSDR["GrievanceID"].Equals(DBNull.Value))
                                    entStudentGrievance.GrievanceID = Convert.ToInt32(objSDR["GrievanceID"]);

                                if (!objSDR["GrievanceStatus"].Equals(DBNull.Value))
                                    entStudentGrievance.GrievanceStatus = Convert.ToString(objSDR["GrievanceStatus"]);

                                if (!objSDR["GrievanceDescription"].Equals(DBNull.Value))
                                    entStudentGrievance.GrievanceDescription = Convert.ToString(objSDR["GrievanceDescription"]);

                                if (!objSDR["GrievanceDate"].Equals(DBNull.Value))
                                    entStudentGrievance.GrievanceDate = Convert.ToDateTime(objSDR["GrievanceDate"]);

                                if (!objSDR["GrievanceUpdateDate"].Equals(DBNull.Value))
                                    entStudentGrievance.GrievanceUpdateDate = Convert.ToDateTime(objSDR["GrievanceUpdateDate"]);
                            }
                        }
                        return entStudentGrievance;
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

        #region Counters

        #region Count All
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
                        objCmd.CommandText = "PR_StudentGrievance_Count";
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
        #endregion Count All

        #region CountAllByPK
        public Int32 CountAllByPK(SqlInt32 StudentID)
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
                        objCmd.CommandText = "PR_StudentGrievance_Count_TotalGrievanceByPK";
                        objCmd.Parameters.AddWithValue("@StudentID", StudentID);
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
        #endregion CountAllByPK

        #region CountRegisteredByPK
        public Int32 CountRegisteredByPK(SqlInt32 StudentID)
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
                        objCmd.CommandText = "PR_StudentGrievance_Count_RegisteredByPK";
                        objCmd.Parameters.AddWithValue("@StudentID", StudentID);
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
        #endregion CountRegisteredByPK

        #region CountInProgressByPK
        public Int32 CountInProgressByPK(SqlInt32 StudentID)
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
                        objCmd.CommandText = "PR_StudentGrievance_Count_InProgressByPK";
                        objCmd.Parameters.AddWithValue("@StudentID", StudentID);
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
        #endregion CountInProgressByPK

        #region CountResolveByPK
        public Int32 CountResolveByPK(SqlInt32 StudentID)
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
                        objCmd.CommandText = "PR_StudentGrievance_Count_ResolveByPK";
                        objCmd.Parameters.AddWithValue("@StudentID", StudentID);
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
        #endregion CountResolveByPK

        #region CountRejectedByPK
        public Int32 CountRejectedByPK(SqlInt32 StudentID)
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
                        objCmd.CommandText = "PR_StudentGrievance_Count_RejectedByPK";
                        objCmd.Parameters.AddWithValue("@StudentID", StudentID);
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
        #endregion CountRejectedByPK

        #endregion Counters

        #endregion Select Operation
    }
}