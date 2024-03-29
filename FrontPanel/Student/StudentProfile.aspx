<%@ Page Title="" Language="C#" MasterPageFile="~/Content/FrontPanelStudent.master" AutoEventWireup="true" CodeFile="StudentProfile.aspx.cs" Inherits="FrontPanel_Student_StudentProfile" %>

<asp:Content ID="ContentTitle" ContentPlaceHolderID="cphTitle" Runat="Server">
    Student Profile
</asp:Content>

<asp:Content ID="ContentHead" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>

<asp:Content ID="ContentPageTitle" ContentPlaceHolderID="cphPageTitle" Runat="Server">
    <asp:Label ID="lblPageTittle" runat="server"></asp:Label>
</asp:Content>

<asp:Content ID="ContentBreadcrumb" ContentPlaceHolderID="cphBreadcrumb" Runat="Server">
    <asp:HyperLink runat="server"><asp:Label ID="lblBreadcrumb" runat="server"></asp:Label></asp:HyperLink>
</asp:Content>

<asp:Content ID="ContentContent" ContentPlaceHolderID="cphContent" Runat="Server">
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
                            <div class="col-sm-3">
                                <div style="float:right;">
                                    <b><asp:Label ID="lblFirstName" runat="server" CssClass="text-right control-label col-form-label" Text="First Name"></asp:Label></b>
                                </div>
                            </div>
                            <div class="col-sm-5">
                                <div style="float:left;">
                                    <asp:Label ID="lblFirstNameDetail" runat="server" CssClass="text-left control-label col-form-label"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="form-group row">
                            <div class="col-sm-3">
                                <div style="float:right;">
                                    <b><asp:Label ID="lblMiddleName" runat="server" CssClass="text-right control-label col-form-label" Text="Middle Name"></asp:Label></b>
                                </div>
                            </div>
                            <div class="col-sm-5">
                                <div style="float:left;">
                                    <asp:Label ID="lblMiddleNameDetail" runat="server" CssClass="text-left control-label col-form-label"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="form-group row">
                            <div class="col-sm-3">
                                <div style="float:right;">
                                    <b><asp:Label ID="lblLastName" runat="server" CssClass="text-right control-label col-form-label" Text="Last Name"></asp:Label></b>
                                </div>
                            </div>
                            <div class="col-sm-5">
                                <div style="float:left;">
                                    <asp:Label ID="lblLastNameDetail" runat="server" CssClass="text-left control-label col-form-label"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="form-group row">
                            <div class="col-sm-3">
                                <div style="float:right;">
                                    <b><asp:Label ID="lblEnrollmentNumber" runat="server" CssClass="text-right control-label col-form-label" Text="Enrollment Number"></asp:Label></b>
                                </div>
                            </div>
                            <div class="col-sm-5">
                                <div style="float:left;">
                                    <asp:Label ID="lblEnrollmentNumberDetail" runat="server" CssClass="text-left control-label col-form-label"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="form-group row">
                            <div class="col-sm-3">
                                <div style="float:right;">
                                    <b><asp:Label ID="lblMobileNumber" runat="server" CssClass="text-right control-label col-form-label" Text="Mobile Number"></asp:Label></b>
                                </div>
                            </div>
                            <div class="col-sm-5">
                                <div style="float:left;">
                                    <asp:Label ID="lblMobileNumberDetail" runat="server" CssClass="text-left control-label col-form-label"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="form-group row">
                            <div class="col-sm-3">
                                <div style="float:right;">
                                    <b><asp:Label ID="lblPersonalEmailAddress" runat="server" CssClass="text-right control-label col-form-label" Text="Personal Email Address"></asp:Label></b>
                                </div>
                            </div>
                            <div class="col-sm-5">
                                <div style="float:left;">
                                    <asp:Label ID="lblPersonalEmailAddressDetail" runat="server" CssClass="text-left control-label col-form-label"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="form-group row">
                            <div class="col-sm-3">
                                <div style="float:right;">
                                    <b><asp:Label ID="lblCollegeEmailAddress" runat="server" CssClass="text-right control-label col-form-label" Text="College Email Address"></asp:Label></b>
                                </div>
                            </div>
                            <div class="col-sm-5">
                                <div style="float:left;">
                                    <asp:Label ID="lblCollegeEmailAddressDetail" runat="server" CssClass="text-left control-label col-form-label"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="form-group row">
                            <div class="col-sm-3">
                                <div style="float:right;">
                                    <b><asp:Label ID="lblCurrentSemester" runat="server" CssClass="text-right control-label col-form-label" Text="Current Semester"></asp:Label></b>
                                </div>
                            </div>
                            <div class="col-sm-5">
                                <div style="float:left;">
                                    <asp:Label ID="lblCurrentSemesterDetail" runat="server" CssClass="text-left control-label col-form-label"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="form-group row">
                            <div class="col-sm-3">
                                <div style="float:right;">
                                    <b><asp:Label ID="lblAdmissionYear" runat="server" CssClass="text-right control-label col-form-label" Text="Admission Year"></asp:Label></b>
                                </div>
                            </div>
                            <div class="col-sm-5">
                                <div style="float:left;">
                                    <asp:Label ID="lblAdmissionYearDetail" runat="server" CssClass="text-left control-label col-form-label"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="ContentScript" ContentPlaceHolderID="cphScript" Runat="Server">
</asp:Content>