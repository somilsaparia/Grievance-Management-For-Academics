﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="StaffGrievanceDetail.aspx.cs" Inherits="AdminPanel_StaffGrievance_StaffGrievanceDetail" %>

<asp:Content ID="ContentTitle" ContentPlaceHolderID="cphTitle" runat="Server">
    Staff Grievance Detail
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
                                <asp:TextBox ID="txtGrievanceName" runat="server" CssClass="form-control" disabled="true"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <asp:Label ID="lblGrievanceStatus" runat="server" CssClass="col-sm-3 text-right control-label col-form-label" Text="Grievance Status"></asp:Label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="txtGrievanceStatus" runat="server" CssClass="form-control" disabled="true"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <asp:Label ID="lblGrievanceDescription" runat="server" CssClass="col-sm-3 text-right control-label col-form-label" Text="Grievance Description"></asp:Label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="txtGrievanceDescription" runat="server" CssClass="form-control" disabled="true" Rows="3" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <asp:Label ID="lblGrievanceDate" runat="server" CssClass="col-sm-3 text-right control-label col-form-label" Text="Grievance Date"></asp:Label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="txtGrievanceDate" runat="server" CssClass="form-control" disabled="true"></asp:TextBox>
                            </div>
                        </div>

                         <div class="form-group row">
                            <asp:Label ID="lblGrievanceUpdateDate" runat="server" CssClass="col-sm-3 text-right control-label col-form-label" Text="Grievance Update Date"></asp:Label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="txtGrievanceUpdateDate" runat="server" CssClass="form-control" disabled="true"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <asp:Label ID="lblStaffFirstName" runat="server" CssClass="col-sm-3 text-right control-label col-form-label" Text="First Name"></asp:Label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="txtStaffFirstName" runat="server" CssClass="form-control" disabled="true"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <asp:Label ID="lblStaffMiddleName" runat="server" CssClass="col-sm-3 text-right control-label col-form-label" Text="Middle Name"></asp:Label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="txtStaffMiddleName" runat="server" CssClass="form-control" disabled="true"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <asp:Label ID="lblStaffLastName" runat="server" CssClass="col-sm-3 text-right control-label col-form-label" Text="Last Name"></asp:Label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="txtStaffLastName" runat="server" CssClass="form-control" disabled="true"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <asp:Label ID="lblStaffCode" runat="server" CssClass="col-sm-3 text-right control-label col-form-label" Text="Staff Code"></asp:Label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="txtStaffCode" runat="server" CssClass="form-control" disabled="true"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <asp:Label ID="lblStaffMobileNumber" runat="server" CssClass="col-sm-3 text-right control-label col-form-label" Text="Mobile Number"></asp:Label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="txtStaffMobileNumber" runat="server" CssClass="form-control" disabled="true"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <asp:Label ID="lblStaffPersonalEmailAddress" runat="server" CssClass="col-sm-3 text-right control-label col-form-label" Text="Personal Email"></asp:Label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="txtStaffPersonalEmailAddress" runat="server" CssClass="form-control" disabled="true"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <asp:Label ID="lblStaffCollegeEmailAddress" runat="server" CssClass="col-sm-3 text-right control-label col-form-label" Text="College Email"></asp:Label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="txtStaffCollegeEmailAddress" runat="server" CssClass="form-control" disabled="true"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <asp:Label ID="lblStaffJoiningYear" runat="server" CssClass="col-sm-3 text-right control-label col-form-label" Text="Joining Year"></asp:Label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="txtStaffJoiningYear" runat="server" CssClass="form-control" disabled="true"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <asp:Label ID="lblDepartmentName" runat="server" CssClass="col-sm-3 text-right control-label col-form-label" Text="Department Name"></asp:Label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="txtDepartmentName" runat="server" CssClass="form-control" disabled="true"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <asp:Label ID="lblCourseName" runat="server" CssClass="col-sm-3 text-right control-label col-form-label" Text="Course Name"></asp:Label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="txtCourseName" runat="server" CssClass="form-control" disabled="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="border-top">
                        <div class="card-body">
                            <div class="form-group row">
                                <div class="col-sm-3"></div>
                                <div class="col-sm-5">
                                    <asp:Button ID="btnCallMeeting" runat="server" Text="Call Meeting" CssClass="btn btn-primary" OnClick="btnCallMeeting_Click" />
                                    <asp:Button ID="btnNotGrievance" runat="server" Text="Not a Grievance" CssClass="btn btn-primary" OnClick="btnNotGrievance_Click" />
                                    <asp:Button ID="btnResolve" runat="server" Text="Resolve" CssClass="btn btn-primary" OnClick="btnResolve_Click" />
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
