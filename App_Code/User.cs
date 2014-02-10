using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{
    //attributes
    #region
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
    public string f_name;
    public string l_name;
    public string gender;
    public string picture;
    public string birth_date;
    public int impact_points;
    public int total_shares;
    public int total_volunteer;
    public double total_money_raise;
    public int total_invitiation_accepted;
    public int total_invitation_send;
    public List<Donation> nonProfit_donation;
    public List<Donation> campaign_donation;
    // public List<Campaign> cmp;
    #endregion

    public User()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public User(string fname, string lname, string pass, string mail, string username)
    {
        // TODO: Complete member initialization
        user_name = username;
        password = pass;
        f_name = fname;
        l_name = lname;
        email = mail;
    }



    public string insert()
    {
        DbServices db = new DbServices();
        return db.insertNewUser(this);
    }

    public User login()
    {
        DbServices db = new DbServices();
        return db.AprroveUser(this);
    }

    public User approved(string p)
    {
        DbServices db = new DbServices();
        return db.AprroveUser(p);
    }

    public User getDetailes()
    {
        DbServices db = new DbServices();
        return db.getUserDetailes(this);
    }

    public int updateProfile()
    {
        DbServices db = new DbServices();
        return db.updateUserProfile(this);
    }
}