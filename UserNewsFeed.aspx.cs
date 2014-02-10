using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserNewsFeed : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["MyUser"] != null && !IsPostBack)
        {
            User p = (User)Session["MyUser"];
            loadNewsFeed(p);
            userProfile.NavigateUrl = "UserProfile.aspx?id=" + p.id;
        }
    }

    private void loadNewsFeed(User p)
    {
        //להכניס את כל החדשות החמות
    }
}