using GrievanceSystem.DAL;
using GrievanceSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StaffLoginDetailBAL
/// </summary>
namespace GrievanceSystem.BAL
{
    public class StaffLoginDetailBAL
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
        public StaffLoginDetailBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(StaffLoginDetailENT entStaffLoginDetail)
        {
            StaffLoginDetailDAL dalStaffLoginDetail = new StaffLoginDetailDAL();
            if (dalStaffLoginDetail.Insert(entStaffLoginDetail))
            {
                return true;
            }
            else
            {
                Message = dalStaffLoginDetail.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region UpdateByStaffID Operation
        public Boolean UpdateByStaffID(StaffLoginDetailENT entStaffLoginDetail)
        {
            StaffLoginDetailDAL dalStaffLoginDetail = new StaffLoginDetailDAL();
            if (dalStaffLoginDetail.UpdateByStaffID(entStaffLoginDetail))
            {
                return true;
            }
            else
            {
                Message = dalStaffLoginDetail.Message;
                return false;
            }
        }
        #endregion UpdateByStaffID Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 StaffID)
        {
            StaffLoginDetailDAL dalStaffLoginDetail = new StaffLoginDetailDAL();

            if (dalStaffLoginDetail.Delete(StaffID))
            {
                return true;
            }
            else
            {
                Message = dalStaffLoginDetail.Message;
                return false;
            }
        }
        #endregion Delete Operation

        #region Select Operation

        #region SelectByStaffID
        public StaffLoginDetailENT SelectByStaffID(SqlInt32 StaffID)
        {
            StaffLoginDetailDAL dalStaffLoginDetail = new StaffLoginDetailDAL();
            return dalStaffLoginDetail.SelectByStaffID(StaffID);
        }
        #endregion SelectByStaffID

        #region SelectByStaffCodePassword
        public StaffLoginDetailENT SelectByStaffCodePassword(SqlString StaffCode, SqlString StaffPassword)
        {
            StaffLoginDetailDAL dalStaffLoginDetail = new StaffLoginDetailDAL();
            return dalStaffLoginDetail.SelectByStaffCodePassword(StaffCode, StaffPassword);
        }
        #endregion SelectByStaffCodePassword

        #endregion Select Operation
    }
}