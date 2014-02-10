using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LoginUserBTN_Click(object sender, EventArgs e)
    {
        User u = new User();
        u.user_name = txtUserUserName.Text;
        u.password = txtUserPassword.Text;
        u = u.login();
        if (u.status == 0)
        {
            lblLoginUser.Text = "Login Failed";
        }
        else
        {
            Session["MyUser"] = u;
            Response.Write("<script>window.opener.location = 'UserNewsFeed.aspx'; window.close();</script>");
        }
    }
}