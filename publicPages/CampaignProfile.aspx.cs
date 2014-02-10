using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class publicPages_CampaignProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["cid"] != null)
            {
                int cid = Convert.ToInt32(Request["cid"]);

                if (Session["MyNonProfit"] != null)
                {
                    NonProfit p = (NonProfit)Session["MyNonProfit"];

                    foreach (Campaign c in p.cmp)
                    {
                        if (c.id == cid)
                        {
                            loadCampaign(p, c);
                            return;
                        }
                    }
                    //אם הגענו לפה זו עמותה שבאה לראות קמפיין אחר
                    loadCampaignFromDataBase(cid);
                }
                else
                {
                    //תאגיד או משתמש
                    loadCampaignFromDataBase(cid);
                }
                
            }
        }
    }

    private void loadCampaignFromDataBase(int cid)
    {
        //לטעון את הקמפיין מהמסד נתונים במקרה שהקמפפין לא שלי
    }

    private void loadCampaign(NonProfit p, Campaign c)
    {
        imgLogo.ImageUrl = "~/nonProfit/" + p.user_name + "/picture/" + p.logo;
        campaignHeader.InnerHtml = c.name;
        imgCampaign.ImageUrl = "~/nonProfit/" + p.user_name + "/campaign/" + c.name + "/" + c.picture; 
        campaignGoal.InnerHtml = c.money_goal.ToString();

        int days = calcDaysLeft(c.end_date);
        lblDaysLeft.Text = days.ToString();
    }

    private int calcDaysLeft(DateTime dateTime)
    {
        string now = System.DateTime.Now.ToShortDateString();
        DateTime currentDate = Convert.ToDateTime(now);
        return dateTime.Subtract(currentDate).Days;
    }
}