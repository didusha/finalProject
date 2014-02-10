using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

public partial class userReg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void submitUserReg_Click(object sender, EventArgs e)
    {
        User u = new User(txtUserFirstName.Text, txtUserLastName.Text, txtPassword.Text,
            txteMail.Text, txtUserName.Text);
        string result = u.insert();
        if (result == "no")
        {
            lblMessage.Text = "user name already exist";
            return;
        }
        else
        {
            string sendTo = txteMail.Text;
            string sendFrom = System.Configuration.ConfigurationManager.AppSettings["ruppinMail"];
            MailMessage m = new MailMessage(sendFrom, sendTo);
            m.Subject = "אישור הרשמה";
            m.Body = "http://localhost:64104/FinalProject/UserEditProfile.aspx?identifier=" + result;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new System.Net.NetworkCredential()
            {
                UserName = sendFrom,
                Password = System.Configuration.ConfigurationManager.AppSettings["mailPassword"]
            };
            smtp.EnableSsl = true;
            smtp.Send(m);
            lblApproval.Text = "please check your mail to approve your registration";
            return;
        }

    }
}