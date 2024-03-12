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
    public partial class Staffcategory : System.Web.UI.Page
    {
        private readonly SISBLL sis = new SISBLL();
        private readonly DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadStaffCategory();
            }
        }
        protected void LoadStaffCategory()
        {
            TBL_staffCategory[] staffCategory = sis.GetAllStaffCategories();
            dt.Columns.Add("staffCategoryCode");
            dt.Columns.Add("staffCategoryName");
            dt.Columns.Add("recordedBy");
            dt.Columns.Add("recordedDate");
            dt.Columns.Add("recordedTime");
            dt.Columns.Add("lastModifiedBy");
            dt.Columns.Add("lastModifiedDate");
            dt.Columns.Add("lastModifiedTime");
            dt.Columns.Add("currentStatus");
            if (staffCategory.Count() > 0)
            {
                for (int j = 0; j < staffCategory.Count(); j++)
                {
                    String stat;
                    if (staffCategory[j].currentStatus == 0)
                        stat = "InActive";
                    else
                        stat = "Active";
                    DataRow dr = dt.NewRow();
                    dr["staffCategoryCode"] = staffCategory[j].staffCategoryCode;
                    dr["staffCategoryName"] = staffCategory[j].staffCategoryName;
                    dr["recordedBy"] = staffCategory[j].recordedBy;
                    dr["recordedDate"] = staffCategory[j].recordedDate;
                    dr["recordedTime"] = staffCategory[j].recordedTime;
                    dr["lastModifiedBy"] = staffCategory[j].lastModifiedBy;
                    dr["lastModifiedDate"] = staffCategory[j].lastModifiedDate;
                    dr["lastModifiedTime"] = staffCategory[j].lastModifiedTime;
                    dr["currentStatus"] = stat;
                    dt.Rows.Add(dr);
                }
                Gv_staffCategory.DataSource = dt;
                Gv_staffCategory.DataBind();
            }
        }

        protected void Gv_staffCategory_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Gv_staffCategory.EditIndex = e.NewEditIndex;
            LoadStaffCategory();
        }

        protected void Gv_staffCategory_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String staffCategoryCode = Gv_staffCategory.DataKeys[e.RowIndex].Values["staffCategoryCode"].ToString();
            TextBox staffCategoryName = (TextBox)Gv_staffCategory.Rows[e.RowIndex].FindControl("txtStaffCategoryName");
            DropDownList currentStatus = (DropDownList)Gv_staffCategory.Rows[e.RowIndex].FindControl("ddlCurrentStatus");

            if (sis.UpdateStaffCategories(staffCategoryCode, staffCategoryName.Text, "superadmin", int.Parse(currentStatus.SelectedValue)))
            {
                Gv_staffCategory.EditIndex = -1;
                LoadStaffCategory();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Sucessfully Updated');", true);
            }

        }

        protected void Gv_staffCategory_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Gv_staffCategory.EditIndex = -1;
            LoadStaffCategory();
        }

        protected void Gv_staffCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string staffCategoryCode = Gv_staffCategory.DataKeys[e.RowIndex].Values["staffCategoryCode"].ToString();

            if (sis.DeleteStaffCategories(staffCategoryCode))
            {
                LoadStaffCategory();
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Sucessfully deleted');",true);
            }
        }

        protected void Gv_staffCategory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Label lblsep = (Label)Gv_staffCategory.FooterRow.FindControl("lblsep");
            TextBox txtStaffCategoryName = (TextBox)Gv_staffCategory.FooterRow.FindControl("insStaffCategoryName");
            LinkButton linkBtnSave = (LinkButton)Gv_staffCategory.FooterRow.FindControl("LinkBtnSave");
            LinkButton linkBtnCancel = (LinkButton)Gv_staffCategory.FooterRow.FindControl("LinkBtnCancel");
            LinkButton linkBtnAdd = (LinkButton)Gv_staffCategory.FooterRow.FindControl("LinkBtnAdd");

            if (e.CommandName.Equals("Add"))
            {
                lblsep.Visible = true;
                txtStaffCategoryName.Visible = true;
                linkBtnSave.Visible = true;
                linkBtnCancel.Visible = true;
                linkBtnAdd.Visible = false;
            }
            if (e.CommandName.Equals("Save"))
            {
                if (sis.AddStaffCategories(txtStaffCategoryName.Text, "superadmin"))
                {
                    LoadStaffCategory();
                    lblmsg.Text = "created sucessfully";

                    lblsep.Visible = false;
                    txtStaffCategoryName.Visible = false;
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
            foreach (GridViewRow row in Gv_staffCategory.Rows)
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

        protected void Gv_staffCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string pName = Gv_staffCategory.SelectedRow.Cells[2].Text; 
            string pjName = Gv_staffCategory.SelectedDataKey.Value.ToString();
            lblmsg.Text = "<b>Publisher Name   :     " + pjName + "</b>";
        }

        protected void Gv_staffCategory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }
    }
}