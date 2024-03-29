using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GrievanceENT
/// </summary>
namespace GrievanceSystem.ENT
{
    public class GrievanceENT
    {
        #region Constructor
        public GrievanceENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

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

        #region GrievanceName
        protected SqlString _GrievanceName;

        public SqlString GrievanceName
        {
            get
            {
                return _GrievanceName;
            }
            set
            {
                _GrievanceName = value;
            }
        }
        #endregion GrievanceName
    }
}