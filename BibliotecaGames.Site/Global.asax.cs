﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace BibliotecaGames.Site
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        { }
            protected void Session_Start(object sender, EventArgs e)
            {
                if (HttpContext.Current.Request.IsAuthenticated)
                {
                    FormsAuthentication.SignOut();
                    FormsAuthentication.RedirectToLoginPage();
                    HttpContext.Current.Response.End();
                }
            }
        }
    
}