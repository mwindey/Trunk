using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Definco.Migrations;
using Definco.Models;
using SimpleMembershipExample;
using WebMatrix.WebData;

namespace Definco
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DefincoDbContext, Configuration>());
            new DefincoDbContext().UserProfiles.Find(1);

            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);

        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
    {
        if (User != null && User.Identity.IsAuthenticated && Roles.Enabled)
        {
            // get userId
            DefincoDbContext ctx = new DefincoDbContext();
            UserProfile loggedInUser = ctx.UserProfiles.FirstOrDefault(x => x.UserName == User.Identity.Name);

            if (loggedInUser != null)
            {
                // store on context
                Context.Items.Add("LoggedInUser", loggedInUser);
            }

            //here we can subscribe user to a role via Roles.AddUserToRole()
        }       
    }
    }
}