using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using NLog;
using PriceListEditor.Events;
using PriceListEditor.Interfaces;
using PriceListEditor.Interfaces.ViewModels;
using PriceListEditor.Interfaces.Views;
using PriceListEditor.Model;
using PriceListEditor.Properties;
using PriceListEditor.Utilities;
using PriceListEditor.ViewModels;
using PriceListEditor.Views;
using Prism.Events;
using Prism.Unity;
using AssemblyResources = PriceListEditor.Utilities.Properties.Resources;

namespace PriceListEditor
{
    internal class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return this.Container.Resolve<MainWindowView>();
        }

        protected async override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
            IEventAggregator eventAggregator = Container.Resolve<IEventAggregator>();

            try
            {
                foreach (String modulePath in Settings.Default.PluginModules)
                {
                    Assembly loadedModule = Assembly.LoadFile(modulePath);
                    List<ILoadableModule> loadedModules = await InvokeLoadableModules(loadedModule);

                    // Synchronise access to the loaded modules list.
                    lock(Utility.LoadedModules)
                    {
                        Utility.LoadedModules.AddRange(loadedModules);
                    }
                }
            }
            catch (OperationCanceledException ex)
            {
                Utilities.Utility.EventLogger.Log
                (
                    LogLevel.Info, 
                    ex
                );
            }

            // Let the main window know that it must load the modules.
            //Thread.Sleep(1000);
            eventAggregator.GetEvent<DisplayLoadedModulesEvent>().Publish();
        }

        /// <summary>
        ///     Searches in the assembly for objects that implement the <see cref="ILoadableModule"/> interface and instantiates them.
        /// </summary>
        /// <param name="loadedModule">
        ///     Object that points to an assembly that was loaded.
        /// </param>
        private Task<List<ILoadableModule>> InvokeLoadableModules(Assembly loadedModule)
        {
            return Task.Run
            ( 
                () => 
                { 
                    List<ILoadableModule> result = new List<ILoadableModule>();
                    foreach (TypeInfo definedType in loadedModule.DefinedTypes)
                    {
                        foreach (TypeInfo implementedInterface in definedType.ImplementedInterfaces)
                        {
                            if (implementedInterface == typeof(ILoadableModule))
                            {
                                try
                                {
                                    ILoadableModule module = Activator.CreateInstance(definedType) as ILoadableModule;
                                    module.InitialiseModule(this.Container);
                                    result.Add(module);
                                }
                                catch (Exception ex)
                                {
                                    Utilities.Utility.EventLogger.Log
                                    (
                                        LogLevel.Error, 
                                        ex, 
                                        () => String.Format(AssemblyResources.ModuleLoadingFailed, definedType.Name)
                                    );
                                }
                            }
                        }
                    }

                    return result; 
                },
                Utility.ModuleLoadCancellationToken.Token
            );
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            // Register the data store
            this.Container.RegisterType<IDataStore, DataStore>(new ContainerControlledLifetimeManager());

            RegisterViews();
            RegisterViewModels();
        }

        private void RegisterViews()
        {
            this.Container.RegisterType<IMainWindowView, MainWindowView>(new ContainerControlledLifetimeManager());
        }

        private void RegisterViewModels()
        {
            this.Container.RegisterType<IMainWindowViewModel, MainWindowViewModel>(new ContainerControlledLifetimeManager());
        }
    } // class Bootstrapper
} // namespace PriceListEditor
