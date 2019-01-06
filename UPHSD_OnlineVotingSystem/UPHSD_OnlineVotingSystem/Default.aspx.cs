using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UPHSD_OnlineVotingSystem.DTO;

namespace UPHSD_OnlineVotingSystem
{
    public partial class _Default : Page
    {        
        public _Default()
        {
            
               
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");
        }

        
    }
}