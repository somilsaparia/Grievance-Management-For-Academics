using GrievanceSystem.DAL;
using GrievanceSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StudentLoginDetailBAL
/// </summary>
namespace GrievanceSystem.BAL
{
    public class StudentLoginDetailBAL
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
        public StudentLoginDetailBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(StudentLoginDetailENT entStudentLoginDetail)
        {
            StudentLoginDetailDAL dalStudentLoginDetail = new StudentLoginDetailDAL();
            if (dalStudentLoginDetail.Insert(entStudentLoginDetail))
            {
                return true;
            }
            else
            {
                Message = dalStudentLoginDetail.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region UpdateByStudentID Operation
        public Boolean UpdateByStudentID(StudentLoginDetailENT entStudentLoginDetail)
        {
            StudentLoginDetailDAL dalStudentLoginDetail = new StudentLoginDetailDAL();
            if (dalStudentLoginDetail.UpdateByStudentID(entStudentLoginDetail))
            {
                return true;
            }
            else
            {
                Message = dalStudentLoginDetail.Message;
                return false;
            }
        }
        #endregion UpdateByStudentID Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 StudentID)
        {
            StudentLoginDetailDAL dalStudentLoginDetail = new StudentLoginDetailDAL();

            if (dalStudentLoginDetail.Delete(StudentID))
            {
                return true;
            }
            else
            {
                Message = dalStudentLoginDetail.Message;
                return false;
            }
        }
        #endregion Delete Operation

        #region Select Operation

        #region SelectByStudentID
        public StudentLoginDetailENT SelectByStudentID(SqlInt32 StudentID)
        {
            StudentLoginDetailDAL dalStudentLoginDetail = new StudentLoginDetailDAL();
            return dalStudentLoginDetail.SelectByStudentID(StudentID);
        }
        #endregion SelectByStudentID

        #region SelectByEnrollmentNumberPassword
        public StudentLoginDetailENT SelectByEnrollmentNumberPassword(SqlString StudentEnrollmentNumber, SqlString StudentPassword)
        {
            StudentLoginDetailDAL dalStudentLoginDetail = new StudentLoginDetailDAL();
            return dalStudentLoginDetail.SelectByEnrollmentNumberPassword(StudentEnrollmentNumber, StudentPassword);
        }
        #endregion SelectByEnrollmentNumberPassword

        #endregion Select Operation
    }
}