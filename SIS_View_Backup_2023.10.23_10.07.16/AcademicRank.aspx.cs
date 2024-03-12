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
    public partial class AcademicRank : System.Web.UI.Page
    {
        private readonly SISBLL sis = new SISBLL();
        private readonly DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadAcademicRank();
            }
        }
        protected void LoadAcademicRank()
        {
            TBL_academicRank[] academicRank = sis.GetAllAcAdemicRanks();
            dt.Columns.Add("academicRankCode");
            dt.Columns.Add("academicRankName");
            dt.Columns.Add("recordedBy");
            dt.Columns.Add("recordedDate");
            dt.Columns.Add("recordedTime");
            dt.Columns.Add("lastModifiedBy");
            dt.Columns.Add("lastModifiedDate");
            dt.Columns.Add("lastModifiedTime");
            dt.Columns.Add("currentStatus");
            if (academicRank.Count() > 0)
            {
                for (int j = 0; j < academicRank.Count(); j++)
                {
                    String stat;
                    if (academicRank[j].currentStatus == 0)
                        stat = "InActive";
                    else
                        stat = "Active";
                    DataRow dr = dt.NewRow();
                    dr["academicRankCode"] = academicRank[j].academicRankCode;
                    dr["academicRankName"] = academicRank[j].academicRankName;
                    dr["recordedBy"] = academicRank[j].recordedBy;
                    dr["recordedDate"] = academicRank[j].recordedDate;
                    dr["recordedTime"] = academicRank[j].recordedTime;
                    dr["lastModifiedBy"] = academicRank[j].lastModifiedBy;
                    dr["lastModifiedDate"] = academicRank[j].lastModifiedDate;
                    dr["lastModifiedTime"] = academicRank[j].lastModifiedTime;
                    dr["currentStatus"] = stat;
                    dt.Rows.Add(dr);
                }
                Gv_academicRank.DataSource = dt;
                Gv_academicRank.DataBind();
            }
        }

        protected void Gv_academicRank_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Gv_academicRank.EditIndex = e.NewEditIndex;
            LoadAcademicRank();
        }

        protected void Gv_academicRank_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String academicRankCode = Gv_academicRank.DataKeys[e.RowIndex].Values["academicRankCode"].ToString();
            TextBox academicRankName = (TextBox)Gv_academicRank.Rows[e.RowIndex].FindControl("txtAcademicRankName");
            DropDownList currentStatus = (DropDownList)Gv_academicRank.Rows[e.RowIndex].FindControl("ddlCurrentStatus");

            if (sis.UpdateAcademicRanks(academicRankCode, academicRankName.Text, "superadmin", int.Parse(currentStatus.SelectedValue)))
            {
                Gv_academicRank.EditIndex = -1;
                LoadAcademicRank();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Sucessfully Updated');", true);
            }

        }

        protected void Gv_academicRank_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Gv_academicRank.EditIndex = -1;
            LoadAcademicRank();
        }

        protected void Gv_academicRank_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string academicRankCode = Gv_academicRank.DataKeys[e.RowIndex].Values["academicRankCode"].ToString();

            if (sis.DeleteAcademicRanks(academicRankCode))
            {
                LoadAcademicRank();
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Sucessfully deleted');", true);
            }
        }

        protected void Gv_academicRank_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Label lblsep = (Label)Gv_academicRank.FooterRow.FindControl("lblsep");
            TextBox txtAcademicRankName = (TextBox)Gv_academicRank.FooterRow.FindControl("insAcademicRankName");
            LinkButton linkBtnSave = (LinkButton)Gv_academicRank.FooterRow.FindControl("LinkBtnSave");
            LinkButton linkBtnCancel = (LinkButton)Gv_academicRank.FooterRow.FindControl("LinkBtnCancel");
            LinkButton linkBtnAdd = (LinkButton)Gv_academicRank.FooterRow.FindControl("LinkBtnAdd");

            if (e.CommandName.Equals("Add"))
            {
                lblsep.Visible = true;
                txtAcademicRankName.Visible = true;
                linkBtnSave.Visible = true;
                linkBtnCancel.Visible = true;
                linkBtnAdd.Visible = false;
            }
            if (e.CommandName.Equals("Save"))
            {
                if (sis.AddAcademicRanks(txtAcademicRankName.Text, "superadmin"))
                {
                    LoadAcademicRank();
                    lblmsg.Text = "created sucessfully";

                    lblsep.Visible = false;
                    txtAcademicRankName.Visible = false;
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
            foreach (GridViewRow row in Gv_academicRank.Rows)
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

        protected void Gv_academicRank_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string pName = Gv_academicRank.SelectedRow.Cells[2].Text; 
            string pjName = Gv_academicRank.SelectedDataKey.Value.ToString();
            lblmsg.Text = "<b>Publisher Name   :     " + pjName + "</b>";
        }

        protected void Gv_academicRank_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }
    }
}