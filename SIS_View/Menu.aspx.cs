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
    public partial class Menu : System.Web.UI.Page
    {
        private readonly SISBLL sis = new SISBLL();
        private readonly DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadMenu();
            }
        }
        protected void LoadMenu()
        {
            TBL_menu[] menu = sis.GetAllMenus();
            dt.Columns.Add("menuCode");
            dt.Columns.Add("parentCode");
            dt.Columns.Add("menuName");
            dt.Columns.Add("menuLink");
            dt.Columns.Add("recordedBy");
            dt.Columns.Add("recordedDate");
            dt.Columns.Add("recordedTime");
            dt.Columns.Add("lastModifiedBy");
            dt.Columns.Add("lastModifiedDate");
            dt.Columns.Add("lastModifiedTime");
            dt.Columns.Add("currentStatus");
            if (menu.Count() > 0)
            {
                for (int j = 0; j < menu.Count(); j++)
                {
                    String stat;
                    if (menu[j].currentStatus == 0)
                        stat = "InActive";
                    else
                        stat = "Active";
                    DataRow dr = dt.NewRow();
                    dr["menuCode"] = menu[j].menuCode;
                    dr["parentCode"] = menu[j].parentCode;
                    dr["menuName"] = menu[j].menuName;
                    dr["menuLink"] = menu[j].menuLink;
                    dr["recordedBy"] = menu[j].recordedBy;
                    dr["recordedDate"] = menu[j].recordedDate;
                    dr["recordedTime"] = menu[j].recordedTime;
                    dr["lastModifiedBy"] = menu[j].lastModifiedBy;
                    dr["lastModifiedDate"] = menu[j].lastModifiedDate;
                    dr["lastModifiedTime"] = menu[j].lastModifiedTime;
                    dr["currentStatus"] = stat;
                    dt.Rows.Add(dr);
                }
                Gv_menu.DataSource = dt;
                Gv_menu.DataBind();
            }
        }

        protected void Gv_menu_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Gv_menu.EditIndex = e.NewEditIndex;
            LoadMenu();
        }

        protected void Gv_menu_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String menuCode = Gv_menu.DataKeys[e.RowIndex].Values["menuCode"].ToString();
            TextBox menuName = (TextBox)Gv_menu.Rows[e.RowIndex].FindControl("txtMenuName");
            TextBox menuLink = (TextBox)Gv_menu.Rows[e.RowIndex].FindControl("txtMenuLink");
            DropDownList parentCode = (DropDownList)Gv_menu.Rows[e.RowIndex].FindControl("txtParentCode");
            DropDownList currentStatus = (DropDownList)Gv_menu.Rows[e.RowIndex].FindControl("ddlCurrentStatus");

            if (sis.UpdateMenus(int.Parse(menuCode), int.Parse(parentCode.SelectedValue), menuName.Text, menuLink.Text, "superadmin", int.Parse(currentStatus.SelectedValue)))
            {
                Gv_menu.EditIndex = -1;
                LoadMenu();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Sucessfully Updated');", true);
            }

        }

        protected void Gv_menu_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Gv_menu.EditIndex = -1;
            LoadMenu();
        }

        protected void Gv_menu_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string menuCode = Gv_menu.DataKeys[e.RowIndex].Values["menuCode"].ToString();

            if (sis.DeleteMenus(int.Parse(menuCode)))
            {
                LoadMenu();
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Sucessfully deleted');", true);
            }
        }

        protected void Gv_menu_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Label lblsep = (Label)Gv_menu.FooterRow.FindControl("lblsep");
            TextBox menuName = (TextBox)Gv_menu.FooterRow.FindControl("insMenuName");
            TextBox menuLink = (TextBox)Gv_menu.FooterRow.FindControl("insMenuLink");
            DropDownList parentCode = (DropDownList)Gv_menu.FooterRow.FindControl("insparentCode");

            LinkButton linkBtnSave = (LinkButton)Gv_menu.FooterRow.FindControl("LinkBtnSave");
            LinkButton linkBtnCancel = (LinkButton)Gv_menu.FooterRow.FindControl("LinkBtnCancel");
            LinkButton linkBtnAdd = (LinkButton)Gv_menu.FooterRow.FindControl("LinkBtnAdd");

            if (e.CommandName.Equals("Add"))
            {
                lblsep.Visible = true;
                menuName.Visible = true;
                menuLink.Visible = true;
                parentCode.Visible = true;

                linkBtnSave.Visible = true;
                linkBtnCancel.Visible = true;
                linkBtnAdd.Visible = false;
            }
            if (e.CommandName.Equals("Save"))
            {
                if (sis.AddMenus(int.Parse(parentCode.SelectedValue), menuName.Text, menuLink.Text, "superadmin"))
                {
                    LoadMenu();
                    lblmsg.Text = "created sucessfully";

                    lblsep.Visible = false;
                    menuName.Visible = false;
                    menuLink.Visible = false;
                    parentCode.Visible = false;
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
            foreach (GridViewRow row in Gv_menu.Rows)
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

        protected void Gv_menu_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string pName = Gv_menu.SelectedRow.Cells[2].Text; 
            string pjName = Gv_menu.SelectedDataKey.Value.ToString();
            lblmsg.Text = "<b>Publisher Name   :     " + pjName + "</b>";
        }

        protected void Gv_menu_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }
    }
}