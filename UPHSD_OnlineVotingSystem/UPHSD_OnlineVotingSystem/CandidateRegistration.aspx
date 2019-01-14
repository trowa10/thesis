<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CandidateRegistration.aspx.cs" Inherits="UPHSD_OnlineVotingSystem.CandidateRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        
        input, select {
            max-width: 100%;
        }
    </style>
    <div class="container">
        <div class="row">
            <div class="col-md-7 col-md-offset-3">
                <div class="panel panel-login">
                   <div class="panel-heading">
                        <div class="row">
                            <div class="col-xs-6">
                                <a href="#" class="active" id="login-form-link">Candidate Registration</a>
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
                                            <asp:HiddenField ID="hdnId" runat="server" />
                                            <asp:TextBox ID="txtVotersId" ClientIDMode="Static" TabIndex="0" CssClass="form-control" placeholder="*Voter's Id" runat="server"></asp:TextBox>
                                            <asp:LinkButton ID="lnkShowInfo" runat="server" OnClick="lnkShowInfo_Click">Show Info</asp:LinkButton>
                                        </div>
                                        <asp:Panel ID="PnlCandidateInfo" Visible="false" runat="server">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtFname" ReadOnly="true" ClientIDMode="Static" TabIndex="1" CssClass="form-control"  runat="server"></asp:TextBox>
                                            </div>                                           
                                        </asp:Panel>

                                        <div class="form-group">
                                            <asp:DropDownList ID="drpPositions" ClientIDMode="Static" CssClass="form-control" TabIndex="6" runat="server"></asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <div class="row">
                                                <div class="col-sm-3 col-xm-offset-2">
                                                    <asp:Button ID="register_submit" name="register_submit" class="form-control btn btn-register" runat="server" Text="Submit" OnClick="register_submit_Click" />
                                                </div>
                                                <div class="col-sm-3 ">
                                                    <asp:Button ID="update" name="update" class="form-control btn btn-register" runat="server" TabIndex="4" Text="Update" OnClick="update_Click" />
                                                </div>
                                                <div class="col-sm-3 ">
                                                    <asp:Button ID="delete" name="delete" class="form-control btn btn-register" runat="server" TabIndex="4" Text="Delete" OnClick="delete_Click" />
                                                </div>
                                                <div class="col-sm-3 ">
                                                    <asp:Button ID="clear" name="clear" class="form-control btn btn-register" runat="server" TabIndex="4" Text="Clear" OnClick="clear_Click"  />
                                                </div>
                                            </div>
                                        </div>

                                          <div>
                                            <asp:Panel ID="Panel1" runat="server" Height-="200px" ScrollBars="Vertical">
                                                <asp:GridView ID="grdCandidates" Width="100%" runat="server" AutoGenerateSelectButton="True"
                                                BorderStyle="None" BorderWidth="1px"
                                                CellPadding="3" CellSpacing="2" AutoGenerateColumns="False" OnSelectedIndexChanged="grdCandidates_SelectedIndexChanged" >
                                                <%--<FooterStyle BackColor="#ad0022" ForeColor="#ad0022" />--%>
                                                <HeaderStyle BackColor="#ad0022" Font-Bold="True" ForeColor="White" />
                                                <%--<PagerStyle ForeColor="#ad0022" HorizontalAlign="Center" />--%>
                                                <%--  <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />--%>
                                                <SelectedRowStyle BackColor="#ff9eaf" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                                                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                                                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                                                <SortedDescendingHeaderStyle BackColor="#93451F" />
                                                <Columns>
                                                    <asp:BoundField HeaderText="Id" DataField="Id" />
                                                    <asp:BoundField HeaderText="Voter's Id" DataField="voterid" />
                                                    <asp:BoundField HeaderText="Candidate Name" DataField="fullname" />
                                                    <asp:BoundField HeaderText="Position" DataField="Position" />
                                                </Columns>
                                            </asp:GridView>

                                            </asp:Panel>
                                            
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
