using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Company
/// </summary>
public class Company
{
    //attrubutes
    #region
    public int id;
    public string user_name;
    public string password;
    public string email;
    public DateTime registration_date;
    public string mobile_phone;
    public string phone;
    public DateTime last_seen_date;
    public int last_seen_hour;
    public string company_name;
    public string logo;
    public string picture;
    public string official_video;
    public int company_number;
    public string about;
    public string goals;
    public string contact_first_name;
    public string contact_last_name;
    public string contact_gendre;
    public string contact_mobile_phone;
    public string contact_phone;
    public string contact_email;
    public string contact_role;
    public int status;
    #endregion

    public Company()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Company(string username, string mail, string pass, string contact_fname,
        string contact_mail, string contact_lname, int Company_num, string Company_name)
    {
        user_name = username;
        password = pass;
        email = mail;
        company_name = Company_name;
        company_number = Company_num;
        contact_first_name = contact_fname;
        contact_last_name = contact_lname;
        contact_email = contact_mail;
    }

    public string insertCompany()
    {
        DbServices p = new DbServices();
        return p.insertCompany(this);
    }

    public Company companyApproved(string c)
    {
        DbServices db = new DbServices();
        return db.companyApproved(c);
    }

    public Company companyLogin()
    {
        DbServices db = new DbServices();
        return db.companyApproved(this);
    }

    public int updateCompanyProfile()
    {
        DbServices db = new DbServices();
        return db.updateCompanyProfile(this);
    }

    public Company getCompanyDetailes()
    {
        DbServices db = new DbServices();
        return db.getCompanyDetailes(this);
    }

}