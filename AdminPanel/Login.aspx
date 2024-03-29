<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="AdminPanel_Login" %>

<!DOCTYPE html>

<html dir="ltr" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <!-- Tell the browser to be responsive to screen width -->
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <!-- Favicon icon -->
    <link rel="icon" type="image/png" sizes="16x16" href="<%=ResolveClientUrl("~/Content/AdminPanel/assets/images/favicon.png") %>" />
    <!-- Custom CSS -->
    <link href="<%=ResolveClientUrl("~/Content/AdminPanel/dist/css/style.min.css") %>" rel="stylesheet" />
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src="<%=ResolveClientUrl("https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js") %>"></script>
    <script src="<%=ResolveClientUrl("https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js") %>"></script>
<![endif]-->

    <title ID="Title" runat="server"></title>

</head>
<body>
    <form runat="server">
        <div class="main-wrapper">
            <!-- ============================================================== -->
            <!-- Preloader - style you can find in spinners.css -->
            <!-- ============================================================== -->
            <div class="preloader">
                <div class="lds-ripple">
                    <div class="lds-pos"></div>
                    <div class="lds-pos"></div>
                </div>
            </div>
            <!-- ============================================================== -->
            <!-- Preloader - style you can find in spinners.css -->
            <!-- ============================================================== -->
            <!-- ============================================================== -->
            <!-- Login box.scss -->
            <!-- ============================================================== -->
            <div class="auth-wrapper d-flex no-block justify-content-center align-items-center bg-dark">
                <div class="auth-box bg-dark border-top border-secondary">

                    <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>

                    <asp:UpdatePanel ID="upnlLogin" runat="server" Visible="true">
                        <ContentTemplate>
                            <div id="loginform">
                                <div class="text-center p-t-20 p-b-20">
                                    <h3 class="text-white">Grievance System</h3>
                                </div>
                                <!-- Form -->
                                <div class="form-horizontal m-t-20" id="loginform">

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

                                    <asp:UpdatePanel ID="upnlAdminLogin" runat="server" Visible="true">
                                        <ContentTemplate>
                                            <div class="row p-b-30">
                                                <div class="col-12">
                                                    <div class="input-group mb-3">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text bg-success text-white" id="basic-addon1"><i class="ti-user"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txtUserName" runat="server" class="form-control form-control-lg" placeholder="Username" aria-label="Username" aria-describedby="basic-addon1"></asp:TextBox>
                                                    </div>
                                                    <div class="input-group mb-3">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text bg-warning text-white" id="basic-addon2"><i class="ti-pencil"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txtPassword" runat="server" class="form-control form-control-lg" placeholder="Password" aria-label="Password" TextMode="Password" aria-describedby="basic-addon1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row border-top border-secondary">
                                                <div class="col-12">
                                                    <div class="form-group">
                                                        <div class="p-t-20">
                                                            <asp:Button ID="btnLogin_Admin" runat="server" class="btn btn-success float-right" Text="Login" OnClick="btnLogin_Admin_Click" Width="100%" />
                                                            <br />
                                                            <br />
                                                            <asp:Button ID="btnStaffLogin_Admin" runat="server" class="btn btn-outline-warning float-left" Text="Staff Login" ValidationGroup="vgLogin" Width="48%" OnClick="btnStaffLogin_Admin_Click" />
                                                            <asp:Button ID="btnStudentLogin_Admin" runat="server" class="btn btn-outline-warning float-right" Text="Student Login" ValidationGroup="vgLogin" Width="48%" OnClick="btnStudentLogin_Admin_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                    <asp:UpdatePanel ID="upnlStaffLogin" runat="server" Visible="false">
                                        <ContentTemplate>
                                            <div class="row p-b-30">
                                                <div class="col-12">
                                                    <div class="input-group mb-3">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text bg-success text-white" id="basic-addon1"><i class="ti-user"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txtStaffCode" runat="server" class="form-control form-control-lg" placeholder="Staff Code" aria-label="Username" aria-describedby="basic-addon1"></asp:TextBox>
                                                    </div>
                                                    <div class="input-group mb-3">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text bg-warning text-white" id="basic-addon2"><i class="ti-pencil"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txtStaffPassword" runat="server" class="form-control form-control-lg" placeholder="Password" aria-label="Password" TextMode="Password" aria-describedby="basic-addon1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row border-top border-secondary">
                                                <div class="col-12">
                                                    <div class="form-group">
                                                        <div class="p-t-20">
                                                            <asp:Button ID="btnLogin_Staff" runat="server" class="btn btn-success float-right" Text="Login" ValidationGroup="vgLogin" Width="100%" OnClick="btnLogin_Staff_Click" />
                                                            <br />
                                                            <br />
                                                            <asp:Button ID="btnAdminLogin_Staff" runat="server" class="btn btn-outline-warning float-left" Text="Admin Login" ValidationGroup="vgLogin" Width="48%" OnClick="btnAdminLogin_Staff_Click" />
                                                            <asp:Button ID="btnStudentLogin_Staff" runat="server" class="btn btn-outline-warning float-right" Text="Student Login" ValidationGroup="vgLogin" Width="48%" OnClick="btnStudentLogin_Staff_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                    <asp:UpdatePanel ID="upnlStudentLogin" runat="server" Visible="false">
                                        <ContentTemplate>
                                            <div class="row p-b-30">
                                                <div class="col-12">
                                                    <div class="input-group mb-3">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text bg-success text-white" id="basic-addon1"><i class="ti-user"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txtStudentEnrollmentNumber" runat="server" class="form-control form-control-lg" placeholder="Enrollment Number" aria-label="Username" aria-describedby="basic-addon1"></asp:TextBox>
                                                    </div>
                                                    <div class="input-group mb-3">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text bg-warning text-white" id="basic-addon2"><i class="ti-pencil"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txtStudentPassword" runat="server" class="form-control form-control-lg" placeholder="Password" aria-label="Password" TextMode="Password" aria-describedby="basic-addon1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row border-top border-secondary">
                                                <div class="col-12">
                                                    <div class="form-group">
                                                        <div class="p-t-20">
                                                            <asp:Button ID="btnStudentLogin_Student" runat="server" class="btn btn-success float-right" Text="Login" ValidationGroup="vgLogin" Width="100%" OnClick="btnStudentLogin_Student_Click" />
                                                            <br />
                                                            <br />
                                                            <asp:Button ID="btnAdminLogin_Student" runat="server" class="btn btn-outline-warning float-left" Text="Admin Login" ValidationGroup="vgLogin" Width="48%" OnClick="btnAdminLogin_Student_Click" />
                                                            <asp:Button ID="btnStaffLogin_Student" runat="server" class="btn btn-outline-warning float-right" Text="Staff Login" ValidationGroup="vgLogin" Width="48%" OnClick="btnStaffLogin_Student_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <asp:UpdatePanel ID="upnlForgotPassword" runat="server" Visible="false">
                        <ContentTemplate>
                            <div id="recoverform">
                                <div class="text-center">
                                    <span class="text-white">Enter your Username below and we will send you instructions how to recover a password.</span>
                                </div>
                                <div class="row m-t-20">
                                    <!-- Form -->
                                    <div class="col-12">
                                        <!-- email -->
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text bg-danger text-white" id="basic-addon1"><i class="ti-email"></i></span>
                                            </div>
                                            <asp:TextBox ID="txtRFUserName" runat="server" class="form-control form-control-lg" placeholder="Username" aria-label="Username" aria-describedby="basic-addon1"></asp:TextBox>
                                        </div>
                                        <!-- pwd -->
                                        <div class="row m-t-20 p-t-20 border-top border-secondary">
                                            <div class="col-12">
                                                <a class="btn btn-success" href="#" id="to-login" name="action">Back To Login</a>
                                                <button class="btn btn-info float-right" type="button" name="action">Recover</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>
            </div>
        </div>
        <!-- ============================================================== -->
        <!-- Login box.scss -->
        <!-- ============================================================== -->
        <!-- ============================================================== -->
        <!-- Page wrapper scss in scafholding.scss -->
        <!-- ============================================================== -->
        <!-- ============================================================== -->
        <!-- Page wrapper scss in scafholding.scss -->
        <!-- ============================================================== -->
        <!-- ============================================================== -->
        <!-- Right Sidebar -->
        <!-- ============================================================== -->
        <!-- ============================================================== -->
        <!-- Right Sidebar -->
        <!-- ============================================================== -->
    </form>
    <!-- ============================================================== -->
    <!-- All Required js -->
    <!-- ============================================================== -->
    <!-- ============================================================== -->
    <!-- All Required js -->
    <!-- ============================================================== -->
    <script src="<%=ResolveClientUrl("~/Content/AdminPanel/assets/libs/jquery/dist/jquery.min.js") %>"></script>
    <!-- Bootstrap tether Core JavaScript -->
    <script src="<%=ResolveClientUrl("~/Content/AdminPanel/assets/libs/popper.js/dist/umd/popper.min.js") %>"></script>
    <script src="<%=ResolveClientUrl("~/Content/AdminPanel/assets/libs/bootstrap/dist/js/bootstrap.min.js") %>"></script>
    <!-- ============================================================== -->
    <!-- This page plugin js -->
    <!-- ============================================================== -->
    <script>

        $('[data-toggle="tooltip"]').tooltip();
        $(".preloader").fadeOut();
        // ============================================================== 
        // Login and Recover Password 
        // ============================================================== 
        $('#to-recover').on("click", function () {
            $("#loginform").slideUp();
            $("#recoverform").fadeIn();
        });
        $('#to-login').click(function () {

            $("#recoverform").hide();
            $("#loginform").fadeIn();
        });
    </script>

</body>
</html>
