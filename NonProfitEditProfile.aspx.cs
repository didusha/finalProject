using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class NonProfitEditProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request["identifier"] != null)
        {
            NonProfit p = new NonProfit();
            p = p.approved(Request["identifier"]);

            if (p.status == 1)
            {
                Session["MyNonProfit"] = p;
                Directory.CreateDirectory(Server.MapPath("~/nonProfit/") + p.user_name);
                Directory.CreateDirectory(Server.MapPath("~/nonProfit/") + p.user_name + "/picture");
                Directory.CreateDirectory(Server.MapPath("~/nonProfit/") + p.user_name + "/video");
                Directory.CreateDirectory(Server.MapPath("~/nonProfit/") + p.user_name + "/campaign");
                viewProfile.NavigateUrl = "NonProfitProfile.aspx?id=" + p.id;
            }
            else
            {
                // הפנייה לכניסת משתמש + הודעה מתאימה
                lblHello.Text = "already register....";
            }
        }
        else if(Session["MyNonProfit"] != null && !IsPostBack)
        {
            NonProfit tmp =  (NonProfit)Session["MyNonProfit"];
            viewProfile.NavigateUrl = "NonProfitProfile.aspx?id=" + tmp.id;
            editProfile(tmp);
        }
    }

    private void editProfile(NonProfit p)
    {
        //למלא שדות קיימים
        txtAbout.Text = p.about;
        txtGoals.Text = p.goals;
        imgLogo.ImageUrl = "nonProfit/" + p.user_name + "/picture/" + p.logo;
        imgProfile.ImageUrl = "nonProfit/" + p.user_name + "/picture/" + p.picture;
        //imgLogo.ImageUrl = p.picture;
    }

    protected void saveBtn_Click(object sender, EventArgs e)
    {
        NonProfit p = (NonProfit)Session["MyNonProfit"];
        //לקחת מכל השדות ערכים
        int res = 0;
        int toDb = 0;

        if (uploadProfile.HasFile)
        {
            toDb++;
            p.picture = uploadProfile.FileName;
        }
        if (uploadLogo.HasFile)
        {
            toDb++;
            p.logo = uploadLogo.FileName;
        }
        if (p.about != txtAbout.Text && txtAbout.Text != "")
        {
            toDb++;
            p.about = txtAbout.Text;
        }
        if (p.goals != txtGoals.Text && txtGoals.Text != "")
        {
            toDb++;
            p.goals = txtGoals.Text;
        }

        if (toDb > 0)
        {
            Session["MyNonProfit"] = p;
            res = p.updateProfile();
        }

        if (res > 0)
        {
            if (uploadProfile.HasFile)
            {
                uploadProfile.SaveAs(Server.MapPath("~/nonProfit/") + p.user_name + "/picture/" + uploadProfile.FileName);
            }
            if (uploadLogo.HasFile)
            {
                uploadLogo.SaveAs(Server.MapPath("~/nonProfit/") + p.user_name + "/picture/" + uploadLogo.FileName);
            }
            
            lblFeedback.Text = "data changed successfuly";
        }
        else
        {
            lblFeedback.Text = "data did not changed, dont look surprise";
        }
    }
}