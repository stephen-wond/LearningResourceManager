using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AuthLoginTutorial.Startup))]
namespace AuthLoginTutorial
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
