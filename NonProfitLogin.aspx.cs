using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NonProfitLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LoginNonProfitBTN_Click(object sender, EventArgs e)
    {
        NonProfit p = new NonProfit();
        p.user_name = txtnonProfitUserName.Text;
        p.password = txtnonProfitPassword.Text;
        p = p.login(); // להביא את כל הנתונים להצגה בחדשות החמות
        if (p.status == 0)
        {
            lblLoginNonProfit.Text = "Login Failed";
        }
        else
        {
            Session["MyNonProfit"] = p;
            Response.Write("<script>window.opener.location = 'NonProfitNewsFeed.aspx'; window.close();</script>");
        }

    }
}