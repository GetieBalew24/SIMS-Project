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
    public partial class AdmissionClassification : System.Web.UI.Page
    {
        private readonly SISBLL sis = new SISBLL();
        private readonly DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadAdmissionClassification();
            }
        }
        protected void LoadAdmissionClassification()
        {
            TBL_admissionClassification[] admissionClassification = sis.GetAllAdmissionClassifications();
            dt.Columns.Add("admissionClassificationCode");
            dt.Columns.Add("admissionClassificationName");
            dt.Columns.Add("recordedBy");
            dt.Columns.Add("recordedDate");
            dt.Columns.Add("recordedTime");
            dt.Columns.Add("lastModifiedBy");
            dt.Columns.Add("lastModifiedDate");
            dt.Columns.Add("lastModifiedTime");
            dt.Columns.Add("currentStatus");
            if (admissionClassification.Count() > 0)
            {
                for (int j = 0; j < admissionClassification.Count(); j++)
                {
                    String stat;
                    if (admissionClassification[j].currentStatus == 0)
                        stat = "InActive";
                    else
                        stat = "Active";
                    DataRow dr = dt.NewRow();
                    dr["admissionClassificationCode"] = admissionClassification[j].admissionClassificationCode;
                    dr["admissionClassificationName"] = admissionClassification[j].admissionClassificationName;
                    dr["recordedBy"] = admissionClassification[j].recordedBy;
                    dr["recordedDate"] = admissionClassification[j].recordedDate;
                    dr["recordedTime"] = admissionClassification[j].recordedTime;
                    dr["lastModifiedBy"] = admissionClassification[j].lastModifiedBy;
                    dr["lastModifiedDate"] = admissionClassification[j].lastModifiedDate;
                    dr["lastModifiedTime"] = admissionClassification[j].lastModifiedTime;
                    dr["currentStatus"] = stat;
                    dt.Rows.Add(dr);
                }
                Gv_admissionClassification.DataSource = dt;
                Gv_admissionClassification.DataBind();
            }
        }

        protected void Gv_admissionClassification_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Gv_admissionClassification.EditIndex = e.NewEditIndex;
            LoadAdmissionClassification();
        }

        protected void Gv_admissionClassification_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String admissionClassificationCode = Gv_admissionClassification.DataKeys[e.RowIndex].Values["admissionClassificationCode"].ToString();
            TextBox admissionClassificationName = (TextBox)Gv_admissionClassification.Rows[e.RowIndex].FindControl("txtAdmissionClassificationName");
            DropDownList currentStatus = (DropDownList)Gv_admissionClassification.Rows[e.RowIndex].FindControl("ddlCurrentStatus");

            if (sis.UpdateAdmissionClassifications(admissionClassificationCode, admissionClassificationName.Text, "superadmin", int.Parse(currentStatus.SelectedValue)))
            {
                Gv_admissionClassification.EditIndex = -1;
                LoadAdmissionClassification();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Sucessfully Updated');", true);
            }

        }

        protected void Gv_admissionClassification_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Gv_admissionClassification.EditIndex = -1;
            LoadAdmissionClassification();
        }

        protected void Gv_admissionClassification_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string admissionClassificationCode = Gv_admissionClassification.DataKeys[e.RowIndex].Values["admissionClassificationCode"].ToString();

            if (sis.DeleteAdmissionClassifications(admissionClassificationCode))
            {
                LoadAdmissionClassification();
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Sucessfully deleted');", true);
            }
        }

        protected void Gv_admissionClassification_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Label lblsep = (Label)Gv_admissionClassification.FooterRow.FindControl("lblsep");
            TextBox txtAdmissionClassificationName = (TextBox)Gv_admissionClassification.FooterRow.FindControl("insAdmissionClassificationName");
            LinkButton linkBtnSave = (LinkButton)Gv_admissionClassification.FooterRow.FindControl("LinkBtnSave");
            LinkButton linkBtnCancel = (LinkButton)Gv_admissionClassification.FooterRow.FindControl("LinkBtnCancel");
            LinkButton linkBtnAdd = (LinkButton)Gv_admissionClassification.FooterRow.FindControl("LinkBtnAdd");

            if (e.CommandName.Equals("Add"))
            {
                lblsep.Visible = true;
                txtAdmissionClassificationName.Visible = true;
                linkBtnSave.Visible = true;
                linkBtnCancel.Visible = true;
                linkBtnAdd.Visible = false;
            }
            if (e.CommandName.Equals("Save"))
            {
                if (sis.AddAdmissionClassifications(txtAdmissionClassificationName.Text, "superadmin"))
                {
                    LoadAdmissionClassification();
                    lblmsg.Text = "created sucessfully";

                    lblsep.Visible = false;
                    txtAdmissionClassificationName.Visible = false;
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
            foreach (GridViewRow row in Gv_admissionClassification.Rows)
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

        protected void Gv_admissionClassification_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string pName = Gv_admissionClassification.SelectedRow.Cells[2].Text; 
            string pjName = Gv_admissionClassification.SelectedDataKey.Value.ToString();
            lblmsg.Text = "<b>Publisher Name   :     " + pjName + "</b>";
        }

        protected void Gv_admissionClassification_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }
    }
}