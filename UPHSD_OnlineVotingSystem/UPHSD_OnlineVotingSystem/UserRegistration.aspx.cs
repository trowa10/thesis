using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UPHSD_OnlineVotingSystem.DTO;

namespace UPHSD_OnlineVotingSystem
{
    public partial class UserRegistration : System.Web.UI.Page
    {
        BusinessLayer _business = null;
        public UserRegistration()
        {

            this._business = new BusinessLayer();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["IsLogged"] != null)
                {
                    if (bool.Parse(Session["IsLogged"].ToString()) == false)
                    {
                        Session["IsLogged"] = false;
                        Response.Redirect("LogIn.aspx");
                    }
                }
                else
                {
                    Session["IsLogged"] = false;
                    Response.Redirect("LogIn.aspx");
                }

                var roleList = _business.GetRole();
                drpRole.DataSource = roleList;
                drpRole.DataTextField = "Name";
                drpRole.DataValueField = "Id";
                drpRole.DataBind();

                var users = _business.GetUsers();
                grdUsers.DataSource = users;
                grdUsers.DataBind();
            }
        }

        private void ClearControls()
        {

            txtVotersId.Text = string.Empty;
            txtFname.Text = string.Empty;
            txtMname.Text = string.Empty;
            txtLname.Text = string.Empty;
            txtAddress.Text = string.Empty;
            drpRole.SelectedIndex = 0;
            txtContact.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            HiddenField1.Value = "";

        }

        protected void register_submit_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(txtVotersId.Text))
            {
                txtVotersId.Focus();
                Message("Please fill required field.");
            }
            else if (string.IsNullOrEmpty(txtFname.Text))
            {
                txtFname.Focus();
                Message("Please fill required field.");
            }
            else if (string.IsNullOrEmpty(txtMname.Text))
            {
                txtMname.Focus();
                Message("Please fill required field.");
            }
            else if (string.IsNullOrEmpty(txtLname.Text))
            {
                txtLname.Focus();
                Message("Please fill required field.");
            }
            else if (string.IsNullOrEmpty(txtContact.Text))
            {
                txtContact.Focus();
                Message("Please fill required field.");
            }
            else if (string.IsNullOrEmpty(drpRole.SelectedValue))
            {
                drpRole.Focus();
                Message("Please fill required field.");
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                txtPassword.Focus();
                Message("Please fill required field.");
            }
            else if (string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                txtConfirmPassword.Focus();
                Message("Please fill required field.");
            }
            else if (txtPassword.Text != txtConfirmPassword.Text)
            {
                Message("Password not match!.");
            }
            else
            {
                var users = _business.GetUsers().Where(x => x.VoterId == txtVotersId.Text).FirstOrDefault();
                if (users != null)
                {
                    var uUserDto = new UUserDto()
                    {
                        Id = int.Parse(HiddenField1.Value),
                        VoterId = txtVotersId.Text,
                        Fname = txtFname.Text,
                        Mname = txtMname.Text,
                        Lname = txtLname.Text,
                        Address = txtAddress.Text,
                        RoleId = int.Parse(drpRole.SelectedValue),
                        ContactNum = txtContact.Text,
                        Password = txtPassword.Text
                    };
                    bool res = _business.UpdateUser(uUserDto);

                    if (res)
                    {
                        Message("User information has been updated!");
                        return;
                    }
                }

                var userDto = new UserDto()
                {
                    VoterId = txtVotersId.Text,
                    Fname = txtFname.Text,
                    Mname = txtMname.Text,
                    Lname = txtLname.Text,
                    Address = txtAddress.Text,
                    RoleId = int.Parse(drpRole.SelectedValue),
                    ContactNum = txtContact.Text,
                    Password = txtPassword.Text
                };

                var result = _business.RegisterUser(userDto);

                if (result)
                {
                    var lsitUsers = _business.GetUsers();
                    grdUsers.DataSource = lsitUsers;
                    grdUsers.DataBind();
                    ClearControls();
                    Message("Insert User Successfull!");
                }
                else
                {
                    Message("Insert User Failed!");
                }
            }
        }
        public void Message(string message)
        {
            Response.Write("<script>alert('" + message + "');</script>");
            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //sb.Append("<script type = 'text/javascript'>");
            //sb.Append("window.onload=function(){");
            //sb.Append("alert('");
            //sb.Append(message);
            //sb.Append("')};");
            //sb.Append("</script>");
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }

        protected void grdPostion_SelectedIndexChanged(object sender, EventArgs e)
        {
            HiddenField1.Value = grdUsers.SelectedRow.Cells[1].Text;
            txtVotersId.Text = grdUsers.SelectedRow.Cells[2].Text;
            txtFname.Text = grdUsers.SelectedRow.Cells[3].Text;
            txtMname.Text = grdUsers.SelectedRow.Cells[4].Text;
            txtLname.Text = grdUsers.SelectedRow.Cells[5].Text;
            var roleList = _business.GetRole().Where(x => x.Name == grdUsers.SelectedRow.Cells[7].Text).FirstOrDefault();
            drpRole.SelectedValue = roleList.Id.ToString();
            txtContact.Text = grdUsers.SelectedRow.Cells[8].Text;
            txtAddress.Text = grdUsers.SelectedRow.Cells[9].Text;
            txtPassword.Text = grdUsers.SelectedRow.Cells[10].Text;
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            if (HiddenField1.Value != string.Empty)
            {
                var res = _business.DeleteUser(int.Parse(HiddenField1.Value));
                if (res)
                {
                    var users = _business.GetUsers();
                    grdUsers.DataSource = users;
                    grdUsers.DataBind();
                    ClearControls();
                    Message("Delete User Successfull!");
                }
            }
        }
    }
}