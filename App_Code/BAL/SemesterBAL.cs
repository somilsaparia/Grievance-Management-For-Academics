using GrievanceSystem.DAL;
using GrievanceSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SemesterBAL
/// </summary>
namespace GrievanceSystem.BAL
{
    public class SemesterBAL
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
        public SemesterBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(SemesterENT entSemester)
        {
            SemesterDAL dalSemester = new SemesterDAL();
            if (dalSemester.Insert(entSemester))
            {
                return true;
            }
            else
            {
                Message = dalSemester.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(SemesterENT entSemester)
        {
            SemesterDAL dalSemester = new SemesterDAL();
            if (dalSemester.Update(entSemester))
            {
                return true;
            }
            else
            {
                Message = dalSemester.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 SemesterID)
        {
            SemesterDAL dalSemester = new SemesterDAL();

            if (dalSemester.Delete(SemesterID))
            {
                return true;
            }
            else
            {
                Message = dalSemester.Message;
                return false;
            }
        }
        #endregion Delete Operation

        #region Select Operation

        #region SelectAll
        public DataTable SelectAll()
        {
            SemesterDAL dalSemester = new SemesterDAL();
            return dalSemester.SelectAll();
        }
        #endregion SelectAll

        #region SelectForDropDownList
        public DataTable SelectForDropDownList()
        {
            SemesterDAL dalSemester = new SemesterDAL();
            return dalSemester.SelectForDropDownList();
        }
        #endregion SelectForDropDownList

        #region SelectForDropDownListByDepartmentID
        public DataTable SelectForDropDownListByDepartmentID(SqlInt32 DepartmentID)
        {
            SemesterDAL dalSemester = new SemesterDAL();
            return dalSemester.SelectForDropDownListByDepartmentID(DepartmentID);
        }
        #endregion SelectForDropDownListByDepartmentID

        #region SelectByPK
        public SemesterENT SelectByPK(SqlInt32 SemesterID)
        {
            SemesterDAL dalSemester = new SemesterDAL();
            return dalSemester.SelectByPK(SemesterID);
        }
        #endregion SelectByPK

        #region Count
        public Int32 Count()
        {
            SemesterDAL dalSemester = new SemesterDAL();
            return dalSemester.Count();
        }
        #endregion Count

        #endregion Select Operation
    }
}