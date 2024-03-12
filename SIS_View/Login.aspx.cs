using SIS_Controller;
using SIS_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIS_View
{
    public partial class Login : System.Web.UI.Page
    {
        private readonly SISBLL ss = new SISBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblusername.Text = "User Name";
            lblpassword.Text = "Password";
            BtnLogin.Text = "Login";
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            TBL_userAccount[] login = ss.Logins(txtusername.Text.Trim(), txtpassword.Text.Trim());
            if (login.Count() > 0)
            {
                if (login[0].userSatatus == 1)
                {
                    Session["category"] = login[0].userCategory;
                    Session["username"] = login[0].username;
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    lblvalid.Visible = true;
                    lblvalid.Text = "Login Failed. Account is deactivated please contact administrator ";
                }
            }
            else
            {
                lblvalid.Visible = true;
                lblvalid.Text = "Login Failed. Please remember that passwords ";
            }
        }

    }
}