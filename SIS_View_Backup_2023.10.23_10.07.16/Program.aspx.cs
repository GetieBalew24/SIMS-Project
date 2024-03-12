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
    public partial class Program : System.Web.UI.Page
    {
        private readonly SISBLL sis = new SISBLL();
        private readonly DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadProgram();
            }
        }
        protected void LoadProgram()
        {
            TBL_program[] program = sis.GetAllPrograms();
            dt.Columns.Add("programCode");
            dt.Columns.Add("programName");
            dt.Columns.Add("recordedBy");
            dt.Columns.Add("recordedDate");
            dt.Columns.Add("recordedTime");
            dt.Columns.Add("lastModifiedBy");
            dt.Columns.Add("lastModifiedDate");
            dt.Columns.Add("lastModifiedTime");
            dt.Columns.Add("currentStatus");
            if (program.Count() > 0)
            {
                for (int j = 0; j < program.Count(); j++)
                {
                    String stat;
                    if (program[j].currentStatus == 0)
                        stat = "InActive";
                    else
                        stat = "Active";
                    DataRow dr = dt.NewRow();
                    dr["programCode"] = program[j].programCode;
                    dr["programName"] = program[j].programName;
                    dr["recordedBy"] = program[j].recordedBy;
                    dr["recordedDate"] = program[j].recordedDate;
                    dr["recordedTime"] = program[j].recordedTime;
                    dr["lastModifiedBy"] = program[j].lastModifiedBy;
                    dr["lastModifiedDate"] = program[j].lastModifiedDate;
                    dr["lastModifiedTime"] = program[j].lastModifiedTime;
                    dr["currentStatus"] = stat;
                    dt.Rows.Add(dr);
                }
                Gv_program.DataSource = dt;
                Gv_program.DataBind();
            }
        }

        protected void Gv_program_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Gv_program.EditIndex = e.NewEditIndex;
            LoadProgram();
        }

        protected void Gv_program_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String programCode = Gv_program.DataKeys[e.RowIndex].Values["programCode"].ToString();
            TextBox programName = (TextBox)Gv_program.Rows[e.RowIndex].FindControl("txtProgramName");
            DropDownList currentStatus = (DropDownList)Gv_program.Rows[e.RowIndex].FindControl("ddlCurrentStatus");

            if (sis.UpdatePrograms(programCode, programName.Text, "superadmin", int.Parse(currentStatus.SelectedValue)))
            {
                Gv_program.EditIndex = -1;
                LoadProgram();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Sucessfully Updated');", true);
            }

        }

        protected void Gv_program_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Gv_program.EditIndex = -1;
            LoadProgram();
        }

        protected void Gv_program_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string programCode = Gv_program.DataKeys[e.RowIndex].Values["programCode"].ToString();

            if (sis.DeletePrograms(programCode))
            {
                LoadProgram();
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Sucessfully deleted');", true);
            }
        }

        protected void Gv_program_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Label lblsep = (Label)Gv_program.FooterRow.FindControl("lblsep");
            TextBox txtProgramName = (TextBox)Gv_program.FooterRow.FindControl("insProgramName");
            LinkButton linkBtnSave = (LinkButton)Gv_program.FooterRow.FindControl("LinkBtnSave");
            LinkButton linkBtnCancel = (LinkButton)Gv_program.FooterRow.FindControl("LinkBtnCancel");
            LinkButton linkBtnAdd = (LinkButton)Gv_program.FooterRow.FindControl("LinkBtnAdd");

            if (e.CommandName.Equals("Add"))
            {
                lblsep.Visible = true;
                txtProgramName.Visible = true;
                linkBtnSave.Visible = true;
                linkBtnCancel.Visible = true;
                linkBtnAdd.Visible = false;
            }
            if (e.CommandName.Equals("Save"))
            {
                if (sis.AddPrograms(txtProgramName.Text, "superadmin"))
                {
                    LoadProgram();
                    lblmsg.Text = "created sucessfully";

                    lblsep.Visible = false;
                    txtProgramName.Visible = false;
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
            foreach (GridViewRow row in Gv_program.Rows)
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

        protected void Gv_program_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string pName = Gv_program.SelectedRow.Cells[2].Text; 
            string pjName = Gv_program.SelectedDataKey.Value.ToString();
            lblmsg.Text = "<b>Publisher Name   :     " + pjName + "</b>";
        }

        protected void Gv_program_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }
    }
}