using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;


public partial class NonProfitUploadCampaign : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Calendar1.Visible = false;
            Calendar2.Visible = false;
        }
    }
    protected void imgCalender_Click(object sender, ImageClickEventArgs e)
    {
        if (Calendar1.Visible)
        {
            Calendar1.Visible = false;
        }
        else
        {
            Calendar1.Visible = true;
        }
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        //להגביל את המשתמש שלא יבחר תאריך שעבר
        txtStartDate.Text = Calendar1.SelectedDate.ToShortDateString();
        Calendar1.Visible = false;
    }
    protected void imgCalenderEndDate_Click(object sender, ImageClickEventArgs e)
    {
        if (Calendar2.Visible)
        {
            Calendar2.Visible = false;
        }
        else
        {
            Calendar2.Visible = true;
        }
    }
    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        //להגביל את המשתמש שלא יבחר תאריך מתחת לתאריך ההתחלה, ולהגביל תאריכים
        txtEndDate.Text = Calendar1.SelectedDate.ToShortDateString();
        Calendar2.Visible = false;
    }
    protected void uploadBtn_Click(object sender, EventArgs e)
    {
        //להוסיף תכונות לקמפיין
        Campaign c = new Campaign();
        c.status = 0; // אם הקמפיין עולה היום אז סטטוס צריך להיות 1
        c.about = txtCampaignContent.Text;
        c.end_date = Convert.ToDateTime(txtEndDate.Text);
        c.start_date = Convert.ToDateTime(txtStartDate.Text);
        c.picture = uploadPicture.FileName;
        c.video = uploadMovie.FileName;
        c.money_goal = Convert.ToInt32(txtMoneyGoal.Text);
        c.name = txtCampaignName.Text;
        c.view_goal = Convert.ToInt32(txtPeopleGoal.Text);
        c.thanks_message = txtThanx.Text;
        c.category = new List<string>();
        c.crowd_destination = new List<string>();

        //אפשר להוריד את המשתנה המיותר search_word
        c.search_word = new List<string>();

        List<string> search_word = (List<string>)ViewState["listWord"]; 

        foreach (string str in search_word)
        {
            c.search_word.Add(str);
        }

        foreach (ListItem li in categoryList.Items)
        {
            if (li.Selected)
            {
                c.category.Add(li.Text);
            }
        }

        foreach (ListItem li in crowdDestList.Items)
        {
            if (li.Selected)
            {
                c.crowd_destination.Add(li.Text);
            }
        }

        NonProfit p = (NonProfit)Session["MyNonProfit"];
        int res = p.insertNewCampaign(c);

        if (res > 0)
        {
            //save all files and transfer
            Directory.CreateDirectory(Server.MapPath("~/nonProfit/" + p.user_name + "/campaign/" + c.name));
            if (uploadMovie.HasFile)
            {
                uploadMovie.SaveAs(Server.MapPath("~/nonProfit/" + p.user_name + "/campaign/" + c.name + "/" + uploadMovie.FileName));
            }
            if (uploadPicture.HasFile)
            {
                uploadPicture.SaveAs(Server.MapPath("~/nonProfit/" + p.user_name + "/campaign/" + c.name + "/" + uploadPicture.FileName));
            }
            //לבדוק העלאת קובץ תודה
            c.id = res;
            p.cmp.Add(c);
            Session["MyNonProfit"] = p;

            lblMessage.Text = "campaign upload successfuly";

            campaignProfile.Visible = true;
            campaignProfile.NavigateUrl = "publicPages/CampaignProfile.aspx?cid=" + c.id;
            return; //replace to code to transfer
            
        }

        lblMessage.Text = "something went wrong";

    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        
        if (ViewState["listWord"] != null)
        {
            List<string> list = (List<string>)ViewState["listWord"];
            foreach (string str in list)
            {
                if (str == txtSearchWord.Text)
                {
                    return;
                }
            }

            list.Add(txtSearchWord.Text);
            ViewState["listWord"] = list;
            txtSearchWord.Text = "";
            txtSearchWordList.Text = "";
            foreach (string st in list)
            {
                txtSearchWordList.Text += st + "\n";
            }
        }
        else
        {
            List<string> searchWord = new List<string>();
            searchWord.Add(txtSearchWord.Text);
            ViewState["listWord"] = searchWord;
            txtSearchWordList.Text = txtSearchWord.Text;
            txtSearchWord.Text = "";
        }

    }
}