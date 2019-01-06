using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UPHSD_OnlineVotingSystem.DTO;

namespace UPHSD_OnlineVotingSystem
{
    public partial class LogIn : System.Web.UI.Page
    {
        BusinessLayer _business = null;
        public LogIn()
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
                    }
                    else
                        Response.Redirect("About.aspx");
                }
                else
                {
                    Session["IsLogged"] = false;
                    Response.Redirect("Default.aspx");
                }
                var roleList = _business.GetRole();
                drpRole.DataSource = roleList;
                drpRole.DataTextField = "Name";
                drpRole.DataValueField = "Id";
                drpRole.DataBind();
            }
        }

        protected void login_submit_Click(object sender, EventArgs e)
        {
            var IsLogged = _business.Login(new LogDTO()
            {
                VoterId = username.Text,
                Password = password.Text
            });

            if (IsLogged)
            {
                Session["IsLogged"] = true;
                Response.Redirect("About.aspx");
                
            }
            else
            {
                Session["IsLogged"] = false;
                Message("Invalid Username or Password.");               
            }
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
    }
}