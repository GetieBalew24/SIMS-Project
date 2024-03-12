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
    public partial class HighSchool : System.Web.UI.Page
    {
        private readonly SISBLL sis = new SISBLL();
        private readonly DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadHighSchool();
            }
        }
        protected void LoadHighSchool()
        {
            TBL_highSchool[] highSchool = sis.GetAllHighSchools();
            dt.Columns.Add("highSchoolCode");
            dt.Columns.Add("woredaCode");
            dt.Columns.Add("highSchoolName");
            dt.Columns.Add("recordedBy");
            dt.Columns.Add("recordedDate");
            dt.Columns.Add("recordedTime");
            dt.Columns.Add("lastModifiedBy");
            dt.Columns.Add("lastModifiedDate");
            dt.Columns.Add("lastModifiedTime");
            dt.Columns.Add("currentStatus");
            if (highSchool.Count() > 0)
            {
                for (int j = 0; j < highSchool.Count(); j++)
                {
                    String stat;
                    if (highSchool[j].currentStatus == 0)
                        stat = "Inactive";
                    else
                        stat = "Active";
                    DataRow dr = dt.NewRow();
                    dr["highSchoolCode"] = highSchool[j].highSchoolCode;
                    dr["woredaCode"] = highSchool[j].woredaCode;
                    dr["highSchoolName"] = highSchool[j].highSchoolName;
                    dr["recordedBy"] = highSchool[j].recordedBy;
                    dr["recordedDate"] = highSchool[j].recordedDate;
                    dr["recordedTime"] = highSchool[j].recordedTime;
                    dr["lastModifiedBy"] = highSchool[j].lastModifiedBy;
                    dr["lastModifiedDate"] = highSchool[j].lastModifiedDate;
                    dr["lastModifiedTime"] = highSchool[j].lastModifiedTime;
                    dr["currentStatus"] = stat;
                    dt.Rows.Add(dr);
                }
                Gv_highSchool.DataSource = dt;
                Gv_highSchool.DataBind();
            }
        }

        protected void Gv_highSchool_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Gv_highSchool.EditIndex = -1;
            LoadHighSchool();
        }

        protected void Gv_highSchool_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string highSchoolCode = Gv_highSchool.DataKeys[e.RowIndex].Values["highSchoolCode"].ToString();

            if (sis.DeleteHighSchools(highSchoolCode))
            {
                LoadHighSchool();
                lblmsg.Text = highSchoolCode + "      Deleted successfully.......    ";
            }
        }

        protected void Gv_highSchool_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Label lblsep = (Label)Gv_highSchool.FooterRow.FindControl("lblsep");
            DropDownList woredaCode = (DropDownList)Gv_highSchool.FooterRow.FindControl("insWoredaCode");
            TextBox highSchoolName = (TextBox)Gv_highSchool.FooterRow.FindControl("insHighSchoolName");

            LinkButton linkBtnSave = (LinkButton)Gv_highSchool.FooterRow.FindControl("LinkBtnSave");
            LinkButton linkBtnCancel = (LinkButton)Gv_highSchool.FooterRow.FindControl("LinkBtnCancel");
            LinkButton linkBtnAdd = (LinkButton)Gv_highSchool.FooterRow.FindControl("LinkBtnAdd");

            if (e.CommandName.Equals("Add"))
            {
                lblsep.Visible = true;
                woredaCode.Visible = true;
                highSchoolName.Visible = true;

                linkBtnSave.Visible = true;
                linkBtnCancel.Visible = true;
                linkBtnAdd.Visible = false;
            }
            if (e.CommandName.Equals("Save"))
            {
                if (sis.AddHighSchools(woredaCode.SelectedValue, highSchoolName.Text, "superadmin"))
                {
                    LoadHighSchool();
                    lblmsg.Text = "created sucessfully";

                    lblsep.Visible = false;
                    woredaCode.Visible = false;
                    highSchoolName.Visible = false;

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

        protected void Gv_highSchool_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }

        protected void BtmDisplay_Click(object sender, EventArgs e)
        {
            string data = "";
            foreach (GridViewRow row in Gv_highSchool.Rows)
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

        protected void Gv_highSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string pName = Gv_university.SelectedRow.Cells[2].Text; 
            string pjName = Gv_highSchool.SelectedDataKey.Value.ToString();
            lblmsg.Text = "<b>Publisher Name   :     " + pjName + "</b>";
        }
    }
}