using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BPU_Project.Startup))]
namespace BPU_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
