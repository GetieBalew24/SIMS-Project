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
    public partial class Systems : System.Web.UI.Page
    {
        private readonly SISBLL sis = new SISBLL();
        private readonly DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadSystem();
            }
        }
        protected void LoadSystem()
        {
            TBL_system[] system = sis.GetAllSystems();
            dt.Columns.Add("systemCode");
            dt.Columns.Add("systemName");
            dt.Columns.Add("recordedBy");
            dt.Columns.Add("recordedDate");
            dt.Columns.Add("recordedTime");
            dt.Columns.Add("lastModifiedBy");
            dt.Columns.Add("lastModifiedDate");
            dt.Columns.Add("lastModifiedTime");
            dt.Columns.Add("currentStatus");
            if (system.Count() > 0)
            {
                for (int j = 0; j < system.Count(); j++)
                {
                    String stat;
                    if (system[j].currentStatus == 0)
                        stat = "InActive";
                    else
                        stat = "Active";
                    DataRow dr = dt.NewRow();
                    dr["systemCode"] = system[j].systemCode;
                    dr["systemName"] = system[j].systemName;
                    dr["recordedBy"] = system[j].recordedBy;
                    dr["recordedDate"] = system[j].recordedDate;
                    dr["recordedTime"] = system[j].recordedTime;
                    dr["lastModifiedBy"] = system[j].lastModifiedBy;
                    dr["lastModifiedDate"] = system[j].lastModifiedDate;
                    dr["lastModifiedTime"] = system[j].lastModifiedTime;
                    dr["currentStatus"] = stat;
                    dt.Rows.Add(dr);
                }
                Gv_system.DataSource = dt;
                Gv_system.DataBind();
            }
        }

        protected void Gv_system_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Gv_system.EditIndex = e.NewEditIndex;
            LoadSystem();
        }

        protected void Gv_system_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String systemCode = Gv_system.DataKeys[e.RowIndex].Values["systemCode"].ToString();
            TextBox systemName = (TextBox)Gv_system.Rows[e.RowIndex].FindControl("txtSystemName");
            DropDownList currentStatus = (DropDownList)Gv_system.Rows[e.RowIndex].FindControl("ddlCurrentStatus");

            if (sis.UpdateSystems(systemCode, systemName.Text, "superadmin", int.Parse(currentStatus.SelectedValue)))
            {
                Gv_system.EditIndex = -1;
                LoadSystem();
            }
        }

        protected void Gv_system_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Gv_system.EditIndex = -1;
            LoadSystem();
        }

        protected void Gv_system_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string systemCode = Gv_system.DataKeys[e.RowIndex].Values["systemCode"].ToString();

            if (sis.DeleteSystems(systemCode))
            {
                LoadSystem();
                lblmsg.Text = systemCode + "      Deleted successfully.......    ";
            }
        }

        protected void Gv_system_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Label lblsep = (Label)Gv_system.FooterRow.FindControl("lblsep");
            TextBox txtSystemName = (TextBox)Gv_system.FooterRow.FindControl("insSystemName");
            LinkButton linkBtnSave = (LinkButton)Gv_system.FooterRow.FindControl("LinkBtnSave");
            LinkButton linkBtnCancel = (LinkButton)Gv_system.FooterRow.FindControl("LinkBtnCancel");
            LinkButton linkBtnAdd = (LinkButton)Gv_system.FooterRow.FindControl("LinkBtnAdd");

            if (e.CommandName.Equals("Add"))
            {
                lblsep.Visible = true;
                txtSystemName.Visible = true;
                linkBtnSave.Visible = true;
                linkBtnCancel.Visible = true;
                linkBtnAdd.Visible = false;
            }
            if (e.CommandName.Equals("Save"))
            {
                if (sis.AddSystems(txtSystemName.Text, "superadmin"))
                {
                    LoadSystem();
                    lblmsg.Text = "created sucessfully";

                    lblsep.Visible = false;
                    txtSystemName.Visible = false;
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

        protected void Gv_system_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string pName = Gv_system.SelectedRow.Cells[2].Text;
            lblmsg.Text = "<b>Publisher Name   :     " + pName + "</b>";
        }

        protected void BtmDisplay_Click(object sender, EventArgs e)
        {
            string data = "";
            foreach (GridViewRow row in Gv_system.Rows)
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

        protected void Gv_system_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }

        protected void Gv_system_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string pName = Gv_university.SelectedRow.Cells[2].Text; 
            string pjName = Gv_system.SelectedDataKey.Value.ToString();
            lblmsg.Text = "<b>Publisher Name   :     " + pjName + "</b>";
        }
    }
}