using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SafeHikerWebsite.Startup))]
namespace SafeHikerWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
