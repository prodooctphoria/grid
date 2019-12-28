using System.Windows;

namespace PPhoria.Grid.EntryPoint
{
    public sealed class OnApplicationStartup : IOnApplicationStartup
    {
        private readonly Cli.BaseOptions _options;

        public OnApplicationStartup(Cli.BaseOptions options)
        {
            _options = options;
        }

        public void Run(object sender, StartupEventArgs e)
        {
        }
    }
}