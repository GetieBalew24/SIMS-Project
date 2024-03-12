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
    public partial class StaffDepartment : System.Web.UI.Page
    {
        private readonly SISBLL sis = new SISBLL();
        private readonly DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadStaff();
            }
        }
        protected void LoadStaff()
        {
            TBL_staffDepartment[] staffDept = sis.GetStaffDepartments();
            dt.Columns.Add("staffDepartmentCode");
            dt.Columns.Add("staffId");
            dt.Columns.Add("departmentCode");
            dt.Columns.Add("positionCode");
            dt.Columns.Add("recordedBy");
            dt.Columns.Add("recordedDate");
            dt.Columns.Add("recordedTime");
            dt.Columns.Add("lastModifiedBy");
            dt.Columns.Add("lastModifiedDate");
            dt.Columns.Add("lastModifiedTime");
            dt.Columns.Add("currentStatus");
            if (staffDept.Count() > 0)
            {
                for (int j = 0; j < staffDept.Count(); j++)
                {
                    String stat;
                    if (staffDept[j].currentStatus == 0)
                        stat = "Inactive";
                    else
                        stat = "Active";
                    DataRow dr = dt.NewRow();
                    dr["staffDepartmentCode"] = staffDept[j].staffDepartmentCode;
                    dr["staffId"] = staffDept[j].staffId;
                    dr["departmentCode"] = staffDept[j].departmentCode;
                    dr["positionCode"] = staffDept[j].positionCode;
                    dr["recordedBy"] = staffDept[j].recordedBy;
                    dr["recordedDate"] = staffDept[j].recordedDate;
                    dr["recordedTime"] = staffDept[j].recordedTime;
                    dr["lastModifiedBy"] = staffDept[j].lastModifiedBy;
                    dr["lastModifiedDate"] = staffDept[j].lastModifiedDate;
                    dr["lastModifiedTime"] = staffDept[j].lastModifiedTime;
                    dr["currentStatus"] = stat;
                    dt.Rows.Add(dr);
                }
                Gv_staffDepartment.DataSource = dt;
                Gv_staffDepartment.DataBind();
            }
        }

        protected void Gv_staffDepartment_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Gv_staffDepartment.EditIndex = e.NewEditIndex;
            LoadStaff();
        }

        protected void Gv_staffDepartment_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String staffDepartmentCode = Gv_staffDepartment.DataKeys[e.RowIndex].Values["staffDepartmentCode"].ToString();
            DropDownList departmentCode = (DropDownList)Gv_staffDepartment.Rows[e.RowIndex].FindControl("ddlDepartmentCode");
            DropDownList positionCode = (DropDownList)Gv_staffDepartment.Rows[e.RowIndex].FindControl("ddlPositionCode");
            DropDownList currentStatus = (DropDownList)Gv_staffDepartment.Rows[e.RowIndex].FindControl("ddlCurrentStatus");

            if (sis.UpdateStaffDepartments(staffDepartmentCode, departmentCode.SelectedValue, positionCode.SelectedValue, "superadmin", int.Parse(currentStatus.SelectedValue)))
            {
                Gv_staffDepartment.EditIndex = -1;
                LoadStaff();
            }
        }

        protected void Gv_staffDepartment_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Gv_staffDepartment.EditIndex = -1;
            LoadStaff();
        }

        protected void Gv_staffDepartment_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string staffDepartmentCode = Gv_staffDepartment.DataKeys[e.RowIndex].Values["staffDepartmentCode"].ToString();

            if (sis.DeleteStaffDepartments(staffDepartmentCode))
            {
                LoadStaff();
                lblmsg.Text = staffDepartmentCode + "      Deleted successfully.......    ";
            }
        }

        protected void Gv_staffDepartment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Label lblsep = (Label)Gv_staffDepartment.FooterRow.FindControl("lblsep");
            DropDownList staffId = (DropDownList)Gv_staffDepartment.FooterRow.FindControl("insStaffId");
            DropDownList departmentCode = (DropDownList)Gv_staffDepartment.FooterRow.FindControl("insDepartmentCode");
            DropDownList positionCode = (DropDownList)Gv_staffDepartment.FooterRow.FindControl("insPositionCode");

            LinkButton linkBtnSave = (LinkButton)Gv_staffDepartment.FooterRow.FindControl("LinkBtnSave");
            LinkButton linkBtnCancel = (LinkButton)Gv_staffDepartment.FooterRow.FindControl("LinkBtnCancel");
            LinkButton linkBtnAdd = (LinkButton)Gv_staffDepartment.FooterRow.FindControl("LinkBtnAdd");

            if (e.CommandName.Equals("Add"))
            {
                lblsep.Visible = true;
                staffId.Visible = true;
                departmentCode.Visible = true;
                positionCode.Visible = true;

                linkBtnSave.Visible = true;
                linkBtnCancel.Visible = true;
                linkBtnAdd.Visible = false;
            }
            if (e.CommandName.Equals("Save"))
            {
                if (sis.AddStaffDepartments(staffId.SelectedValue, departmentCode.SelectedValue, positionCode.SelectedValue, "superadmin"))
                {
                    LoadStaff();
                    lblmsg.Text = "created sucessfully";

                    lblsep.Visible = false;
                    staffId.Visible = false;
                    departmentCode.Visible = false;
                    positionCode.Visible = false;

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

        protected void Gv_staffDepartment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }

        protected void Gv_staffDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string pName = Gv_university.SelectedRow.Cells[2].Text; 
            string pjName = Gv_staffDepartment.SelectedDataKey.Value.ToString();
            lblmsg.Text = "<b>Publisher Name   :     " + pjName + "</b>";
        }

        protected void BtmDisplay_Click(object sender, EventArgs e)
        {
            string data = "";
            foreach (GridViewRow row in Gv_staffDepartment.Rows)
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
    }
}