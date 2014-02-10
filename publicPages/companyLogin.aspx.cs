using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class publicPages_companyLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void LoginCompanyBTN_Click(object sender, EventArgs e)
    {

        Company c = new Company();
        c.user_name = txtcompanyUserName.Text;
        c.password = txtcompanyPassword.Text;
        c = c.companyLogin(); // להביא את כל הנתונים להצגה בחדשות החמות
        if (c.status == 0)
        {
            lblLoginCompany.Text = "Login Failed";
        }
        else
        {
            string script = "var _location = document.location.toString(); var applicationNameIndex = _location.indexOf('/', _location.indexOf('://') + 3); var applicationName = _location.substring(0, applicationNameIndex) + '/'; var webFolderIndex = _location.indexOf('/', _location.indexOf(applicationName) + applicationName.length); var webFolderFullPath = _location.substring(0, webFolderIndex); path = webFolderFullPath + '/companyNewsFeed.aspx'; window.opener.location = path; window.close();";
            Session["MyCompany"] = c;
            Response.Write("<script>" + script + "</script>");
        }



        //var _location = document.location.toString();
        //var applicationNameIndex = _location.indexOf('/', _location.indexOf('://') + 3);
        //var applicationName = _location.substring(0, applicationNameIndex) + '/';
        //var webFolderIndex = _location.indexOf('/', _location.indexOf(applicationName) + applicationName.length);
        //var webFolderFullPath = _location.substring(0, webFolderIndex);
    }

}