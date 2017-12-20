using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SeniorDating.Startup))]
namespace SeniorDating
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
