using GrievanceSystem.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontPanel_Staff_Default : System.Web.UI.Page
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
            lblPageTittle.Text = "Home";
            AllGrievance();
            RegisteredGrievance();
            InProgressGrievance();
            ResolveGrievance();
            RejectedGrievance();
        }
        #endregion Page Not Post Back
    }
    #endregion Page Load

    #region Counters

    #region AllGrievance
    private void AllGrievance()
    {
        StaffGrievanceBAL balStaffGrievance = new StaffGrievanceBAL();

        int Count = balStaffGrievance.CountAllByPK(Convert.ToInt32(Session["StaffID"]));
        lblTotalGrievance.Text = Count.ToString();
    }
    #endregion TotalGrievance

    #region RegisteredGrievance
    private void RegisteredGrievance()
    {
        StaffGrievanceBAL balStaffGrievance = new StaffGrievanceBAL();

        int Count = balStaffGrievance.CountRegisteredByPK(Convert.ToInt32(Session["StaffID"]));
        lblRegisteredGrievance.Text = Count.ToString();
    }
    #endregion RegisteredGrievance

    #region InProgressGrievance
    private void InProgressGrievance()
    {
        StaffGrievanceBAL balStaffGrievance = new StaffGrievanceBAL();

        int Count = balStaffGrievance.CountInProgressByPK(Convert.ToInt32(Session["StaffID"]));
        lblInProgressGrievance.Text = Count.ToString();
    }
    #endregion InProgressGrievance

    #region ResolveGrievance
    private void ResolveGrievance()
    {
        StaffGrievanceBAL balStaffGrievance = new StaffGrievanceBAL();

        int Count = balStaffGrievance.CountResolveByPK(Convert.ToInt32(Session["StaffID"]));
        lblResolveGrievance.Text = Count.ToString();
    }
    #endregion ResolveGrievance

    #region RejectedGrievance
    private void RejectedGrievance()
    {
        StaffGrievanceBAL balStaffGrievance = new StaffGrievanceBAL();

        int Count = balStaffGrievance.CountRejectedByPK(Convert.ToInt32(Session["StaffID"]));
        lblRejectedGrievance.Text = Count.ToString();
    }
    #endregion RejectedGrievance

    #endregion Counter
}