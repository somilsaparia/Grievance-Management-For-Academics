<%@ Page Title="" Language="C#" MasterPageFile="~/Content/FrontPanelStudent.master" AutoEventWireup="true" CodeFile="GrievanceAddEdit.aspx.cs" Inherits="FrontPanel_Student_Grievance_GrievanceAddEdit" %>

<asp:Content ID="ContentTitle" ContentPlaceHolderID="cphTitle" runat="Server">
    Grievance Add / Edit
</asp:Content>

<asp:Content ID="ContentHead" ContentPlaceHolderID="cphHead" runat="Server">
    <script type="text/Javascript" language="javascript">  
        function confirmation() {
            var pageTitle = document.getElementById('<%= lblPageTittle.ClientID %>').innerHTML;            
            if (pageTitle == 'Grievance Edit') {
            var answer = confirm("You can only update you grievance once. Do you want to continue?");
                return answer;
            } 
        }
    </script>
</asp:Content>

<asp:Content ID="ContentPageTitle" ContentPlaceHolderID="cphPageTitle" runat="Server">
    <asp:Label ID="lblPageTittle" runat="server"></asp:Label>
</asp:Content>

<asp:Content ID="ContentBreadcrumb" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
    <asp:HyperLink runat="server">
        <asp:Label ID="lblBreadcrumb" runat="server"></asp:Label>
    </asp:HyperLink>     
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
                            <asp:Label ID="lblGrievanceName" runat="server" CssClass="col-sm-3 text-right control-label col-form-label" Text="Grievance Type"></asp:Label>
                            <div class="col-sm-5">
                                <asp:DropDownList ID="ddlGrievanceName" runat="server" CssClass="select2 form-control custom-select"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvGrievanceName" runat="server" ControlToValidate="ddlGrievanceName" Text="Please select Grievance" ForeColor="Red" Display="Dynamic"
                                    ValidationGroup="vgInsert" InitialValue="-1"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group row">
                            <asp:Label ID="lblGrievanceDescription" runat="server" CssClass="col-sm-3 text-right control-label col-form-label" Text="Grievance Description"></asp:Label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="txtGrievanceDescription" runat="server" CssClass="form-control" placeholder="Grievance Description Here" TextMode="MultiLine" Rows="3" MaxLength="500"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvGrievanceDescription" runat="server" ControlToValidate="txtGrievanceDescription" Text="Please enter Grievance Description" ForeColor="Red" Display="Dynamic"
                                    ValidationGroup="vgInsert"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <asp:Panel ID="pnlEdit" runat="server" Visible="false">
                            <div class="form-group row">
                                <asp:Label ID="lblGrievanceStatus" runat="server" CssClass="col-sm-3 text-right control-label col-form-label" Text="Grievance Status"></asp:Label>
                                <div class="col-sm-5">
                                    <asp:TextBox ID="txtGrievanceStatus" runat="server" CssClass="form-control" placeholder="Grievance Status Here" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group row">
                                <asp:Label ID="lblGrievanceDate" runat="server" CssClass="col-sm-3 text-right control-label col-form-label" Text="Grievance Date"></asp:Label>
                                <div class="col-sm-5">
                                    <asp:TextBox ID="txtGrievanceDate" runat="server" CssClass="form-control" placeholder="Grievance Date Here" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group row">
                                <asp:Label ID="lblGrievanceUpdateDate" runat="server" CssClass="col-sm-3 text-right control-label col-form-label" Text="Grievance Update Date"></asp:Label>
                                <div class="col-sm-5">
                                    <asp:TextBox ID="txtGrievanceUpdateDate" runat="server" CssClass="form-control" placeholder="Grievance Update Date Here" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </asp:Panel>


                    </div>
                   
                    <div class="border-top">
                        <div class="card-body">
                            <div class="form-group row">
                                <div class="col-sm-3"></div>
                                <div class="col-sm-5">
                                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-primary" OnClick="btnEdit_Click" Visible="false" />
                                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" OnClientClick="return confirmation();" OnClick="btnSubmit_Click" ValidationGroup="vgInsert" />
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

