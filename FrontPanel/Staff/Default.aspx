<%@ Page Title="" Language="C#" MasterPageFile="~/Content/FrontPanelStaff.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="FrontPanel_Staff_Default" %>

<asp:Content ID="ContentTitle" ContentPlaceHolderID="cphTitle" runat="Server">
    Home
</asp:Content>

<asp:Content ID="ContentHead" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>

<asp:Content ID="ContentPageTitle" ContentPlaceHolderID="cphpageTitle" runat="server">
    <asp:Label ID="lblPageTittle" runat="server"></asp:Label>
</asp:Content>

<asp:Content ID="ContentBreadcrumb" ContentPlaceHolderID="cphBreadcrumb" runat="server">
</asp:Content>

<asp:Content ID="ContentContent" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="row">
        <div class="col-md-6 col-lg-2 col-xlg-3">
            <div class="card card-hover">
                <asp:HyperLink ID="hlTotalGrievance" runat="server" NavigateUrl="~/FrontPanel/Staff/Grievance/GrievanceList.aspx">
                    <div class="box bg-cyan text-center">
                        <h1 class="font-light text-white"><i class="mdi mdi-receipt"></i></h1>
                        <h6 class="text-white">Total Grievance</h6>
                        <span class="text-white counter-value"><asp:Label ID="lblTotalGrievance" runat="server"></asp:Label></span>
                    </div>
                </asp:HyperLink>
            </div>
        </div>

        <div class="col-md-6 col-lg-2 col-xlg-3">
            <div class="card card-hover">
                <asp:HyperLink ID="hlRegisteredGrievance" runat="server" NavigateUrl="~/FrontPanel/Staff/Grievance/GrievanceList.aspx">
                    <div class="box bg-success text-center">
                        <h1 class="font-light text-white"><i class="mdi mdi-receipt"></i></h1>
                        <h6 class="text-white">New Grievance</h6>
                        <span class="text-white counter-value ">
                            <asp:Label ID="lblRegisteredGrievance" runat="server"></asp:Label></span>
                    </div>
                </asp:HyperLink>
            </div>
        </div>

        <div class="col-md-6 col-lg-4 col-xlg-3">
            <div class="card card-hover">
                <asp:HyperLink ID="hlInProgressGrievance" runat="server" NavigateUrl="~/FrontPanel/Staff/Grievance/GrievanceList.aspx">
                    <div class="box bg-info text-center">
                        <h1 class="font-light text-white"><i class="mdi mdi-receipt"></i></h1>
                        <h6 class="text-white">In-Progress Grievance</h6>
                        <span class="text-white counter-value ">
                            <asp:Label ID="lblInProgressGrievance" runat="server"></asp:Label></span>
                    </div>
                </asp:HyperLink>
            </div>
        </div>

        <div class="col-md-6 col-lg-2 col-xlg-3">
            <div class="card card-hover">
                <asp:HyperLink ID="hlResolveGrievance" runat="server" NavigateUrl="~/FrontPanel/Staff/Grievance/GrievanceList.aspx">
                    <div class="box bg-warning text-center">
                        <h1 class="font-light text-white"><i class="mdi mdi-receipt"></i></h1>
                        <h6 class="text-white">Resolved Grievance</h6>
                        <span class="text-white counter-value ">
                            <asp:Label ID="lblResolveGrievance" runat="server"></asp:Label></span>
                    </div>
                </asp:HyperLink>
            </div>
        </div>

        <div class="col-md-6 col-lg-2 col-xlg-3">
            <div class="card card-hover">
                <asp:HyperLink ID="hlRejectedGrievance" runat="server" NavigateUrl="~/FrontPanel/Staff/Grievance/GrievanceList.aspx">
                    <div class="box bg-danger text-center">
                        <h1 class="font-light text-white"><i class="mdi mdi-receipt"></i></h1>
                        <h6 class="text-white">Rejected Grievance</h6>
                        <span class="text-white counter-value ">
                            <asp:Label ID="lblRejectedGrievance" runat="server"></asp:Label></span>
                    </div>
                </asp:HyperLink>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="alert alert-danger alert-dismissible fade show" role="alert" style="width: 100%;">
            <asp:Label ID="lblImportantNotice" runat="server"><b>Important Notice</b></asp:Label>
            <br /><hr />
            <asp:Label ID="lblNotice1" runat="server" Text="1. Grievance can only be update once."></asp:Label>
            <br />
            <asp:Label ID="lblNotice2" runat="server" Text="2. Grievance cannot be edited or deleted after it's status changed to In-Progress."></asp:Label>
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                <span aria-hidden="true">&times;</span>
            </button>
        </div>
    </div>
</asp:Content>

<asp:Content ID="ContentScript" ContentPlaceHolderID="cphScript" runat="Server">
</asp:Content>