using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AWNegocioBanco.Startup))]
namespace AWNegocioBanco
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
