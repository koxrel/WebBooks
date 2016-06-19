using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebBooks.Startup))]
namespace WebBooks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
