using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExoIdentityExtend.Startup))]
namespace ExoIdentityExtend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
