using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

public partial class nonProfitReg : System.Web.UI.Page
{
    string[] numbers = { "111", "222", "333", "444", "555" };

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void submitReg_Click(object sender, EventArgs e)
    {
        string numberToCheck = txtNumber.Text;

        foreach (string str in numbers)
        {
            if (str == numberToCheck)
            {
                NonProfit p = new NonProfit(txtUserName.Text, txteMail.Text, txtPassword.Text,
                    txtContactFirstName.Text, txtContactMail.Text, txtContactLastName.Text, txtNumber.Text, txtName.Text);
                string result = p.insert();
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
                    m.Body = "http://localhost:64104/FinalProject/NonProfitEditProfile.aspx?identifier=" + result;
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.Credentials = new System.Net.NetworkCredential()
                    {
                        UserName = sendFrom,
                        Password = System.Configuration.ConfigurationManager.AppSettings["mailPassword"]
                    };
                    smtp.EnableSsl = true;
                    smtp.Send(m);
                    //Session["NonProfit"] = p;
                    lblApproval.Text = "please check your mail to approve your registration";
                    return;
                }
            }
        }

        lblMessage.Text = "wrong number";
    }
  
}