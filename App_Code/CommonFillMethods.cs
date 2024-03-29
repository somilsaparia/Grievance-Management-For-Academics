using GrievanceSystem.BAL;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CommonFillMethods
/// </summary>
namespace GrievanceSystem
{
    public class CommonFillMethods
    {
        #region Constructor
        public CommonFillMethods()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region FillDropDownList - Course
        public static void FillDropDownListCourse(DropDownList ddl)
        {
            CourseBAL balCourse = new CourseBAL();
            ddl.DataSource = balCourse.SelectForDropDownList();
            ddl.DataValueField = "CourseID";
            ddl.DataTextField = "CourseName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Course", "-1"));
        }
        #endregion FillDropDownList - BloodGroup

        #region FillDropDownList - Department
        public static void FillDropDownListDepartment(DropDownList ddl)
        {
            DepartmentBAL balDepartment = new DepartmentBAL();
            ddl.DataSource = balDepartment.SelectForDropDownList();
            ddl.DataValueField = "DepartmentID";
            ddl.DataTextField = "DepartmentName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Department", "-1"));
        }
        #endregion FillDropDownList - Department

        #region FillDropDownList - Department By CourseID
        public static void FillDropDownListDepartmentByCourseID(DropDownList ddl, SqlInt32 CourseID)
        {
            DepartmentBAL balDepartment = new DepartmentBAL();
            ddl.DataSource = balDepartment.SelectForDropDownListByCourseID(CourseID);
            ddl.DataValueField = "DepartmentID";
            ddl.DataTextField = "DepartmentName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Department", "-1"));
        }
        #endregion FillDropDownList - Department By CourseID

        #region FillDropDownList - Semester By DepartmentID
        public static void FillDropDownListSemesterByDepartmentID(DropDownList ddl, SqlInt32 DepartmentID)
        {
            SemesterBAL balSemester = new SemesterBAL();
            ddl.DataSource = balSemester.SelectForDropDownListByDepartmentID(DepartmentID);
            ddl.DataValueField = "SemesterID";
            ddl.DataTextField = "SemesterNumber";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Semester", "-1"));
        }
        #endregion FillDropDownList - Semester By DepartmentID

        #region FillDropDownList - Grievance
        public static void FillDropDownListGrievance(DropDownList ddl)
        {
            GrievanceBAL balGrievance = new GrievanceBAL();
            ddl.DataSource = balGrievance.SelectForDropDownList();
            ddl.DataValueField = "GrievanceID";
            ddl.DataTextField = "GrievanceName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Grievance", "-1"));
        }
        #endregion FillDropDownList - Grievance

        #region FillDropDownList - Empty
        public static void FillDropDownListEmpty(DropDownList ddl, String DropDownListName)
        {
            ddl.Items.Clear();
            ddl.Items.Insert(0, new ListItem("Select " + DropDownListName, "-1"));
        }
        #endregion FillDropDownList - Empty
    }
}