<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Election.aspx.cs" Inherits="UPHSD_OnlineVotingSystem.Election" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div class="container">
        <div class="row">
            <div class="col-md-6 col-md-offset-4">
                <div class="panel panel-login">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-xs-10">

                                <a href="#" class="active" id="login-form-link">Voting Page</a>
                            </div>
                        </div>
                        <hr>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <form>
                                  
                                    <div class="divVoteForm">
                                        <div class="form-group">
                                            <div class="row">
                                                <div class="col-xs-3">
                                                    Choose Position: 
                                                </div>
                                                <div class="col-xs-5">
                                                    <asp:DropDownList ID="drpPositions" AutoPostBack="true" ClientIDMode="Static" CssClass="form-control" runat="server" OnSelectedIndexChanged="drpPositions_SelectedIndexChanged" ></asp:DropDownList>
                                                </div>
                                                <div class="col-xs-3">
                                                    <asp:Button ID="btnCHoose" name="btnCHoose" class="btn btn-default btn-sm" runat="server" TabIndex="4" Text="See Candidates" OnClick="btnCHoose_Click" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="row">
                                                <div class="col-xs-3">
                                                </div>
                                                <div class="col-xs-5">
                                                    <asp:CheckBoxList ID="chCandidates" Visible="false" runat="server"></asp:CheckBoxList>
                                                    <asp:RadioButtonList ID="rdCandidates" Visible="false" runat="server"></asp:RadioButtonList>
                                                </div>
                                                <div class="col-xs-3">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Panel ID="PnlVote" Visible="false" runat="server">
                                            </asp:Panel>
                                        </div>


                                        <div class="form-group">
                                            <div class="row">
                                                <div class="col-sm-6 col-sm-offset-3">
                                                    <asp:Button ID="Vote_submit" Visible="false" name="register_submit" class="form-control btn btn-register" runat="server" TabIndex="4" Text="Vote Now" OnClientClick="return confirm('Are you certain you want to submit your vote?');" OnClick="Vote_submit_Click"  />

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
