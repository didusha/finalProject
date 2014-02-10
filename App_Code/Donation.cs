using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Donation
/// </summary>
public class Donation
{
    public int id;
    public System.DateTime donate_date;
    public int donate_hour;
    public double amount;
    public string currency;
    public string payment_option;
    public int donate_type;

	public Donation()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}