using SIS_Controller;
using SIS_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIS_View
{
    public partial class SIS : System.Web.UI.MasterPage
    {
        private readonly SISBLL ss = new SISBLL();
        DataTable dtSource = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            GetLabel();
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    username1.Visible = true;
                    Logout1.Visible = true;
                    Login1.Visible = false;
                    DisplayNameAttribute(Session["username"].ToString());

                    dtSource = GetData(Session["username"].ToString());
                    DataTable dt = GetChildData(-1);
                    foreach (DataRow dr in dt.Rows)
                    {
                        TreeNode parentNode = new TreeNode
                        {
                            Text = dr["menuname"].ToString(),
                            Value = dr["menuid"].ToString(),
                            NavigateUrl = dr["menulink"].ToString()
                        };
                        AddNodes(ref parentNode);
                        TreeView1.Nodes.Add(parentNode);
                        TreeView1.CollapseAll();
                    }
                }
                else
                {
                    username1.Visible = false;
                    Logout1.Visible = false;
                    Login1.Visible = true;
                }
            }
            else
            {
                Session.Clear();
                Session["username"] = string.Empty;
                Session["userrole"] = string.Empty;
            }
        }

        private void DisplayNameAttribute(String username)
        {
            username1.Text = username;

        }
        private void AddNodes(ref TreeNode node)
        {
            DataTable dt = GetChildData(Convert.ToInt32(node.Value));
            foreach (DataRow row in dt.Rows)
            {
                TreeNode childNode = new TreeNode
                {
                    Value = row["menuid"].ToString(),
                    Text = row["menuname"].ToString(),
                    NavigateUrl = row["menulink"].ToString()
                };
                AddNodes(ref childNode);
                node.ChildNodes.Add(childNode);
            }
        }

        private DataTable GetChildData(int parentId)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("menuid", typeof(int)),
                new DataColumn("parentid",typeof(int)),
                new DataColumn("menuname"),
                new DataColumn("menulink")});

            foreach (DataRow dr in dtSource.Rows)
            {
                if (dr[1].ToString() != parentId.ToString())
                {
                    continue;
                }
                DataRow row = dt.NewRow();
                row["menuid"] = dr["menuid"];
                row["parentid"] = dr["parentid"];
                row["menuname"] = dr["menuname"];
                row["menulink"] = dr["menulink"];
                dt.Rows.Add(row);
            }

            return dt;
        }

        private DataTable GetData(String un)
        {
            TBL_view_manegerole[] mrole = ss.GetViewManageRole(un);
            DataTable dt = new DataTable();
            dt.Columns.Add("menuid");
            dt.Columns.Add("parentid");
            dt.Columns.Add("menuname");
            dt.Columns.Add("menulink");
            if (mrole.Count() > 0 )
            {
                
                for (int j = 0; j < mrole.Count(); j++)
                {
                    DataRow dr = dt.NewRow();
                    dr["menuid"] = mrole[j].menuCode;
                    dr["menuname"] = mrole[j].menuName;
                    dr["parentid"] = mrole[j].parentCode;
                    dr["menulink"] = mrole[j].menuLink;
                    dt.Rows.Add(dr);
                } 
            }
            return dt;
        }

        private void GetLabel()
        {
            TBL_system[] sys = ss.GetAllSystems();
            TBL_university[] univ = ss.GetAllUniversities();
            lbldate.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
            lblsystem.Text = univ[0].universityCode + " - " + sys[0].systemName.ToString() + "( " + sys[0].systemCode.ToString() + " ) ";
            Login1.Text = "Login";
            Logout1.Text = "Logout";
        }
         
        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            lblpage.Text = "..:: " + TreeView1.SelectedNode.ValuePath + " ::..";
        }
    }
}