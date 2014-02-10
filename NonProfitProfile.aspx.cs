using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


public partial class NonProfitProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["MyNonProfit"] != null)
        {
            NonProfit tmp = (NonProfit)Session["MyNonProfit"];
            if (Convert.ToInt32(Request["id"]) == tmp.id)
            {
                //להראות סרגל עריכה
                uploadCampaign.Visible = true;
                uploadCampaign.NavigateUrl = "NonProfitUploadCampaign.aspx";
                editProfile.Visible = true;
                editProfile.NavigateUrl = "NonProfitEditProfile.aspx";
                loadNonProfit(tmp);

            }
            else
            {
                getNonProfitForShow();
            }
        }
        //lblHello.Text = p.nonProfit_name;
        else
        {
            getNonProfitForShow();
        }
        
    }

    private void getNonProfitForShow()
    {
        editProfile.Visible = false;
        NonProfit p = new NonProfit();
        p.id = Convert.ToInt32(Request["id"]);
        p = p.getDetailes();
        loadNonProfit(p);
    }

    private void loadNonProfit(NonProfit tmp)
    {
        imgLogo.ImageUrl = "nonProfit/" + tmp.user_name + "/picture/" + tmp.logo;
        imgProfile.ImageUrl = "nonProfit/" + tmp.user_name + "/picture/" + tmp.picture;
        HtmlGenericControl about = new HtmlGenericControl("p");
        about.InnerHtml = tmp.about;
        pnlAbout.Controls.Add(about);
        HtmlGenericControl goals = new HtmlGenericControl("p");
        goals.InnerHtml = tmp.goals;
        pnlAbout.Controls.Add(goals);
    }
}