using System;
using System.Windows;
using Ninject;
using Ninject.Activation;
using Ninject.Syntax;

namespace PPhoria.Grid.EntryPoint
{
    public sealed class ApplicationProvider : Provider<Application>
    {
        private readonly Lazy<Application> _value;

        public ApplicationProvider(IResolutionRoot kernel)
        {
            _value = new Lazy<Application>(() =>
            {
                var app = new App(
                    kernel.Get<IOnApplicationStartup>(),
                    kernel.Get<IOnApplicationExit>()
                );
                app.InitializeComponent();
                kernel.Get<IApplicationConfigurator>().Configure(app);
                return app;
            });
        }

        protected override Application CreateInstance(IContext context)
        {
            return _value.Value;
        }
    }
}