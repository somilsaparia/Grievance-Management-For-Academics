using GrievanceSystem.DAL;
using GrievanceSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StudentGrievanceBAL
/// </summary>
namespace GrievanceSystem.BAL
{
    public class StudentGrievanceBAL
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
        public StudentGrievanceBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(StudentGrievanceENT entStudentGrievance)
        {
            StudentGrievanceDAL dalStudentGrievance = new StudentGrievanceDAL();
            if (dalStudentGrievance.Insert(entStudentGrievance))
            {
                return true;
            }
            else
            {
                Message = dalStudentGrievance.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation

        #region UpdateByPK
        public Boolean UpdateByPK(StudentGrievanceENT entStudentGrievance)
        {
            StudentGrievanceDAL dalStudentGrievance = new StudentGrievanceDAL();
            if (dalStudentGrievance.UpdateByPK(entStudentGrievance))
            {
                return true;
            }
            else
            {
                Message = dalStudentGrievance.Message;
                return false;
            }
        }
        #endregion UpdateByPK

        #region UpdateStatusByPK
        public Boolean UpdateStatusByPK(StudentGrievanceENT entStudentGrievance)
        {
            StudentGrievanceDAL dalStudentGrievance = new StudentGrievanceDAL();
            if (dalStudentGrievance.UpdateByPK(entStudentGrievance))
            {
                return true;
            }
            else
            {
                Message = dalStudentGrievance.Message;
                return false;
            }
        }
        #endregion UpdateStatusByPK

        #region UpdateStatusToInProgress
        public Boolean UpdateStatusToInProgress(SqlInt32 StudentGrievanceID)
        {
            StudentGrievanceDAL dalStudentGrievance = new StudentGrievanceDAL();
            if (dalStudentGrievance.UpdateStatusToInProgress(StudentGrievanceID))
            {
                return true;
            }
            else
            {
                Message = dalStudentGrievance.Message;
                return false;
            }
        }
        #endregion UpdateStatusToInProgress

        #region UpdateStatusToRejected
        public Boolean UpdateStatusToRejected(SqlInt32 StudentGrievanceID)
        {
            StudentGrievanceDAL dalStudentGrievance = new StudentGrievanceDAL();
            if (dalStudentGrievance.UpdateStatusToRejected(StudentGrievanceID))
            {
                return true;
            }
            else
            {
                Message = dalStudentGrievance.Message;
                return false;
            }
        }
        #endregion UpdateStatusToRejected

        #region UpdateStatusToResolve
        public Boolean UpdateStatusToResolve(SqlInt32 StudentGrievanceID)
        {
            StudentGrievanceDAL dalStudentGrievance = new StudentGrievanceDAL();
            if (dalStudentGrievance.UpdateStatusToResolve(StudentGrievanceID))
            {
                return true;
            }
            else
            {
                Message = dalStudentGrievance.Message;
                return false;
            }
        }
        #endregion UpdateStatusToResolve

        #region UpdateGrievanceByPK
        public Boolean UpdateGrievanceByPK(StudentGrievanceENT entStudentGrievance)
        {
            StudentGrievanceDAL dalStudentGrievance = new StudentGrievanceDAL();
            if (dalStudentGrievance.UpdateByPK(entStudentGrievance))
            {
                return true;
            }
            else
            {
                Message = dalStudentGrievance.Message;
                return false;
            }
        }
        #endregion UpdateGrievanceByPK

        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 StudentGrievanceID)
        {
            StudentGrievanceDAL dalStudentGrievance = new StudentGrievanceDAL();

            if (dalStudentGrievance.Delete(StudentGrievanceID))
            {
                return true;
            }
            else
            {
                Message = dalStudentGrievance.Message;
                return false;
            }
        }
        #endregion Delete Operation

        #region Select Operation

        #region SelectAll
        public DataTable SelectAll()
        {
            StudentGrievanceDAL dalStudentGrievance = new StudentGrievanceDAL();
            return dalStudentGrievance.SelectAll();
        }
        #endregion SelectAll

        #region SelectAllByStudentID
        public DataTable SelectAllByStudentID(SqlInt32 StudentID)
        {
            StudentGrievanceDAL dalStudentGrievance = new StudentGrievanceDAL();
            return dalStudentGrievance.SelectAllByStudentID(StudentID);
        }
        #endregion SelectAllByStudentID

        #region SelectRegisteredByStudentID
        public DataTable SelectRegisteredByStudentID(SqlInt32 StudentID)
        {
            StudentGrievanceDAL dalStudentGrievance = new StudentGrievanceDAL();
            return dalStudentGrievance.SelectRegisteredByStudentID(StudentID);
        }
        #endregion SelectRegisteredByStudentID

        #region SelectInProgressByStudentID
        public DataTable SelectInProgressByStudentID(SqlInt32 StudentID)
        {
            StudentGrievanceDAL dalStudentGrievance = new StudentGrievanceDAL();
            return dalStudentGrievance.SelectInProgressByStudentID(StudentID);
        }
        #endregion SelectInProgressByStudentID

        #region SelectResolveByStudentID
        public DataTable SelectResolveByStudentID(SqlInt32 StudentID)
        {
            StudentGrievanceDAL dalStudentGrievance = new StudentGrievanceDAL();
            return dalStudentGrievance.SelectResolveByStudentID(StudentID);
        }
        #endregion SelectResolveByStudentID

        #region SelectRejectedByStudentID
        public DataTable SelectRejectedByStudentID(SqlInt32 StudentID)
        {
            StudentGrievanceDAL dalStudentGrievance = new StudentGrievanceDAL();
            return dalStudentGrievance.SelectRejectedByStudentID(StudentID);
        }
        #endregion SelectRejectedByStudentID

        #region SelectForDropDownList
        public DataTable SelectForDropDownList()
        {
            StudentGrievanceDAL dalStudentGrievance = new StudentGrievanceDAL();
            return dalStudentGrievance.SelectForDropDownList();
        }
        #endregion SelectForDropDownList

        #region SelectByPK
        public StudentGrievanceENT SelectByPK(SqlInt32 StudentGrievanceID)
        {
            StudentGrievanceDAL dalStudentGrievance = new StudentGrievanceDAL();
            return dalStudentGrievance.SelectByPK(StudentGrievanceID);
        }
        #endregion SelectByPK

        #region Counters

        #region CountAll
        public Int32 Count()
        {
            StudentGrievanceDAL dalStudentGrievance = new StudentGrievanceDAL();
            return dalStudentGrievance.Count();
        }
        #endregion CountAll

        #region CountAllByPK
        public Int32 CountAllByPK(SqlInt32 StudentID)
        {
            StudentGrievanceDAL dalStudentGrievance = new StudentGrievanceDAL();
            return dalStudentGrievance.CountAllByPK(StudentID);
        }
        #endregion CountAllByPK

        #region CountRegisteredByPK
        public Int32 CountRegisteredByPK(SqlInt32 StudentID)
        {
            StudentGrievanceDAL dalStudentGrievance = new StudentGrievanceDAL();
            return dalStudentGrievance.CountRegisteredByPK(StudentID);
        }
        #endregion CountRegisteredByPK

        #region CountInProgressByPK
        public Int32 CountInProgressByPK(SqlInt32 StudentID)
        {
            StudentGrievanceDAL dalStudentGrievance = new StudentGrievanceDAL();
            return dalStudentGrievance.CountInProgressByPK(StudentID);
        }
        #endregion CountInProgressByPK

        #region CountResolveByPK
        public Int32 CountResolveByPK(SqlInt32 StudentID)
        {
            StudentGrievanceDAL dalStudentGrievance = new StudentGrievanceDAL();
            return dalStudentGrievance.CountResolveByPK(StudentID);
        }
        #endregion CountResolveByPK

        #region CountRejectedByPK
        public Int32 CountRejectedByPK(SqlInt32 StudentID)
        {
            StudentGrievanceDAL dalStudentGrievance = new StudentGrievanceDAL();
            return dalStudentGrievance.CountRejectedByPK(StudentID);
        }
        #endregion CountRejectedByPK

        #endregion Counters

        #endregion Select Operation
    }
}