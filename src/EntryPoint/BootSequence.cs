using System;
using System.Windows;
using Ninject;

namespace PPhoria.Grid.EntryPoint
{
    public sealed class BootSequence : IBootSequence
    {
        private readonly Cli.BaseOptions _options;
        // private IMarshalledWindowManager _marshalledWindowManager;
        // private IWindowManager _windowManager;


        public BootSequence(Cli.BaseOptions options)
        {
            _options = options;
        }


        public void Init()
        {
            // var viewModel = _kernel.Get<IStartUpShellViewModel>();
            // _marshalledWindowManager.ShowWindow(viewModel);
        }

        // [Inject]
        // public void BuildUp(IKernel kernel)
        // {
        //     // _windowManager = windowManager;
        //     // _marshalledWindowManager = marshalledWindowManager;
        //     // _marshalledWindowManager.LastWindowClosed += MarshalledWindowManagerOnLastWindowClosed;
        // }

        // [Inject]
        // public void BuildUp(IKernel kernel, IWindowManager windowManager,
        //     IMarshalledWindowManager marshalledWindowManager)
        // {
        //     _kernel = kernel;
        //     _windowManager = windowManager;
        //     _marshalledWindowManager = marshalledWindowManager;
        //     _marshalledWindowManager.LastWindowClosed += MarshalledWindowManagerOnLastWindowClosed;
        // }

        private void MarshalledWindowManagerOnLastWindowClosed(object sender, EventArgs eventArgs)
        {
            //ToDo: Add a confirmation dialog
            Application.Current.Shutdown();
        }
    }
}