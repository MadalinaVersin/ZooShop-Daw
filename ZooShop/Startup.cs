using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZooShop.Startup))]
namespace ZooShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
