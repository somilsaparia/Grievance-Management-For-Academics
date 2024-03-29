using GrievanceSystem.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Department_DepartmentList : System.Web.UI.Page
{
    #region Page load
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
            lblPageTittle.Text = "Department List";
            lblCardTitle.Text = lblPageTittle.Text;
            lblBreadcrumb.Text = lblPageTittle.Text;
            FillGridViewDepartment();
        }
        #endregion Page Not post Back
    }
    #endregion Page Load

    #region Fill Department GridView
    private void FillGridViewDepartment()
    {
        DepartmentBAL balDepartment = new DepartmentBAL();
        DataTable dtDepartment = new DataTable();

        dtDepartment = balDepartment.SelectAll();

        if (dtDepartment != null && dtDepartment.Rows.Count > 0)
        {
            gvDepartment.DataSource = dtDepartment;
            gvDepartment.DataBind();
            upnlDepartmentList.Visible = true;
            upnlNoDataFound.Visible = false;
        }
        else
        {
            upnlDepartmentList.Visible = false;
            upnlNoDataFound.Visible = true;
        }
    }
    #endregion Fill Department GridView

    #region GridView: Department - RowCommand
    protected void gvDepartment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                DepartmentBAL balDepartment = new DepartmentBAL();
                if (balDepartment.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    lblSuccessMessage.Text = "Department Deleted Successfully";
                    pnlSuccessMessage.Visible = true;
                    Response.Redirect("~/AdminPanel/Department/DepartmentList.aspx");
                }
                else
                {
                    lblErrorMessage.Text = balDepartment.Message;
                }
            }
        }
    }
    #endregion GridView: Department - RowCommand

    #region Button Add - Click
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Department/DepartmentAddEdit.aspx");
    }
    #endregion Button Add - Click
}