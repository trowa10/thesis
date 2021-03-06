﻿using System;
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
                GridRefresh();

            }


        }
        private void GridRefresh()
        {
            var listCandidates = _business.GetCandidates();
            grdCandidates.DataSource = listCandidates;
            grdCandidates.DataBind();
        }
        protected void lnkShowInfo_Click(object sender, EventArgs e)
        {
            PnlCandidateInfo.Visible = false;
            var res = this._business.GetUserInfo(txtVotersId.Text);
            if (res.Id != 0)
            {
                hdnId.Value = res.Id.ToString();
                txtFname.Text = $"{res?.FirstName} {res?.MidName} {res?.LastName}";
                PnlCandidateInfo.Visible = true;
            }
            else
                Message("Provided Id is not exist!.");


        }

        private void Clear()
        {
            var Positions = _business.GetPositions();
            drpPositions.DataSource = Positions;
            drpPositions.DataTextField = "Name";
            drpPositions.DataValueField = "Id";
            drpPositions.DataBind();

            hdnId.Value = "";
            txtFname.Text = "";
            txtVotersId.Text = "";
            drpPositions.SelectedIndex = 0;
            PnlCandidateInfo.Visible = false;
            GridRefresh();
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
                var isExist = _business.GetCandidates().Where(x => x.VoterId == txtVotersId.Text).FirstOrDefault();

                if (isExist != null)
                {
                    Message("Candidate already registered!");                
                }
                else
                {
                    CandidateDTO dto = new CandidateDTO()
                    {
                        VoterId = txtVotersId.Text,
                        PositionId = int.Parse(drpPositions.SelectedValue),
                    };

                    var result = _business.RegisterCandidate(dto);

                    if (result)
                    {
                        Message("Insert Candidate Successfull!");
                        Clear();
                    }
                    else
                    {
                        Message("Insert User Failed!");
                    }

                }


            }

        }

        protected void update_Click(object sender, EventArgs e)
        {
            if (hdnId.Value != "")
            {
                UCandidateDTO uCandidateDTO = new UCandidateDTO()
                {
                    Id = int.Parse(hdnId.Value),
                    PositionId = int.Parse(drpPositions.SelectedValue),
                    VoterId = txtVotersId.Text
                };
                _business.UpdateCandidate(uCandidateDTO);
                Message("Update Successfull!.");
                Clear();
            }
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            if (hdnId.Value != "")
            {
                _business.DeleteCandidate(int.Parse(hdnId.Value));
                Message("Delete Successfull!.");
                Clear();
            }
        }

        protected void clear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void grdCandidates_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdnId.Value = grdCandidates.SelectedRow.Cells[1].Text;
            txtVotersId.Text = grdCandidates.SelectedRow.Cells[2].Text;
            txtFname.Text = grdCandidates.SelectedRow.Cells[3].Text;
            drpPositions.SelectedItem.Text = grdCandidates.SelectedRow.Cells[4].Text;

            var Position = _business.GetPositions().Where(x => x.Name == grdCandidates.SelectedRow.Cells[4].Text).FirstOrDefault();
            drpPositions.SelectedValue = Position.Id.ToString();
            PnlCandidateInfo.Visible = true;
            GridRefresh();

        }
    }
}