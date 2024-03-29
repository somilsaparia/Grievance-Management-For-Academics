using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StaffGrievanceENT
/// </summary>
namespace GrievanceSystem.ENT
{
    public class StaffGrievanceENT
    {
        #region Constructor
        public StaffGrievanceENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region StaffGrievanceID
        protected SqlInt32 _StaffGrievanceID;

        public SqlInt32 StaffGrievanceID
        {
            get
            {
                return _StaffGrievanceID;
            }
            set
            {
                _StaffGrievanceID = value;
            }
        }
        #endregion StaffGrievanceID

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