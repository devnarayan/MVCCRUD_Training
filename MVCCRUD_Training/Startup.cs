using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCCRUD_Training.Startup))]
namespace MVCCRUD_Training
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
