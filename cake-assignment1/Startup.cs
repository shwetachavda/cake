using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(cake_assignment1.Startup))]
namespace cake_assignment1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
