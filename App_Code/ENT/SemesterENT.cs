using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SemesterENT
/// </summary>
namespace GrievanceSystem.ENT
{
    public class SemesterENT
    {
        #region Constructor
        public SemesterENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region SemesterID
        protected SqlInt32 _SemesterID;

        public SqlInt32 SemesterID
        {
            get
            {
                return _SemesterID;
            }
            set
            {
                _SemesterID = value;
            }
        }
        #endregion SemesterID

        #region SemesterNumber
        protected SqlInt32 _SemesterNumber;

        public SqlInt32 SemesterNumber
        {
            get
            {
                return _SemesterNumber;
            }
            set
            {
                _SemesterNumber = value;
            }
        }
        #endregion SemesterNumber

        #region DepartmentID
        protected SqlInt32 _DepartmentID;

        public SqlInt32 DepartmentID
        {
            get
            {
                return _DepartmentID;
            }
            set
            {
                _DepartmentID = value;
            }
        }
        #endregion DepartmentID

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
    }
}