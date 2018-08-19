using Owin;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(TestSignalR.Startup))]
namespace TestSignalR
{
//Sert à démarrer SignalR avant tout
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}