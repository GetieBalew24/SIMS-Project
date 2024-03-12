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
    public partial class Salutation : System.Web.UI.Page
    {
        private readonly SISBLL sis = new SISBLL();
        private readonly DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadSalutation();
            }
        }
        protected void LoadSalutation()
        {
            TBL_salutation[] salutation = sis.GetAllSalutations();
            dt.Columns.Add("salutationCode");
            dt.Columns.Add("salutationName");
            dt.Columns.Add("recordedBy");
            dt.Columns.Add("recordedDate");
            dt.Columns.Add("recordedTime");
            dt.Columns.Add("lastModifiedBy");
            dt.Columns.Add("lastModifiedDate");
            dt.Columns.Add("lastModifiedTime");
            dt.Columns.Add("currentStatus");
            if (salutation.Count() > 0)
            {
                for (int j = 0; j < salutation.Count(); j++)
                {
                    String stat;
                    if (salutation[j].currentStatus == 0)
                        stat = "InActive";
                    else
                        stat = "Active";
                    DataRow dr = dt.NewRow();
                    dr["salutationCode"] = salutation[j].salutationCode;
                    dr["salutationName"] = salutation[j].salutationName;
                    dr["recordedBy"] = salutation[j].recordedBy;
                    dr["recordedDate"] = salutation[j].recordedDate;
                    dr["recordedTime"] = salutation[j].recordedTime;
                    dr["lastModifiedBy"] = salutation[j].lastModifiedBy;
                    dr["lastModifiedDate"] = salutation[j].lastModifiedDate;
                    dr["lastModifiedTime"] = salutation[j].lastModifiedTime;
                    dr["currentStatus"] = stat;
                    dt.Rows.Add(dr);
                }
                Gv_salutation.DataSource = dt;
                Gv_salutation.DataBind();
            }
        }

        protected void Gv_salutation_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Gv_salutation.EditIndex = e.NewEditIndex;
            LoadSalutation();
        }

        protected void Gv_salutation_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String salutationCode = Gv_salutation.DataKeys[e.RowIndex].Values["salutationCode"].ToString();
            TextBox salutationName = (TextBox)Gv_salutation.Rows[e.RowIndex].FindControl("txtSalutationName");
            DropDownList currentStatus = (DropDownList)Gv_salutation.Rows[e.RowIndex].FindControl("ddlCurrentStatus");

            if (sis.UpdateSalutations(salutationCode, salutationName.Text, "superadmin", int.Parse(currentStatus.SelectedValue)))
            {
                Gv_salutation.EditIndex = -1;
                LoadSalutation();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Sucessfully Updated');", true);
            }

        }

        protected void Gv_salutation_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Gv_salutation.EditIndex = -1;
            LoadSalutation();
        }

        protected void Gv_salutation_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string salutationCode = Gv_salutation.DataKeys[e.RowIndex].Values["salutationCode"].ToString();

            if (sis.DeleteSalutations(salutationCode))
            {
                LoadSalutation();
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Sucessfully deleted');", true);
            }
        }

        protected void Gv_salutation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Label lblsep = (Label)Gv_salutation.FooterRow.FindControl("lblsep");
            TextBox txtSalutationName = (TextBox)Gv_salutation.FooterRow.FindControl("insSalutationName");
            LinkButton linkBtnSave = (LinkButton)Gv_salutation.FooterRow.FindControl("LinkBtnSave");
            LinkButton linkBtnCancel = (LinkButton)Gv_salutation.FooterRow.FindControl("LinkBtnCancel");
            LinkButton linkBtnAdd = (LinkButton)Gv_salutation.FooterRow.FindControl("LinkBtnAdd");

            if (e.CommandName.Equals("Add"))
            {
                lblsep.Visible = true;
                txtSalutationName.Visible = true;
                linkBtnSave.Visible = true;
                linkBtnCancel.Visible = true;
                linkBtnAdd.Visible = false;
            }
            if (e.CommandName.Equals("Save"))
            {
                if (sis.AddSalutations(txtSalutationName.Text, "superadmin"))
                {
                    LoadSalutation();
                    lblmsg.Text = "created sucessfully";

                    lblsep.Visible = false;
                    txtSalutationName.Visible = false;
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
            foreach (GridViewRow row in Gv_salutation.Rows)
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

        protected void Gv_salutation_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string pName = Gv_salutation.SelectedRow.Cells[2].Text; 
            string pjName = Gv_salutation.SelectedDataKey.Value.ToString();
            lblmsg.Text = "<b>Publisher Name   :     " + pjName + "</b>";
        }

        protected void Gv_salutation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }
    }
}