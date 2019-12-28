using System.Windows;

namespace PPhoria.Grid.EntryPoint
{
    public interface IOnApplicationExit
    {
        void Run(object sender, ExitEventArgs e);
    }
}