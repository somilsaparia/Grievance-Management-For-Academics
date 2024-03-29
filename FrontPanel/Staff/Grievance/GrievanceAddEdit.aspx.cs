using GrievanceSystem;
using GrievanceSystem.BAL;
using GrievanceSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontPanel_Staff_Grievance_GrievanceAddEdit : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Check Valid User
        if (Session["StaffID"] == null)
        {
            Response.Redirect("~/AdminPanel/Login.aspx");
        }
        #endregion Check Valid User

        #region Page Not Post Back
        if (!Page.IsPostBack)
        {
            FillDropDownListGrievance();
            if (Request.QueryString["StaffGrievanceID"] == null)
            {
                lblPageTittle.Text = "Grievance Add";
                lblCardTitle.Text = lblPageTittle.Text;
                lblBreadcrumb.Text = lblPageTittle.Text;
                btnSubmit.Text = "Submit";
            }
            else
            {
                if (Convert.ToInt32(Request.QueryString["Enable"]) == 1)
                {
                    lblPageTittle.Text = "Grievance Edit";
                    lblCardTitle.Text = lblPageTittle.Text;
                    lblBreadcrumb.Text = lblPageTittle.Text;
                    btnSubmit.Text = "Update";
                    FillControls(Convert.ToInt32(Request.QueryString["StaffGrievanceID"]));
                    pnlEdit.Visible = true;
                }
                else
                {
                    lblPageTittle.Text = "Grievance Details";
                    lblCardTitle.Text = lblPageTittle.Text;
                    lblBreadcrumb.Text = lblPageTittle.Text;
                    ddlGrievanceName.Enabled = false;
                    txtGrievanceDescription.ReadOnly = true;
                    btnEdit.Visible = true;
                    btnSubmit.Visible = false;
                    btnClear.Visible = false;
                    FillControls(Convert.ToInt32(Request.QueryString["StaffGrievanceID"]));
                    pnlEdit.Visible = true;
                }
            }
        }
        #endregion Page Not Post Back
    }
    #endregion Page Load

    #region Button: Edit - Click
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        int GrievanceID = Convert.ToInt32(Request.QueryString["StaffGrievanceID"]);
        Response.Redirect("~/FrontPanel/Staff/Grievance/GrievanceAddEdit.aspx?Enable=1&StaffGrievanceID=" + GrievanceID);
    }
    #endregion Button: Edit - Click

    #region Button: Submit - Click
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        #region Local Variables
        string strErrorMessage = "";
        #endregion Local Variables

        #region Server Side Validation
        if (txtGrievanceDescription.Text.Trim() == "")
        {
            strErrorMessage += "Please enter Grievance Description <br />";
        }

        if (ddlGrievanceName.SelectedIndex == 0)
        {
            strErrorMessage += "Please select Grievance <br />";
        }

        if (strErrorMessage.Trim() != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            pnlErrorMessage.Visible = true;
            return;
        }
        #endregion Server Side Validation

        #region Collect Form Data
        StaffGrievanceENT entStaffGrievance = new StaffGrievanceENT();

        if (Session["StaffID"] != null)
            entStaffGrievance.StaffID = Convert.ToInt32(Session["StaffID"]);

        if (txtGrievanceDescription.Text.Trim() != "")
            entStaffGrievance.GrievanceDescription = txtGrievanceDescription.Text.Trim();

        if (ddlGrievanceName.SelectedIndex > 0)
            entStaffGrievance.GrievanceID = Convert.ToInt32(ddlGrievanceName.SelectedValue);

        #endregion Collect Form Data

        #region Insert
        StaffGrievanceBAL balStaffGrievance = new StaffGrievanceBAL();

        if (Request.QueryString["StaffGrievanceID"] == null)
        {
            if (balStaffGrievance.Insert(entStaffGrievance))
            {
                ClearControls();
                lblSuccessMessage.Text = "Data Inserted Successfully";
                pnlSuccessMessage.Visible = true;
            }
            else
            {
                lblErrorMessage.Text = balStaffGrievance.Message;
                pnlErrorMessage.Visible = true;
            }
        }
        else
        {
            entStaffGrievance.StaffGrievanceID = Convert.ToInt32(Request.QueryString["StaffGrievanceID"]);

            if (balStaffGrievance.UpdateByPK(entStaffGrievance))
            {
                ClearControls();
                Response.Redirect("~/FrontPanel/Staff/Grievance/GrievanceList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balStaffGrievance.Message;
                pnlErrorMessage.Visible = true;
            }
        }
        #endregion Insert
    }
    #endregion Button: Submit - Click

    #region Button: Back - Click
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/FrontPanel/Staff/Grievance/GrievanceList.aspx");
    }
    #endregion Button: Back - Click

    #region Button: Reset - Click
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtGrievanceDescription.Text = "";
        txtGrievanceStatus.Text = "";
        txtGrievanceDate.Text = "";
        txtGrievanceUpdateDate.Text = "";
        ddlGrievanceName.SelectedIndex = 0;

        ddlGrievanceName.Focus();
    }
    #endregion Button: Reset - Click

    #region Clear Controls
    private void ClearControls()
    {
        txtGrievanceDescription.Text = "";
        txtGrievanceStatus.Text = "";
        txtGrievanceDate.Text = "";
        txtGrievanceUpdateDate.Text = "";
        ddlGrievanceName.SelectedIndex = 0;

        ddlGrievanceName.Focus();
    }
    #endregion Clear Controls

    #region Fill Controls
    private void FillControls(SqlInt32 StaffGrievanceID)
    {
        StaffGrievanceENT entStaffGrievance = new StaffGrievanceENT();
        StaffGrievanceBAL balStaffGrievance = new StaffGrievanceBAL();

        entStaffGrievance = balStaffGrievance.SelectByPK(StaffGrievanceID);

        if (!entStaffGrievance.GrievanceDescription.IsNull)
            txtGrievanceDescription.Text = entStaffGrievance.GrievanceDescription.Value.ToString();

        if (!entStaffGrievance.GrievanceID.IsNull)
            ddlGrievanceName.SelectedValue = entStaffGrievance.GrievanceID.Value.ToString();

        if (!entStaffGrievance.GrievanceDate.IsNull)
            txtGrievanceDate.Text = entStaffGrievance.GrievanceDate.Value.ToString();

        if (!entStaffGrievance.GrievanceUpdateDate.IsNull)
            txtGrievanceUpdateDate.Text = entStaffGrievance.GrievanceUpdateDate.Value.ToString();

        if (!entStaffGrievance.GrievanceStatus.IsNull)
        {
            txtGrievanceStatus.Text = entStaffGrievance.GrievanceStatus.Value.ToString();
            if (txtGrievanceStatus.Text.ToString() == "Rejected" || txtGrievanceStatus.Text.ToString() == "Resolved"
                || txtGrievanceStatus.Text.ToString() == "In-Progress" || txtGrievanceUpdateDate.Text.ToString() != "")
            {
                btnEdit.Visible = false;
            }
        }
    }
    #endregion Fill Controls

    #region FillDropDownList - Grievance
    public void FillDropDownListGrievance()
    {
        CommonFillMethods.FillDropDownListGrievance(ddlGrievanceName);
    }
    #endregion FillDorpDownList - Grievance
}