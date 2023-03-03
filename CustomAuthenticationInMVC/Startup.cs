using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomAuthenticationInMVC.Startup))]
namespace CustomAuthenticationInMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
