using GrievanceSystem.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Student_StudentList : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Check Valid User
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/AdminPanel/Login.aspx");
        }
        #endregion Check Valid User

        #region Page Not post Back
        if (!Page.IsPostBack)
        {
            lblPageTittle.Text = "Student List";
            lblCardTitle.Text = lblPageTittle.Text;
            lblBreadcrumb.Text = lblPageTittle.Text;
            FillGridViewStudent();
        }
        #endregion Page Not post Back
    }
    #endregion Page Load

    #region Fill Student GridView
    private void FillGridViewStudent()
    {
        StudentBAL balStudent = new StudentBAL();
        DataTable dtStudent = new DataTable();

        dtStudent = balStudent.SelectAll();

        if (dtStudent != null && dtStudent.Rows.Count > 0)
        {
            gvStudent.DataSource = dtStudent;
            gvStudent.DataBind();
            upnlStudentList.Visible = true;
            upnlNoDataFound.Visible = false;
        }
        else
        {
            upnlStudentList.Visible = false;
            upnlNoDataFound.Visible = true;
        }
    }
    #endregion Fill Student GridView

    #region GridView: Student - RowCommand
    protected void gvStudent_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                StudentLoginDetailBAL balStudentLoginDetail = new StudentLoginDetailBAL();
                StudentBAL balStudent = new StudentBAL();

                if (balStudentLoginDetail.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    if (balStudent.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                    {
                        lblSuccessMessage.Text = "Student Deleted Successfully";
                        pnlSuccessMessage.Visible = true;
                        Response.Redirect("~/AdminPanel/Student/StudentList.aspx");
                    }
                }
                else
                {
                    lblErrorMessage.Text = balStudentLoginDetail.Message;
                    lblErrorMessage.Text = balStudent.Message;
                }
            }
        }
    }
    #endregion GridView: Student - RowCommand

    #region Button Add - Click
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Student/StudentAddEdit.aspx");
    }
    #endregion Button Add - Click
}