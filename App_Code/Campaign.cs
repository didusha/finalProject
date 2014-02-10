using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for Campaign
/// </summary>
public class Campaign
{
    //attributes
    #region
    public int status;
    public int id;
    public System.DateTime start_date;
    public System.DateTime end_date;
    public string name;
    public string picture;
    public string video;
    public int money_goal;
    public float money_raise;
    public int view_goal;
    public int view_active;
    public string thanks_message;
    public List<Donation> campaign_donation;
    public string about;
    public List<string> campaign_pictures;
    public List<string> category;
    public List<string> crowd_destination;
    public List<string> search_word;
    #endregion

    public Campaign()
	{
		//
		// TODO: Add constructor logic here
		//
	}

}