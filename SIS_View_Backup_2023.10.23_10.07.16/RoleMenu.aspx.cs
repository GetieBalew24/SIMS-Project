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
    public partial class RoleMenu : System.Web.UI.Page
    {
        private readonly SISBLL sis = new SISBLL();
        private readonly DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Gv_LoadRoleMenu();
            }
        }
        protected void Gv_LoadRoleMenu()
        {
            TBL_roleMenu[] roleMenu = sis.GetAllRoleMenus();
            dt.Columns.Add("roleMenuCode");
            dt.Columns.Add("menuCode");
            dt.Columns.Add("roleCode");
            dt.Columns.Add("recordedBy");
            dt.Columns.Add("recordedDate");
            dt.Columns.Add("recordedTime");
            dt.Columns.Add("lastModifiedBy");
            dt.Columns.Add("lastModifiedDate");
            dt.Columns.Add("lastModifiedTime");
            dt.Columns.Add("currentStatus");
            if (roleMenu.Count() > 0)
            {
                for (int j = 0; j < roleMenu.Count(); j++)
                {
                    String stat;
                    if (roleMenu[j].currentStatus == 0)
                        stat = "Inactive";
                    else
                        stat = "Active";
                    DataRow dr = dt.NewRow();

                    dr["roleMenuCode"] = roleMenu[j].roleMenuCode;
                    dr["menuCode"] = roleMenu[j].menuCode;
                    dr["roleCode"] = roleMenu[j].roleCode;
                    dr["recordedBy"] = roleMenu[j].recordedBy;
                    dr["recordedDate"] = roleMenu[j].recordedDate;
                    dr["recordedTime"] = roleMenu[j].recordedTime;
                    dr["lastModifiedBy"] = roleMenu[j].lastModifiedBy;
                    dr["lastModifiedDate"] = roleMenu[j].lastModifiedDate;
                    dr["lastModifiedTime"] = roleMenu[j].lastModifiedTime;
                    dr["currentStatus"] = stat;
                    dt.Rows.Add(dr);
                }
                Gv_roleMenu.DataSource = dt;
                Gv_roleMenu.DataBind();
            }
        }
        protected void Gv_roleMenu_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Gv_roleMenu.EditIndex = -1;
            Gv_LoadRoleMenu();
        }

        protected void Gv_roleMenu_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string roleMenuCode = Gv_roleMenu.DataKeys[e.RowIndex].Values["roleMenuCode"].ToString();

            if (sis.DeleteRoleMenus(roleMenuCode))
            {
                Gv_LoadRoleMenu();
                lblmsg.Text = roleMenuCode + "      Deleted successfully.......    ";
            }
        }

        protected void Gv_roleMenu_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DropDownList menuCode = (DropDownList)Gv_roleMenu.FooterRow.FindControl("insMenuCode");
            DropDownList roleCode = (DropDownList)Gv_roleMenu.FooterRow.FindControl("insRoleCode");

            LinkButton linkBtnSave = (LinkButton)Gv_roleMenu.FooterRow.FindControl("LinkBtnSave");
            LinkButton linkBtnCancel = (LinkButton)Gv_roleMenu.FooterRow.FindControl("LinkBtnCancel");
            LinkButton linkBtnAdd = (LinkButton)Gv_roleMenu.FooterRow.FindControl("LinkBtnAdd");

            if (e.CommandName.Equals("Add"))
            {
                menuCode.Visible = true;
                roleCode.Visible = true;

                linkBtnSave.Visible = true;
                linkBtnCancel.Visible = true;
                linkBtnAdd.Visible = false;
            }
            if (e.CommandName.Equals("Save"))
            {
                if (sis.AddRoleMenus(roleCode.SelectedValue, int.Parse(menuCode.SelectedValue),  "superadmin"))
                {
                    Gv_LoadRoleMenu();
                    lblmsg.Text = "created sucessfully";

                    menuCode.Visible = false;
                    roleCode.Visible = false;

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

        protected void Gv_roleMenu_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }

        protected void Gv_roleMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string pName = Gv_university.SelectedRow.Cells[2].Text; 
            string pjName = Gv_roleMenu.SelectedDataKey.Value.ToString();
            lblmsg.Text = "<b>Publisher Name   :     " + pjName + "</b>";
        }

    }
}