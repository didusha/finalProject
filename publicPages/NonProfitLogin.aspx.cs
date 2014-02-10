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
            string script = "var _location = document.location.toString(); var applicationNameIndex = _location.indexOf('/', _location.indexOf('://') + 3); var applicationName = _location.substring(0, applicationNameIndex) + '/'; var webFolderIndex = _location.indexOf('/', _location.indexOf(applicationName) + applicationName.length); var webFolderFullPath = _location.substring(0, webFolderIndex); path = webFolderFullPath + '/NonProfitNewsFeed.aspx'; window.opener.location = path; window.close();";
            Session["MyNonProfit"] = p;
            Response.Write("<script>" + script + "</script>");
        }

    }
}