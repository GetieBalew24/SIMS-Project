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
    public partial class Occupation : System.Web.UI.Page
    {
        private readonly SISBLL sis = new SISBLL();
        private readonly DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadOccupation();
            }
        }
        protected void LoadOccupation()
        {
            TBL_occupation[] occupation = sis.GetAllOccupations();
            dt.Columns.Add("occupationCode");
            dt.Columns.Add("occupationName");
            dt.Columns.Add("recordedBy");
            dt.Columns.Add("recordedDate");
            dt.Columns.Add("recordedTime");
            dt.Columns.Add("lastModifiedBy");
            dt.Columns.Add("lastModifiedDate");
            dt.Columns.Add("lastModifiedTime");
            dt.Columns.Add("currentStatus");
            if (occupation.Count() > 0)
            {
                for (int j = 0; j < occupation.Count(); j++)
                {
                    String stat;
                    if (occupation[j].currentStatus == 0)
                        stat = "Inactive";
                    else
                        stat = "Active";
                    DataRow dr = dt.NewRow();
                    dr["occupationCode"] = occupation[j].occupationCode;
                    dr["occupationName"] = occupation[j].occupationName;
                    dr["recordedBy"] = occupation[j].recordedBy;
                    dr["recordedDate"] = occupation[j].recordedDate;
                    dr["recordedTime"] = occupation[j].recordedTime;
                    dr["lastModifiedBy"] = occupation[j].lastModifiedBy;
                    dr["lastModifiedDate"] = occupation[j].lastModifiedDate;
                    dr["lastModifiedTime"] = occupation[j].lastModifiedTime;
                    dr["currentStatus"] = stat;
                    dt.Rows.Add(dr);
                }
                Gv_occupation.DataSource = dt;
                Gv_occupation.DataBind();
            }
        }

        protected void Gv_occupation_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Gv_occupation.EditIndex = -1;
            LoadOccupation();
        }

        protected void Gv_occupation_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string occupationCode = Gv_occupation.DataKeys[e.RowIndex].Values["occupationCode"].ToString();

            if (sis.DeleteOccupations(occupationCode))
            {
                LoadOccupation();
                lblmsg.Text = occupationCode + "      Deleted successfully.......    ";
            }
        }

        protected void Gv_occupation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Label lblsep = (Label)Gv_occupation.FooterRow.FindControl("lblsep");
            TextBox occupationName = (TextBox)Gv_occupation.FooterRow.FindControl("insOccupationName");

            LinkButton linkBtnSave = (LinkButton)Gv_occupation.FooterRow.FindControl("LinkBtnSave");
            LinkButton linkBtnCancel = (LinkButton)Gv_occupation.FooterRow.FindControl("LinkBtnCancel");
            LinkButton linkBtnAdd = (LinkButton)Gv_occupation.FooterRow.FindControl("LinkBtnAdd");

            if (e.CommandName.Equals("Add"))
            {
                lblsep.Visible = true;
                occupationName.Visible = true;

                linkBtnSave.Visible = true;
                linkBtnCancel.Visible = true;
                linkBtnAdd.Visible = false;
            }
            if (e.CommandName.Equals("Save"))
            {
                if (sis.AddOccupations(occupationName.Text, "superadmin"))
                {
                    LoadOccupation();
                    lblmsg.Text = "created sucessfully";

                    lblsep.Visible = false;
                    occupationName.Visible = false;

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

        protected void Gv_occupation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }

        protected void BtmDisplay_Click(object sender, EventArgs e)
        {
            string data = "";
            foreach (GridViewRow row in Gv_occupation.Rows)
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

        protected void Gv_occupation_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string pName = Gv_university.SelectedRow.Cells[2].Text; 
            string pjName = Gv_occupation.SelectedDataKey.Value.ToString();
            lblmsg.Text = "<b>Publisher Name   :     " + pjName + "</b>";
        }
    }
}