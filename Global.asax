<%@ Application Language="C#" %>
<%@ Import Namespace="System.Data" %>


<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

    void Application_AuthenticateRequest(Object sender, EventArgs e)
    {
        if (Request.IsAuthenticated) // find all roles for this user
        {
            // Extract the forms authentication cookie
            string cookieName = FormsAuthentication.FormsCookieName;
            HttpCookie authCookie = Context.Request.Cookies[cookieName];
            if (null == authCookie)
            {
                return;  // There is no authentication cookie.

            }
            FormsAuthenticationTicket authTicket = null;
            try
            {
                authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            }
            catch (Exception ex)
            {
                return;  // Log exception details (omitted for simplicity)

            }
            if (null == authTicket)
                return;  // Cookie failed to decrypt.

            // When the ticket was created, the UserData property was assigned
            // a pipe delimited string of role names.
            // Dim roles As String() = authTicket.UserData.Split(";"c)
            string roles = authTicket.UserData;
            string[] roleListArray = roles.Split(new char[] { '|' });
            // Add the roles obtained above to the User Principal
            HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(User.Identity, roleListArray);

            /*  -- old technique where instead of using the
             * pipe delimited info from UserData, database was
             * queried on each hit of Application_AuthenticationRequest
            string connStr = ConfigurationManager.ConnectionStrings["XYZEVEDSN"].ConnectionString;
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connStr);
            conn.Open();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("GetUserRoles", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Username", User.Identity.Name));
            System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();

            // get the array of user roles

            ArrayList roleList = new ArrayList();
            while (reader.Read())
                roleList.Add(reader["Role"]);
            conn.Close();

            // Convert the roleList ArrayList to a String array
            int i = 0;
            string[] roleListArray = new string[roleList.Count];
            // Attach the new principal object to the current HttpContext object
            HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(User.Identity, roleListArray);
            */

        }
    }
 
       
</script>
