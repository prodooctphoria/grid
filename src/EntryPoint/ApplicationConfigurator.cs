using System.Windows;

namespace PPhoria.Grid.EntryPoint
{
    public sealed class ApplicationConfigurator : IApplicationConfigurator
    {
        public void Configure(Application application)
        {
            application.ShutdownMode = ShutdownMode.OnExplicitShutdown;
        }
    }
}