using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for DbServices
/// </summary>
public class DbServices
{
    string connection = System.Configuration.ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
    SqlCommand cmd;

	public DbServices()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //nonProfit function

    internal string insertNonProfit(NonProfit nonProfit)
    {
        string identifier = "no";
        int res = -1;
        
        SqlConnection con = new SqlConnection(connection);
        cmd = new SqlCommand("sp_insertNewNonProfit", con);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@user_name" , nonProfit.user_name);
        cmd.Parameters.AddWithValue("@password " , nonProfit.password);
        cmd.Parameters.AddWithValue("@email" , nonProfit.email);
        cmd.Parameters.AddWithValue("@nonProfit_name" , nonProfit.nonProfit_name);
        cmd.Parameters.AddWithValue("@nonProfit_number" , nonProfit.nonProfit_number);
        cmd.Parameters.AddWithValue("@contact_first_name" , nonProfit.contact_first_name);
        cmd.Parameters.AddWithValue("@contact_last_name" , nonProfit.contact_last_name);
        cmd.Parameters.AddWithValue("@contact_email", nonProfit.contact_email);
       
        using (con)
        {
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                res = Convert.ToInt32(rdr["approval"]);
                if (res == 1)
                {
                    identifier = rdr["uniqueId"].ToString();
                }
            }
        }

        return identifier;
    }

    internal NonProfit approvedNonProfit(string p)
    {
        NonProfit tmp = new NonProfit();
       
        SqlConnection con = new SqlConnection(connection);
        cmd = new SqlCommand("sp_approveNewNonProfit", con);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@identifier" , p);
        using (con)
        {
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                tmp.status = Convert.ToInt32(rdr["status"]);
                if (tmp.status == 1)
                {
                    tmp.user_name = rdr["user_name"].ToString();
                    tmp.id = Convert.ToInt32(rdr["id"]);
                    // add all the attr to tmp...........
                }
            }
        }

        return tmp;
    }

    internal NonProfit loginNonProfit(NonProfit nonProfit)
    {
        
        SqlConnection con = new SqlConnection(connection);
        cmd = new SqlCommand("sp_LoginNonProfit", con);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@user_name", nonProfit.user_name);
        cmd.Parameters.AddWithValue("@password ", nonProfit.password);

        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adapt.Fill(ds);
        DataTable npTable = ds.Tables[0];

        foreach (DataRow dr in npTable.Rows)
        {
            nonProfit.status = Convert.ToInt32(dr["status"]);
            if (nonProfit.status == 1)
            {
                ds.Tables[1].TableName = "CampaignOfNonProfit";
                ds.Tables[2].TableName = "DonationForCampaign";
                ds.Tables[3].TableName = "DonationForNonProfit";

                //להוסיף את שאר השדות של העמותה

                nonProfit.nonProfit_number = dr["nonProfit_number"].ToString();
                nonProfit.goals = dr["goals"].ToString();
                nonProfit.picture = dr["picture"].ToString();
                nonProfit.logo = dr["logo"].ToString();
                nonProfit.about = dr["about"].ToString();
                nonProfit.id = Convert.ToInt32(dr["id"]);


                nonProfit.cmp = new List<Campaign>();

                foreach (DataRow dr1 in ds.Tables["CampaignOfNonProfit"].Rows)
                {
                    Campaign cmp = new Campaign();

                    cmp.campaign_donation = new List<Donation>();
                    //להוסיף את כל נתוני הקמפיין
                    cmp.id = Convert.ToInt32(dr1["cid"]);
                    cmp.name = dr1["name"].ToString();
                    cmp.money_goal = Convert.ToInt32(dr1["money_goal"]);
                    cmp.picture = dr1["picture"].ToString();
                    cmp.end_date = Convert.ToDateTime(dr1["end_date"].ToString());

                    foreach (DataRow dr2 in ds.Tables["DonationForCampaign"].Rows)
                    {
                        if (dr2["cid"].ToString() == cmp.id.ToString())
                        {
                            Donation dt = new Donation();
                            //יש להוסיף את כל נתוני התרומה
                            dt.id = Convert.ToInt32(dr2["id"]);
                            dt.amount = Convert.ToDouble(dr2["amount"]);
                            cmp.campaign_donation.Add(dt);
                            //dr2.Delete();
                        }
                    }

                    nonProfit.cmp.Add(cmp);
                }

                nonProfit.nonProfit_donation = new List<Donation>();
                foreach (DataRow dr3 in ds.Tables["DonationForNonProfit"].Rows)
                {
                    Donation dt = new Donation();
                    //יש להוסיף את כל נתוני התרומה
                    dt.id = Convert.ToInt32(dr3["id"]);
                    dt.amount = Convert.ToDouble(dr3["amount"]);
                    nonProfit.nonProfit_donation.Add(dt);
                }

            }

        }

        return nonProfit;
    }


    internal int updateNonProfitProfile(NonProfit nonProfit)
    {
        //לעדכן את הפרוצדורה במסד נתונים לפי שדות העריכה
        int res = 0;

        SqlConnection con = new SqlConnection(connection);
        cmd = new SqlCommand("sp_UpdateNonProfit", con);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@id", nonProfit.id);
        cmd.Parameters.AddWithValue("@about", nonProfit.about);
        cmd.Parameters.AddWithValue("@goals", nonProfit.goals);
        cmd.Parameters.AddWithValue("@logo", nonProfit.logo);
        cmd.Parameters.AddWithValue("@picture", nonProfit.picture);
        using (con)
        {
            con.Open();
            res = cmd.ExecuteNonQuery();
        }
        return res;
    }

    internal NonProfit getNonProfitDetailes(NonProfit nonProfit)
    {
        SqlConnection con = new SqlConnection(connection);
        cmd = new SqlCommand("sp_getNonProfitDetailes", con);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@id", nonProfit.id);
        using (con)
        {
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                //יש להשלים את הקיראהת נתונים
                nonProfit.picture = rdr["picture"].ToString();
                nonProfit.logo = rdr["logo"].ToString();
                nonProfit.about = rdr["about"].ToString();
                nonProfit.goals = rdr["goals"].ToString();
                nonProfit.user_name = rdr["user_name"].ToString();
            }
        }
        return nonProfit;
    }

    internal int insertNewCampaign(int id, Campaign c)
    {
        int res = 0;

        SqlConnection con = new SqlConnection(connection);
        cmd = new SqlCommand("sp_insertNewCampaign", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@nid", id);
        cmd.Parameters.AddWithValue("@name", c.name);
        cmd.Parameters.AddWithValue("@start_date", c.start_date.ToShortDateString());
        cmd.Parameters.AddWithValue("@end_date", c.end_date.ToShortDateString());
        cmd.Parameters.AddWithValue("@picture", c.picture);
        cmd.Parameters.AddWithValue("@video", c.video);
        cmd.Parameters.AddWithValue("@money_goal", c.money_goal);
        cmd.Parameters.AddWithValue("@view_goal", c.view_goal);
        cmd.Parameters.AddWithValue("@about", c.about);
        cmd.Parameters.AddWithValue("@thanks_message", c.thanks_message);


        using (con)
        {
            con.Open();
            try
            {
                res = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch
            {
                res = 0;
            }
            cmd.Parameters.Clear();

            if (res > 0)
            {
                //insert category
                cmd.CommandText = "sp_InsertCategoryToCampaign";
                cmd.Parameters.AddWithValue("@cid", res);
                foreach (string category in c.category)
                {
                    cmd.Parameters.AddWithValue("@campaign_category", category);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.RemoveAt("@campaign_category");
                }
                //insert crowd destination
                cmd.CommandText = "sp_InsertCrowdToCampaign";
                foreach (string destinaition in c.crowd_destination)
                {
                    cmd.Parameters.AddWithValue("@campaign_crowd", destinaition);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.RemoveAt("@campaign_crowd");
                }
                //insert search word
                cmd.CommandText = "sp_InsertCampaignSearchWord";
                foreach (string word in c.search_word)
                {
                    cmd.Parameters.AddWithValue("@word", word);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.RemoveAt("@word");
                }
            }
        }
         
        return res;
    }

    //user function
    internal string insertNewUser(User user)
    {
        string identifier = "no";
        int res = -1;

        SqlConnection con = new SqlConnection(connection);
        cmd = new SqlCommand("sp_insertNewUser", con);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@user_name", user.user_name);
        cmd.Parameters.AddWithValue("@password ", user.password);
        cmd.Parameters.AddWithValue("@first_name", user.f_name);
        cmd.Parameters.AddWithValue("@last_name", user.l_name);
        cmd.Parameters.AddWithValue("@email", user.email);

        using (con)
        {
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                res = Convert.ToInt32(rdr["approval"]);
                if (res == 1)
                {
                    identifier = rdr["uniqueId"].ToString();
                }
            }
        }

        return identifier;
    }

    internal User AprroveUser(User user)
    {
        SqlConnection con = new SqlConnection(connection);
        cmd = new SqlCommand("sp_LoginUser", con);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@user_name", user.user_name);
        cmd.Parameters.AddWithValue("@password ", user.password);

        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adapt.Fill(ds);
        ds.Tables[0].TableName = "UsersDetailes";
        DataTable usTable = ds.Tables[0];

        foreach (DataRow dr in usTable.Rows)
        {
            user.status = Convert.ToInt32(dr["status"]);
            if (user.status == 1)
            {
                //לעדכן בהמשך את הפרוצדורה שתביא עוד נתונים על המשתמש בעת רישום
                ds.Tables[1].TableName = "UserDonationForCampaign";
                ds.Tables[2].TableName = "UserDonationForNonProfit";

                //להוסיף את שאר שדות המשתמש
                user.picture = dr["picture"].ToString();
                user.phone = dr["phone"].ToString();
                user.mobile_phone = dr["mobile_phone"].ToString();
                user.id = Convert.ToInt32(dr["id"]);
                user.user_name = dr["user_name"].ToString();
            }
        }

        //user.nonProfit_donation = new List<Donation>();

        //foreach (DataRow dr1 in ds.Tables["UserDonationForCampaign"].Rows)
        //{
        //     if (dr1["uid"].ToString() == id.ToString())
        //     {
        //    Donation d=new Donation();
        //    להוסיף את כל נתוני הקמפיין
        //    d.id = Convert.ToInt32(dr1["id"]);
        //    d.donate_date =Convert.ToDateTime(dr1["donate_date"]);
        //    d.donate_hour = Convert.ToInt32(dr1["donate_hour"]);
        //    d.amount=Convert.ToDouble(dr1["amount"]);
        //     user.nonProfit_donation.Add(d);
        //     }
        //}

        //    foreach (DataRow dr2 in ds.Tables["UserDonationForNonProfit"].Rows)
        //    {
        //        if (dr2["cid"].ToString() == cmp.id.ToString())
        //        {
        //            Donation dt = new Donation();
        //            יש להוסיף את כל נתוני התרומה
        //            dt.id = Convert.ToInt32(dr2["id"]);
        //            dt.amount = Convert.ToDouble(dr2["amount"]);
        //            cmp.campaign_donation.Add(dt);
        //            dr2.Delete();
        //        }
        //    }


        //}

        //user.nonProfit_donation = new List<Donation>();
        //foreach (DataRow dr3 in ds.Tables["DonationForNonProfit"].Rows)
        //{
        //    Donation dt = new Donation();
        //    //יש להוסיף את כל נתוני התרומה
        //    dt.id = Convert.ToInt32(dr3["id"]);
        //    dt.amount = Convert.ToDouble(dr3["amount"]);
        //    user.nonProfit_donation.Add(dt);
        //}

        //}
        return user;
    }

    internal User AprroveUser(string p)
    {
        User tmp = new User();

        SqlConnection con = new SqlConnection(connection);
        cmd = new SqlCommand("sp_approveNewUser", con);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@identifier", p);
        using (con)
        {
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                tmp.status = Convert.ToInt32(rdr["status"]);
                if (tmp.status == 1)
                {
                    tmp.user_name = rdr["user_name"].ToString();
                    tmp.id = Convert.ToInt32(rdr["id"]);
                    // add all the attr to tmp...........
                }
            }
        }

        return tmp;
    }

    internal User getUserDetailes(User user)
    {
        SqlConnection con = new SqlConnection(connection);
        cmd = new SqlCommand("sp_getUserDetailes", con);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@id", user.id);
        using (con)
        {
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                //יש להשלים את הקיראהת נתונים
                user.picture = rdr["picture"].ToString();
                user.birth_date = rdr["birth_date"].ToString();
                user.gender = rdr["gender"].ToString();
                user.f_name = rdr["first_name"].ToString();
                user.l_name = rdr["last_name"].ToString();
                user.gender = rdr["gender"].ToString();
                user.user_name = rdr["user_name"].ToString();
            }
        }
        return user;
    }

    internal int updateUserProfile(User user)
    {
        //לעדכן את הפרוצדורה במסד נתונים לפי שדות העריכה
        int res = 0;

        SqlConnection con = new SqlConnection(connection);
        cmd = new SqlCommand("sp_UpdateUser", con);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@id", user.id);
        cmd.Parameters.AddWithValue("@phone", user.phone);
        cmd.Parameters.AddWithValue("@mobile_phone", user.mobile_phone);
        cmd.Parameters.AddWithValue("@gender", user.gender);
        cmd.Parameters.AddWithValue("@birth_date", user.birth_date);
        cmd.Parameters.AddWithValue("@picture", user.picture);
        using (con)
        {
            con.Open();
            res = cmd.ExecuteNonQuery();
        }
        return res;
    }

    //company function

    internal string insertCompany(Company company)
    {
        string identifier = "no";
        int res = -1;

        SqlConnection con = new SqlConnection(connection);
        cmd = new SqlCommand("sp_insertNewCompany", con);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@user_name", company.user_name);
        cmd.Parameters.AddWithValue("@password ", company.password);
        cmd.Parameters.AddWithValue("@email", company.email);
        cmd.Parameters.AddWithValue("@company_name", company.company_name);
        cmd.Parameters.AddWithValue("@company_number", company.company_number);
        cmd.Parameters.AddWithValue("@contact_first_name", company.contact_first_name);
        cmd.Parameters.AddWithValue("@contact_last_name", company.contact_last_name);
        cmd.Parameters.AddWithValue("@contact_email", company.contact_email);

        using (con)
        {
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                res = Convert.ToInt32(rdr["approval"]);
                if (res == 1)
                {
                    identifier = rdr["uniqueId"].ToString();
                }
            }
        }

        return identifier;
    }

    internal Company companyApproved(string c)
    {
        Company tmp = new Company();

        SqlConnection con = new SqlConnection(connection);
        cmd = new SqlCommand("sp_approveNewCompany", con);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@idetifier", c);
        using (con)
        {
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                tmp.status = Convert.ToInt32(rdr["status"]);
                if (tmp.status == 1)
                {
                    tmp.user_name = rdr["user_name"].ToString();
                    tmp.id = Convert.ToInt32(rdr["id"]);
                    // add all the attr to company...........
                }
            }
        }

        return tmp;
    }

    internal Company companyApproved(Company company)
    {
        SqlConnection con = new SqlConnection(connection);
        cmd = new SqlCommand("sp_LoginCompany", con);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@user_name", company.user_name);
        cmd.Parameters.AddWithValue("@password ", company.password);

        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adapt.Fill(ds);
        DataTable npTable = ds.Tables[0];

        foreach (DataRow dr in npTable.Rows)
        {
            company.status = Convert.ToInt32(dr["status"]);
            if (company.status == 1)
            {

                //להוסיף את שאר השדות של החברה

                company.company_number = Convert.ToInt32(dr["company_number"]);
                company.goals = dr["goals"].ToString();
                company.picture = dr["picture"].ToString();
                company.logo = dr["logo"].ToString();
                company.id = Convert.ToInt32(dr["id"]);

            }

        }

        return company;
    }

    internal int updateCompanyProfile(Company company)
    {
        //לעדכן את הפרוצדורה במסד נתונים לפי שדות העריכה
        int res = 0;

        SqlConnection con = new SqlConnection(connection);
        cmd = new SqlCommand("sp_UpdateCompany", con);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@id", company.id);
        cmd.Parameters.AddWithValue("@about", company.about);
        cmd.Parameters.AddWithValue("@goals", company.goals);
        cmd.Parameters.AddWithValue("@logo", company.logo);
        cmd.Parameters.AddWithValue("@picture", company.picture);
        using (con)
        {
            con.Open();
            res = cmd.ExecuteNonQuery();
        }
        return res;
    }

    internal Company getCompanyDetailes(Company company)
    {
        SqlConnection con = new SqlConnection(connection);
        cmd = new SqlCommand("sp_getCompanyDetailes", con);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@id", company.id);
        using (con)
        {
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                //יש להשלים את קיראת נתונים
                company.picture = rdr["picture"].ToString();
                company.logo = rdr["logo"].ToString();
                company.about = rdr["about"].ToString();
                company.goals = rdr["goals"].ToString();
                company.user_name = rdr["user_name"].ToString();
            }
        }
        return company;
    }
}

