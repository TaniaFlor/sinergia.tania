using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(vista.inventario.Startup))]
namespace vista.inventario
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
