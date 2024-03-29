using GrievanceSystem.DAL;
using GrievanceSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AdminLoginDetailBAL
/// </summary>
namespace GrievanceSystem.BAL
{
    public class AdminLoginDetailBAL
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
        public AdminLoginDetailBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Select Operation

        #region SelectByPK
        public AdminLoginDetailENT SelectByUserNamePassword(SqlString AdminUserName, SqlString AdminPassword)
        {
            AdminLoginDetailDAL dalAdminLoginDetail = new AdminLoginDetailDAL();
            return dalAdminLoginDetail.SelectByUserNamePassword(AdminUserName, AdminPassword);
        }
        #endregion SelectByPK

        #endregion Select Operation
    }
}