using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LemonMember.Startup))]
namespace LemonMember
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
