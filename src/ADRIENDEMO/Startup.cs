using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ADRIENDEMO.Startup))]
namespace ADRIENDEMO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
