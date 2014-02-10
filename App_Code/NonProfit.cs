using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class NonProfit
{
    //attributes
    #region

    public List<Donation> nonProfit_donation;
    public List<Campaign> cmp;
    public int status;
    public int id;
	public string user_name;
	public string password; 
	public string email;
	public DateTime registration_date;
	public string mobile_phone;
	public string phone;
	public DateTime last_seen_date;
	public int last_seen_hour;
    public string nonProfit_name;
    public string logo;
    public string picture;
    public string official_video;
    public string nonProfit_number;
    public string about;
    public string goals;
    public string vision;
    public int foundation_year;
    public string link;
    public string contact_first_name;
    public string contact_last_name;
    public string contact_gender;
    public string contact_mobile_phone;
    public string contact_phone;
    public string contact_email;
    public string contact_role;
    public string thanks_message;

#endregion 

	public NonProfit()
	{

	}

    public NonProfit(string username, string mail, string pass, string contact_fname,
        string contact_mail, string contact_lname, string nonprofit_num, string nonprofit_name)
    {
         user_name = username;
         password = pass;
         email = mail;
         nonProfit_name = nonprofit_name;
         nonProfit_number = nonprofit_num;
         contact_first_name = contact_fname;
         contact_last_name = contact_lname;
         contact_email = contact_mail;
    }

    public string insert()
    {
        DbServices p = new DbServices();
        return p.insertNonProfit(this);
    }

    public NonProfit approved(string p)
    {
        DbServices db = new DbServices();
        return db.approvedNonProfit(p);
    }

    public NonProfit login()
    {
        DbServices db = new DbServices();
        return db.loginNonProfit(this);
    }

    public int updateProfile()
    {
        DbServices db = new DbServices();
        return db.updateNonProfitProfile(this);
    }

    public NonProfit getDetailes()
    {
        DbServices db = new DbServices();
        return db.getNonProfitDetailes(this);
    }

    public int insertNewCampaign(Campaign c)
    {
        DbServices db = new DbServices();
        return db.insertNewCampaign(this.id, c);
    }
}