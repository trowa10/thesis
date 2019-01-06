<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CandidateRegistration.aspx.cs" Inherits="UPHSD_OnlineVotingSystem.CandidateRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="panel panel-login">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-xs-10">

                                <a href="#" class="active" id="login-form-link">Candidates Registration</a>
                            </div>
                        </div>
                        <hr>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <form>
                                    <div class="divRegisterForm">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtVotersId" ClientIDMode="Static" TabIndex="0" CssClass="form-control" placeholder="*Voter's Id" runat="server"></asp:TextBox>
                                            <asp:LinkButton ID="lnkShowInfo" runat="server" OnClick="lnkShowInfo_Click">Show Info</asp:LinkButton>
                                        </div>
                                        <asp:Panel ID="PnlCandidateInfo" Visible="false" runat="server">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtFname" ReadOnly="true" ClientIDMode="Static" TabIndex="1" CssClass="form-control"  runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <asp:TextBox ID="txtMname" ReadOnly="true" ClientIDMode="Static" TabIndex="2" CssClass="form-control"  runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <asp:TextBox ID="txtLname" ReadOnly="true" ClientIDMode="Static" TabIndex="3" CssClass="form-control"  runat="server"></asp:TextBox>
                                            </div>
                                        </asp:Panel>

                                        <div class="form-group">
                                            <asp:DropDownList ID="drpPositions" ClientIDMode="Static" CssClass="form-control" TabIndex="6" runat="server"></asp:DropDownList>
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
</asp:Content>
