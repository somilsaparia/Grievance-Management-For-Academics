using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StudentGrievanceENT
/// </summary>
namespace GrievanceSystem.ENT
{
    public class StudentGrievanceENT
    {
        #region Constructor
        public StudentGrievanceENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region StudentGrievanceID
        protected SqlInt32 _StudentGrievanceID;

        public SqlInt32 StudentGrievanceID
        {
            get
            {
                return _StudentGrievanceID;
            }
            set
            {
                _StudentGrievanceID = value;
            }
        }
        #endregion StudentGrievanceID

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

        #region GrievanceID
        protected SqlInt32 _GrievanceID;

        public SqlInt32 GrievanceID
        {
            get
            {
                return _GrievanceID;
            }
            set
            {
                _GrievanceID = value;
            }
        }
        #endregion GrievanceID

        #region GrievanceStatus
        protected SqlString _GrievanceStatus;

        public SqlString GrievanceStatus
        {
            get
            {
                return _GrievanceStatus;
            }
            set
            {
                _GrievanceStatus = value;
            }
        }
        #endregion GrievanceStatus

        #region GrievanceDescription
        protected SqlString _GrievanceDescription;

        public SqlString GrievanceDescription
        {
            get
            {
                return _GrievanceDescription;
            }
            set
            {
                _GrievanceDescription = value;
            }
        }
        #endregion GrievanceDescription

        #region GrievanceDate
        protected SqlDateTime _GrievanceDate;

        public SqlDateTime GrievanceDate
        {
            get
            {
                return _GrievanceDate;
            }
            set
            {
                _GrievanceDate = value;
            }
        }
        #endregion GrievanceDate

        #region GrievanceUpdateDate
        protected SqlDateTime _GrievanceUpdateDate;

        public SqlDateTime GrievanceUpdateDate
        {
            get
            {
                return _GrievanceUpdateDate;
            }
            set
            {
                _GrievanceUpdateDate = value;
            }
        }
        #endregion GrievanceUpdateDate
    }
}