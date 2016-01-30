using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SafeHiker.Startup))]
namespace SafeHiker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
