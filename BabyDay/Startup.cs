using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartupAttribute(typeof(BabyDay.Startup))]
namespace BabyDay
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            InitializeDIContainer(app);
            ConfigureAuth(app);            
        }
    }
}