using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;


/// <summary>
/// Summary description for Productservice
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService] 
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Productservice : System.Web.Services.WebService {
    IDataAccount ida = GenericFactory<BusinessLayer, IDataAccount>.CreateInstance();

    public Productservice () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    [WebMethod]
    public string UpdatePrice(string pid, string pwd)
    {
        string ret = "";
        if (pwd == "admin100")
        {
            int id = int.Parse(pid);
            int rows = ida.DeleteNonQueryDBFromProducts(id);
            if (rows > 0)
            {
                ret = "Products delete successfully";
            }
            else
            {
                ret = "This product is not exist.";
            }
        }
        else
        {
            ret = "PW is invalid..";
        }
        return ret;
    }
    
}
