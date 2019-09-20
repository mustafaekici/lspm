using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Shared.Core.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Threading;
using AutofacModule = Autofac.Module;

namespace Shared.Core.DI
{
    public sealed class IoC : IDisposable
    {
        static private volatile IoC _instance;
        static private readonly object SyncRoot = new object();
        static private bool _lockWasTaken;
        private IContainer _container;

        private IEnumerable<Type> GetAllTypesOf<T>(Func<Type, bool> predicate = null, Func<AssemblyName, bool> predicateAsm = null)
        {
            var platform = Environment.OSVersion.Platform.ToString();
            var runtimeAssemblyNames = DependencyContext.Default.GetRuntimeAssemblyNames(platform);

            return runtimeAssemblyNames
                .WhereEmptyIfNull(predicateAsm)
                .Select(Assembly.Load)
                .SelectMany(a => a.GetTypes())
                .WhereEmptyIfNull(predicate)
                .Where(t => typeof(T).IsAssignableFrom(t));
        }


        private void RegisterAutofacModules(ContainerBuilder builder)
        {
            var autofacModules = AppDomain.CurrentDomain.GetAssemblies()
                .Where(w => w.FullName.StartsWith("LS."))
                .SelectMany(a => a.ExportedTypes.Where(t => typeof(IModule).IsAssignableFrom(t) && !t.IsAbstract))
                .ToArray()
                .Distinct()
                .Select(w => Activator.CreateInstance(w))
                .Cast<IModule>();
            foreach (IModule afModule in autofacModules)
            {
                builder.RegisterModule(afModule);
            }
        }

        public static IoC Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;

                Monitor.TryEnter(SyncRoot, 5000, ref _lockWasTaken);
                try
                {
                    IoC temp = new IoC();
                    Interlocked.Exchange(ref _instance, temp);
                }
                finally
                {
                    if (_lockWasTaken)
                    {
                        Monitor.Exit(SyncRoot);
                    }
                }
                return _instance;
            }
        }

        public void BuildContainer(IServiceCollection services)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);

            RegisterAutofacModules(containerBuilder);
            _container = containerBuilder.Build();
        }

        public IServiceProvider BuildContainerAsServiceProvider(IServiceCollection services)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);

            RegisterAutofacModules(containerBuilder);
            _container = containerBuilder.Build();
            return new AutofacServiceProvider(_container);
        }

        public T ResolveDefNull<T>()
        {
            T instance;
            _container.TryResolve<T>(out instance);
            return instance;
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public IEnumerable<T> ResolveAll<T>(object obj = null)
        {
            return _container.Resolve<IEnumerable<T>>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #region IDisposable Support
        private bool _disposedValue = false;

        void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _container?.Dispose();
                }
                _disposedValue = true;
            }
        }
        #endregion
    }
}
