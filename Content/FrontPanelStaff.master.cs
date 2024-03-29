using GrievanceSystem.BAL;
using GrievanceSystem.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_FrontPanel : System.Web.UI.MasterPage
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        getStaffName();
    }
    #endregion Page Load

    #region Button - Logout
    protected void lbLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("~/AdminPanel/Login.aspx");
    }
    #endregion Button - Logout

    #region getStaffName
    protected void getStaffName()
    {
        StaffENT entStaff = new StaffENT();
        StaffBAL balStaff = new StaffBAL();

        entStaff = balStaff.SelectByPK(Convert.ToInt32(Session["StaffID"]));

        if (!entStaff.StaffFirstName.IsNull)
            lblStaffFirstName.Text = entStaff.StaffFirstName.Value.ToString();

        if (!entStaff.StaffLastName.IsNull)
            lblStaffLastName.Text = entStaff.StaffLastName.Value.ToString();
    }
    #endregion getStaffName
}
