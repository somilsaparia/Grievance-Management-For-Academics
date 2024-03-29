using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StaffENT
/// </summary>
namespace GrievanceSystem.ENT
{
    public class StaffENT
    {
        #region Constructor
        public StaffENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region StaffID
        protected SqlInt32 _StaffID;

        public SqlInt32 StaffID
        {
            get
            {
                return _StaffID;
            }
            set
            {
                _StaffID = value;
            }
        }
        #endregion StaffID

        #region StaffFirstName
        protected SqlString _StaffFirstName;

        public SqlString StaffFirstName
        {
            get
            {
                return _StaffFirstName;
            }
            set
            {
                _StaffFirstName = value;
            }
        }
        #endregion StaffFirstName

        #region StaffMiddleName
        protected SqlString _StaffMiddleName;

        public SqlString StaffMiddleName
        {
            get
            {
                return _StaffMiddleName;
            }
            set
            {
                _StaffMiddleName = value;
            }
        }
        #endregion StaffMiddleName

        #region StaffLastName
        protected SqlString _StaffLastName;

        public SqlString StaffLastName
        {
            get
            {
                return _StaffLastName;
            }
            set
            {
                _StaffLastName = value;
            }
        }
        #endregion StaffLastName

        #region StaffCode
        protected SqlString _StaffCode;

        public SqlString StaffCode
        {
            get
            {
                return _StaffCode;
            }
            set
            {
                _StaffCode = value;
            }
        }
        #endregion StaffCode

        #region StaffMobileNumber
        protected SqlString _StaffMobileNumber;

        public SqlString StaffMobileNumber
        {
            get
            {
                return _StaffMobileNumber;
            }
            set
            {
                _StaffMobileNumber = value;
            }
        }
        #endregion StaffMobileNumber

        #region StaffPersonalEmailAddress
        protected SqlString _StaffPersonalEmailAddress;

        public SqlString StaffPersonalEmailAddress
        {
            get
            {
                return _StaffPersonalEmailAddress;
            }
            set
            {
                _StaffPersonalEmailAddress = value;
            }
        }
        #endregion StaffPersonalEmailAddress

        #region StaffCollegeEmailAddress
        protected SqlString _StaffCollegeEmailAddress;

        public SqlString StaffCollegeEmailAddress
        {
            get
            {
                return _StaffCollegeEmailAddress;
            }
            set
            {
                _StaffCollegeEmailAddress = value;
            }
        }
        #endregion StaffCollegeEmailAddress

        #region StaffJoiningYear
        protected SqlInt32 _StaffJoiningYear;

        public SqlInt32 StaffJoiningYear
        {
            get
            {
                return _StaffJoiningYear;
            }
            set
            {
                _StaffJoiningYear = value;
            }
        }
        #endregion StaffJoiningYear

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
    }
}