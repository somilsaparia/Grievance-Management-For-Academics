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

public partial class FrontPanel_Student_Grievance_GrievanceAddEdit : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Check Valid User
        if (Session["StudentID"] == null)
        {
            Response.Redirect("~/AdminPanel/Login.aspx");
        }
        #endregion Check Valid User

        #region Page Not Post Back
        if (!Page.IsPostBack)
        {
            FillDropDownListGrievance();
            if (Request.QueryString["StudentGrievanceID"] == null)
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
                    FillControls(Convert.ToInt32(Request.QueryString["StudentGrievanceID"]));
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
                    FillControls(Convert.ToInt32(Request.QueryString["StudentGrievanceID"]));
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
        int GrievanceID = Convert.ToInt32(Request.QueryString["StudentGrievanceID"]);
        Response.Redirect("~/FrontPanel/Student/Grievance/GrievanceAddEdit.aspx?Enable=1&StudentGrievanceID=" +GrievanceID);
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
        StudentGrievanceENT entStudentGrievance = new StudentGrievanceENT();

        if (Session["StudentID"] != null)
            entStudentGrievance.StudentID = Convert.ToInt32(Session["StudentID"]);

        if (txtGrievanceDescription.Text.Trim() != "")
            entStudentGrievance.GrievanceDescription = txtGrievanceDescription.Text.Trim();

        if (ddlGrievanceName.SelectedIndex > 0)
            entStudentGrievance.GrievanceID = Convert.ToInt32(ddlGrievanceName.SelectedValue);

        #endregion Collect Form Data

        #region Insert
        StudentGrievanceBAL balStudentGrievance = new StudentGrievanceBAL();

        if (Request.QueryString["StudentGrievanceID"] == null)
        {
            if (balStudentGrievance.Insert(entStudentGrievance))
            {
                ClearControls();
                lblSuccessMessage.Text = "Data Inserted Successfully";
                pnlSuccessMessage.Visible = true;
            }
            else
            {
                lblErrorMessage.Text = balStudentGrievance.Message;
                pnlErrorMessage.Visible = true;
            }
        }
        else
        {
            entStudentGrievance.StudentGrievanceID = Convert.ToInt32(Request.QueryString["StudentGrievanceID"]);

            if (balStudentGrievance.UpdateByPK(entStudentGrievance))
            {
                ClearControls();
                Response.Redirect("~/FrontPanel/Student/Grievance/GrievanceList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balStudentGrievance.Message;
                pnlErrorMessage.Visible = true;
            }
        }
        #endregion Insert
    }
    #endregion Button: Submit - Click

    #region Button: Back - Click
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/FrontPanel/Student/Grievance/GrievanceList.aspx");
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
    private void FillControls(SqlInt32 StudentGrievanceID)
    {
        StudentGrievanceENT entStudentGrievance = new StudentGrievanceENT();
        StudentGrievanceBAL balStudentGrievance = new StudentGrievanceBAL();

        entStudentGrievance = balStudentGrievance.SelectByPK(StudentGrievanceID);

        if (!entStudentGrievance.GrievanceDescription.IsNull)
            txtGrievanceDescription.Text = entStudentGrievance.GrievanceDescription.Value.ToString();

        if (!entStudentGrievance.GrievanceID.IsNull)
            ddlGrievanceName.SelectedValue = entStudentGrievance.GrievanceID.Value.ToString();

        if (!entStudentGrievance.GrievanceDate.IsNull)
            txtGrievanceDate.Text = entStudentGrievance.GrievanceDate.Value.ToString();

        if (!entStudentGrievance.GrievanceUpdateDate.IsNull)
            txtGrievanceUpdateDate.Text = entStudentGrievance.GrievanceUpdateDate.Value.ToString();

        if (!entStudentGrievance.GrievanceStatus.IsNull)
        {
            txtGrievanceStatus.Text = entStudentGrievance.GrievanceStatus.Value.ToString();
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