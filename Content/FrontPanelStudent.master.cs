using GrievanceSystem.BAL;
using GrievanceSystem.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_FrontPanelStudent : System.Web.UI.MasterPage
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        getStudentName();
    }
    #endregion Page Load

    #region Button - Logout
    protected void lbLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("~/AdminPanel/Login.aspx");
    }
    #endregion Button - Logout

    #region getStudentName
    protected void getStudentName()
    {
        StudentENT entStudent = new StudentENT();
        StudentBAL balStudent = new StudentBAL();

        entStudent = balStudent.SelectByPK(Convert.ToInt32(Session["StudentID"]));

        if (!entStudent.StudentFirstName.IsNull)
            lblStudentFirstName.Text = entStudent.StudentFirstName.Value.ToString();

        if (!entStudent.StudentLastName.IsNull)
            lblStudentLastName.Text = entStudent.StudentLastName.Value.ToString();
    }
    #endregion getStudentName
}
