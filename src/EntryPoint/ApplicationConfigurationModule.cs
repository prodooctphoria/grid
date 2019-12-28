using Ninject.Modules;

namespace PPhoria.Grid.EntryPoint
{
    public sealed class ApplicationConfigurationModule : NinjectModule, IInjectionModuleFlag
    {
        public override void Load()
        {
            Bind<IApplicationConfigurator>().To<ApplicationConfigurator>().InSingletonScope();
            Bind<IOnApplicationStartup>().To<OnApplicationStartup>().InSingletonScope();
            Bind<IOnApplicationExit>().To<OnApplicationExit>().InSingletonScope();
        }
    }
}