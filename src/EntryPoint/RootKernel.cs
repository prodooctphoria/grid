using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Caliburn.Micro;
using Ninject;
using Ninject.Modules;

namespace PPhoria.Grid.EntryPoint
{
    public sealed class RootKernel : IDisposable
    {
        private RootKernel()
        {
            Kernel = new StandardKernel();
        }

        public static RootKernel Instance => Nested.NestedInstance;

        private class Nested
        {
            static Nested()
            {
            }

            internal static readonly RootKernel NestedInstance = new RootKernel();
        }

        private IKernel Kernel { get; }

        private static bool CheckType(Type refType, Type compType)
        {
            return refType.IsAssignableFrom(compType) && refType != compType && !compType.IsAbstract &&
                   !compType.IsInterface && compType.IsClass;
        }

        private static bool HasEmptyConstructor(Type type)
        {
            var constructor = type.GetConstructor(new Type[0]);
            return constructor != null;
        }


        private static IDictionary<Type, IList<Type>> GetAssemblyTypesThatMatch(Type[] lookUpTypes)
        {
            var result =
                lookUpTypes.ToDictionary<Type, Type, IList<Type>>(lookUpType => lookUpType,
                    lookUpType => new List<Type>());

            foreach (var assmbType in AppDomain.CurrentDomain.GetAssemblies().SelectMany(asmb => asmb.GetTypes()))
            foreach (var lookUpType in lookUpTypes)
            {
                if (!CheckType(lookUpType, assmbType)) continue;
                if (HasEmptyConstructor(assmbType)) result[lookUpType].Add(assmbType);
            }

            return result;
        }

        private static IList<T> ActivateList<T>(IEnumerable<Type> types)
        {
            return types
                .Select(type => (T) Activator.CreateInstance(type))
                .ToList();
        }


        public void Configure(Cli.BaseOptions options)
        {
            Kernel.Bind<Cli.BaseOptions>().ToConstant(options).InSingletonScope();
            Kernel.Bind<Application>().ToProvider<ApplicationProvider>().InSingletonScope();
            Kernel.Bind<ApplicationProvider>().ToSelf();
            Kernel.Bind<BootstrapperBase>().To<Bootstrapper>().InSingletonScope();


            var assemblies = GetAssemblyTypesThatMatch(new[]
            {
                typeof(IInjectionModuleFlag)
            });

            Kernel.Load(ActivateList<INinjectModule>(assemblies[typeof(IInjectionModuleFlag)]));
        }

        public object GetInstance(Type service, string key)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service));
            return Kernel.Get(service);
        }

        public IEnumerable<object> GetAllInstances(Type service)
        {
            return Kernel.GetAll(service);
        }

        public void BuildUp(object instance)
        {
            Kernel.Inject(instance);
        }

        public T Get<T>()
        {
            return (T) GetInstance(typeof(T), null);
        }


        public void Dispose()
        {
            Kernel.Dispose();
        }
    }
}