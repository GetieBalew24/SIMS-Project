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
    public partial class Department : System.Web.UI.Page
    {
        private readonly SISBLL sis = new SISBLL();
        private readonly DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadDepartment();
            }
        }
        protected void LoadDepartment()
        {
            TBL_department[] department = sis.GetAllDepartments();
            dt.Columns.Add("collegeCode");
            dt.Columns.Add("departmentCode");
            dt.Columns.Add("departmentName");
            dt.Columns.Add("recordedBy");
            dt.Columns.Add("recordedDate");
            dt.Columns.Add("recordedTime");
            dt.Columns.Add("lastModifiedBy");
            dt.Columns.Add("lastModifiedDate");
            dt.Columns.Add("lastModifiedTime");
            dt.Columns.Add("currentStatus");
            if (department.Count() > 0)
            {
                for (int j = 0; j < department.Count(); j++)
                {
                    String stat;
                    if (department[j].currentStatus == 0)
                        stat = "InActive";
                    else
                        stat = "Active";
                    DataRow dr = dt.NewRow();
                    dr["collegeCode"] = department[j].collegeCode;
                    dr["departmentCode"] = department[j].departmentCode;
                    dr["departmentName"] = department[j].departmentName;
                    dr["recordedBy"] = department[j].recordedBy;
                    dr["recordedDate"] = department[j].recordedDate;
                    dr["recordedTime"] = department[j].recordedTime;
                    dr["lastModifiedBy"] = department[j].lastModifiedBy;
                    dr["lastModifiedDate"] = department[j].lastModifiedDate;
                    dr["lastModifiedTime"] = department[j].lastModifiedTime;
                    dr["currentStatus"] = stat;
                    dt.Rows.Add(dr);
                }
                Gv_department.DataSource = dt;
                Gv_department.DataBind();
            }
        }

        protected void Gv_department_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Gv_department.EditIndex = e.NewEditIndex;
            LoadDepartment();
        }

        protected void Gv_department_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String departmentCode = Gv_department.DataKeys[e.RowIndex].Values["departmentCode"].ToString();
            TextBox departmentName = (TextBox)Gv_department.Rows[e.RowIndex].FindControl("txtdepartmentName");
            DropDownList collegeCode = (DropDownList)Gv_department.Rows[e.RowIndex].FindControl("ddlCollegeCode");
            DropDownList currentStatus = (DropDownList)Gv_department.Rows[e.RowIndex].FindControl("ddlCurrentStatus");

            if (sis.UpdateDepartments(departmentCode, collegeCode.SelectedValue, departmentName.Text, "superadmin", int.Parse(currentStatus.SelectedValue)))
            {
                Gv_department.EditIndex = -1;
                LoadDepartment();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Sucessfully Updated');", true);
            }

        }

        protected void Gv_department_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Gv_department.EditIndex = -1;
            LoadDepartment();
        }

        protected void Gv_department_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string departmentCode = Gv_department.DataKeys[e.RowIndex].Values["departmentCode"].ToString();

            if (sis.DeleteDepartments(departmentCode))
            {
                LoadDepartment();
            }
        }

        protected void Gv_department_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Label lblsep = (Label)Gv_department.FooterRow.FindControl("lblsep");
            DropDownList ddlcollegeCode = (DropDownList)Gv_department.FooterRow.FindControl("insCollegeCode");
            TextBox txtdepartmentName = (TextBox)Gv_department.FooterRow.FindControl("insdepartmentName");
            LinkButton linkBtnSave = (LinkButton)Gv_department.FooterRow.FindControl("LinkBtnSave");
            LinkButton linkBtnCancel = (LinkButton)Gv_department.FooterRow.FindControl("LinkBtnCancel");
            LinkButton linkBtnAdd = (LinkButton)Gv_department.FooterRow.FindControl("LinkBtnAdd");

            if (e.CommandName.Equals("Add"))
            {
                lblsep.Visible = true;
                ddlcollegeCode.Visible = true;
                txtdepartmentName.Visible = true;
                linkBtnSave.Visible = true;
                linkBtnCancel.Visible = true;
                linkBtnAdd.Visible = false;
            }
            if (e.CommandName.Equals("Save"))
            {
                if (sis.AddDepartments(ddlcollegeCode.SelectedValue, txtdepartmentName.Text, "superadmin"))
                {
                    LoadDepartment();
                    lblmsg.Text = "created sucessfully";

                    lblsep.Visible = false;
                    ddlcollegeCode.Visible = false;
                    txtdepartmentName.Visible = false;
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
            foreach (GridViewRow row in Gv_department.Rows)
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

        protected void Gv_department_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string pName = Gv_department.SelectedRow.Cells[2].Text; 
            string pjName = Gv_department.SelectedDataKey.Value.ToString();
            lblmsg.Text = "<b>Publisher Name   :     " + pjName + "</b>";
        }

        protected void Gv_department_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }
    }
}