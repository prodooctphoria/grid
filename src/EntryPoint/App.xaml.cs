using System.Windows;

namespace PPhoria.Grid.EntryPoint
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private readonly IOnApplicationStartup _onStartup;
        private readonly IOnApplicationExit _onExit;

        public App(IOnApplicationStartup onStartup, IOnApplicationExit onExit)
        {
            _onStartup = onStartup;
            _onExit = onExit;
            Startup += OnStartup;
            Exit += OnExit;
        }

        private void OnExit(object sender, ExitEventArgs e)
        {
            _onExit.Run(sender, e);
        }

        ~App()
        {
            Startup -= OnStartup;
            Exit -= OnExit;
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            _onStartup.Run(sender, e);
        }
    }
}