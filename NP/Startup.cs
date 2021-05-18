using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NP.Startup))]
namespace NP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
