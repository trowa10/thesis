<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Configurations.aspx.cs" Inherits="UPHSD_OnlineVotingSystem.Configurations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .divRegisterPositionForm {
        }

        input, select {
            max-width: 100%;
        }
    </style>
    <div class="container">
        <div class="row">
            <div class="col-md-5 col-md-offset-3">
                <div class="panel panel-login">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-xs-6">
                                <a href="#" class="active" id="login-form-link">Position Configuration</a>
                            </div>
                        </div>
                        <hr>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <form>
                                    <div class="divRegisterPositionForm">
                                        <div class="form-group">
                                            <asp:Label ID="lblId" Visible="false" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtPosition" TabIndex="1" CssClass="form-control" AutoPostBack="true" placeholder="Enter Position" runat="server" OnTextChanged="txtPosition_TextChanged"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtNumWinner" TabIndex="2" CssClass="form-control" AutoPostBack="true" placeholder="Place number of required winner" runat="server" OnTextChanged="txtNumWinner_TextChanged"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <asp:DropDownList ID="drpPositionObject" ClientIDMode="Static" AutoPostBack="true" CssClass="form-control" TabIndex="3" runat="server" OnSelectedIndexChanged="drpPositionObject_SelectedIndexChanged"></asp:DropDownList>
                                        </div>

                                        <div class="form-group">
                                            <div class="row">
                                                <div class="col-sm-3 col-xm-offset-2">
                                                    <asp:Button ID="submit" name="submit" class="form-control btn btn-register" runat="server" TabIndex="4" Text="Submit" OnClick="submit_Click" />
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
                                                <asp:GridView ID="grdPostion" Width="100%" runat="server" AutoGenerateSelectButton="True"
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
                                                    <asp:BoundField HeaderText="Name" DataField="Name" />
                                                    <asp:BoundField HeaderText="Require Winner" DataField="RequireWinner" />
                                                    <asp:BoundField HeaderText="Object" DataField="Object" />
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


    <script>
        $(function () {
            //$(".divRegisterForm").hide();

            //$('#login-form-link').click(function (e) {
            //    $("#login-form").delay(100).fadeIn(100);
            //    $("#register-form").fadeOut(100);
            //    $('#register-form-link').removeClass('active');
            //    $(this).addClass('active');
            //    $(".divRegisterForm").hide();
            //    $(".divLoginForm").show();
            //    e.preventDefault();
            //});

            //$('#register-form-link').click(function (e) {

            //    $("#register-form").delay(100).fadeIn(100);
            //    $("#login-form").fadeOut(100);
            //    $('#login-form-link').removeClass('active');
            //    $(this).addClass('active');
            //    $(".divLoginForm").hide();
            //    $(".divRegisterForm").show();
            //    e.preventDefault();

            //});

        <%--    $('#<%=register_submit.ClientID %>').click(function (e) {
            
                if ($("#txtVotersId").val() == "" || $("#txtFname").val() == "" || $("#txtMname").val() == "" || $("#txtLname").val() == "" || $("#txtContact").val() == ""
                    || $("#txtAddress").val() == "" || $("#drpRole").val() == "" || $("#txtPassword").val() == "" ) {
                     $(".divRegisterForm").show();
                }

            });--%>

        });


    </script>

</asp:Content>
