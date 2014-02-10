using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class NonProfitNewsFeed : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["MyNonProfit"] != null && !IsPostBack)
        {   
            NonProfit p = (NonProfit)Session["MyNonProfit"];
            loadNewsFeed(p);
            profileLink.NavigateUrl = "NonProfitProfile.aspx?id=" + p.id;
        }
    }

    private void loadNewsFeed(NonProfit p)
    {
        foreach (Campaign c in p.cmp)
        {
            HtmlGenericControl h1 = new HtmlGenericControl("h1");
            h1.InnerHtml = c.name;
            checkNews.Controls.Add(h1);
            foreach (Donation d in c.campaign_donation)
            {
                HtmlGenericControl donate = new HtmlGenericControl("p");
                donate.InnerHtml = "donate - " + d.amount;
                checkNews.Controls.Add(donate);
            }
        }
    }
}