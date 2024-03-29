using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StaffLoginDetailENT
/// </summary>
namespace GrievanceSystem.ENT
{
    public class StaffLoginDetailENT
    {
        #region Constructor
        public StaffLoginDetailENT()
	    {
		    //
		    // TODO: Add constructor logic here
		    //
        }
        #endregion Constructor

        #region StaffLoginDetailID
        protected SqlInt32 _StaffLoginDetailID;

        public SqlInt32 StaffLoginDetailID
        {
            get
            {
                return _StaffLoginDetailID;
            }
            set
            {
                _StaffLoginDetailID = value;
            }
        }
        #endregion StaffLoginDetailID

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

        #region StaffPassword
        protected SqlString _StaffPassword;

        public SqlString StaffPassword
        {
            get
            {
                return _StaffPassword;
            }
            set
            {
                _StaffPassword = value;
            }
        }
        #endregion StaffPassword

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
    }
}