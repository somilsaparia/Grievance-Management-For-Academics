using GrievanceSystem.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Staff_StaffList : System.Web.UI.Page
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
            lblPageTittle.Text = "Staff List";
            lblCardTitle.Text = lblPageTittle.Text;
            lblBreadcrumb.Text = lblPageTittle.Text;
            FillGridViewStaff();
        }
        #endregion Page Not post Back
    }
    #endregion Page Load

    #region Fill Staff GridView
    private void FillGridViewStaff()
    {
        StaffBAL balStaff = new StaffBAL();
        DataTable dtStaff = new DataTable();

        dtStaff = balStaff.SelectAll();

        if (dtStaff != null && dtStaff.Rows.Count > 0)
        {
            gvStaff.DataSource = dtStaff;
            gvStaff.DataBind();
            upnlStaffList.Visible = true;
            upnlNoDataFound.Visible = false;
        }
        else
        {
            upnlStaffList.Visible = false;
            upnlNoDataFound.Visible = true;
        }
    }
    #endregion Fill Staff GridView

    #region GridView: Staff - RowCommand
    protected void gvStaff_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                StaffLoginDetailBAL balStudentLoginDetail = new StaffLoginDetailBAL();
                StaffBAL balStaff = new StaffBAL();

                if (balStudentLoginDetail.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    if (balStaff.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                    {
                        lblSuccessMessage.Text = "Staff Deleted Successfully";
                        pnlSuccessMessage.Visible = true;
                        Response.Redirect("~/AdminPanel/Staff/StaffList.aspx");
                    }
                }
                else
                {
                    lblErrorMessage.Text = balStudentLoginDetail.Message;
                    lblErrorMessage.Text = balStaff.Message;
                }
            }
        }
    }
    #endregion GridView: Staff - RowCommand

    #region Button Add - Click
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Staff/StaffAddEdit.aspx");
    }
    #endregion Button Add - Click
}