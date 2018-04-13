using System;
using System.Web;

namespace Sitecore.Login.External
{
    public partial class LoginExternal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string claims = Request.QueryString["username"];

            if (string.IsNullOrEmpty(claims))
            {
                return;
            }

            string domainUser = claims;


            if (!Sitecore.Security.Accounts.User.Exists(domainUser))
            {
                Sitecore.Security.Accounts.User user = Sitecore.Security.Accounts.User.Create(domainUser, "b");

                Sitecore.Security.UserProfile userProfile = user.Profile;
                userProfile.FullName = string.Format("{0} {1}", domainUser, "");
                userProfile.IsAdministrator = true;
                userProfile.Save();
            }

            if (AuthenticateUser(domainUser, "b"))
            {
                Sitecore.Security.Authentication.AuthenticationManager.Login(domainUser, false, true);
                Response.Redirect(HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host + "/sitecore/client/Applications/Launchpad?sc_lang=en");
            }

        }

        public static bool AuthenticateUser(string username, string password)
        {
            bool isAuthenticated = false;
            try
            {
                if (Sitecore.Security.Accounts.User.Exists(username))
                {
                    isAuthenticated = Sitecore.Security.Authentication.AuthenticationManager.Login(username, password, true);
                }
            }
            catch (Exception)
            {
                isAuthenticated = false;
            }
            return isAuthenticated;
        }

    }
}