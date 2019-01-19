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
        BusinessLayer _business = null;
        public ElectionResult()
        {
            this._business = new BusinessLayer();
        }
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

                var res = _business.GetElectionResults();
                grdResult.DataSource = res;
                grdResult.DataBind();


            }
        }

        protected void grdResult_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}