<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="UPHSD_OnlineVotingSystem.UserRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
    .container {
            width: 1800px;
        }
    </script>
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-login">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-md-2">
                                <a href="#" id="register-form-link">Register User</a>
                            </div>
                        </div>
                        <hr>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <form>
                                <div class="col-sm-3">
                                    <div class="divRegisterForm">
                                        <div class="form-group">
                                            <asp:HiddenField ID="HiddenField1" runat="server" Value="" />
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
                                            <asp:TextBox ID="txtPassword" MaxLength="10" ClientIDMode="Static" TabIndex="7" CssClass="form-control" placeholder="*Password" runat="server" TextMode="Password"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtConfirmPassword" MaxLength="10" ClientIDMode="Static" TabIndex="8" CssClass="form-control" placeholder="Confirm Password" runat="server" TextMode="Password"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <asp:Button ID="register_submit" name="register_submit" class="form-control btn btn-register" runat="server" TabIndex="4" Text="Submit Now" OnClick="register_submit_Click" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-9">
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-sm-3">
                                                <asp:Button ID="btnDelete" name="delete" class="form-control btn btn-register" runat="server" TabIndex="4" Text="Delete" OnClick="delete_Click" />
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <asp:Panel ID="Panel1" runat="server" Height="520px" ScrollBars="Vertical">
                                            <asp:GridView ID="grdUsers" Width="100%" runat="server" AutoGenerateSelectButton="True"
                                                BorderStyle="None" BorderWidth="1px"
                                                CellPadding="3" CellSpacing="2" AutoGenerateColumns="False" OnSelectedIndexChanged="grdPostion_SelectedIndexChanged">
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
                                                    <asp:BoundField HeaderText="Voter Id" DataField="VoterId" />
                                                    <asp:BoundField HeaderText="FirstName" DataField="FirstName" />
                                                    <asp:BoundField HeaderText="MidName" DataField="MidName" />
                                                    <asp:BoundField HeaderText="LastName" DataField="LastName" />
                                                    <asp:BoundField Visible="false" HeaderText="RoleId" DataField="RoleId" />
                                                    <asp:BoundField HeaderText="Role" DataField="Role" />
                                                    <asp:BoundField HeaderText="ContactNumber" DataField="ContactNumber" />
                                                    <asp:BoundField HeaderText="Address" DataField="Address" />
                                                    <asp:BoundField Visible="false" HeaderText="Password" DataField="password" />
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
