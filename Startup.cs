using Microsoft.Owin;
using Orion.Mapping;
using Owin;

[assembly: OwinStartupAttribute(typeof(Orion.Startup))]
namespace Orion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            MappingProfileRegistry.Configure();
        }
    }
}
