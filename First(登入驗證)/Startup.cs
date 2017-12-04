using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(First_登入驗證_.Startup))]
namespace First_登入驗證_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
