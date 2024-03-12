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
    public partial class Religion : System.Web.UI.Page
    {
        private readonly SISBLL sis = new SISBLL();
        private readonly DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadReligion();
            }
        }
        protected void LoadReligion()
        {
            TBL_religion[] religion = sis.GetAllReligions();
            dt.Columns.Add("religionCode");
            dt.Columns.Add("religionName"); 
            dt.Columns.Add("recordedBy");
            dt.Columns.Add("recordedDate");
            dt.Columns.Add("recordedTime");
            dt.Columns.Add("lastModifiedBy");
            dt.Columns.Add("lastModifiedDate");
            dt.Columns.Add("lastModifiedTime");
            dt.Columns.Add("currentStatus");
            if (religion.Count() > 0)
            {
                for (int j = 0; j < religion.Count(); j++)
                {
                    String stat;
                    if (religion[j].currentStatus == 0)
                        stat = "Inactive";
                    else
                        stat = "Active";
                    DataRow dr = dt.NewRow();
                    dr["religionCode"] = religion[j].religionCode; 
                    dr["religionName"] = religion[j].religionName;
                    dr["recordedBy"] = religion[j].recordedBy;
                    dr["recordedDate"] = religion[j].recordedDate;
                    dr["recordedTime"] = religion[j].recordedTime;
                    dr["lastModifiedBy"] = religion[j].lastModifiedBy;
                    dr["lastModifiedDate"] = religion[j].lastModifiedDate;
                    dr["lastModifiedTime"] = religion[j].lastModifiedTime;
                    dr["currentStatus"] = stat;
                    dt.Rows.Add(dr);
                }
                Gv_religion.DataSource = dt;
                Gv_religion.DataBind();
            }
        }

        protected void Gv_religion_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Gv_religion.EditIndex = -1;
            LoadReligion();
        }

        protected void Gv_religion_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string religionCode = Gv_religion.DataKeys[e.RowIndex].Values["religionCode"].ToString();

            if (sis.DeleteReligions(religionCode))
            {
                LoadReligion();
                lblmsg.Text = religionCode + "      Deleted successfully.......    ";
            }
        }

        protected void Gv_religion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Label lblsep = (Label)Gv_religion.FooterRow.FindControl("lblsep");
            TextBox religionName = (TextBox)Gv_religion.FooterRow.FindControl("insReligionName");

            LinkButton linkBtnSave = (LinkButton)Gv_religion.FooterRow.FindControl("LinkBtnSave");
            LinkButton linkBtnCancel = (LinkButton)Gv_religion.FooterRow.FindControl("LinkBtnCancel");
            LinkButton linkBtnAdd = (LinkButton)Gv_religion.FooterRow.FindControl("LinkBtnAdd");

            if (e.CommandName.Equals("Add"))
            {
                lblsep.Visible = true; 
                religionName.Visible = true;

                linkBtnSave.Visible = true;
                linkBtnCancel.Visible = true;
                linkBtnAdd.Visible = false;
            }
            if (e.CommandName.Equals("Save"))
            {
                if (sis.AddReligions(religionName.Text, "superadmin"))
                {
                    LoadReligion();
                    lblmsg.Text = "created sucessfully";

                    lblsep.Visible = false; 
                    religionName.Visible = false;

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

        protected void Gv_religion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }

        protected void BtmDisplay_Click(object sender, EventArgs e)
        {
            string data = "";
            foreach (GridViewRow row in Gv_religion.Rows)
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

        protected void Gv_religion_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string pName = Gv_university.SelectedRow.Cells[2].Text; 
            string pjName = Gv_religion.SelectedDataKey.Value.ToString();
            lblmsg.Text = "<b>Publisher Name   :     " + pjName + "</b>";
        }
    }
}