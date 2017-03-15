using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Memberships.Startup))]
namespace Memberships
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
