using Topshelf;

namespace GPermission.MessageBroker
{
    class Program
    {
        static void Main(string[] args)
        {
            
            HostFactory.Run(x =>
            {
                x.Service<Bootstrap>(s =>
                {
                    s.ConstructUsing(name => new Bootstrap());
                    s.WhenStarted(bs =>
                    {
                        bs.Initialize();
                        bs.Start();
                    });
                    s.WhenStopped(bs => bs.Stop());
                });
                x.RunAsLocalSystem();
                x.SetDescription("GPermission Host");
                x.SetDisplayName("GPermissionBroker");
                x.SetServiceName("GPermissionBroker");
            });                                      
        }
    }
}
