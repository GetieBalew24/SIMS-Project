using SIS_Controller;
using SIS_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIS_View
{
    public partial class Position : System.Web.UI.Page
    {
        private readonly SISBLL sis = new SISBLL();
        private readonly DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadPosition();
            }
        }
        protected void LoadPosition()
        {
            TBL_position[] position = sis.GetAllPositions();
            dt.Columns.Add("positionCode");
            dt.Columns.Add("positionName");
            dt.Columns.Add("recordedBy");
            dt.Columns.Add("recordedDate");
            dt.Columns.Add("recordedTime");
            dt.Columns.Add("lastModifiedBy");
            dt.Columns.Add("lastModifiedDate");
            dt.Columns.Add("lastModifiedTime");
            dt.Columns.Add("currentStatus");
            if (position.Count() > 0)
            {
                for (int j = 0; j < position.Count(); j++)
                {
                    String stat;
                    if (position[j].currentStatus == 0)
                        stat = "InActive";
                    else
                        stat = "Active";
                    DataRow dr = dt.NewRow();
                    dr["positionCode"] = position[j].positionCode;
                    dr["positionName"] = position[j].positionName;
                    dr["recordedBy"] = position[j].recordedBy;
                    dr["recordedDate"] = position[j].recordedDate;
                    dr["recordedTime"] = position[j].recordedTime;
                    dr["lastModifiedBy"] = position[j].lastModifiedBy;
                    dr["lastModifiedDate"] = position[j].lastModifiedDate;
                    dr["lastModifiedTime"] = position[j].lastModifiedTime;
                    dr["currentStatus"] = stat;
                    dt.Rows.Add(dr);
                }
                Gv_position.DataSource = dt;
                Gv_position.DataBind();
            }
        }

        protected void Gv_position_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Gv_position.EditIndex = e.NewEditIndex;
            LoadPosition();
        }

        protected void Gv_position_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String positionCode = Gv_position.DataKeys[e.RowIndex].Values["positionCode"].ToString();
            TextBox positionName = (TextBox)Gv_position.Rows[e.RowIndex].FindControl("txtPositionName");
            DropDownList currentStatus = (DropDownList)Gv_position.Rows[e.RowIndex].FindControl("ddlCurrentStatus");

            if (sis.UpdatePositions(positionCode, positionName.Text, "superadmin", int.Parse(currentStatus.SelectedValue)))
            {
                Gv_position.EditIndex = -1;
                LoadPosition();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Sucessfully Updated');", true);
            }

        }

        protected void Gv_position_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Gv_position.EditIndex = -1;
            LoadPosition();
        }

        protected void Gv_position_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string positionCode = Gv_position.DataKeys[e.RowIndex].Values["positionCode"].ToString();

            if (sis.DeletePositions(positionCode))
            {
                LoadPosition();
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Sucessfully deleted');", true);
            }
        }

        protected void Gv_position_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Label lblsep = (Label)Gv_position.FooterRow.FindControl("lblsep");
            TextBox txtPositionName = (TextBox)Gv_position.FooterRow.FindControl("insPositionName");
            LinkButton linkBtnSave = (LinkButton)Gv_position.FooterRow.FindControl("LinkBtnSave");
            LinkButton linkBtnCancel = (LinkButton)Gv_position.FooterRow.FindControl("LinkBtnCancel");
            LinkButton linkBtnAdd = (LinkButton)Gv_position.FooterRow.FindControl("LinkBtnAdd");

            if (e.CommandName.Equals("Add"))
            {
                lblsep.Visible = true;
                txtPositionName.Visible = true;
                linkBtnSave.Visible = true;
                linkBtnCancel.Visible = true;
                linkBtnAdd.Visible = false;
            }
            if (e.CommandName.Equals("Save"))
            {
                if (sis.AddPositions(txtPositionName.Text, "superadmin"))
                {
                    LoadPosition();
                    lblmsg.Text = "created sucessfully";

                    lblsep.Visible = false;
                    txtPositionName.Visible = false;
                    linkBtnSave.Visible = false;
                    linkBtnCancel.Visible = false;
                    linkBtnAdd.Visible = true;
                }
                else
                {
                    lblmsg.Text = "not created sucessfully";
                }
            }
        }

        protected void BtmDisplay_Click(object sender, EventArgs e)
        {
            string data = "";
            foreach (GridViewRow row in Gv_position.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkCtrl") as CheckBox);
                    if (chkRow.Checked)
                    {
                        string storid = row.Cells[1].Text;
                        string storname = row.Cells[2].Text;
                        string state = row.Cells[3].Text;
                        data = data + storid + " ,  " + storname + " , " + state + "<br>";
                    }
                }
            }
            lblmsg.Text = data;
        }

        protected void Gv_position_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string pName = Gv_position.SelectedRow.Cells[2].Text; 
            string pjName = Gv_position.SelectedDataKey.Value.ToString();
            lblmsg.Text = "<b>Publisher Name   :     " + pjName + "</b>";
        }

        protected void Gv_position_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        } 
    }
}