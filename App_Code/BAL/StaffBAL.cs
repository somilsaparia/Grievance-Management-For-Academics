using GrievanceSystem.DAL;
using GrievanceSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StaffBAL
/// </summary>
namespace GrievanceSystem.BAL
{
    public class StaffBAL
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
        public StaffBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(StaffENT entStaff)
        {
            StaffDAL dalStaff = new StaffDAL();
            if (dalStaff.Insert(entStaff))
            {
                return true;
            }
            else
            {
                Message = dalStaff.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(StaffENT entStaff)
        {
            StaffDAL dalStaff = new StaffDAL();
            if (dalStaff.Update(entStaff))
            {
                return true;
            }
            else
            {
                Message = dalStaff.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 StaffID)
        {
            StaffDAL dalStaff = new StaffDAL();

            if (dalStaff.Delete(StaffID))
            {
                return true;
            }
            else
            {
                Message = dalStaff.Message;
                return false;
            }
        }
        #endregion Delete Operation

        #region Select Operation

        #region SelectAll
        public DataTable SelectAll()
        {
            StaffDAL dalStaff = new StaffDAL();
            return dalStaff.SelectAll();
        }
        #endregion SelectAll

        #region SelectForDropDownList
        public DataTable SelectForDropDownList()
        {
            StaffDAL dalStaff = new StaffDAL();
            return dalStaff.SelectForDropDownList();
        }
        #endregion SelectForDropDownList

        #region SelectByPK
        public StaffENT SelectByPK(SqlInt32 StaffID)
        {
            StaffDAL dalStaff = new StaffDAL();
            return dalStaff.SelectByPK(StaffID);
        }
        #endregion SelectByPK

        #region Count
        public Int32 Count()
        {
            StaffDAL dalStaff = new StaffDAL();
            return dalStaff.Count();
        }
        #endregion Count

        #endregion Select Operation
    }
}