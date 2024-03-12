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
    public partial class University : System.Web.UI.Page
    {
        private readonly SISBLL sis = new SISBLL();
        private readonly DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!IsPostBack)
            {
                LoadUniversity();
            }
        }
        protected void LoadUniversity()
        {
            TBL_university[] university = sis.GetAllUniversities();
            dt.Columns.Add("universityCode");
            dt.Columns.Add("universityName");
            dt.Columns.Add("recordedBy");
            dt.Columns.Add("recordedDate");
            dt.Columns.Add("recordedTime");
            dt.Columns.Add("lastModifiedBy");
            dt.Columns.Add("lastModifiedDate");
            dt.Columns.Add("lastModifiedTime");
            dt.Columns.Add("currentStatus");
            if (university.Count() > 0)
            {
                for (int j = 0; j < university.Count(); j++)
                {
                    String stat;
                    if (university[j].currentStatus == 0)
                        stat = "InActive";
                    else
                        stat = "Active";
                    DataRow dr = dt.NewRow();
                    dr["universityCode"] = university[j].universityCode;
                    dr["universityName"] = university[j].universityName;
                    dr["recordedBy"] = university[j].recordedBy;
                    dr["recordedDate"] = university[j].recordedDate;
                    dr["recordedTime"] = university[j].recordedTime;
                    dr["lastModifiedBy"] = university[j].lastModifiedBy;
                    dr["lastModifiedDate"] = university[j].lastModifiedDate;
                    dr["lastModifiedTime"] = university[j].lastModifiedTime;
                    dr["currentStatus"] = stat;
                    dt.Rows.Add(dr);
                }
                Gv_university.DataSource = dt;
                Gv_university.DataBind();
            }
        }
        protected void Gv_university_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Gv_university.EditIndex = e.NewEditIndex;
            LoadUniversity();
        }
        protected void Gv_university_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String universityCode = Gv_university.DataKeys[e.RowIndex].Values["universityCode"].ToString();
            TextBox universityName = (TextBox)Gv_university.Rows[e.RowIndex].FindControl("txtUniversityName");
            DropDownList currentStatus = (DropDownList)Gv_university.Rows[e.RowIndex].FindControl("ddlCurrentStatus");

            if (sis.UpdateUniversities(universityCode, universityName.Text, "superadmin", int.Parse(currentStatus.SelectedValue)))
            {
                Gv_university.EditIndex = -1;
                LoadUniversity();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Sucessfully Updated');", true);
            }

        }

        protected void Gv_university_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Gv_university.EditIndex = -1;
            LoadUniversity();
        }

        protected void Gv_university_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string universityCode = Gv_university.DataKeys[e.RowIndex].Values["universityCode"].ToString();

            if (sis.DeleteUniversities(universityCode))
            {
                LoadUniversity();
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Sucessfully deleted');",true);
            }
        }

        protected void Gv_university_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Label lblsep = (Label)Gv_university.FooterRow.FindControl("lblsep");
            TextBox txtUniversityName = (TextBox)Gv_university.FooterRow.FindControl("insUniversityName");
            LinkButton linkBtnSave = (LinkButton)Gv_university.FooterRow.FindControl("LinkBtnSave");
            LinkButton linkBtnCancel = (LinkButton)Gv_university.FooterRow.FindControl("LinkBtnCancel");
            LinkButton linkBtnAdd = (LinkButton)Gv_university.FooterRow.FindControl("LinkBtnAdd");

            if (e.CommandName.Equals("Add"))
            {
                lblsep.Visible = true;
                txtUniversityName.Visible = true;
                linkBtnSave.Visible = true;
                linkBtnCancel.Visible = true;
                linkBtnAdd.Visible = false;
            }
            if (e.CommandName.Equals("Save"))
            {
                if (sis.AddUniversities(txtUniversityName.Text, "superadmin"))
                {
                    LoadUniversity();
                    lblmsg.Text = "created sucessfully";

                    lblsep.Visible = false;
                    txtUniversityName.Visible = false;
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
            foreach (GridViewRow row in Gv_university.Rows)
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

        protected void Gv_university_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string pName = Gv_university.SelectedRow.Cells[2].Text; 
            string pjName = Gv_university.SelectedDataKey.Value.ToString();
            lblmsg.Text = "<b>University Code :     " + pjName + "</b>";
        }

        protected void Gv_university_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /*Tell the compiler that the control is rendered
             * explicitly by overriding the VerifyRenderingInServerForm event.*/
        }
        protected void btntoCsv_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=gvtocsv.csv");
            Response.Charset = "";
            Response.ContentType = "application/text";
            StringBuilder sBuilder = new System.Text.StringBuilder();
            for (int index = 0; index < Gv_university.Columns.Count; index++)
            {
                sBuilder.Append(Gv_university.Columns[index].HeaderText + ',');
            }
            sBuilder.Append("\r\n");
            for (int i = 0; i < Gv_university.Rows.Count; i++)
            {
                for (int k = 0; k < Gv_university.HeaderRow.Cells.Count; k++)
                {
                    sBuilder.Append(Gv_university.Rows[i].Cells[k].Text.Replace(",", "") + ",");
                }
                sBuilder.Append("\r\n");
            }
            Response.Output.Write(sBuilder.ToString());
            Response.Flush();
            Response.End();
        }

        protected void btntoExcel_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=gvtoexcel.xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Gv_university.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
    }
}