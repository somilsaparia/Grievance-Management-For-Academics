using GrievanceSystem.BAL;
using GrievanceSystem.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontPanel_Staff_StaffProfile : System.Web.UI.Page
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
            lblPageTittle.Text = "Staff Profile";
            lblCardTitle.Text = "Staff Profile";
            lblBreadcrumb.Text = "Staff Profile";
            FillStaffDetails();
        }
        #endregion Page Not Post Back
    }
    #endregion Page Load

    #region Button: Back
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/FrontPanel/Staff/Default.aspx");
    }
    #endregion button: Back

    #region Fill Staff Details
    protected void FillStaffDetails()
    {
        StaffENT entStaff = new StaffENT();
        StaffBAL balStaff = new StaffBAL();

        entStaff = balStaff.SelectByPK(Convert.ToInt32(Session["StaffID"]));

        if (!entStaff.StaffFirstName.IsNull)
            lblFirstNameDetail.Text = entStaff.StaffFirstName.Value.ToString();

        if (!entStaff.StaffMiddleName.IsNull)
            lblMiddleNameDetail.Text = entStaff.StaffMiddleName.Value.ToString();

        if (!entStaff.StaffLastName.IsNull)
            lblLastNameDetail.Text = entStaff.StaffLastName.Value.ToString();

        if (!entStaff.StaffCode.IsNull)
            lblCodeDetail.Text = entStaff.StaffCode.Value.ToString();

        if (!entStaff.StaffMobileNumber.IsNull)
            lblMobileNumberDetail.Text = entStaff.StaffMobileNumber.Value.ToString();

        if (!entStaff.StaffPersonalEmailAddress.IsNull)
            lblPersonalEmailAddressDetail.Text = entStaff.StaffPersonalEmailAddress.Value.ToString();

        if (!entStaff.StaffCollegeEmailAddress.IsNull)
            lblCollegeEmailAddressDetail.Text = entStaff.StaffCollegeEmailAddress.Value.ToString();

        if (!entStaff.StaffJoiningYear.IsNull)
            lblJoiningYearDetail.Text = entStaff.StaffJoiningYear.Value.ToString();
    }
    #endregion Fill Staff Details
}