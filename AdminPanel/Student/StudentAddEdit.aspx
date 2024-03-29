<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="StudentAddEdit.aspx.cs" Inherits="AdminPanel_Student_StudentAddEdit" %>

<asp:Content ID="ContentTitle" ContentPlaceHolderID="cphTitle" runat="Server">
    Student Add / Edit
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
                            <asp:Label ID="lblStudentFirstName" runat="server" CssClass="col-sm-3 text-right control-label col-form-label" Text="First Name"></asp:Label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="txtStudentFirstName" runat="server" CssClass="form-control" placeholder="First Name Here"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvStudentFirstName" runat="server" ControlToValidate="txtStudentFirstName" Text="Please enter First Name" ForeColor="Red" Display="Dynamic"
                                    ValidationGroup="vgInsert"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group row">
                            <asp:Label ID="lblStudentMiddleName" runat="server" CssClass="col-sm-3 text-right control-label col-form-label" Text="Middle Name"></asp:Label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="txtStudentMiddleName" runat="server" CssClass="form-control" placeholder="Middle Name Here"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvStudentMiddleName" runat="server" ControlToValidate="txtStudentMiddleName" Text="Please enter Middle Name" ForeColor="Red" Display="Dynamic"
                                    ValidationGroup="vgInsert"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group row">
                            <asp:Label ID="lblStudentLastName" runat="server" CssClass="col-sm-3 text-right control-label col-form-label" Text="Last Name"></asp:Label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="txtStudentLastName" runat="server" CssClass="form-control" placeholder="Last Name Here"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvStudentLastName" runat="server" ControlToValidate="txtStudentLastName" Text="Please enter Last Name" ForeColor="Red" Display="Dynamic"
                                    ValidationGroup="vgInsert"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group row">
                            <asp:Label ID="lblStudentEnrollmentNumber" runat="server" CssClass="col-sm-3 text-right control-label col-form-label" Text="Enrollment Number"></asp:Label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="txtStudentEnrollmentNumber" runat="server" CssClass="form-control" placeholder="Student Code Here"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvStudentEnrollmentNumber" runat="server" ControlToValidate="txtStudentEnrollmentNumber" Text="Please enter Enrollment Number" ForeColor="Red" Display="Dynamic"
                                    ValidationGroup="vgInsert"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group row">
                            <asp:Label ID="lblStudentMobileNumber" runat="server" CssClass="col-sm-3 text-right control-label col-form-label" Text="Mobile Number"></asp:Label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="txtStudentMobileNumber" runat="server" CssClass="form-control" placeholder="Mobile Number Here"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revStudentMobileNumber" runat="server" ControlToValidate="txtStudentMobileNumber" ValidationExpression="[0-9]{10}"
                                    Text="Please enter valid Mobile Number" Display="Dynamic" ForeColor="Red" ValidationGroup="vgInsert"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="rfvMobileNumber" runat="server" ControlToValidate="txtStudentMobileNumber" Text="Please enter Mobile Number" ForeColor="Red" Display="Dynamic"
                                    ValidationGroup="vgInsert"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group row">
                            <asp:Label ID="lblStudentPersonalEmailAddress" runat="server" CssClass="col-sm-3 text-right control-label col-form-label" Text="Personal Email"></asp:Label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="txtStudentPersonalEmailAddress" runat="server" CssClass="form-control" placeholder="Personal Email Here"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revStudentPersonalEmailAddress" runat="server" ControlToValidate="txtStudentPersonalEmailAddress" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    Text="Please enter valid Personal Email" Display="Dynamic" ForeColor="Red" ValidationGroup="vgInsert"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="rfvStudentPersonalEmailAddress" runat="server" ControlToValidate="txtStudentPersonalEmailAddress" Text="Please enter Personal Email" ForeColor="Red" Display="Dynamic"
                                    ValidationGroup="vgInsert"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group row">
                            <asp:Label ID="lblStudentCollegeEmailAddress" runat="server" CssClass="col-sm-3 text-right control-label col-form-label" Text="College Email"></asp:Label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="txtStudentCollegeEmailAddress" runat="server" CssClass="form-control" placeholder="College Email Here"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revStudentCollegeEmailAddress" runat="server" ControlToValidate="txtStudentCollegeEmailAddress" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    Text="Please enter valid College Email" Display="Dynamic" ForeColor="Red" ValidationGroup="vgInsert"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="rfvStudentCollegeEmailAddress" runat="server" ControlToValidate="txtStudentCollegeEmailAddress" Text="Please enter College Email" ForeColor="Red" Display="Dynamic"
                                    ValidationGroup="vgInsert"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group row">
                            <asp:Label ID="lblStudentCurrentSemester" runat="server" CssClass="col-sm-3 text-right control-label col-form-label" Text="Current Semester"></asp:Label>
                            <div class="col-sm-5">
                                <asp:DropDownList ID="ddlStudentCurrentSemester" runat="server" CssClass="select2 form-control custom-select" AutoPostBack="True"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvStudentCurrentSemester" runat="server" ControlToValidate="ddlStudentCurrentSemester" Text="Please enter Current Semester" ForeColor="Red" Display="Dynamic"
                                    ValidationGroup="vgInsert"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group row">
                            <asp:Label ID="lblStudentAdmissionYear" runat="server" CssClass="col-sm-3 text-right control-label col-form-label" Text="Admission Year"></asp:Label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="txtStudentAdmissionYear" runat="server" CssClass="form-control" placeholder="Admission Year Here"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvStudentAdmissionYear" runat="server" ControlToValidate="txtStudentAdmissionYear" Text="Please enter Admission Year" ForeColor="Red" Display="Dynamic"
                                    ValidationGroup="vgInsert"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group row">
                            <asp:Label ID="lblDepartmentName" runat="server" CssClass="col-sm-3 text-right control-label col-form-label" Text="Department Name"></asp:Label>
                            <div class="col-sm-5">
                                <asp:DropDownList ID="ddlDepartmentName" runat="server" CssClass="select2 form-control custom-select" AutoPostBack="True" OnSelectedIndexChanged="ddlDepartmentName_SelectedIndexChanged"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvDepartmentName" runat="server" ControlToValidate="ddlDepartmentName" Text="Please select Department" ForeColor="Red" Display="Dynamic"
                                    ValidationGroup="vgInsert" InitialValue="-1"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group row">
                            <asp:Label ID="lblCourseName" runat="server" CssClass="col-sm-3 text-right control-label col-form-label" Text="Course Name"></asp:Label>
                            <div class="col-sm-5">
                                <asp:DropDownList ID="ddlCourseName" runat="server" CssClass="select2 form-control custom-select" AutoPostBack="True" OnSelectedIndexChanged="ddlCourseName_SelectedIndexChanged"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvCourseName" runat="server" ControlToValidate="ddlCourseName" Text="Please select Course" ForeColor="Red" Display="Dynamic"
                                    ValidationGroup="vgInsert" InitialValue="-1"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group row">
                            <asp:Label ID="lblPassword" runat="server" CssClass="col-sm-3 text-right control-label col-form-label" Text="Password"></asp:Label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password Here"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" Text="Please enter Password" ForeColor="Red" Display="Dynamic"
                                    ValidationGroup="vgInsert" InitialValue="-1"></asp:RequiredFieldValidator>
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
