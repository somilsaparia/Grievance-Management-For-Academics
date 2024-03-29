using GrievanceSystem.DAL;
using GrievanceSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StudentBAL
/// </summary>
namespace GrievanceSystem.BAL
{
    public class StudentBAL
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
        public StudentBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(StudentENT entStudent)
        {
            StudentDAL dalStudent = new StudentDAL();
            if (dalStudent.Insert(entStudent))
            {
                return true;
            }
            else
            {
                Message = dalStudent.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(StudentENT entStudent)
        {
            StudentDAL dalStudent = new StudentDAL();
            if (dalStudent.Update(entStudent))
            {
                return true;
            }
            else
            {
                Message = dalStudent.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 StudentID)
        {
            StudentDAL dalStudent = new StudentDAL();

            if (dalStudent.Delete(StudentID))
            {
                return true;
            }
            else
            {
                Message = dalStudent.Message;
                return false;
            }
        }
        #endregion Delete Operation

        #region Select Operation

        #region SelectAll
        public DataTable SelectAll()
        {
            StudentDAL dalStudent = new StudentDAL();
            return dalStudent.SelectAll();
        }
        #endregion SelectAll

        #region SelectForDropDownList
        public DataTable SelectForDropDownList()
        {
            StudentDAL dalStudent = new StudentDAL();
            return dalStudent.SelectForDropDownList();
        }
        #endregion SelectForDropDownList

        #region SelectByPK
        public StudentENT SelectByPK(SqlInt32 StudentID)
        {
            StudentDAL dalStudent = new StudentDAL();
            return dalStudent.SelectByPK(StudentID);
        }
        #endregion SelectByPK

        #region Count
        public Int32 Count()
        {
            StudentDAL dalStudent = new StudentDAL();
            return dalStudent.Count();
        }
        #endregion Count

        #endregion Select Operation
    }
}