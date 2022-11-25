using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RiaChristoforidouBlog.Startup))]
namespace RiaChristoforidouBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
