using GrievanceSystem.BAL;
using GrievanceSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Grievance_GrievanceAddEdit : System.Web.UI.Page
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

        #region Page Not Post Back
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["GrievanceID"] == null)
            {
                lblPageTittle.Text = "Grievance Add";
                lblCardTitle.Text = lblPageTittle.Text;
                lblBreadcrumb.Text = lblPageTittle.Text;
                btnSubmit.Text = "Submit";
            }
            else
            {
                lblPageTittle.Text = "Grievance Edit";
                lblCardTitle.Text = lblPageTittle.Text;
                lblBreadcrumb.Text = lblPageTittle.Text;
                btnSubmit.Text = "Update";
                FillControls(Convert.ToInt32(Request.QueryString["GrievanceID"]));
            }
        }
        #endregion Page Not Post Back
    }
    #endregion Page Load

    #region Button: Submit - Click
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        #region Local Variables
        string strErrorMessage = "";
        #endregion Local Variables

        #region Server Side Validation
        if (txtGrievanceName.Text.Trim() == "")
        {
            strErrorMessage += "Please enter Grievance Name <br />";
        }
        #endregion Server Side Validation

        #region Collect Form Data
        GrievanceENT entGrievance = new GrievanceENT();

        if (txtGrievanceName.Text.Trim() != "")
            entGrievance.GrievanceName = txtGrievanceName.Text.Trim();
        #endregion Collect Form Data

        #region Insert
        GrievanceBAL balGrievance = new GrievanceBAL();

        if (Request.QueryString["GrievanceID"] == null)
        {
            if (balGrievance.Insert(entGrievance))
            {
                ClearControls();
                lblSuccessMessage.Text = "Data Inserted Successfully";
                pnlSuccessMessage.Visible = true;
            }
            else
            {
                lblErrorMessage.Text = balGrievance.Message;
                pnlErrorMessage.Visible = true;
            }
        }
        else
        {
            entGrievance.GrievanceID = Convert.ToInt32(Request.QueryString["GrievanceID"]);

            if (balGrievance.Update(entGrievance))
            {
                ClearControls();
                Response.Redirect("~/AdminPanel/Grievance/GrievanceList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balGrievance.Message;
                pnlErrorMessage.Visible = true;
            }
        }
        #endregion Insert
    }
    #endregion Button: Submit - Click

    #region Button: Back - Click
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Grievance/GrievanceList.aspx");
    }
    #endregion Button: Back - Click

    #region Button: Reset - Click
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtGrievanceName.Text = "";

        txtGrievanceName.Focus();
    }
    #endregion Button: Reset - Click

    #region Clear Controls
    private void ClearControls()
    {
        txtGrievanceName.Text = "";

        txtGrievanceName.Focus();
    }
    #endregion Clear Controls

    #region Fill Controls
    private void FillControls(SqlInt32 GrievanceID)
    {
        GrievanceENT entGrievance = new GrievanceENT();
        GrievanceBAL balGrievance = new GrievanceBAL();

        entGrievance = balGrievance.SelectByPK(GrievanceID);

        if (!entGrievance.GrievanceName.IsNull)
            txtGrievanceName.Text = entGrievance.GrievanceName.Value.ToString();
    }
    #endregion Fill Controls
}