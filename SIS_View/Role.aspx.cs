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
    public partial class Role : System.Web.UI.Page
    {
        private readonly SISBLL sis = new SISBLL();
        private readonly DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadRole();
            }
        }
        protected void LoadRole()
        {
            TBL_role[] role = sis.GetAllRoles();
            dt.Columns.Add("roleCode");
            dt.Columns.Add("roleName");
            dt.Columns.Add("recordedBy");
            dt.Columns.Add("recordedDate");
            dt.Columns.Add("recordedTime");
            dt.Columns.Add("lastModifiedBy");
            dt.Columns.Add("lastModifiedDate");
            dt.Columns.Add("lastModifiedTime");
            dt.Columns.Add("currentStatus");
            if (role.Count() > 0)
            {
                for (int j = 0; j < role.Count(); j++)
                {
                    String stat;
                    if (role[j].currentStatus == 0)
                        stat = "InActive";
                    else
                        stat = "Active";
                    DataRow dr = dt.NewRow();
                    dr["roleCode"] = role[j].roleCode;
                    dr["roleName"] = role[j].roleName;
                    dr["recordedBy"] = role[j].recordedBy;
                    dr["recordedDate"] = role[j].recordedDate;
                    dr["recordedTime"] = role[j].recordedTime;
                    dr["lastModifiedBy"] = role[j].lastModifiedBy;
                    dr["lastModifiedDate"] = role[j].lastModifiedDate;
                    dr["lastModifiedTime"] = role[j].lastModifiedTime;
                    dr["currentStatus"] = stat;
                    dt.Rows.Add(dr);
                }
                Gv_role.DataSource = dt;
                Gv_role.DataBind();
            }
        }

        protected void Gv_role_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Gv_role.EditIndex = e.NewEditIndex;
            LoadRole();
        }

        protected void Gv_role_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String roleCode = Gv_role.DataKeys[e.RowIndex].Values["roleCode"].ToString();
            TextBox roleName = (TextBox)Gv_role.Rows[e.RowIndex].FindControl("txtRoleName");
            DropDownList currentStatus = (DropDownList)Gv_role.Rows[e.RowIndex].FindControl("ddlCurrentStatus");

            if (sis.UpdateRoles(roleCode, roleName.Text, "superadmin", int.Parse(currentStatus.SelectedValue)))
            {
                Gv_role.EditIndex = -1;
                LoadRole();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Sucessfully Updated');", true);
            }

        }

        protected void Gv_role_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Gv_role.EditIndex = -1;
            LoadRole();
        }

        protected void Gv_role_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string roleCode = Gv_role.DataKeys[e.RowIndex].Values["roleCode"].ToString();

            if (sis.DeleteRoles(roleCode))
            {
                LoadRole();
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Sucessfully deleted');", true);
            }
        }

        protected void Gv_role_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Label lblsep = (Label)Gv_role.FooterRow.FindControl("lblsep");
            TextBox txtRoleName = (TextBox)Gv_role.FooterRow.FindControl("insRoleName");
            LinkButton linkBtnSave = (LinkButton)Gv_role.FooterRow.FindControl("LinkBtnSave");
            LinkButton linkBtnCancel = (LinkButton)Gv_role.FooterRow.FindControl("LinkBtnCancel");
            LinkButton linkBtnAdd = (LinkButton)Gv_role.FooterRow.FindControl("LinkBtnAdd");

            if (e.CommandName.Equals("Add"))
            {
                lblsep.Visible = true;
                txtRoleName.Visible = true;
                linkBtnSave.Visible = true;
                linkBtnCancel.Visible = true;
                linkBtnAdd.Visible = false;
            }
            if (e.CommandName.Equals("Save"))
            {
                if (sis.AddRoles(txtRoleName.Text, "superadmin"))
                {
                    LoadRole();
                    lblmsg.Text = "created sucessfully";

                    lblsep.Visible = false;
                    txtRoleName.Visible = false;
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
            foreach (GridViewRow row in Gv_role.Rows)
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

        protected void Gv_role_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string pName = Gv_role.SelectedRow.Cells[2].Text; 
            string pjName = Gv_role.SelectedDataKey.Value.ToString();
            lblmsg.Text = "<b>Publisher Name   :     " + pjName + "</b>";
        }

        protected void Gv_role_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }
    }
}