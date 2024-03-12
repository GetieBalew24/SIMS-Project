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
    public partial class Ethinic : System.Web.UI.Page
    {
        private readonly SISBLL sis = new SISBLL();
        private readonly DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadEthinic();
            }
        }
        protected void LoadEthinic()
        {
            TBL_ethinic[] ethinic = sis.GetAllEthinics();
            dt.Columns.Add("ethinicCode");
            dt.Columns.Add("ethinicName");
            dt.Columns.Add("recordedBy");
            dt.Columns.Add("recordedDate");
            dt.Columns.Add("recordedTime");
            dt.Columns.Add("lastModifiedBy");
            dt.Columns.Add("lastModifiedDate");
            dt.Columns.Add("lastModifiedTime");
            dt.Columns.Add("currentStatus");
            if (ethinic.Count() > 0)
            {
                for (int j = 0; j < ethinic.Count(); j++)
                {
                    String stat;
                    if (ethinic[j].currentStatus == 0)
                        stat = "Inactive";
                    else
                        stat = "Active";
                    DataRow dr = dt.NewRow();
                    dr["ethinicCode"] = ethinic[j].ethinicCode;
                    dr["ethinicName"] = ethinic[j].ethinicName;
                    dr["recordedBy"] = ethinic[j].recordedBy;
                    dr["recordedDate"] = ethinic[j].recordedDate;
                    dr["recordedTime"] = ethinic[j].recordedTime;
                    dr["lastModifiedBy"] = ethinic[j].lastModifiedBy;
                    dr["lastModifiedDate"] = ethinic[j].lastModifiedDate;
                    dr["lastModifiedTime"] = ethinic[j].lastModifiedTime;
                    dr["currentStatus"] = stat;
                    dt.Rows.Add(dr);
                }
                Gv_ethinic.DataSource = dt;
                Gv_ethinic.DataBind();
            }
        }

        protected void Gv_ethinic_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Gv_ethinic.EditIndex = -1;
            LoadEthinic();
        }

        protected void Gv_ethinic_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string ethinicCode = Gv_ethinic.DataKeys[e.RowIndex].Values["ethinicCode"].ToString();

            if (sis.DeleteEthinics(ethinicCode))
            {
                LoadEthinic();
                lblmsg.Text = ethinicCode + "      Deleted successfully.......    ";
            }
        }

        protected void Gv_ethinic_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Label lblsep = (Label)Gv_ethinic.FooterRow.FindControl("lblsep");
            TextBox ethinicName = (TextBox)Gv_ethinic.FooterRow.FindControl("insEthinicName");

            LinkButton linkBtnSave = (LinkButton)Gv_ethinic.FooterRow.FindControl("LinkBtnSave");
            LinkButton linkBtnCancel = (LinkButton)Gv_ethinic.FooterRow.FindControl("LinkBtnCancel");
            LinkButton linkBtnAdd = (LinkButton)Gv_ethinic.FooterRow.FindControl("LinkBtnAdd");

            if (e.CommandName.Equals("Add"))
            {
                lblsep.Visible = true;
                ethinicName.Visible = true;

                linkBtnSave.Visible = true;
                linkBtnCancel.Visible = true;
                linkBtnAdd.Visible = false;
            }
            if (e.CommandName.Equals("Save"))
            {
                if (sis.AddEthinics(ethinicName.Text, "superadmin"))
                {
                    LoadEthinic();
                    lblmsg.Text = "created sucessfully";

                    lblsep.Visible = false;
                    ethinicName.Visible = false;

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

        protected void Gv_ethinic_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }

        protected void BtmDisplay_Click(object sender, EventArgs e)
        {
            string data = "";
            foreach (GridViewRow row in Gv_ethinic.Rows)
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

        protected void Gv_ethinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string pName = Gv_university.SelectedRow.Cells[2].Text; 
            string pjName = Gv_ethinic.SelectedDataKey.Value.ToString();
            lblmsg.Text = "<b>Publisher Name   :     " + pjName + "</b>";
        }
    }
}