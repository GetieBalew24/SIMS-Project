using SIS_Controller;
using SIS_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIS_View
{
    public partial class UserRole : System.Web.UI.Page
    {
        private readonly SISBLL sis = new SISBLL();

        string userId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadStaff();
                LoadUserRole();
            }
        }
        protected void LoadStaff()
        {
            DataTable dt = new DataTable();
            TBL_staff[] staff = sis.GetStaffs();
            dt.Columns.Add("staffId");
            dt.Columns.Add("fullname");
            dt.Columns.Add("recordedDate");
            if (staff.Count() > 0)
            {
                for (int j = 0; j < staff.Count(); j++)
                {
                    DataRow dr = dt.NewRow();
                    dr["staffId"] = staff[j].staffId;
                    dr["fullname"] = staff[j].firstName + " " + staff[j].fatherName + " " + staff[j].grandFatherName;
                    dr["recordedDate"] = staff[j].recordedDate;

                    dt.Rows.Add(dr);
                }
                Gv_userRole1.DataSource = dt;
                Gv_userRole1.DataBind();
            }
        }
        protected void LinkBtnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            TBL_staff[] staff;
            if (ddlSearch.SelectedItem.ToString() == "username")
                staff = sis.FindStaffCodes(txtSearchCriteria.Text.ToString());
            else if (ddlSearch.SelectedItem.ToString() == "firstname")
                staff = sis.FindStaffNames(txtSearchCriteria.Text.ToString());
            else
                staff = sis.GetStaffs();
            dt.Columns.Add("staffId");
            dt.Columns.Add("fullname");
            dt.Columns.Add("recordedDate");
            if (staff.Count() > 0)
            {
                for (int j = 0; j < staff.Count(); j++)
                {
                    DataRow dr = dt.NewRow();
                    dr["staffId"] = staff[j].staffId;
                    dr["fullname"] = staff[j].firstName + staff[j].fatherName;
                    dr["recordedDate"] = staff[j].recordedDate;
                    dt.Rows.Add(dr);
                }
                Gv_userRole1.DataSource = dt;
                Gv_userRole1.DataBind();
            }
        }
        protected void Gv_userRole1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pjName = Gv_userRole1.SelectedDataKey.Value.ToString();
            userId = pjName;
            lblmsg.Visible = true;
            Gv_userRole2.Visible = true;
            LoadUserRole();
            lblmsg.Text = "<b>University Code :     " + pjName + "</b>";
        }

        protected void Gv_userRole1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }
         
        private void LoadUserRole()
        {
            DataTable dt = new DataTable();
            TBL_userRole[] userRole = sis.FindUserRoleUsernames(userId);
            dt.Columns.Add("userRoleCode");
            dt.Columns.Add("username");
            dt.Columns.Add("roleCode");
            dt.Columns.Add("createdDate");

            if (userRole.Count() > 0)
            {
                for (int j = 0; j < userRole.Count(); j++)
                {
                    DataRow dr = dt.NewRow();
                    dr["userRoleCode"] = userRole[j].userRoleCode;
                    dr["username"] = userRole[j].username;
                    dr["roleCode"] = userRole[j].roleCode;
                    dr["createdDate"] = userRole[j].recordedDate;

                    dt.Rows.Add(dr);
                }
                Gv_userRole2.DataSource = dt;
                Gv_userRole2.DataBind();
            }
        }


        protected void Gv_userRole2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string userRoleCode = Gv_userRole2.DataKeys[e.RowIndex].Values["userRoleCode"].ToString();

            if (sis.DeleteUserRoles(userRoleCode))
            {
                LoadUserRole();
            }
        }

        protected void Gv_userRole2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DropDownList txtRoleCode = (DropDownList)Gv_userRole2.FooterRow.FindControl("insRoleCode");
            
            LinkButton linkBtnSave = (LinkButton)Gv_userRole2.FooterRow.FindControl("LinkBtnSave");
            LinkButton linkBtnCancel = (LinkButton)Gv_userRole2.FooterRow.FindControl("LinkBtnCancel");
            LinkButton linkBtnAdd = (LinkButton)Gv_userRole2.FooterRow.FindControl("LinkBtnAdd");

            if (e.CommandName.Equals("Add"))
            {
                txtRoleCode.Visible = true;

                linkBtnSave.Visible = true;
                linkBtnCancel.Visible = true;
                linkBtnAdd.Visible = false;
            }
            if (e.CommandName.Equals("Save"))
            {
                if (sis.AddUserRoles(userId.Trim(), txtRoleCode.SelectedValue, "superadmin"))
                { 
                    LoadUserRole();
                    txtRoleCode.Visible = false;
                    linkBtnSave.Visible = false;
                    linkBtnCancel.Visible = false;
                    linkBtnAdd.Visible = true;
                }
            }
        }

        protected void Gv_userRole2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Gv_userRole2.EditIndex = -1;
            LoadUserRole();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (sis.AddUserRoles(userId.Trim(), ddlRoless.SelectedValue, "superadmin"))
            {
                LoadUserRole();
            }
        }
    }
}