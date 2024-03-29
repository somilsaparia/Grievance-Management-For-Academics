<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="DepartmentList.aspx.cs" Inherits="AdminPanel_Department_DepartmentList" %>

<asp:Content ID="ContentTitle" ContentPlaceHolderID="cphTitle" runat="Server">
    Department List
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
                                <div>
                                    <div style="float: left;">
                                        <h4 class="card-title">
                                            <asp:Label ID="lblCardTitle" runat="server"></asp:Label></h4>
                                    </div>
                                    <div style="float: right;">
                                        <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-outline-success btn-sm" OnClick="btnAdd_Click" />
                                    </div>
                                    <br />
                                </div>

                                <asp:UpdatePanel ID="upnlDepartmentList" runat="server" Visible="false">
                                    <ContentTemplate>

                                <asp:GridView ID="gvDepartment" runat="server" CssClass="table" AutoGenerateColumns="false" OnRowCommand="gvDepartment_RowCommand" GridLines="None">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="DepartmentName" HeaderText="Department Name" />
                                        <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div align="right">
                                                    <asp:HyperLink ID="hlEdit" runat="server" Text="Edit" CssClass="btn btn-outline-primary" Width="20%" NavigateUrl='<%# "~/AdminPanel/Department/DepartmentAddEdit.aspx?DepartmentID=" + Eval("DepartmentID").ToString() %>' />
                                                    &nbsp;
                                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-outline-danger" Width="20%" CommandName="DeleteRecord" CommandArgument='<%# Eval("DepartmentID") %>' />
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>

                                </ContentTemplate>
                            </asp:UpdatePanel>

                    <asp:UpdatePanel ID="upnlNoDataFound" runat="server" Visible="false">
                            <ContentTemplate>
                                <hr />
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
