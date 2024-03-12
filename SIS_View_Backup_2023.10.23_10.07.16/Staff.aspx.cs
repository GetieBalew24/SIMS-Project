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
    public partial class Staff : System.Web.UI.Page
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
            TBL_staff[] staff = sis.GetStaffs();
            dt.Columns.Add("staffId");
            dt.Columns.Add("salutationCode");
            dt.Columns.Add("firstName");
            dt.Columns.Add("fathername");
            dt.Columns.Add("grandFathername");
            dt.Columns.Add("gender");
            dt.Columns.Add("phone");
            dt.Columns.Add("email");
            dt.Columns.Add("academicRankCode");
            dt.Columns.Add("academicQualificationCode");
            dt.Columns.Add("staffCategoryCode");
            dt.Columns.Add("isExternal");
            dt.Columns.Add("recordedBy");
            dt.Columns.Add("recordedDate");
            dt.Columns.Add("recordedTime");
            dt.Columns.Add("lastModifiedBy");
            dt.Columns.Add("lastModifiedDate");
            dt.Columns.Add("lastModifiedTime");
            dt.Columns.Add("currentStatus");
            if (staff.Count() > 0)
            {
                for (int j = 0; j < staff.Count(); j++)
                {
                    String stat;
                    if (staff[j].currentStatus == 0)
                        stat = "InActive";
                    else
                        stat = "Active";
                    DataRow dr = dt.NewRow();
                    dr["staffId"] = staff[j].staffId;
                    dr["salutationCode"] = staff[j].salutationCode;
                    dr["firstName"] = staff[j].firstName;
                    dr["fatherName"] = staff[j].fatherName;
                    dr["grandfathername"] = staff[j].grandFatherName;
                    dr["gender"] = staff[j].gender;
                    dr["phone"] = staff[j].phone;
                    dr["email"] = staff[j].email;
                    dr["academicRankCode"] = staff[j].academicRankCode;
                    dr["academicQualificationCode"] = staff[j].academicQualificationCode;
                    dr["staffCategoryCode"] = staff[j].staffCategoryCode;
                    dr["isExternal"] = staff[j].isExternal;
                    dr["recordedBy"] = staff[j].recordedBy;
                    dr["recordedDate"] = staff[j].recordedDate;
                    dr["recordedTime"] = staff[j].recordedTime;
                    dr["lastModifiedBy"] = staff[j].lastModifiedBy;
                    dr["lastModifiedDate"] = staff[j].lastModifiedDate;
                    dr["lastModifiedTime"] = staff[j].lastModifiedTime;
                    dr["currentStatus"] = stat;
                    dt.Rows.Add(dr);
                }
                Gv_staff.DataSource = dt;
                Gv_staff.DataBind();
            }
        }

        protected void Gv_staff_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Gv_staff.EditIndex = e.NewEditIndex;
            LoadStaff();
        }

        protected void Gv_staff_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String staffId = Gv_staff.DataKeys[e.RowIndex].Values["staffId"].ToString();
            DropDownList salutationCode = (DropDownList)Gv_staff.Rows[e.RowIndex].FindControl("ddlSalutationCode");
            TextBox firstName = (TextBox)Gv_staff.Rows[e.RowIndex].FindControl("txtFirstName");
            TextBox fatherName = (TextBox)Gv_staff.Rows[e.RowIndex].FindControl("txtFatherName");
            TextBox grandFatherName = (TextBox)Gv_staff.Rows[e.RowIndex].FindControl("txtGrandFatherName");
            DropDownList gender = (DropDownList)Gv_staff.Rows[e.RowIndex].FindControl("ddlGender");
            TextBox phone = (TextBox)Gv_staff.Rows[e.RowIndex].FindControl("txtPhone");
            TextBox email = (TextBox)Gv_staff.Rows[e.RowIndex].FindControl("txtEmail");
            DropDownList academicRankCode = (DropDownList)Gv_staff.Rows[e.RowIndex].FindControl("ddlAcademicRankCode");
            DropDownList academicQualificationCode = (DropDownList)Gv_staff.Rows[e.RowIndex].FindControl("ddlAcademicQualificationCode");
            DropDownList staffCategoryCode = (DropDownList)Gv_staff.Rows[e.RowIndex].FindControl("ddlStaffCategoryCode");
            DropDownList isExternal = (DropDownList)Gv_staff.Rows[e.RowIndex].FindControl("ddlIsExternal");
            DropDownList currentStatus = (DropDownList)Gv_staff.Rows[e.RowIndex].FindControl("ddlCurrentStatus");

            if (sis.UpdateStaffs(staffId, salutationCode.SelectedValue, firstName.Text, fatherName.Text, grandFatherName.Text, gender.SelectedValue, phone.Text, email.Text, academicRankCode.SelectedValue, academicQualificationCode.Text, staffCategoryCode.SelectedValue, isExternal.SelectedValue, "superadmin", int.Parse(currentStatus.SelectedValue)))
            {
                Gv_staff.EditIndex = -1;
                LoadStaff();
            }
        }

        protected void Gv_staff_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Gv_staff.EditIndex = -1;
            LoadStaff();
        }

        protected void Gv_staff_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string staffId = Gv_staff.DataKeys[e.RowIndex].Values["staffId"].ToString();

            if (sis.DeleteStaffs(staffId))
            {
                LoadStaff();
                lblmsg.Text = staffId + "      Deleted successfully.......    ";
            }
        }

        protected void Gv_staff_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Label lblsep = (Label)Gv_staff.FooterRow.FindControl("lblsep");
            DropDownList salutationCode = (DropDownList)Gv_staff.FooterRow.FindControl("insSalutationCode");
            TextBox firstName = (TextBox)Gv_staff.FooterRow.FindControl("insFirstName");
            TextBox fatherName = (TextBox)Gv_staff.FooterRow.FindControl("insFatherName");
            TextBox grandFatherName = (TextBox)Gv_staff.FooterRow.FindControl("insGrandFatherName");
            TextBox phone = (TextBox)Gv_staff.FooterRow.FindControl("insPhone");
            TextBox email = (TextBox)Gv_staff.FooterRow.FindControl("insEmail");
            DropDownList gender = (DropDownList)Gv_staff.FooterRow.FindControl("insGender");
            DropDownList academicRankCode = (DropDownList)Gv_staff.FooterRow.FindControl("insAcademicRankCode");
            DropDownList academicQualificationCode = (DropDownList)Gv_staff.FooterRow.FindControl("insAcademicQualificationCode");
            DropDownList staffCategoryCode = (DropDownList)Gv_staff.FooterRow.FindControl("insStaffCategoryCode");
            DropDownList isExternal = (DropDownList)Gv_staff.FooterRow.FindControl("insIsExternal");
            LinkButton linkBtnSave = (LinkButton)Gv_staff.FooterRow.FindControl("LinkBtnSave");
            LinkButton linkBtnCancel = (LinkButton)Gv_staff.FooterRow.FindControl("LinkBtnCancel");
            LinkButton linkBtnAdd = (LinkButton)Gv_staff.FooterRow.FindControl("LinkBtnAdd");

            if (e.CommandName.Equals("Add"))
            {
                lblsep.Visible = true;
                salutationCode.Visible = true;
                firstName.Visible = true;
                fatherName.Visible = true;
                grandFatherName.Visible = true;
                phone.Visible = true;
                email.Visible = true;
                gender.Visible = true;
                academicRankCode.Visible = true;
                academicQualificationCode.Visible = true;
                staffCategoryCode.Visible = true;
                isExternal.Visible = true;

                linkBtnSave.Visible = true;
                linkBtnCancel.Visible = true;
                linkBtnAdd.Visible = false;
            }
            if (e.CommandName.Equals("Save"))
            {
                if (sis.AddStaffs(salutationCode.SelectedValue, firstName.Text, fatherName.Text, grandFatherName.Text, gender.SelectedValue, phone.Text, email.Text, academicRankCode.SelectedValue, academicQualificationCode.SelectedValue, staffCategoryCode.SelectedValue, isExternal.SelectedValue, "superadmin"))
                {
                    LoadStaff();
                    lblmsg.Text = "created sucessfully";

                    lblsep.Visible = false;
                    salutationCode.Visible = false;
                    firstName.Visible = false;
                    fatherName.Visible = false;
                    grandFatherName.Visible = false;
                    phone.Visible = false;
                    email.Visible = false;
                    gender.Visible = false;
                    academicRankCode.Visible = false;
                    academicQualificationCode.Visible = false;
                    staffCategoryCode.Visible = false;
                    isExternal.Visible = false;

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

        protected void Gv_staff_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }

        protected void Gv_staff_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string pName = Gv_university.SelectedRow.Cells[2].Text; 
            string pjName = Gv_staff.SelectedDataKey.Value.ToString();
            lblmsg.Text = "<b>Publisher Name   :     " + pjName + "</b>";
        }

        protected void BtmDisplay_Click(object sender, EventArgs e)
        {
            string data = "";
            foreach (GridViewRow row in Gv_staff.Rows)
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