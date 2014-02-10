using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class UserProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["MyUser"] != null)
        {
            User tmp = (User)Session["MyUser"];
            if (Convert.ToInt32(Request["id"]) == tmp.id)
            {

                editProfile.Visible = true;
                editProfile.NavigateUrl = "UserEditProfile.aspx";
                loadUser(tmp);

            }
            else
            {
                getUserForShow();
            }
        }
        //lblHello.Text = p.nonProfit_name;
        else
        {
            getUserForShow();
        }

    }

    private void getUserForShow()
    {
        editProfile.Visible = false;
        User p = new User();
        p.id = Convert.ToInt32(Request["id"]);
        p = p.getDetailes();
        loadUser(p);
    }

    private void loadUser(User tmp)
    {
        imgProfile.ImageUrl = "users/" + tmp.user_name + "/picture/" + tmp.picture;

        HtmlGenericControl mobile_phone = new HtmlGenericControl("p");
        mobile_phone.InnerHtml = tmp.mobile_phone;
        pnlcellphone.Controls.Add(mobile_phone);

        HtmlGenericControl phone = new HtmlGenericControl("p");
        phone.InnerHtml = tmp.phone;
        pnlphone.Controls.Add(phone);

        HtmlGenericControl gender = new HtmlGenericControl("p");
        gender.InnerHtml = tmp.gender;
        pnlgender.Controls.Add(gender);

        HtmlGenericControl birth_date = new HtmlGenericControl("p");
        birth_date.InnerHtml = tmp.birth_date;
        pnlbirthdate.Controls.Add(birth_date);

    }
}