using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LeMoulinDaCote.Startup))]
namespace LeMoulinDaCote
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
