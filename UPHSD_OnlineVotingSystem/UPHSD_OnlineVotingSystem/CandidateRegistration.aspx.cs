using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UPHSD_OnlineVotingSystem.DTO;

namespace UPHSD_OnlineVotingSystem
{
    public partial class CandidateRegistration : System.Web.UI.Page
    {
        BusinessLayer _business = null;
        public CandidateRegistration()
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
                        Response.Redirect("Default.aspx");
                    }
                    else
                        Response.Redirect("About.aspx");
                }
                else
                {
                    Session["IsLogged"] = false;
                    Response.Redirect("Default.aspx");
                }
                var Positions = _business.GetPositions();
                drpPositions.DataSource = Positions;
                drpPositions.DataTextField = "Name";
                drpPositions.DataValueField = "Id";
                drpPositions.DataBind();
            }

           
        }

        protected void lnkShowInfo_Click(object sender, EventArgs e)
        {
            PnlCandidateInfo.Visible = false;
            var res = this._business.GetUserInfo(txtVotersId.Text);
            if (res.Id != 0)
            {
                txtFname.Text = res?.FirstName;
                txtMname.Text = res?.MidName;
                txtLname.Text = res?.LastName;
                PnlCandidateInfo.Visible = true;
            }
            else
                Message("Provided Id is not exist!.");


        }

        public void Message(string message)
        {
            Response.Write("<script>alert('" + message + "');</script>");           
        }

        protected void register_submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtVotersId.Text))
            {
                txtVotersId.Focus();
                Message("Please fill required field.");
            }
            else
            {
                CandidateDTO dto = new CandidateDTO() {
                    VoterId = txtVotersId.Text,                   
                    PositionId = int.Parse(drpPositions.SelectedValue),
                };

                var result = _business.RegisterCandidate(dto);

                if (result)
                {
                    Message("Insert Candidate Successfull!");
                }
                else
                {
                    Message("Insert User Failed!");
                }
            }

        }
    }
}