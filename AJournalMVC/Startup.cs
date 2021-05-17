using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AJournalMVC.Startup))]
namespace AJournalMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
