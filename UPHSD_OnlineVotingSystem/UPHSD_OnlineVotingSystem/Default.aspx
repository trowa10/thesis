<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UPHSD_OnlineVotingSystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .txtWidth532 {
            width: 532px;
        }
    </style>

    <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="panel panel-login">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-xs-6">
                                <a href="#" class="active" id="login-form-link">Login</a>
                            </div>
                            <div class="col-xs-6">
                                <a href="#" id="register-form-link">Register</a>
                            </div>
                        </div>
                        <hr>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <form>
                                    <div class="divLoginForm">

                                        <div class="form-group">
                                            <asp:TextBox ID="username" TabIndex="1" CssClass="form-control" placeholder="Username" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="password" TabIndex="2" CssClass="form-control" placeholder="Password" runat="server"></asp:TextBox>
                                        </div>

                                        <div class="form-group">
                                            <div class="row">
                                                <div class="col-sm-6 col-sm-offset-3">
                                                    <asp:Button ID="login_submit" name="login-submit" class="form-control btn btn-login" runat="server" TabIndex="4" Text="Log In" OnClick="register_submit_Click" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div class="text-center">
                                                        <a href="https://phpoll.com/recover" tabindex="5" class="forgot-password">Forgot Password?</a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="divRegisterForm">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtVotersId" ClientIDMode="Static" TabIndex="0" CssClass="form-control" placeholder="*Voter's Id" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtFname" ClientIDMode="Static" TabIndex="1" CssClass="form-control" placeholder="*First Name" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtMname" ClientIDMode="Static" TabIndex="2" CssClass="form-control" placeholder="*Middle Name" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtLname" ClientIDMode="Static" TabIndex="3" CssClass="form-control" placeholder="*Last Name" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtContact" ClientIDMode="Static" TabIndex="4" CssClass="form-control" placeholder="*Contact #" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtAddress" ClientIDMode="Static" TabIndex="5" CssClass="form-control" placeholder="Address" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <asp:DropDownList ID="drpRole" ClientIDMode="Static" CssClass="form-control" TabIndex="6" runat="server"></asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtPassword" ClientIDMode="Static" TabIndex="7" CssClass="form-control" placeholder="*Password" runat="server" TextMode="Password"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtConfirmPassword" ClientIDMode="Static" TabIndex="8" CssClass="form-control" placeholder="Confirm Password" runat="server" TextMode="Password"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <div class="row">
                                                <div class="col-sm-6 col-sm-offset-3">
                                                    <asp:Button ID="register_submit" name="register_submit" class="form-control btn btn-register" runat="server" TabIndex="4" Text="Register Now" OnClick="register_submit_Click" />

                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <script>
        $(function () {
            $(".divRegisterForm").hide();

            $('#login-form-link').click(function (e) {
                $("#login-form").delay(100).fadeIn(100);
                $("#register-form").fadeOut(100);
                $('#register-form-link').removeClass('active');
                $(this).addClass('active');
                $(".divRegisterForm").hide();
                $(".divLoginForm").show();
                e.preventDefault();
            });

            $('#register-form-link').click(function (e) {

                $("#register-form").delay(100).fadeIn(100);
                $("#login-form").fadeOut(100);
                $('#login-form-link').removeClass('active');
                $(this).addClass('active');
                $(".divLoginForm").hide();
                $(".divRegisterForm").show();
                e.preventDefault();

            });

            $('#<%=register_submit.ClientID %>').click(function (e) {
            
                if ($("#txtVotersId").val() == "" || $("#txtFname").val() == "" || $("#txtMname").val() == "" || $("#txtLname").val() == "" || $("#txtContact").val() == ""
                    || $("#txtAddress").val() == "" || $("#drpRole").val() == "" || $("#txtPassword").val() == "" ) {
                     $(".divRegisterForm").show();
                }

            });

        });


    </script>
</asp:Content>
