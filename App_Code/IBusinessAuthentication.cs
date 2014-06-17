using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IAuthentication
/// </summary>
public interface IBusinessAuthentication
{
    string CheckUser(string uid, string pwd);
    string GetRolesForUser(string uname);

}