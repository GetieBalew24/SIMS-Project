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
    public partial class Kebele : System.Web.UI.Page
    {
        private readonly SISBLL sis = new SISBLL();
        private readonly DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadKebele();
            }
        }
        protected void LoadKebele()
        {
            TBL_kebele[] kebele = sis.GetAllKebeles();
            dt.Columns.Add("kebeleCode");
            dt.Columns.Add("woredaCode");
            dt.Columns.Add("kebeleName");
            dt.Columns.Add("recordedBy");
            dt.Columns.Add("recordedDate");
            dt.Columns.Add("recordedTime");
            dt.Columns.Add("lastModifiedBy");
            dt.Columns.Add("lastModifiedDate");
            dt.Columns.Add("lastModifiedTime");
            dt.Columns.Add("currentStatus");
            if (kebele.Count() > 0)
            {
                for (int j = 0; j < kebele.Count(); j++)
                {
                    String stat;
                    if (kebele[j].currentStatus == 0)
                        stat = "Inactive";
                    else
                        stat = "Active";
                    DataRow dr = dt.NewRow();
                    dr["kebeleCode"] = kebele[j].kebeleCode;
                    dr["woredaCode"] = kebele[j].woredaCode;
                    dr["kebeleName"] = kebele[j].kebeleName;
                    dr["recordedBy"] = kebele[j].recordedBy;
                    dr["recordedDate"] = kebele[j].recordedDate;
                    dr["recordedTime"] = kebele[j].recordedTime;
                    dr["lastModifiedBy"] = kebele[j].lastModifiedBy;
                    dr["lastModifiedDate"] = kebele[j].lastModifiedDate;
                    dr["lastModifiedTime"] = kebele[j].lastModifiedTime;
                    dr["currentStatus"] = stat;
                    dt.Rows.Add(dr);
                }
                Gv_kebele.DataSource = dt;
                Gv_kebele.DataBind();
            }
        }

        protected void Gv_kebele_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Gv_kebele.EditIndex = -1;
            LoadKebele();
        }

        protected void Gv_kebele_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string kebeleCode = Gv_kebele.DataKeys[e.RowIndex].Values["kebeleCode"].ToString();

            if (sis.DeleteKebeles(kebeleCode))
            {
                LoadKebele();
                lblmsg.Text = kebeleCode + "      Deleted successfully.......    ";
            }
        }

        protected void Gv_kebele_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Label lblsep = (Label)Gv_kebele.FooterRow.FindControl("lblsep");
            DropDownList woredaCode = (DropDownList)Gv_kebele.FooterRow.FindControl("insWoredaCode");
            TextBox kebeleName = (TextBox)Gv_kebele.FooterRow.FindControl("insKebeleName");

            LinkButton linkBtnSave = (LinkButton)Gv_kebele.FooterRow.FindControl("LinkBtnSave");
            LinkButton linkBtnCancel = (LinkButton)Gv_kebele.FooterRow.FindControl("LinkBtnCancel");
            LinkButton linkBtnAdd = (LinkButton)Gv_kebele.FooterRow.FindControl("LinkBtnAdd");

            if (e.CommandName.Equals("Add"))
            {
                lblsep.Visible = true;
                woredaCode.Visible = true;
                kebeleName.Visible = true;

                linkBtnSave.Visible = true;
                linkBtnCancel.Visible = true;
                linkBtnAdd.Visible = false;
            }
            if (e.CommandName.Equals("Save"))
            {
                if (sis.AddKebeles(woredaCode.SelectedValue, kebeleName.Text, "superadmin"))
                {
                    LoadKebele();
                    lblmsg.Text = "created sucessfully";

                    lblsep.Visible = false;
                    woredaCode.Visible = false;
                    kebeleName.Visible = false;

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

        protected void Gv_kebele_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }

        protected void BtmDisplay_Click(object sender, EventArgs e)
        {
            string data = "";
            foreach (GridViewRow row in Gv_kebele.Rows)
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

        protected void Gv_kebele_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string pName = Gv_university.SelectedRow.Cells[2].Text; 
            string pjName = Gv_kebele.SelectedDataKey.Value.ToString();
            lblmsg.Text = "<b>Publisher Name   :     " + pjName + "</b>";
        }
    }
}