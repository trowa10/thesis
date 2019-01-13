using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UPHSD_OnlineVotingSystem.DTO;
using UPHSD_OnlineVotingSystem.Model;

namespace UPHSD_OnlineVotingSystem
{
    public partial class Configurations : System.Web.UI.Page
    {
        BusinessLayer _business = null;
        public Configurations()
        {
            this._business = new BusinessLayer();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            List<ObjectModel> objectModels = new List<ObjectModel>();
            objectModels.Add(new ObjectModel()
            {
                Id = 1,
                Name = "RadioButton"
            });
            objectModels.Add(new ObjectModel()
            {
                Id = 2,
                Name = "Checkbox"
            });

            if (!IsPostBack)
            {
                drpPositionObject.DataSource = objectModels;
                drpPositionObject.DataTextField = "Name";
                drpPositionObject.DataValueField = "Name";
                drpPositionObject.DataBind();
                GridRefresh();
            }       

           
        }
        public void GridRefresh()
        {
            var Positions = _business.GetPositions();
            grdPostion.DataSource = Positions;
            grdPostion.DataBind();
            clrObject();
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            try
            {
                PositionDTO positionDTO = new PositionDTO()
                {
                    Name = txtPosition.Text,
                    RequireWinner = int.Parse(txtNumWinner.Text),
                    Object = drpPositionObject.SelectedValue
                };
                var result = _business.RegisterPosition(positionDTO);
                if (result)
                    Response.Write("<script>alert('" + "Save Successfull!" + "');</script>");

                GridRefresh();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }



        }

        private void clrObject()
        {
            lblId.Text = string.Empty;
            txtNumWinner.Text = string.Empty;
            txtPosition.Text = string.Empty;
            drpPositionObject.SelectedIndex = 0;
        }

        protected void grdPostion_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblId.Visible = true;
            txtPosition.Text = grdPostion.SelectedRow.Cells[2].Text;
            txtNumWinner.Text = grdPostion.SelectedRow.Cells[3].Text;
            drpPositionObject.SelectedValue = grdPostion.SelectedRow.Cells[4].Text;
            lblId.Text = grdPostion.SelectedRow.Cells[1].Text;

        }

        protected void update_Click(object sender, EventArgs e)
        {
            try
            {
                UPositionDTO positionDTO = new UPositionDTO()
                {
                    Id = int.Parse(lblId.Text),
                    Name = txtPosition.Text,
                    RequireWinner = int.Parse(txtNumWinner.Text),
                    Object = drpPositionObject.SelectedValue
                };
                var result = _business.UpdatePosition(positionDTO);
                if (result)
                    Response.Write("<script>alert('" + "Update Successfull!" + "');</script>");

                GridRefresh();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            try
            {               
                var result = _business.DeletePosition(int.Parse(lblId.Text));
                if (result)
                    Response.Write("<script>alert('" + "Delete Successfull!" + "');</script>");

                GridRefresh();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void txtPosition_TextChanged(object sender, EventArgs e)
        {
            lblId.Visible = false;
        }

        protected void txtNumWinner_TextChanged(object sender, EventArgs e)
        {
            lblId.Visible = false;
        }

        protected void drpPositionObject_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblId.Visible = false;
        }

        protected void clear_Click(object sender, EventArgs e)
        {
            clrObject();
        }
    }
}