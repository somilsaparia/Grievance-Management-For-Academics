using GrievanceSystem.DAl;
using GrievanceSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StaffGrievanceBAL
/// </summary>
namespace GrievanceSystem.BAL
{
    public class StaffGrievanceBAL
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
        public StaffGrievanceBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(StaffGrievanceENT entStaffGrievance)
        {
            StaffGrievanceDAL dalStaffGrievance = new StaffGrievanceDAL();
            if (dalStaffGrievance.Insert(entStaffGrievance))
            {
                return true;
            }
            else
            {
                Message = dalStaffGrievance.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation

        #region UpdateByPK
        public Boolean UpdateByPK(StaffGrievanceENT entStaffGrievance)
        {
            StaffGrievanceDAL dalStaffGrievance = new StaffGrievanceDAL();
            if (dalStaffGrievance.UpdateByPK(entStaffGrievance))
            {
                return true;
            }
            else
            {
                Message = dalStaffGrievance.Message;
                return false;
            }
        }
        #endregion UpdateByPK

        #region UpdateStatusByPK
        public Boolean UpdateStatusByPK(StaffGrievanceENT entStaffGrievance)
        {
            StaffGrievanceDAL dalStaffGrievance = new StaffGrievanceDAL();
            if (dalStaffGrievance.UpdateByPK(entStaffGrievance))
            {
                return true;
            }
            else
            {
                Message = dalStaffGrievance.Message;
                return false;
            }
        }
        #endregion UpdateStatusByPK

        #region UpdateStatusToInProgress
        public Boolean UpdateStatusToInProgress(SqlInt32 StaffGrievanceID)
        {
            StaffGrievanceDAL dalStaffGrievance = new StaffGrievanceDAL();
            if (dalStaffGrievance.UpdateStatusToInProgress(StaffGrievanceID))
            {
                return true;
            }
            else
            {
                Message = dalStaffGrievance.Message;
                return false;
            }
        }
        #endregion UpdateStatusToInProgress

        #region UpdateStatusToRejected
        public Boolean UpdateStatusToRejected(SqlInt32 StaffGrievanceID)
        {
            StaffGrievanceDAL dalStaffGrievance = new StaffGrievanceDAL();
            if (dalStaffGrievance.UpdateStatusToRejected(StaffGrievanceID))
            {
                return true;
            }
            else
            {
                Message = dalStaffGrievance.Message;
                return false;
            }
        }
        #endregion UpdateStatusToRejected

        #region UpdateStatusToResolve
        public Boolean UpdateStatusToResolve(SqlInt32 StaffGrievanceID)
        {
            StaffGrievanceDAL dalStaffGrievance = new StaffGrievanceDAL();
            if (dalStaffGrievance.UpdateStatusToResolve(StaffGrievanceID))
            {
                return true;
            }
            else
            {
                Message = dalStaffGrievance.Message;
                return false;
            }
        }
        #endregion UpdateStatusToResolve

        #region UpdateGrievanceByPK
        public Boolean UpdateGrievanceByPK(StaffGrievanceENT entStaffGrievance)
        {
            StaffGrievanceDAL dalStaffGrievance = new StaffGrievanceDAL();
            if (dalStaffGrievance.UpdateByPK(entStaffGrievance))
            {
                return true;
            }
            else
            {
                Message = dalStaffGrievance.Message;
                return false;
            }
        }
        #endregion UpdateGrievanceByPK

        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 StaffGrievanceID)
        {
            StaffGrievanceDAL dalStaffGrievance = new StaffGrievanceDAL();

            if (dalStaffGrievance.Delete(StaffGrievanceID))
            {
                return true;
            }
            else
            {
                Message = dalStaffGrievance.Message;
                return false;
            }
        }
        #endregion Delete Operation

        #region Select Operation

        #region SelectAll
        public DataTable SelectAll()
        {
            StaffGrievanceDAL dalStaffGrievance = new StaffGrievanceDAL();
            return dalStaffGrievance.SelectAll();
        }
        #endregion SelectAll

        #region SelectAllByStaffID
        public DataTable SelectAllByStaffID(SqlInt32 StaffID)
        {
            StaffGrievanceDAL dalStaffGrievance = new StaffGrievanceDAL();
            return dalStaffGrievance.SelectAllByStaffID(StaffID);
        }
        #endregion SelectAllByStaffID

        #region SelectRegisteredByStaffID
        public DataTable SelectRegisteredByStaffID(SqlInt32 StaffID)
        {
            StaffGrievanceDAL dalStaffGrievance = new StaffGrievanceDAL();
            return dalStaffGrievance.SelectRegisteredByStaffID(StaffID);
        }
        #endregion SelectRegisteredByStaffID

        #region SelectInProgressByStaffID
        public DataTable SelectInProgressByStaffID(SqlInt32 StaffID)
        {
            StaffGrievanceDAL dalStaffGrievance = new StaffGrievanceDAL();
            return dalStaffGrievance.SelectInProgressByStaffID(StaffID);
        }
        #endregion SelectInProgressByStaffID

        #region SelectResolveByStaffID
        public DataTable SelectResolveByStaffID(SqlInt32 StaffID)
        {
            StaffGrievanceDAL dalStaffGrievance = new StaffGrievanceDAL();
            return dalStaffGrievance.SelectResolveByStaffID(StaffID);
        }
        #endregion SelectResolveByStaffID

        #region SelectRejectedByStaffID
        public DataTable SelectRejectedByStaffID(SqlInt32 StaffID)
        {
            StaffGrievanceDAL dalStaffGrievance = new StaffGrievanceDAL();
            return dalStaffGrievance.SelectRejectedByStaffID(StaffID);
        }
        #endregion SelectRejectedByStaffID

        #region SelectForDropDownList
        public DataTable SelectForDropDownList()
        {
            StaffGrievanceDAL dalStaffGrievance = new StaffGrievanceDAL();
            return dalStaffGrievance.SelectForDropDownList();
        }
        #endregion SelectForDropDownList

        #region SelectByPK
        public StaffGrievanceENT SelectByPK(SqlInt32 StaffGrievanceID)
        {
            StaffGrievanceDAL dalStaffGrievance = new StaffGrievanceDAL();
            return dalStaffGrievance.SelectByPK(StaffGrievanceID);
        }
        #endregion SelectByPK

        #region Counters

        #region CountAll
        public Int32 Count()
        {
            StaffGrievanceDAL dalStaffGrievance = new StaffGrievanceDAL();
            return dalStaffGrievance.Count();
        }
        #endregion CountAll

        #region CountAllByPK
        public Int32 CountAllByPK(SqlInt32 StaffID)
        {
            StaffGrievanceDAL dalStaffGrievance = new StaffGrievanceDAL();
            return dalStaffGrievance.CountAllByPK(StaffID);
        }
        #endregion CountAllByPK

        #region CountRegisteredByPK
        public Int32 CountRegisteredByPK(SqlInt32 StaffID)
        {
            StaffGrievanceDAL dalStaffGrievance = new StaffGrievanceDAL();
            return dalStaffGrievance.CountRegisteredByPK(StaffID);
        }
        #endregion CountRegisteredByPK

        #region CountInProgressByPK
        public Int32 CountInProgressByPK(SqlInt32 StaffID)
        {
            StaffGrievanceDAL dalStaffGrievance = new StaffGrievanceDAL();
            return dalStaffGrievance.CountInProgressByPK(StaffID);
        }
        #endregion CountInProgressByPK

        #region CountResolveByPK
        public Int32 CountResolveByPK(SqlInt32 StaffID)
        {
            StaffGrievanceDAL dalStaffGrievance = new StaffGrievanceDAL();
            return dalStaffGrievance.CountResolveByPK(StaffID);
        }
        #endregion CountResolveByPK

        #region CountRejectedByPK
        public Int32 CountRejectedByPK(SqlInt32 StaffID)
        {
            StaffGrievanceDAL dalStaffGrievance = new StaffGrievanceDAL();
            return dalStaffGrievance.CountRejectedByPK(StaffID);
        }
        #endregion CountRejectedByPK

        #endregion Counters

        #endregion Select Operation
    }
}