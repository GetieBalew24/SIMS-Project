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
    public partial class AcademicQualification : System.Web.UI.Page
    {
        private readonly SISBLL sis = new SISBLL();
        private readonly DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadAcademicQualification();
            }
        }
        protected void LoadAcademicQualification()
        {
            TBL_academicQualification[] academicQualification = sis.GetAllAcademicQualifications();
            dt.Columns.Add("academicQualificationCode");
            dt.Columns.Add("academicQualificationName");
            dt.Columns.Add("recordedBy");
            dt.Columns.Add("recordedDate");
            dt.Columns.Add("recordedTime");
            dt.Columns.Add("lastModifiedBy");
            dt.Columns.Add("lastModifiedDate");
            dt.Columns.Add("lastModifiedTime");
            dt.Columns.Add("currentStatus");
            if (academicQualification.Count() > 0)
            {
                for (int j = 0; j < academicQualification.Count(); j++)
                {
                    String stat;
                    if (academicQualification[j].currentStatus == 0)
                        stat = "InActive";
                    else
                        stat = "Active";
                    DataRow dr = dt.NewRow();
                    dr["academicQualificationCode"] = academicQualification[j].academicQualificationCode;
                    dr["academicQualificationName"] = academicQualification[j].academicQualificationName;
                    dr["recordedBy"] = academicQualification[j].recordedBy;
                    dr["recordedDate"] = academicQualification[j].recordedDate;
                    dr["recordedTime"] = academicQualification[j].recordedTime;
                    dr["lastModifiedBy"] = academicQualification[j].lastModifiedBy;
                    dr["lastModifiedDate"] = academicQualification[j].lastModifiedDate;
                    dr["lastModifiedTime"] = academicQualification[j].lastModifiedTime;
                    dr["currentStatus"] = stat;
                    dt.Rows.Add(dr);
                }
                Gv_academicQualification.DataSource = dt;
                Gv_academicQualification.DataBind();
            }
        }

        protected void Gv_academicQualification_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Gv_academicQualification.EditIndex = e.NewEditIndex;
            LoadAcademicQualification();
        }

        protected void Gv_academicQualification_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String academicQualificationCode = Gv_academicQualification.DataKeys[e.RowIndex].Values["academicQualificationCode"].ToString();
            TextBox academicQualificationName = (TextBox)Gv_academicQualification.Rows[e.RowIndex].FindControl("txtAcademicQualificationName");
            DropDownList currentStatus = (DropDownList)Gv_academicQualification.Rows[e.RowIndex].FindControl("ddlCurrentStatus");

            if (sis.UpdateAcademicQualifications(academicQualificationCode, academicQualificationName.Text, "superadmin", int.Parse(currentStatus.SelectedValue)))
            {
                Gv_academicQualification.EditIndex = -1;
                LoadAcademicQualification();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Sucessfully Updated');", true);
            }

        }

        protected void Gv_academicQualification_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Gv_academicQualification.EditIndex = -1;
            LoadAcademicQualification();
        }

        protected void Gv_academicQualification_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string academicQualificationCode = Gv_academicQualification.DataKeys[e.RowIndex].Values["academicQualificationCode"].ToString();

            if (sis.DeleteAcademicQualifications(academicQualificationCode))
            {
                LoadAcademicQualification();
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Sucessfully deleted');", true);
            }
        }

        protected void Gv_academicQualification_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Label lblsep = (Label)Gv_academicQualification.FooterRow.FindControl("lblsep");
            TextBox txtAcademicQualificationName = (TextBox)Gv_academicQualification.FooterRow.FindControl("insAcademicQualificationName");
            LinkButton linkBtnSave = (LinkButton)Gv_academicQualification.FooterRow.FindControl("LinkBtnSave");
            LinkButton linkBtnCancel = (LinkButton)Gv_academicQualification.FooterRow.FindControl("LinkBtnCancel");
            LinkButton linkBtnAdd = (LinkButton)Gv_academicQualification.FooterRow.FindControl("LinkBtnAdd");

            if (e.CommandName.Equals("Add"))
            {
                lblsep.Visible = true;
                txtAcademicQualificationName.Visible = true;
                linkBtnSave.Visible = true;
                linkBtnCancel.Visible = true;
                linkBtnAdd.Visible = false;
            }
            if (e.CommandName.Equals("Save"))
            {
                if (sis.AddAcademicQualifications(txtAcademicQualificationName.Text, "superadmin"))
                {
                    LoadAcademicQualification();
                    lblmsg.Text = "created sucessfully";

                    lblsep.Visible = false;
                    txtAcademicQualificationName.Visible = false;
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
            foreach (GridViewRow row in Gv_academicQualification.Rows)
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

        protected void Gv_academicQualification_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string pName = Gv_academicQualification.SelectedRow.Cells[2].Text; 
            string pjName = Gv_academicQualification.SelectedDataKey.Value.ToString();
            lblmsg.Text = "<b>Publisher Name   :     " + pjName + "</b>";
        }

        protected void Gv_academicQualification_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }
    }
}