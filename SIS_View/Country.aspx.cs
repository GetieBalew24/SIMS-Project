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
    public partial class Country : System.Web.UI.Page
    {
        private readonly SISBLL sis = new SISBLL();
        private readonly DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadCountry();
            }
        }
        protected void LoadCountry()
        {
            TBL_country[] country = sis.GetAllCountrys();
            dt.Columns.Add("countryCode");
            dt.Columns.Add("countryname");
            dt.Columns.Add("continent");
            dt.Columns.Add("nationality");
            dt.Columns.Add("recordedBy");
            dt.Columns.Add("recordedDate");
            dt.Columns.Add("recordedTime");
            dt.Columns.Add("lastModifiedBy");
            dt.Columns.Add("lastModifiedDate");
            dt.Columns.Add("lastModifiedTime");
            dt.Columns.Add("currentStatus");
            if (country.Count() > 0)
            {
                for (int j = 0; j < country.Count(); j++)
                {
                    String stat;
                    if (country[j].currentStatus == 0)
                        stat = "Inactive";
                    else
                        stat = "Active";
                    DataRow dr = dt.NewRow();
                    dr["countryCode"] = country[j].countryCode;
                    dr["countryName"] = country[j].countryName;
                    dr["continent"] = country[j].continent;
                    dr["nationality"] = country[j].nationality;
                    dr["recordedBy"] = country[j].recordedBy;
                    dr["recordedDate"] = country[j].recordedDate;
                    dr["recordedTime"] = country[j].recordedTime;
                    dr["lastModifiedBy"] = country[j].lastModifiedBy;
                    dr["lastModifiedDate"] = country[j].lastModifiedDate;
                    dr["lastModifiedTime"] = country[j].lastModifiedTime;
                    dr["currentStatus"] = stat;
                    dt.Rows.Add(dr);
                }
                Gv_country.DataSource = dt;
                Gv_country.DataBind();
            }
        }
         
        protected void Gv_country_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Gv_country.EditIndex = -1;
            LoadCountry();
        }

        protected void Gv_country_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string countryCode = Gv_country.DataKeys[e.RowIndex].Values["countryCode"].ToString();

            if (sis.DeleteCountrys(countryCode))
            {
                LoadCountry();
                lblmsg.Text = countryCode + "      Deleted successfully.......    ";
            }
        }

        protected void Gv_country_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Label lblsep = (Label)Gv_country.FooterRow.FindControl("lblsep");
            TextBox countryname = (TextBox)Gv_country.FooterRow.FindControl("insCountryName");
            DropDownList continent = (DropDownList)Gv_country.FooterRow.FindControl("insContinent");
            TextBox nationality = (TextBox)Gv_country.FooterRow.FindControl("insnationality");

            LinkButton linkBtnSave = (LinkButton)Gv_country.FooterRow.FindControl("LinkBtnSave");
            LinkButton linkBtnCancel = (LinkButton)Gv_country.FooterRow.FindControl("LinkBtnCancel");
            LinkButton linkBtnAdd = (LinkButton)Gv_country.FooterRow.FindControl("LinkBtnAdd");

            if (e.CommandName.Equals("Add"))
            {
                lblsep.Visible = true;
                countryname.Visible = true;
                continent.Visible = true;
                nationality.Visible = true;

                linkBtnSave.Visible = true;
                linkBtnCancel.Visible = true;
                linkBtnAdd.Visible = false;
            }
            if (e.CommandName.Equals("Save"))
            {
                if (sis.AddCountrys(countryname.Text, continent.SelectedValue,nationality.Text, "superadmin"))
                {
                    LoadCountry();
                    lblmsg.Text = "created sucessfully";

                    lblsep.Visible = false;
                    countryname.Visible = false;
                    continent.Visible = false;
                    nationality.Visible = false;

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

        protected void Gv_country_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }

        protected void Gv_country_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string pName = Gv_university.SelectedRow.Cells[2].Text; 
            string pjName = Gv_country.SelectedDataKey.Value.ToString();
            lblmsg.Text = "<b>Publisher Name   :     " + pjName + "</b>";
        }

        protected void BtmDisplay_Click(object sender, EventArgs e)
        {
            string data = "";
            foreach (GridViewRow row in Gv_country.Rows)
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