﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="GrievanceAddEdit.aspx.cs" Inherits="AdminPanel_Grievance_GrievanceAddEdit" %>

<asp:Content ID="ContentTitle" ContentPlaceHolderID="cphTitle" runat="Server">
    Grievance Add / Edit
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
        <div class="col-md-12">
            <div class="card">
                <div class="form-horizontal">
                    <div class="card-body">
                        <div>
                            <div style="float: left;">
                                <h4 class="card-title">
                                    <asp:Label ID="lblCardTitle" runat="server"></asp:Label></h4>
                            </div>
                            <div style="float: right;">
                                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnBack_Click" />
                            </div>
                            <br />
                        </div>

                        <hr />

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
                        <div class="form-group row">
                            <asp:Label ID="lblGrievanceName" runat="server" CssClass="col-sm-3 text-right control-label col-form-label" Text="Grievance Name"></asp:Label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="txtGrievanceName" runat="server" CssClass="form-control" placeholder="Grievance Name Here"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvGrievanceName" runat="server" ControlToValidate="txtGrievanceName" Text="Please enter Grievance Name" ForeColor="Red" Display="Dynamic"
                                    ValidationGroup="vgInsert"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="border-top">
                        <div class="card-body">
                            <div class="form-group row">
                                <div class="col-sm-3"></div>
                                <div class="col-sm-5">
                                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" OnClick="btnSubmit_Click" ValidationGroup="vgInsert" />
                                    <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-danger" OnClick="btnReset_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="ContentScript" ContentPlaceHolderID="cphScript" runat="Server">
</asp:Content>
