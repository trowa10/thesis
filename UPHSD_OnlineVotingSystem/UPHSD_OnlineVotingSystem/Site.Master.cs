using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UPHSD_OnlineVotingSystem
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (bool.Parse(Session["IsLogged"].ToString()))
                {
                    lnkLogout.Visible = true;
                }
                else
                {
                    lnkLogout.Visible = false;
                }
            }
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            if (bool.Parse(Session["IsLogged"].ToString()))
            {
                Session["IsLogged"] = false;
                Response.Redirect("LogIn.aspx");
            }
        }
    }
}