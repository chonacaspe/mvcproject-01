using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(chnprjct.Startup))]
namespace chnprjct
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
