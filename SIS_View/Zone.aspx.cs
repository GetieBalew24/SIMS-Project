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
    public partial class Zone : System.Web.UI.Page
    {
        private readonly SISBLL sis = new SISBLL();
        private readonly DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadZone();
            }
        }
        protected void LoadZone()
        {
            TBL_zone[] zone = sis.GetAllZones();
            dt.Columns.Add("zoneCode");
            dt.Columns.Add("regionCode");
            dt.Columns.Add("zoneName"); 
            dt.Columns.Add("recordedBy");
            dt.Columns.Add("recordedDate");
            dt.Columns.Add("recordedTime");
            dt.Columns.Add("lastModifiedBy");
            dt.Columns.Add("lastModifiedDate");
            dt.Columns.Add("lastModifiedTime");
            dt.Columns.Add("currentStatus");
            if (zone.Count() > 0)
            {
                for (int j = 0; j < zone.Count(); j++)
                {
                    String stat;
                    if (zone[j].currentStatus == 0)
                        stat = "Inactive";
                    else
                        stat = "Active";
                    DataRow dr = dt.NewRow();
                    dr["zoneCode"] = zone[j].zoneCode;
                    dr["regionCode"] = zone[j].regionCode;
                    dr["zoneName"] = zone[j].zoneName; 
                    dr["recordedBy"] = zone[j].recordedBy;
                    dr["recordedDate"] = zone[j].recordedDate;
                    dr["recordedTime"] = zone[j].recordedTime;
                    dr["lastModifiedBy"] = zone[j].lastModifiedBy;
                    dr["lastModifiedDate"] = zone[j].lastModifiedDate;
                    dr["lastModifiedTime"] = zone[j].lastModifiedTime;
                    dr["currentStatus"] = stat;
                    dt.Rows.Add(dr);
                }
                Gv_zone.DataSource = dt;
                Gv_zone.DataBind();
            }
        }

        protected void Gv_zone_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Gv_zone.EditIndex = -1;
            LoadZone();
        }

        protected void Gv_zone_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string zoneCode = Gv_zone.DataKeys[e.RowIndex].Values["zoneCode"].ToString();

            if (sis.DeleteZones(zoneCode))
            {
                LoadZone();
                lblmsg.Text = zoneCode + "      Deleted successfully.......    ";
            }
        }

        protected void Gv_zone_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Label lblsep = (Label)Gv_zone.FooterRow.FindControl("lblsep"); 
            DropDownList regionCode = (DropDownList)Gv_zone.FooterRow.FindControl("insRegionCode");
            TextBox zoneName = (TextBox)Gv_zone.FooterRow.FindControl("insZoneName");

            LinkButton linkBtnSave = (LinkButton)Gv_zone.FooterRow.FindControl("LinkBtnSave");
            LinkButton linkBtnCancel = (LinkButton)Gv_zone.FooterRow.FindControl("LinkBtnCancel");
            LinkButton linkBtnAdd = (LinkButton)Gv_zone.FooterRow.FindControl("LinkBtnAdd");

            if (e.CommandName.Equals("Add"))
            {
                lblsep.Visible = true;
                regionCode.Visible = true;
                zoneName.Visible = true; 

                linkBtnSave.Visible = true;
                linkBtnCancel.Visible = true;
                linkBtnAdd.Visible = false;
            }
            if (e.CommandName.Equals("Save"))
            {
                if (sis.AddZones(regionCode.SelectedValue,zoneName.Text, "superadmin"))
                {
                    LoadZone();
                    lblmsg.Text = "created sucessfully";

                    lblsep.Visible = false;
                    regionCode.Visible = false;
                    zoneName.Visible = false; 

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

        protected void Gv_zone_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }
 
        protected void BtmDisplay_Click(object sender, EventArgs e)
        {
            string data = "";
            foreach (GridViewRow row in Gv_zone.Rows)
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

        protected void Gv_zone_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string pName = Gv_university.SelectedRow.Cells[2].Text; 
            string pjName = Gv_zone.SelectedDataKey.Value.ToString();
            lblmsg.Text = "<b>Publisher Name   :     " + pjName + "</b>";
        }
    }
}