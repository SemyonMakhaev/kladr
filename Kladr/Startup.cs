using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kladr.Startup))]
namespace Kladr
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
