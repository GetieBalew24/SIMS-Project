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
    public partial class College : System.Web.UI.Page
    {
        private readonly SISBLL sis = new SISBLL();
        private readonly DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadCollege();
            }
        } 
        protected void LoadCollege()
        {
            TBL_college[] college = sis.GetAllColleges();
            dt.Columns.Add("universityCode");
            dt.Columns.Add("collegeCode");
            dt.Columns.Add("collegeName");
            dt.Columns.Add("recordedBy");
            dt.Columns.Add("recordedDate");
            dt.Columns.Add("recordedTime");
            dt.Columns.Add("lastModifiedBy");
            dt.Columns.Add("lastModifiedDate");
            dt.Columns.Add("lastModifiedTime");
            dt.Columns.Add("currentStatus");
            if (college.Count() > 0)
            {
                for (int j = 0; j < college.Count(); j++)
                {
                    String stat;
                    if (college[j].currentStatus == 0)
                        stat = "InActive";
                    else
                        stat = "Active";
                    DataRow dr = dt.NewRow();
                    dr["universityCode"] = college[j].universityCode;
                    dr["collegeCode"] = college[j].collegeCode;
                    dr["collegeName"] = college[j].collegeName;
                    dr["recordedBy"] = college[j].recordedBy;
                    dr["recordedDate"] = college[j].recordedDate;
                    dr["recordedTime"] = college[j].recordedTime;
                    dr["lastModifiedBy"] = college[j].lastModifiedBy;
                    dr["lastModifiedDate"] = college[j].lastModifiedDate;
                    dr["lastModifiedTime"] = college[j].lastModifiedTime;
                    dr["currentStatus"] = stat;
                    dt.Rows.Add(dr);
                }
                Gv_college.DataSource = dt;
                Gv_college.DataBind();
            }
        }

        protected void Gv_college_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Gv_college.EditIndex = e.NewEditIndex;
            LoadCollege();
        }

        protected void Gv_college_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String collegeCode = Gv_college.DataKeys[e.RowIndex].Values["collegeCode"].ToString();
            TextBox collegeName = (TextBox)Gv_college.Rows[e.RowIndex].FindControl("txtCollegeName");
            DropDownList universityCode = (DropDownList)Gv_college.Rows[e.RowIndex].FindControl("ddlUniversityCode");
            DropDownList currentStatus = (DropDownList)Gv_college.Rows[e.RowIndex].FindControl("ddlCurrentStatus");

            if (sis.UpdateColleges(collegeCode, universityCode.SelectedValue, collegeName.Text, "superadmin", int.Parse(currentStatus.SelectedValue)))
            {
                Gv_college.EditIndex = -1;
                LoadCollege();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Sucessfully Updated');", true);
            }

        }

        protected void Gv_college_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Gv_college.EditIndex = -1;
            LoadCollege();
        }

        protected void Gv_college_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string collegeCode = Gv_college.DataKeys[e.RowIndex].Values["collegeCode"].ToString();

            if (sis.DeleteColleges(collegeCode))
            {
                LoadCollege();
            }
        }

        protected void Gv_college_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Label lblsep = (Label)Gv_college.FooterRow.FindControl("lblsep");
            DropDownList ddluniversityCode = (DropDownList)Gv_college.FooterRow.FindControl("insUniversityCode");
            TextBox txtCollegeName = (TextBox)Gv_college.FooterRow.FindControl("insCollegeName");
            LinkButton linkBtnSave = (LinkButton)Gv_college.FooterRow.FindControl("LinkBtnSave");
            LinkButton linkBtnCancel = (LinkButton)Gv_college.FooterRow.FindControl("LinkBtnCancel");
            LinkButton linkBtnAdd = (LinkButton)Gv_college.FooterRow.FindControl("LinkBtnAdd");
            
            if (e.CommandName.Equals("Add"))
            {
                lblsep.Visible = true;
                ddluniversityCode.Visible = true;
                txtCollegeName.Visible = true;
                linkBtnSave.Visible = true;
                linkBtnCancel.Visible = true;
                linkBtnAdd.Visible = false;
            }
            if (e.CommandName.Equals("Save"))
            {
                if (sis.AddColleges(ddluniversityCode.SelectedValue, txtCollegeName.Text, "superadmin"))
                {
                    LoadCollege();
                    lblmsg.Text = "created sucessfully";

                    lblsep.Visible = false;
                    ddluniversityCode.Visible = false;
                    txtCollegeName.Visible = false;
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
            foreach (GridViewRow row in Gv_college.Rows)
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

        protected void Gv_college_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string pName = Gv_college.SelectedRow.Cells[2].Text; 
            string pjName = Gv_college.SelectedDataKey.Value.ToString();
            lblmsg.Text = "<b>Publisher Name   :     " + pjName + "</b>";
        }

        protected void Gv_college_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }
        
    }
}