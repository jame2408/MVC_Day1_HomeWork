using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyAccountingBook.Startup))]
namespace MyAccountingBook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
