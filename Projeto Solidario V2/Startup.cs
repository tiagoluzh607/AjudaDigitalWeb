using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Projeto_Solidario_V2.Startup))]
namespace Projeto_Solidario_V2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
