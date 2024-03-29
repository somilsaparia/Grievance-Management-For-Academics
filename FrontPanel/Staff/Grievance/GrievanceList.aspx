<%@ Page Title="" Language="C#" MasterPageFile="~/Content/FrontPanelStaff.master" AutoEventWireup="true" CodeFile="GrievanceList.aspx.cs" Inherits="FrontPanel_Staff_Grievance_GrievanceList" %>

<asp:Content ID="ContentTitle" ContentPlaceHolderID="cphTitle" runat="Server">
    Grievance List
</asp:Content>

<asp:Content ID="ContentHead" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>

<asp:Content ID="ContentPageTitle" ContentPlaceHolderID="cphPageTitle" runat="server">
    <asp:Label ID="lblPageTittle" runat="server"></asp:Label>
</asp:Content>

<asp:Content ID="ContentBreadcrumb" ContentPlaceHolderID="cphBreadcrumb" runat="server">
    <asp:HyperLink runat="server"><asp:Label ID="lblBreadcrumb" runat="server"></asp:Label></asp:HyperLink>
</asp:Content>

<asp:Content ID="ContentContent" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="row">
        <div class="col-12">
            <div class="card">

                <asp:Panel ID="pnlSuccessMessage" runat="server" Visible="false">
                    <div class="alert alert-success alert-dismissible fade show" role="alert">
                        <asp:Label ID="lblSuccessMessage" runat="server"></asp:Label>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                </asp:Panel>

                <asp:Panel ID="pnlErrorMessage" runat="server" Visible="false">
                    <div class="alert alert-danger alert-dismissible fade show" role="alert">
                        <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                </asp:Panel>

                <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" Visible="true">
                    <ContentTemplate>

                        <div class="card-body">

                            <div class="row">
                                <div class="col-lg-12" style="float: left;">
                                    <div class="row">
                                        <div class="col-lg-2">
                                            <asp:Button ID="btnAllGrievance" runat="server" Text="All Grievance" CssClass="btn btn-outline-primary" Width="100%" Enabled="false" OnClick="btnAllGrievance_Click" />
                                        </div>
                                        <div class="col-lg-2">
                                            <asp:Button ID="btnNewGrievance" runat="server" Text="New Grievance" CssClass="btn btn-outline-primary" Width="100%" OnClick="btnNewGrievance_Click" />
                                        </div>
                                        <div class="col-lg-2">
                                            <asp:Button ID="btnInProgressGrievance" runat="server" Text="In-Progress Grievance" CssClass="btn btn-outline-primary" Width="100%" OnClick="btnInProgressGrievance_Click" />
                                        </div>
                                        <div class="col-lg-2">
                                            <asp:Button ID="btnResolvedGrievance" runat="server" Text="Resolved Grievance" CssClass="btn btn-outline-primary" Width="100%" OnClick="btnResolvedGrievance_Click" />
                                        </div>
                                        <div class="col-lg-2">
                                            <asp:Button ID="btnRejectedGrievance" runat="server" Text="Rejected Grievance" CssClass="btn btn-outline-primary" Width="100%" OnClick="btnRejectedGrievance_Click" />
                                        </div>
                                        <div class="col-lg-2">
                                            <asp:Button ID="btnAdd" runat="server" Text="Add Grievance" CssClass="btn btn-outline-success" OnClick="btnAdd_Click" Width="100%" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            
                            <hr />

                            <div>
                                <div style="float: left;">
                                    <h4 class="card-title">
                                        <asp:Label ID="lblCardTitle" runat="server"></asp:Label></h4>
                                </div>
                            </div>

                            <asp:UpdatePanel ID="upnlStaffGrievance" runat="server" Visible="true">
                                <ContentTemplate>

                            <asp:GridView ID="gvStaffGrievance" runat="server" CssClass="table" AutoGenerateColumns="false" OnRowCommand="gvStaffGrievance_RowCommand" GridLines="None">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="GrievanceName" HeaderText="Grievance Type" />
                                    <asp:BoundField DataField="GrievanceStatus" HeaderText="Grievance Status" />
                                    <asp:BoundField DataField="GrievanceDescription" HeaderText="Grievance Description" />
                                    <asp:BoundField DataField="GrievanceDate" HeaderText="Grievance Date" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="GrievanceUpdateDate" HeaderText="Grievance Update Date" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <div align="right">
                                                <asp:HyperLink ID="hlEdit" runat="server" Text="Edit" CssClass="btn btn-outline-primary" 
                                                    Visible='<%# Eval("GrievanceStatus").ToString() == "In-Progress" || Eval("GrievanceStatus").ToString() == "Rejected" || Eval("GrievanceStatus").ToString() == "Resolved" || Eval("GrievanceUpdateDate").ToString() != "" ? false: true %>' 
                                                    NavigateUrl='<%# "~/FrontPanel/Staff/Grievance/GrievanceAddEdit.aspx?Enable=1&StaffGrievanceID=" + Eval("StaffGrievanceID").ToString() %>' />
                                                &nbsp;
                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-outline-danger" 
                                                    Visible='<%# Eval("GrievanceStatus").ToString() == "In-Progress" || Eval("GrievanceStatus").ToString() == "Rejected" || Eval("GrievanceStatus").ToString() == "Resolved" ? false: true %>' CommandName="DeleteRecord" CommandArgument='<%# Eval("StaffGrievanceID") %>' />
                                                &nbsp;
                                                <asp:HyperLink ID="hlDetails" runat="server" Text="Details" CssClass="btn btn-outline-primary" 
                                                    NavigateUrl='<%# "~/FrontPanel/Staff/Grievance/GrievanceAddEdit.aspx?Enable=0&StaffGrievanceID=" + Eval("StaffGrievanceID").ToString() %>' />
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <asp:UpdatePanel ID="upnlNoDataFound" runat="server" Visible="false">
                            <ContentTemplate>
                                <br />
                                <h1 style="text-align: center;"><i class="m-r-10 mdi mdi-alert"></i> No Data Found</h1>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="ContentScript" ContentPlaceHolderID="cphScript" runat="Server">
</asp:Content>