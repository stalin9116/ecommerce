using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ecommerce.MVC.Startup))]
namespace ecommerce.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
