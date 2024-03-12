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
    public partial class Region : System.Web.UI.Page
    {
        private readonly SISBLL sis = new SISBLL();
        private readonly DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadRegion();
            }
        }
        protected void LoadRegion()
        {
            TBL_region[] region = sis.GetAllRegions();
            dt.Columns.Add("regionCode");
            dt.Columns.Add("countryCode");
            dt.Columns.Add("regionName");
            dt.Columns.Add("regionNo"); 
            dt.Columns.Add("recordedBy");
            dt.Columns.Add("recordedDate");
            dt.Columns.Add("recordedTime");
            dt.Columns.Add("lastModifiedBy");
            dt.Columns.Add("lastModifiedDate");
            dt.Columns.Add("lastModifiedTime");
            dt.Columns.Add("currentStatus");
            if (region.Count() > 0)
            {
                for (int j = 0; j < region.Count(); j++)
                {
                    String stat;
                    if (region[j].currentStatus == 0)
                        stat = "Inactive";
                    else
                        stat = "Active";
                    DataRow dr = dt.NewRow();
                    dr["regionCode"] = region[j].regionCode;
                    dr["countryCode"] = region[j].countryCode;
                    dr["regionName"] = region[j].regionName;
                    dr["regionNo"] = region[j].regionNo; 
                    dr["recordedBy"] = region[j].recordedBy;
                    dr["recordedDate"] = region[j].recordedDate;
                    dr["recordedTime"] = region[j].recordedTime;
                    dr["lastModifiedBy"] = region[j].lastModifiedBy;
                    dr["lastModifiedDate"] = region[j].lastModifiedDate;
                    dr["lastModifiedTime"] = region[j].lastModifiedTime;
                    dr["currentStatus"] = stat;
                    dt.Rows.Add(dr);
                }
                Gv_region.DataSource = dt;
                Gv_region.DataBind();
            }
        }

        protected void Gv_region_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Gv_region.EditIndex = -1;
            LoadRegion();
        }

        protected void Gv_region_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string regionCode = Gv_region.DataKeys[e.RowIndex].Values["regionCode"].ToString();

            if (sis.DeleteRegions(regionCode))
            {
                LoadRegion();
                lblmsg.Text = regionCode + "      Deleted successfully.......    ";
            }
        }

        protected void Gv_region_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Label lblsep = (Label)Gv_region.FooterRow.FindControl("lblsep");
            TextBox regionName = (TextBox)Gv_region.FooterRow.FindControl("insRegionName");
            DropDownList countryCode = (DropDownList)Gv_region.FooterRow.FindControl("insCountryCode");
            TextBox regionNo = (TextBox)Gv_region.FooterRow.FindControl("insRegionNo");

            LinkButton linkBtnSave = (LinkButton)Gv_region.FooterRow.FindControl("LinkBtnSave");
            LinkButton linkBtnCancel = (LinkButton)Gv_region.FooterRow.FindControl("LinkBtnCancel");
            LinkButton linkBtnAdd = (LinkButton)Gv_region.FooterRow.FindControl("LinkBtnAdd");

            if (e.CommandName.Equals("Add"))
            {
                lblsep.Visible = true;
                regionName.Visible = true;
                countryCode.Visible = true;
                regionNo.Visible = true;

                linkBtnSave.Visible = true;
                linkBtnCancel.Visible = true;
                linkBtnAdd.Visible = false;
            }
            if (e.CommandName.Equals("Save"))
            {
                if (sis.AddRegions(countryCode.SelectedValue,regionName.Text,regionNo.Text, "superadmin"))
                {
                    LoadRegion();
                    lblmsg.Text = "created sucessfully";

                    lblsep.Visible = false;
                    regionName.Visible = false;
                    countryCode.Visible = false;
                    regionNo.Visible = false;

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

        protected void Gv_region_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }

        protected void Gv_region_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string pName = Gv_university.SelectedRow.Cells[2].Text; 
            string pjName = Gv_region.SelectedDataKey.Value.ToString();
            lblmsg.Text = "<b>Publisher Name   :     " + pjName + "</b>";
        }

        protected void BtmDisplay_Click(object sender, EventArgs e)
        {
            string data = "";
            foreach (GridViewRow row in Gv_region.Rows)
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
    }
}