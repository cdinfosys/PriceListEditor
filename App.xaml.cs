using System;
using System.Windows;
using NLog;
using PriceListEditor.Interfaces;
using PriceListEditor.Utilities;

namespace PriceListEditor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        ///     Program entry point.
        /// </summary>
        /// <param name="eventArgs"></param>
        protected override void OnStartup(StartupEventArgs eventArgs)
        {
            //PriceListService.PriceListServiceClient client1 = new PriceListService.PriceListServiceClient();
            //PriceListService.CompositeType ct = new PriceListService.CompositeType();
            //var a = client1.GetSupplierDetail();

            try
            {
                base.OnStartup(eventArgs);
                Bootstrapper bootstrapper = new Bootstrapper();
                bootstrapper.Run();
            }
            catch (Exception ex)
            {
                Utilities.Utility.EventLogger.Log(LogLevel.Error, ex);
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            try
            {
                Utility.ModuleLoadCancellationToken.Cancel();

                // Synchronise access to the loaded modules list while we destroy it.
                lock(Utility.LoadedModules)
                {
                    for (Int32 moduleIndex = (Utility.LoadedModules.Count - 1); moduleIndex >= 0; --moduleIndex)
                    {
                        try
                        {
                            // Tell each module that the program is closing
                            Utility.LoadedModules[moduleIndex].ProgramClosing();
                        }
                        catch (Exception ex)
                        {
                            Utility.EventLogger.Log(LogLevel.Error, ex);
                        }

                        Utility.LoadedModules.RemoveAt(moduleIndex);
                    }
                }

                base.OnExit(e);
            }
            catch (Exception ex)
            {
                Utilities.Utility.EventLogger.Log(LogLevel.Error, ex);
            }
        }

    } // class App
} // namespace PriceListEditor
