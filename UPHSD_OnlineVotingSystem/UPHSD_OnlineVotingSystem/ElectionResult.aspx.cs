using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UPHSD_OnlineVotingSystem
{
    public partial class ElectionResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
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
            }
        }
    }
}