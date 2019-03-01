using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Imdb.App.Startup))]
namespace Imdb.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
