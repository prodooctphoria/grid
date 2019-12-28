using Caliburn.Micro;
using Ninject.Modules;

namespace PPhoria.Grid.EntryPoint
{
    public sealed class BootInjectionModule : NinjectModule, IInjectionModuleFlag
    {
        public override void Load()
        {

            // Bind<IWindowFactory>().ToProvider<WindowFactoryProvider>().InSingletonScope();
            // Bind<WindowFactoryProvider>().ToSelf();

            // Bind<IMarshalledWindowManager>().To<WindowManager>();

            Bind<IWindowManager>().To<WindowManager>().InSingletonScope();

            Bind<IBootSequence>().To<BootSequence>().InSingletonScope();
            // Bind<BootSequenceProvider>().ToSelf();
        }
    }
}