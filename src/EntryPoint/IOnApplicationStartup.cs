using System.Windows;

namespace PPhoria.Grid.EntryPoint
{
    public interface IOnApplicationStartup
    {
        void Run(object sender, StartupEventArgs e);
    }
}