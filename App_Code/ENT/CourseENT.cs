using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CourseENT
/// </summary>
namespace GrievanceSystem.ENT
{
    public class CourseENT
    {
        #region Constructor
        public CourseENT()
	    {
		    //
		    // TODO: Add constructor logic here
		    //
        }
        #endregion Constructor

        #region CourseID
        protected SqlInt32 _CourseID;

        public SqlInt32 CourseID
        {
            get
            {
                return _CourseID;
            }
            set
            {
                _CourseID = value;
            }
        }
        #endregion CourseID

        #region CourseName
        protected SqlString _CourseName;

        public SqlString CourseName
        {
            get
            {
                return _CourseName;
            }
            set
            {
                _CourseName = value;
            }
        }
        #endregion CourseName
    }
}