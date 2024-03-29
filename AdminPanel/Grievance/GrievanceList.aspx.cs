using GrievanceSystem.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Grievance_GrievanceList : System.Web.UI.Page
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
            lblPageTittle.Text = "Grievance List";
            lblCardTitle.Text = lblPageTittle.Text;
            lblBreadcrumb.Text = lblPageTittle.Text;
            FillGridViewGrievance();
        }
        #endregion Page Not post Back
    }
    #endregion Page Load

    #region Fill Grievance GridView
    private void FillGridViewGrievance()
    {
        GrievanceBAL balGrievance = new GrievanceBAL();
        DataTable dtGrievance = new DataTable();

        dtGrievance = balGrievance.SelectAll();

        if (dtGrievance != null && dtGrievance.Rows.Count > 0)
        {
            gvGrievance.DataSource = dtGrievance;
            gvGrievance.DataBind();
            upnlGrievanceList.Visible = true;
            upnlNoDataFound.Visible = false;
        }
        else
        {
            upnlGrievanceList.Visible = false;
            upnlNoDataFound.Visible = true;
        }
    }
    #endregion Fill Grievance GridView

    #region GridView: Grievance - RowCommand
    protected void gvGrievance_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                GrievanceBAL balGrievance = new GrievanceBAL();
                if (balGrievance.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    lblSuccessMessage.Text = "Grievance Deleted Successfully";
                    pnlSuccessMessage.Visible = true;
                    Response.Redirect("~/AdminPanel/Grievance/GrievanceList.aspx");
                }
                else
                {
                    lblErrorMessage.Text = balGrievance.Message;
                }
            }
        }
    }
    #endregion GridView: Grievance - RowCommand

    #region Button Add - Click
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Grievance/GrievanceAddEdit.aspx");
    }
    #endregion Button Add - Click
}