using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class UserEditProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["identifier"] != null)
        {
            User u = new User();
            u = u.approved(Request["identifier"]);

            if (u.status == 1)
            {
                Session["MyUser"] = u;
                Directory.CreateDirectory(Server.MapPath("~/users/") + u.user_name);
                Directory.CreateDirectory(Server.MapPath("~/users/") + u.user_name + "/picture");
                viewProfile.NavigateUrl = "UserProfile.aspx?id=" + u.id;
                //editProfile(p);
            }
            else
            {
                // הפנייה לכניסת משתמש + הודעה מתאימה
                lblHello.Text = "already register....";
            }
        }
        else if (Session["MyUser"] != null)
        {
            User tmp = (User)Session["MyUser"];
            viewProfile.NavigateUrl = "UserProfile.aspx?id=" + tmp.id;
            editProfile(tmp);
        }
    }
    protected void saveBtn_Click(object sender, EventArgs e)
    {
        User p = (User)Session["MyUser"];
        //לקחת מכל השדות ערכים

        p.picture = uploadProfile.FileName;
        p.birth_date = txtBirthDate.Text;
        p.mobile_phone = txtCellPhone.Text;
        p.phone = txtPhone.Text;
        p.gender = RadioButtonListGender.SelectedValue;
        Session["MyUser"] = p;
        int res = p.updateProfile();

        if (res > 0)
        {
            if (uploadProfile.HasFile)
            {
                uploadProfile.SaveAs(Server.MapPath("~/users/") + p.user_name + "/picture/" + uploadProfile.FileName);
            }
            lblFeedback.Text = "data changed successfuly";
        }
        else
        {
            lblFeedback.Text = "data did not changed, dont look surprise";
        }
    }


    private void editProfile(User tmp)
    {
        //למלא שדות קיימים
        txtBirthDate.Text = tmp.birth_date;
        txtCellPhone.Text = tmp.mobile_phone;
        txtPhone.Text = tmp.phone;
        RadioButtonListGender.SelectedValue = tmp.gender;
        imgProfile.ImageUrl = "users/" + tmp.user_name + "/picture/" + tmp.picture;

    }
}