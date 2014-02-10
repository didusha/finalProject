using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class companyEditProfil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["identifier"] != null)
        {
            Company c = new Company();
            c = c.companyApproved(Request["identifier"]);

            if (c.status == 1)
            {
                Session["MyCompany"] = c;
                Directory.CreateDirectory(Server.MapPath("~/company/") + c.user_name);
                Directory.CreateDirectory(Server.MapPath("~/company/") + c.user_name + "/picture");
                Directory.CreateDirectory(Server.MapPath("~/company/") + c.user_name + "/video");
                // Directory.CreateDirectory(Server.MapPath("~/company/") + c.user_name + "/campaign");
                //viewProfile.NavigateUrl = "CompanyProfile.aspx?id=" + c.id;
                //editProfile(p);
            }
            else
            {
                // הפנייה לכניסת משתמש + הודעה מתאימה
                lblHello.Text = "Company already register....";
            }
        }
        else if (Session["MyCompany"] != null)
        {
            Company tmp = (Company)Session["MyCompany"];
           // viewProfile.NavigateUrl = "CompanyProfile.aspx?id=" + tmp.id;
            CompanyEditProfile(tmp);
        }
    }

    private void CompanyEditProfile(Company c)
    {
        //למלא שדות קיימים
        txtAbout.Text = c.about;
        txtGoals.Text = c.goals;
        imgLogo.ImageUrl = "company/" + c.user_name + "/picture/" + c.logo;
        imgProfile.ImageUrl = "company/" + c.user_name + "/picture/" + c.picture;
        //imgLogo.ImageUrl = p.picture;
    }


    protected void saveBtn_Click(object sender, EventArgs e)
    {
        Company c = (Company)Session["MyCompany"];
        //לקחת מכל השדות ערכים

        c.picture = uploadProfile.FileName;
        c.logo = uploadLogo.FileName;
        c.about = txtAbout.Text;
        c.goals = txtGoals.Text;
        Session["MyCompany"] = c;
        int res = c.updateCompanyProfile();

        if (res == 1)
        {
            uploadProfile.SaveAs(Server.MapPath("~/company/") + c.user_name + "/picture/" + uploadProfile.FileName);
            uploadLogo.SaveAs(Server.MapPath("~/company/") + c.user_name + "/picture/" + uploadLogo.FileName);
            //if( Directory.Exists(Server.MapPath("~/Company/") + p.user_name + "/picture"))
            //{

            //} 
            lblFeedback.Text = "data changed successfuly";
        }
        else
        {
            lblFeedback.Text = "data did not changed, dont look surprise";
        }
    }
}