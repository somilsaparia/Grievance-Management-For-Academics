<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="AdminPanel_Default" %>

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
                <asp:HyperLink ID="hlCourse" runat="server" NavigateUrl="~/AdminPanel/Course/CourseList.aspx">
                    <div class="box bg-cyan text-center">
                        <h1 class="font-light text-white"><i class="mdi mdi-receipt"></i></h1>
                        <h6 class="text-white">Course</h6>
                        <span class="text-white counter-value "><asp:Label ID="lblCourse" runat="server"></asp:Label></span>
                    </div>
                </asp:HyperLink>
            </div>
        </div>

        <div class="col-md-6 col-lg-4 col-xlg-3">
            <div class="card card-hover">
                <asp:HyperLink ID="hlDepartment" runat="server" NavigateUrl="~/AdminPanel/Department/DepartmentList.aspx">
                    <div class="box bg-success text-center">
                        <h1 class="font-light text-white"><i class="mdi mdi-receipt"></i></h1>
                        <h6 class="text-white">Department</h6>
                        <span class="text-white counter-value "><asp:Label ID="lblDepartment" runat="server"></asp:Label></span>
                    </div>
                </asp:HyperLink>
            </div>
        </div>

        <div class="col-md-6 col-lg-2 col-xlg-3">
            <div class="card card-hover">
                <asp:HyperLink ID="hlSemester" runat="server" NavigateUrl="~/AdminPanel/Semester/SemesterList.aspx">
                    <div class="box bg-warning text-center">
                        <h1 class="font-light text-white"><i class="mdi mdi-receipt"></i></h1>
                        <h6 class="text-white">Semester</h6>
                        <span class="text-white counter-value "><asp:Label ID="lblSemester" runat="server"></asp:Label></span>
                    </div>
                </asp:HyperLink>
            </div>
        </div>

        <div class="col-md-6 col-lg-4 col-xlg-3">
            <div class="card card-hover">
                <asp:HyperLink ID="hlGrievance" runat="server" NavigateUrl="~/AdminPanel/Grievance/GrievanceList.aspx">
                    <div class="box bg-danger text-center">
                        <h1 class="font-light text-white"><i class="mdi mdi-receipt"></i></h1>
                        <h6 class="text-white">Grievance Category</h6>
                        <span class="text-white counter-value "><asp:Label ID="lblGrievance" runat="server"></asp:Label></span>
                    </div>
                </asp:HyperLink>
            </div>
        </div>

        <div class="col-md-6 col-lg-4 col-xlg-3">
            <div class="card card-hover">
                <asp:HyperLink ID="hlStaff" runat="server" NavigateUrl="~/AdminPanel/Staff/StaffList.aspx">
                    <div class="box bg-info text-center">
                        <h1 class="font-light text-white"><i class="mdi mdi-receipt"></i></h1>
                        <h6 class="text-white">Staff</h6>
                        <span class="text-white counter-value "><asp:Label ID="lblStaff" runat="server"></asp:Label></span>
                    </div>
                </asp:HyperLink>
            </div>
        </div>

        <div class="col-md-6 col-lg-2 col-xlg-3">
            <div class="card card-hover">
                <asp:HyperLink ID="hlStaffGrievance" runat="server" NavigateUrl="~/AdminPanel/UserGrievanceList.aspx">
                    <div class="box bg-danger text-center">
                        <h1 class="font-light text-white"><i class="mdi mdi-receipt"></i></h1>
                        <h6 class="text-white">Staff Grievance</h6>
                        <span class="text-white counter-value "><asp:Label ID="lblStaffGrievance" runat="server"></asp:Label></span>
                    </div>
                </asp:HyperLink>
            </div>
        </div>

        <div class="col-md-6 col-lg-4 col-xlg-3">
            <div class="card card-hover">
                <asp:HyperLink ID="hlStudent" runat="server" NavigateUrl="~/AdminPanel/Student/StudentList.aspx">
                    <div class="box bg-success text-center">
                        <h1 class="font-light text-white"><i class="mdi mdi-receipt"></i></h1>
                        <h6 class="text-white">Student</h6>
                        <span class="text-white counter-value "><asp:Label ID="lblStudent" runat="server"></asp:Label></span>
                    </div>
                </asp:HyperLink>
            </div>
        </div>

        <div class="col-md-6 col-lg-2 col-xlg-3">
            <div class="card card-hover">
                <asp:HyperLink ID="hlStudentGrievance" runat="server" NavigateUrl="~/AdminPanel/UserGrievanceList.aspx">
                    <div class="box bg-cyan text-center">
                        <h1 class="font-light text-white"><i class="mdi mdi-receipt"></i></h1>
                        <h6 class="text-white">Student Grievance</h6>
                        <span class="text-white counter-value "><asp:Label ID="lblStudentGrievance" runat="server"></asp:Label></span>
                    </div>
                </asp:HyperLink>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="ContentScript" ContentPlaceHolderID="cphScript" runat="Server">
</asp:Content>
