using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Utils
/// </summary>
public class Utils
{
	public Utils()
	{
	}

    public static string StripPunctuation(string inp)
    {
        string inp2 = inp.Replace("'", "''");
        inp2 = inp2.Replace(";", "");
        inp2 = inp2.Replace("-", "");
        inp2 = inp2.Replace("%", "");
        inp2 = inp2.Replace("*", "");
        return inp2;
    }
}
