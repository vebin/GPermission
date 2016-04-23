using Topshelf;

namespace GPermission.ProcessorHost
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
                x.SetDescription("GPermission Service Host");
                x.SetDisplayName("GPermissionService");
                x.SetServiceName("GPermissionService");
            });
        }
    }
}
