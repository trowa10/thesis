<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ElectionResult.aspx.cs" Inherits="UPHSD_OnlineVotingSystem.ElectionResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
   
    </script>
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-login">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-md-2">
                                <a href="#" id="register-form-link">Election Results</a>
                            </div>
                        </div>
                        <hr>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <form>
                                <div class="col-md-12">


                                    <div class="form-group">
                                        <asp:Panel ID="Panel1" runat="server" Height="520px" ScrollBars="Vertical">
                                            <asp:GridView ID="grdResult" Width="100%" runat="server"
                                                BorderStyle="None" BorderWidth="1px"
                                                CellPadding="3" CellSpacing="2" AutoGenerateColumns="False" OnSelectedIndexChanged="grdResult_SelectedIndexChanged">
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
                                                    <asp:BoundField HeaderText="Vote Count" DataField="VoteCount" />
                                                    <asp:BoundField HeaderText="Full Name" DataField="Fullname" />
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
</asp:Content>
