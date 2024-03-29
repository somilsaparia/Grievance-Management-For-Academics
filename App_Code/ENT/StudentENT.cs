using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StudentENT
/// </summary>
namespace GrievanceSystem.ENT
{
    public class StudentENT
    {
        #region Constructor
        public StudentENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region StudentID
        protected SqlInt32 _StudentID;

        public SqlInt32 StudentID
        {
            get
            {
                return _StudentID;
            }
            set
            {
                _StudentID = value;
            }
        }
        #endregion StudentID

        #region StudentFirstName
        protected SqlString _StudentFirstName;

        public SqlString StudentFirstName
        {
            get
            {
                return _StudentFirstName;
            }
            set
            {
                _StudentFirstName = value;
            }
        }
        #endregion StudentFirstName

        #region StudentMiddleName
        protected SqlString _StudentMiddleName;

        public SqlString StudentMiddleName
        {
            get
            {
                return _StudentMiddleName;
            }
            set
            {
                _StudentMiddleName = value;
            }
        }
        #endregion StudentMiddleName

        #region StudentLastName
        protected SqlString _StudentLastName;

        public SqlString StudentLastName
        {
            get
            {
                return _StudentLastName;
            }
            set
            {
                _StudentLastName = value;
            }
        }
        #endregion StudentLastName

        #region StudentEnrollmentNumber
        protected SqlString _StudentEnrollmentNumber;

        public SqlString StudentEnrollmentNumber
        {
            get
            {
                return _StudentEnrollmentNumber;
            }
            set
            {
                _StudentEnrollmentNumber = value;
            }
        }
        #endregion StudentEnrollmentNumber

        #region StudentMobileNumber
        protected SqlString _StudentMobileNumber;

        public SqlString StudentMobileNumber
        {
            get
            {
                return _StudentMobileNumber;
            }
            set
            {
                _StudentMobileNumber = value;
            }
        }
        #endregion StudentMobileNumber

        #region StudentPersonalEmailAddress
        protected SqlString _StudentPersonalEmailAddress;

        public SqlString StudentPersonalEmailAddress
        {
            get
            {
                return _StudentPersonalEmailAddress;
            }
            set
            {
                _StudentPersonalEmailAddress = value;
            }
        }
        #endregion StudentPersonalEmailAddress

        #region StudentCollegeEmailAddress
        protected SqlString _StudentCollegeEmailAddress;

        public SqlString StudentCollegeEmailAddress
        {
            get
            {
                return _StudentCollegeEmailAddress;
            }
            set
            {
                _StudentCollegeEmailAddress = value;
            }
        }
        #endregion StudentCollegeEmailAddress

        #region StudentCurrentSemester
        protected SqlInt32 _StudentCurrentSemester;

        public SqlInt32 StudentCurrentSemester
        {
            get
            {
                return _StudentCurrentSemester;
            }
            set
            {
                _StudentCurrentSemester = value;
            }
        }
        #endregion StudentCurrentSemester

        #region StudentAdmissionYear
        protected SqlInt32 _StudentAdmissionYear;

        public SqlInt32 StudentAdmissionYear
        {
            get
            {
                return _StudentAdmissionYear;
            }
            set
            {
                _StudentAdmissionYear = value;
            }
        }
        #endregion StudentAdmissionYear

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