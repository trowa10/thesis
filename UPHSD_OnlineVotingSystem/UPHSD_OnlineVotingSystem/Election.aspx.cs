using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UPHSD_OnlineVotingSystem.DTO;

namespace UPHSD_OnlineVotingSystem
{
    public partial class Election : System.Web.UI.Page
    {
        BusinessLayer _business = null;
        public Election()
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

                var Positions = _business.GetPositions();
                drpPositions.DataSource = Positions;
                drpPositions.DataTextField = "Name";
                drpPositions.DataValueField = "Id";
                drpPositions.DataBind();

                var userId = (int)Session["LoggedId"];
                var mayvotes = _business.GetVotes().Where(x => x.UserId == userId && x.PositionId == int.Parse(drpPositions.SelectedValue));
                var voteCounts = mayvotes.Count();
                var requiredVotes = Positions.Where(x => x.Id == int.Parse(drpPositions.SelectedValue)).FirstOrDefault();
                if (requiredVotes != null)
                {
                    if (requiredVotes.RequireWinner == voteCounts)
                    {
                        Vote_submit.Enabled = false;
                    }
                }
            }
        }

        protected void Vote_submit_Click(object sender, EventArgs e)
        {
            try
            {

                if (chCandidates.Visible)
                {

                    for (int i = 0; i < chCandidates.Items.Count; i++)
                    {
                        if (chCandidates.Items[i].Selected)
                        {
                            VoteDTO myVote = new VoteDTO()
                            {
                                Fullname = chCandidates.Items[i].Text,
                                PositionId = int.Parse(drpPositions.SelectedValue),
                                UserId = (int)Session["LoggedId"],
                                VotersId = chCandidates.Items[i].Value
                            };
                            _business.SubmitVotes(myVote);
                        }

                    }
                    Response.Write("<script>alert('" + "Vote for " + drpPositions.SelectedItem.Text + "Successfull!." + "');</script>");
                }
                else if (rdCandidates.Visible)
                {
                    for (int i = 0; i < rdCandidates.Items.Count; i++)
                    {
                        if (rdCandidates.Items[i].Selected)
                        {
                            VoteDTO myVote = new VoteDTO()
                            {
                                Fullname = rdCandidates.Items[i].Text,
                                PositionId = int.Parse(drpPositions.SelectedValue),
                                UserId = (int)Session["LoggedId"],
                                VotersId = rdCandidates.Items[i].Value
                            };
                            _business.SubmitVotes(myVote);
                        }

                    }
                    Response.Write("<script>alert('" + "Vote for " + drpPositions.SelectedItem.Text + "Successfull!." + "');</script>");

                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }

        protected void btnCHoose_Click(object sender, EventArgs e)
        {

        }

        protected void drpPositions_SelectedIndexChanged(object sender, EventArgs e)
        {
            chCandidates.Visible = false;
            rdCandidates.Visible = false;
            chCandidates.DataSource = null;
            chCandidates.DataBind();
            rdCandidates.DataSource = null;
            rdCandidates.DataBind();
            Vote_submit.Visible = false;
        }

        protected void btnCHoose0_Click(object sender, EventArgs e)
        {
            try
            {
                var Positions = _business.GetPositions();
                var userId = (int)Session["LoggedId"];
                var mayvotes = _business.GetVotes().Where(x => x.UserId == userId && x.PositionId == int.Parse(drpPositions.SelectedValue));
                var voteCounts = mayvotes.Count();
                var requiredVotes = Positions.Where(x => x.Id == int.Parse(drpPositions.SelectedValue)).FirstOrDefault();

                rdCandidates.DataSource = null;
                rdCandidates.Enabled = true;
                chCandidates.DataSource = null;
                chCandidates.Enabled = true;

                var selectedPost = drpPositions.SelectedValue;
                var candidates = _business.GetCandidatesByPosition(int.Parse(selectedPost));
                var objectPost = Positions.Where(x => x.Id == int.Parse(selectedPost)).FirstOrDefault();
                var data = Positions.Where(x => x.Id == int.Parse(selectedPost));
                if (objectPost != null && candidates != null)
                {
                    if (objectPost.Object == "RadioButton")
                    {
                        rdCandidates.DataSource = candidates;
                        rdCandidates.DataTextField = "Fullname";
                        rdCandidates.DataValueField = "VoterId";
                        rdCandidates.DataBind();
                        rdCandidates.Visible = true;
                        chCandidates.Visible = false;
                    }
                    else
                    {
                        chCandidates.DataSource = candidates;
                        chCandidates.DataTextField = "Fullname";
                        chCandidates.DataValueField = "VoterId";
                        chCandidates.DataBind();
                        rdCandidates.Visible = false;
                        chCandidates.Visible = true;
                    }
                    Vote_submit.Visible = true;
                }

                if (requiredVotes != null)
                {
                    bool hasVote = false;
                    if (chCandidates.Visible)
                    {
                        for (int i = 0; i < chCandidates.Items.Count; i++)
                        {
                            hasVote = mayvotes.Where(x => x.VotersId == chCandidates.Items[i].Value && x.PositionId == int.Parse(selectedPost)).Count() > 0 ? true : false;
                            if (hasVote)
                            {
                                chCandidates.Items[i].Selected = true;
                                chCandidates.Enabled = false;
                            }


                        }
                    }
                    else if (rdCandidates.Visible)
                    {
                        for (int i = 0; i < rdCandidates.Items.Count; i++)
                        {
                            hasVote = mayvotes.Where(x => x.VotersId == rdCandidates.Items[i].Value && x.PositionId == int.Parse(selectedPost)).Count() > 0 ? true : false;
                            if (hasVote)
                            {
                                rdCandidates.Items[i].Selected = true;
                                rdCandidates.Enabled = false;
                            }
                        }


                    }

                    if (requiredVotes.RequireWinner == voteCounts)
                    {
                        Vote_submit.Enabled = false;
                        Response.Write("<script>alert('" + "Vote is already subtmitted for this position." + "');</script>");
                    }
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}