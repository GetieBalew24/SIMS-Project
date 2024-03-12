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
    public partial class PositionRole : System.Web.UI.Page
    {
        private readonly SISBLL sis = new SISBLL();
        private readonly DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Gv_LoadPositionRole();
            }
        }
        protected void Gv_LoadPositionRole()
        {
            TBL_positionRole[] positionRole = sis.GetAllPositionRoles();
            dt.Columns.Add("positionRoleCode");
            dt.Columns.Add("positionCode");
            dt.Columns.Add("roleCode");
            dt.Columns.Add("recordedBy");
            dt.Columns.Add("recordedDate");
            dt.Columns.Add("recordedTime");
            dt.Columns.Add("lastModifiedBy");
            dt.Columns.Add("lastModifiedDate");
            dt.Columns.Add("lastModifiedTime");
            dt.Columns.Add("currentStatus");
            if (positionRole.Count() > 0)
            {
                for (int j = 0; j < positionRole.Count(); j++)
                {
                    String stat;
                    if (positionRole[j].currentStatus == 0)
                        stat = "Inactive";
                    else
                        stat = "Active";
                    DataRow dr = dt.NewRow();

                    dr["positionRoleCode"] = positionRole[j].positionRoleCode;
                    dr["positionCode"] = positionRole[j].positionCode;
                    dr["roleCode"] = positionRole[j].roleCode;
                    dr["recordedBy"] = positionRole[j].recordedBy;
                    dr["recordedDate"] = positionRole[j].recordedDate;
                    dr["recordedTime"] = positionRole[j].recordedTime;
                    dr["lastModifiedBy"] = positionRole[j].lastModifiedBy;
                    dr["lastModifiedDate"] = positionRole[j].lastModifiedDate;
                    dr["lastModifiedTime"] = positionRole[j].lastModifiedTime;
                    dr["currentStatus"] = stat;
                    dt.Rows.Add(dr);
                }
                Gv_positionRole.DataSource = dt;
                Gv_positionRole.DataBind();
            }
        }
        protected void Gv_positionRole_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Gv_positionRole.EditIndex = -1;
            Gv_LoadPositionRole();
        }

        protected void Gv_positionRole_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string positionRoleCode = Gv_positionRole.DataKeys[e.RowIndex].Values["positionRoleCode"].ToString();

            if (sis.DeletePositionRoles(positionRoleCode))
            {
                Gv_LoadPositionRole();
                lblmsg.Text = positionRoleCode + "      Deleted successfully.......    ";
            }
        }

        protected void Gv_positionRole_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DropDownList positionCode = (DropDownList)Gv_positionRole.FooterRow.FindControl("insPositionCode");
            DropDownList roleCode = (DropDownList)Gv_positionRole.FooterRow.FindControl("insRoleCode");

            LinkButton linkBtnSave = (LinkButton)Gv_positionRole.FooterRow.FindControl("LinkBtnSave");
            LinkButton linkBtnCancel = (LinkButton)Gv_positionRole.FooterRow.FindControl("LinkBtnCancel");
            LinkButton linkBtnAdd = (LinkButton)Gv_positionRole.FooterRow.FindControl("LinkBtnAdd");

            if (e.CommandName.Equals("Add"))
            {
                positionCode.Visible = true;
                roleCode.Visible = true;

                linkBtnSave.Visible = true;
                linkBtnCancel.Visible = true;
                linkBtnAdd.Visible = false;
            }
            if (e.CommandName.Equals("Save"))
            {
                if (sis.AddPositionRoles(positionCode.SelectedValue, roleCode.SelectedValue, "superadmin"))
                {
                    Gv_LoadPositionRole();
                    lblmsg.Text = "created sucessfully";

                    positionCode.Visible = false;
                    roleCode.Visible = false;

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

        protected void Gv_positionRole_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }

        protected void Gv_positionRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string pName = Gv_university.SelectedRow.Cells[2].Text; 
            string pjName = Gv_positionRole.SelectedDataKey.Value.ToString();
            lblmsg.Text = "<b>Publisher Name   :     " + pjName + "</b>";
        }

    }
}