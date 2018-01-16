using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoodFood.Startup))]
namespace GoodFood
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
