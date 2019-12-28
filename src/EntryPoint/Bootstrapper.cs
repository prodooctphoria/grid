using System;
using System.Collections.Generic;
using System.Windows;
using Caliburn.Micro;

namespace PPhoria.Grid.EntryPoint
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override object GetInstance(Type service, string key)
        {
            return RootKernel.Instance.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return RootKernel.Instance.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            RootKernel.Instance.BuildUp(instance);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            base.OnStartup(sender, e);
            IoC.Get<IBootSequence>().Init();
        }

        protected override void OnExit(object sender, EventArgs e)
        {
            base.OnExit(sender, e);
            RootKernel.Instance.Dispose();
        }
    }
}