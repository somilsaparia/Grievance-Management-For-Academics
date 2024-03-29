<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="UserGrievanceList.aspx.cs" Inherits="AdminPanel_UserGrievanceList" %>

<asp:Content ID="ContentTitle" ContentPlaceHolderID="cphTitle" runat="Server">
    Student Grievance List
</asp:Content>

<asp:Content ID="ContentHead" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>

<asp:Content ID="ContentPageTitle" ContentPlaceHolderID="cphpageTitle" runat="server">
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
                                        <div class="col-lg-6">
                                            <asp:Button ID="btnStaffGrievance" runat="server" Text="Staff Grievance" CssClass="btn btn-outline-success" Width="100%" Enabled="false" OnClick="btnStaffGrievance_Click" />
                                        </div>
                                        <div class="col-lg-6">
                                            <asp:Button ID="btnStudentGrievance" runat="server" Text="Student Grievance" CssClass="btn btn-outline-success" Width="100%" OnClick="btnStudentGrievance_Click" />
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

                                    <asp:GridView ID="gvStaffGrievance" runat="server" CssClass="table" AutoGenerateColumns="false" GridLines="None">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="StaffCode" HeaderText="Staff Code" />
                                            <asp:BoundField DataField="GrievanceName" HeaderText="Grievance Name" />
                                            <asp:BoundField DataField="GrievanceStatus" HeaderText="Grievance Status" />
                                            <asp:BoundField DataField="GrievanceDate" HeaderText="Grievance Date" DataFormatString="{0:dd/MM/yyyy}" />
                                            <asp:BoundField DataField="GrievanceUpdateDate" HeaderText="Grievance Update Date" DataFormatString="{0:dd/MM/yyyy}" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <div align="right">
                                                        <asp:HyperLink ID="hlDetails" runat="server" Text="Details" CssClass="btn btn-outline-primary" Width="70%" NavigateUrl='<%# "~/AdminPanel/StaffGrievance/StaffGrievanceDetail.aspx?StaffGrievanceID=" + Eval("StaffGrievanceID").ToString() %>' />
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>

                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <asp:UpdatePanel ID="upnlStudentGrievance" runat="server" Visible="false">
                                <ContentTemplate>

                                    <asp:GridView ID="gvStudentGrievance" runat="server" CssClass="table" AutoGenerateColumns="false" GridLines="None">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="StudentEnrollmentNumber" HeaderText="Enrollment Number" />
                                            <asp:BoundField DataField="GrievanceName" HeaderText="Grievance Name" />
                                            <asp:BoundField DataField="GrievanceStatus" HeaderText="Grievance Status" />
                                            <asp:BoundField DataField="GrievanceDate" HeaderText="Grievance Date" />
                                            <asp:BoundField DataField="GrievanceUpdateDate" HeaderText="Grievance Update Date" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <div align="right">
                                                        <asp:HyperLink ID="hlDetails" runat="server" Text="Details" CssClass="btn btn-outline-primary" Width="70%" NavigateUrl='<%# "~/AdminPanel/StudentGrievance/StudentGrievanceDetail.aspx?StudentGrievanceID=" + Eval("StudentGrievanceID").ToString() %>' />
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
