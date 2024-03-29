using GrievanceSystem.DAL;
using GrievanceSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GrievanceBAL
/// </summary>
namespace GrievanceSystem.BAL
{
    public class GrievanceBAL
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
        public GrievanceBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(GrievanceENT entGrievance)
        {
            GrievanceDAL dalGrievance = new GrievanceDAL();
            if (dalGrievance.Insert(entGrievance))
            {
                return true;
            }
            else
            {
                Message = dalGrievance.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(GrievanceENT entGrievance)
        {
            GrievanceDAL dalGrievance = new GrievanceDAL();
            if (dalGrievance.Update(entGrievance))
            {
                return true;
            }
            else
            {
                Message = dalGrievance.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 GrievanceID)
        {
            GrievanceDAL dalGrievance = new GrievanceDAL();

            if (dalGrievance.Delete(GrievanceID))
            {
                return true;
            }
            else
            {
                Message = dalGrievance.Message;
                return false;
            }
        }
        #endregion Delete Operation

        #region Select Operation

        #region SelectAll
        public DataTable SelectAll()
        {
            GrievanceDAL dalGrievance = new GrievanceDAL();
            return dalGrievance.SelectAll();
        }
        #endregion SelectAll

        #region SelectForDropDownList
        public DataTable SelectForDropDownList()
        {
            GrievanceDAL dalGrievance = new GrievanceDAL();
            return dalGrievance.SelectForDropDownList();
        }
        #endregion SelectForDropDownList

        #region SelectByPK
        public GrievanceENT SelectByPK(SqlInt32 GrievanceID)
        {
            GrievanceDAL dalGrievance = new GrievanceDAL();
            return dalGrievance.SelectByPK(GrievanceID);
        }
        #endregion SelectByPK

        #region Count
        public Int32 Count()
        {
            GrievanceDAL dalGrievance = new GrievanceDAL();
            return dalGrievance.Count();
        }
        #endregion Count

        #endregion Select Operation
    }
}