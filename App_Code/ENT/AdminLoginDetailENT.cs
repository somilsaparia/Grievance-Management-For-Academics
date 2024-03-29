using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AdminLoginDetailENT
/// </summary>
namespace GrievanceSystem.ENT
{
    public class AdminLoginDetailENT
    {
        #region Constructor
        public AdminLoginDetailENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region AdminLoginDetailID
        protected SqlInt32 _AdminLoginDetailID;

        public SqlInt32 AdminLoginDetailID
        {
            get
            {
                return _AdminLoginDetailID;
            }
            set
            {
                _AdminLoginDetailID = value;
            }
        }
        #endregion AdminLoginDetailID

        #region AdminUserName
        protected SqlString _AdminUserName;

        public SqlString AdminUserName
        {
            get
            {
                return _AdminUserName;
            }
            set
            {
                _AdminUserName = value;
            }
        }
        #endregion AdminUserName

        #region AdminPassword
        protected SqlString _AdminPassword;

        public SqlString AdminPassword
        {
            get
            {
                return _AdminPassword;
            }
            set
            {
                _AdminPassword = value;
            }
        }
        #endregion AdminPassword
    }
}