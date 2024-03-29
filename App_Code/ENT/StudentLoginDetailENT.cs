using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StudentLoginDetail
/// </summary>
namespace GrievanceSystem.ENT
{
    public class StudentLoginDetailENT
    {
        #region Constructor
        public StudentLoginDetailENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region StudentLoginDetailID
        protected SqlInt32 _StudentLoginDetailID;

        public SqlInt32 StudentLoginDetailID
        {
            get
            {
                return _StudentLoginDetailID;
            }
            set
            {
                _StudentLoginDetailID = value;
            }
        }
        #endregion StudentLoginDetailID

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

        #region StudentPassword
        protected SqlString _StudentPassword;

        public SqlString StudentPassword
        {
            get
            {
                return _StudentPassword;
            }
            set
            {
                _StudentPassword = value;
            }
        }
        #endregion StudentPassword

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
    }
}