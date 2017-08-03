using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;

namespace BabyDay
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {            
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                CookieHttpOnly = true,
                ExpireTimeSpan = TimeSpan.FromMinutes(60),
                SlidingExpiration = true,
                CookieSecure = CookieSecureOption.SameAsRequest,
                LoginPath = new PathString("/Account/Login")
            });
        }
    }
}