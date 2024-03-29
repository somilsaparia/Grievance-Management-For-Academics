using GrievanceSystem.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontPanel_Student_Default : System.Web.UI.Page
{
    #region Page load
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
        StudentGrievanceBAL balStudentGrievance = new StudentGrievanceBAL();

        int Count = balStudentGrievance.CountAllByPK(Convert.ToInt32(Session["StudentID"]));
        lblTotalGrievance.Text = Count.ToString();
    }
    #endregion TotalGrievance

    #region RegisteredGrievance
    private void RegisteredGrievance()
    {
        StudentGrievanceBAL balStudentGrievance = new StudentGrievanceBAL();

        int Count = balStudentGrievance.CountRegisteredByPK(Convert.ToInt32(Session["StudentID"]));
        lblRegisteredGrievance.Text = Count.ToString();
    }
    #endregion RegisteredGrievance

    #region InProgressGrievance
    private void InProgressGrievance()
    {
        StudentGrievanceBAL balStudentGrievance = new StudentGrievanceBAL();

        int Count = balStudentGrievance.CountInProgressByPK(Convert.ToInt32(Session["StudentID"]));
        lblInProgressGrievance.Text = Count.ToString();
    }
    #endregion InProgressGrievance

    #region ResolveGrievance
    private void ResolveGrievance()
    {
        StudentGrievanceBAL balStudentGrievance = new StudentGrievanceBAL();

        int Count = balStudentGrievance.CountResolveByPK(Convert.ToInt32(Session["StudentID"]));
        lblResolveGrievance.Text = Count.ToString();
    }
    #endregion ResolveGrievance

    #region RejectedGrievance
    private void RejectedGrievance()
    {
        StudentGrievanceBAL balStudentGrievance = new StudentGrievanceBAL();

        int Count = balStudentGrievance.CountRejectedByPK(Convert.ToInt32(Session["StudentID"]));
        lblRejectedGrievance.Text = Count.ToString();
    }
    #endregion RejectedGrievance

    #endregion Counter
}