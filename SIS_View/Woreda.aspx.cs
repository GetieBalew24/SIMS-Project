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
    public partial class Woreda : System.Web.UI.Page
    {
        private readonly SISBLL sis = new SISBLL();
        private readonly DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadWoreda();
            }
        }
        protected void LoadWoreda()
        {
            TBL_woreda[] woreda = sis.GetAllWoredas();
            dt.Columns.Add("woredaCode");
            dt.Columns.Add("zoneCode");
            dt.Columns.Add("woredaName");
            dt.Columns.Add("recordedBy");
            dt.Columns.Add("recordedDate");
            dt.Columns.Add("recordedTime");
            dt.Columns.Add("lastModifiedBy");
            dt.Columns.Add("lastModifiedDate");
            dt.Columns.Add("lastModifiedTime");
            dt.Columns.Add("currentStatus");
            if (woreda.Count() > 0)
            {
                for (int j = 0; j < woreda.Count(); j++)
                {
                    String stat;
                    if (woreda[j].currentStatus == 0)
                        stat = "Inactive";
                    else
                        stat = "Active";
                    DataRow dr = dt.NewRow();
                    dr["woredaCode"] = woreda[j].woredaCode;
                    dr["zoneCode"] = woreda[j].zoneCode;
                    dr["woredaName"] = woreda[j].woredaName;
                    dr["recordedBy"] = woreda[j].recordedBy;
                    dr["recordedDate"] = woreda[j].recordedDate;
                    dr["recordedTime"] = woreda[j].recordedTime;
                    dr["lastModifiedBy"] = woreda[j].lastModifiedBy;
                    dr["lastModifiedDate"] = woreda[j].lastModifiedDate;
                    dr["lastModifiedTime"] = woreda[j].lastModifiedTime;
                    dr["currentStatus"] = stat;
                    dt.Rows.Add(dr);
                }
                Gv_woreda.DataSource = dt;
                Gv_woreda.DataBind();
            }
        }

        protected void Gv_woreda_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Gv_woreda.EditIndex = -1;
            LoadWoreda();
        }

        protected void Gv_woreda_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string woredaCode = Gv_woreda.DataKeys[e.RowIndex].Values["woredaCode"].ToString();

            if (sis.DeleteWoredas(woredaCode))
            {
                LoadWoreda();
                lblmsg.Text = woredaCode + "      Deleted successfully.......    ";
            }
        }

        protected void Gv_woreda_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Label lblsep = (Label)Gv_woreda.FooterRow.FindControl("lblsep");
            DropDownList zoneCode = (DropDownList)Gv_woreda.FooterRow.FindControl("insZoneCode");
            TextBox woredaName = (TextBox)Gv_woreda.FooterRow.FindControl("insWoredaName");

            LinkButton linkBtnSave = (LinkButton)Gv_woreda.FooterRow.FindControl("LinkBtnSave");
            LinkButton linkBtnCancel = (LinkButton)Gv_woreda.FooterRow.FindControl("LinkBtnCancel");
            LinkButton linkBtnAdd = (LinkButton)Gv_woreda.FooterRow.FindControl("LinkBtnAdd");

            if (e.CommandName.Equals("Add"))
            {
                lblsep.Visible = true;
                zoneCode.Visible = true;
                woredaName.Visible = true;

                linkBtnSave.Visible = true;
                linkBtnCancel.Visible = true;
                linkBtnAdd.Visible = false;
            }
            if (e.CommandName.Equals("Save"))
            {
                if (sis.AddWoredas(zoneCode.SelectedValue, woredaName.Text, "superadmin"))
                {
                    LoadWoreda();
                    lblmsg.Text = "created sucessfully";

                    lblsep.Visible = false;
                    zoneCode.Visible = false;
                    woredaName.Visible = false;

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

        protected void Gv_woreda_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }

        protected void BtmDisplay_Click(object sender, EventArgs e)
        {
            string data = "";
            foreach (GridViewRow row in Gv_woreda.Rows)
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

        protected void Gv_woreda_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string pName = Gv_university.SelectedRow.Cells[2].Text; 
            string pjName = Gv_woreda.SelectedDataKey.Value.ToString();
            lblmsg.Text = "<b>Publisher Name   :     " + pjName + "</b>";
        }
    }
}