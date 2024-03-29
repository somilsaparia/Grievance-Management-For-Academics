using GrievanceSystem.DAL;
using GrievanceSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CourseBAL
/// </summary>
namespace GrievanceSystem.BAL
{
    public class CourseBAL
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
        public CourseBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(CourseENT entCourse)
        {
            CourseDAL dalCourse = new CourseDAL();
            if (dalCourse.Insert(entCourse))
            {
                return true;
            }
            else
            {
                Message = dalCourse.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(CourseENT entCourse)
        {
            CourseDAL dalCourse = new CourseDAL();
            if (dalCourse.Update(entCourse))
            {
                return true;
            }
            else
            {
                Message = dalCourse.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 CourseID)
        {
            CourseDAL dalCourse = new CourseDAL();

            if (dalCourse.Delete(CourseID))
            {
                return true;
            }
            else
            {
                Message = dalCourse.Message;
                return false;
            }
        }
        #endregion Delete Operation

        #region Select Operation

        #region SelectAll
        public DataTable SelectAll()
        {
            CourseDAL dalCourse = new CourseDAL();
            return dalCourse.SelectAll();
        }
        #endregion SelectAll

        #region SelectForDropDownList
        public DataTable SelectForDropDownList()
        {
            CourseDAL dalCourse = new CourseDAL();
            return dalCourse.SelectForDropDownList();
        }
        #endregion SelectForDropDownList

        #region SelectByPK
        public CourseENT SelectByPK(SqlInt32 CourseID)
        {
            CourseDAL dalCourse = new CourseDAL();
            return dalCourse.SelectByPK(CourseID);
        }
        #endregion SelectByPK

        #region Count
        public Int32 Count()
        {
            CourseDAL dalCourse = new CourseDAL();
            return dalCourse.Count();
        }
        #endregion Count

        #endregion Select Operation
    }
}