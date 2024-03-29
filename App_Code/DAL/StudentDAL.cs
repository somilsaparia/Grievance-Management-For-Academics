using GrievanceSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StudentDAL
/// </summary>
namespace GrievanceSystem.DAL
{
    public class StudentDAL : DatabaseConfig
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
        public StudentDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(StudentENT entStudent)
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
                        objCmd.CommandText = "PR_Student_Insert";
                        objCmd.Parameters.Add("@StudentID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@StudentFirstName", SqlDbType.VarChar).Value = entStudent.StudentFirstName;
                        objCmd.Parameters.Add("@StudentMiddleName", SqlDbType.VarChar).Value = entStudent.StudentMiddleName;
                        objCmd.Parameters.Add("@StudentLastName", SqlDbType.VarChar).Value = entStudent.StudentLastName;
                        objCmd.Parameters.Add("@StudentEnrollmentNumber", SqlDbType.VarChar).Value = entStudent.StudentEnrollmentNumber;
                        objCmd.Parameters.Add("@StudentMobileNumber", SqlDbType.VarChar).Value = entStudent.StudentMobileNumber;
                        objCmd.Parameters.Add("@StudentPersonalEmailAddress", SqlDbType.VarChar).Value = entStudent.StudentPersonalEmailAddress;
                        objCmd.Parameters.Add("@StudentCollegeEmailAddress", SqlDbType.VarChar).Value = entStudent.StudentCollegeEmailAddress;
                        objCmd.Parameters.Add("@StudentCurrentSemesterID", SqlDbType.Int).Value = entStudent.StudentCurrentSemester;
                        objCmd.Parameters.Add("@StudentAdmissionYear", SqlDbType.Int).Value = entStudent.StudentAdmissionYear;
                        objCmd.Parameters.Add("@CourseID", SqlDbType.Int).Value = entStudent.CourseID;
                        objCmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = entStudent.DepartmentID;
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        if (objCmd.Parameters["@StudentID"] != null)
                            entStudent.StudentID = Convert.ToInt32(objCmd.Parameters["@StudentID"].Value);

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
        public Boolean Update(StudentENT entStudent)
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
                        objCmd.CommandText = "PR_Student_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@StudentID", entStudent.StudentID);
                        objCmd.Parameters.AddWithValue("@StudentFirstName", entStudent.StudentFirstName);
                        objCmd.Parameters.AddWithValue("@StudentMiddleName", entStudent.StudentMiddleName);
                        objCmd.Parameters.AddWithValue("@StudentLastName", entStudent.StudentLastName);
                        objCmd.Parameters.AddWithValue("@StudentEnrollmentNumber", entStudent.StudentEnrollmentNumber);
                        objCmd.Parameters.AddWithValue("@StudentMobileNumber", entStudent.StudentMobileNumber);
                        objCmd.Parameters.AddWithValue("@StudentPersonalEmailAddress", entStudent.StudentPersonalEmailAddress);
                        objCmd.Parameters.AddWithValue("@StudentCollegeEmailAddress", entStudent.StudentCollegeEmailAddress);
                        objCmd.Parameters.AddWithValue("@StudentCurrentSemesterID", entStudent.StudentCurrentSemester);
                        objCmd.Parameters.AddWithValue("@StudentAdmissionYear", entStudent.StudentAdmissionYear);
                        objCmd.Parameters.AddWithValue("@CourseID", entStudent.CourseID);
                        objCmd.Parameters.AddWithValue("@DepartmentID", entStudent.DepartmentID);
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
                        objCmd.CommandText = "PR_Student_DeleteByPK";
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
                        objCmd.CommandText = "PR_Student_SelectAll";
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
                        objCmd.CommandText = "PR_Student_SelectForDropDownList";
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
        public StudentENT SelectByPK(SqlInt32 StudentID)
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
                        objCmd.CommandText = "PR_Student_SelectByPK";
                        objCmd.Parameters.AddWithValue("@StudentID", StudentID);
                        #endregion Prepare Command

                        #region PrepareDate and Set Controls
                        StudentENT entStudent = new StudentENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["StudentID"].Equals(DBNull.Value))
                                    entStudent.StudentID = Convert.ToInt32(objSDR["StudentID"]);

                                if (!objSDR["StudentFirstName"].Equals(DBNull.Value))
                                    entStudent.StudentFirstName = Convert.ToString(objSDR["StudentFirstName"]);

                                if (!objSDR["StudentMiddleName"].Equals(DBNull.Value))
                                    entStudent.StudentMiddleName = Convert.ToString(objSDR["StudentMiddleName"]);

                                if (!objSDR["StudentLastName"].Equals(DBNull.Value))
                                    entStudent.StudentLastName = Convert.ToString(objSDR["StudentLastName"]);

                                if (!objSDR["StudentEnrollmentNumber"].Equals(DBNull.Value))
                                    entStudent.StudentEnrollmentNumber = Convert.ToString(objSDR["StudentEnrollmentNumber"]);

                                if (!objSDR["StudentMobileNumber"].Equals(DBNull.Value))
                                    entStudent.StudentMobileNumber = Convert.ToString(objSDR["StudentMobileNumber"]);

                                if (!objSDR["StudentPersonalEmailAddress"].Equals(DBNull.Value))
                                    entStudent.StudentPersonalEmailAddress = Convert.ToString(objSDR["StudentPersonalEmailAddress"]);

                                if (!objSDR["StudentCollegeEmailAddress"].Equals(DBNull.Value))
                                    entStudent.StudentCollegeEmailAddress = Convert.ToString(objSDR["StudentCollegeEmailAddress"]);

                                if (!objSDR["StudentCurrentSemesterID"].Equals(DBNull.Value))
                                    entStudent.StudentCurrentSemester = Convert.ToInt32(objSDR["StudentCurrentSemesterID"]);

                                if (!objSDR["StudentAdmissionYear"].Equals(DBNull.Value))
                                    entStudent.StudentAdmissionYear = Convert.ToInt32(objSDR["StudentAdmissionYear"]);

                                if (!objSDR["CourseID"].Equals(DBNull.Value))
                                    entStudent.CourseID = Convert.ToInt32(objSDR["CourseID"]);

                                if (!objSDR["DepartmentID"].Equals(DBNull.Value))
                                    entStudent.DepartmentID = Convert.ToInt32(objSDR["DepartmentID"]);
                            }
                        }
                        return entStudent;
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
                        objCmd.CommandText = "PR_Student_Count";
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