using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using NLog;
using PriceListEditor.Events;
using PriceListEditor.Interfaces;
using PriceListEditor.Interfaces.ViewModels;
using PriceListEditor.Interfaces.Views;
using PriceListEditor.Utilities;
using Prism.Events;

namespace PriceListEditor
{
    namespace ViewModels
    {
        public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
        {
            #region Private data members
            /// <summary>
            ///     Collection of loaded modules returned by the LoadedModules property.
            /// </summary>
            private ObservableCollection<ILoadableModule> mLoadedModules;

            /// <summary>
            ///     Backing member for the SelectedModule property.
            /// </summary>
            private ILoadableModule mSelectedModule = null;

            /// <summary>
            ///     Cancellation token for the <see cref="SwitchActiveModulesCancellationToken"/> method.
            /// </summary>
            private CancellationTokenSource mSwitchActiveModulesCancellationTokenSource = new CancellationTokenSource();

            /// <summary>
            ///     Backing member for the ActiveView property.
            /// </summary>
            private Object mActiveView = null;

            /// <summary>
            ///     Backing member for the DefaultView property.
            /// </summary>
            private Object mDefaultView = null;
            #endregion Private data members


            #region Construction
            public MainWindowViewModel(IUnityContainer container, IEventAggregator eventAggregator)
                :   base(container, eventAggregator)
            {
                eventAggregator.GetEvent<DisplayLoadedModulesEvent>().Subscribe
                (
                    () => 
                    {
                         DisplayLoadedModules();
                    }
                );
            }
            #endregion Construction

            #region Public properties
            public ObservableCollection<ILoadableModule> LoadedModules
            {
                get 
                { 
                    return this.mLoadedModules; 
                }
                private set
                {
                    this.mLoadedModules = new ObservableCollection<ILoadableModule>(value);
                    OnPropertyChanged();
                }
            }

            /// <summary>
            ///     Gets or sets the module that is selected in the main menu.
            /// </summary>
            public ILoadableModule SelectedModule
            {
                get
                {
                    return this.mSelectedModule;
                }
                set
                {
                    ILoadableModule previousModule = this.mSelectedModule;
                    if (SetProperty<ILoadableModule>(ref this.mSelectedModule, value))
                    {
                        ActiveView = (this.mSelectedModule == null) ? DefaultView : this.mSelectedModule.ModuleView;
                        // Cancel previous operations
                        mSwitchActiveModulesCancellationTokenSource?.Cancel();
                        mSwitchActiveModulesCancellationTokenSource = new CancellationTokenSource();
                        SwitchActiveModules(previousModule, value, mSwitchActiveModulesCancellationTokenSource.Token);
                    }
                }
            }

            /// <summary>
            ///     Gets or sets the view that is currently active in the main window.
            /// </summary>
            public Object ActiveView
            {
                get
                {
                    return this.mActiveView;
                }
                set
                {
                    if (value == null)
                    {
                        SetProperty<Object>(ref this.mDefaultView, value);
                    }
                    else
                    {
                        SetProperty<Object>(ref this.mActiveView, value);
                    }
                }
            }

            /// <summary>
            ///     Gets or setsh the default view that is displayed if no modules are active.
            /// </summary>
            public Object DefaultView
            {
                get { return this.mDefaultView; }
                set 
                { 
                    if (SetProperty<Object>(ref this.mDefaultView, value))
                    {
                        if (Object.Equals(this.mActiveView, this.mDefaultView))
                        {
                            OnPropertyChanged(nameof(ActiveView));
                        }
                    }
                }
            }

            #endregion Public properties

            #region Helper methods
            private async void SwitchActiveModules(ILoadableModule previousModule, ILoadableModule newModule, CancellationToken cancellationToken)
            {

                try
                {
                    await Task.Run
                    (
                        () =>
                        {
                            lock (this)
                            {
                                DeactivateModule(previousModule);
                                ActivateModule(newModule);
                            }
                        }
                    );
                }
                catch (OperationCanceledException)
                {
                }
            }

            private void ActivateModule(ILoadableModule module)
            {
                try
                {
                    System.Diagnostics.Debug.WriteLine("Activated " + module.ModuleName);
                    this.mSelectedModule?.ActivateModule();
                }
                catch (Exception ex)
                {
                    Utility.EventLogger.Log(LogLevel.Error, ex);
                }
            }

            private void DeactivateModule(ILoadableModule module)
            {
                try
                {
                    System.Diagnostics.Debug.WriteLine("Deactivated " + module.ModuleName);
                    this.mSelectedModule?.DeactivateModule();
                }
                catch (Exception ex)
                {
                    Utility.EventLogger.Log(LogLevel.Error, ex);
                }
            }

            private void DisplayLoadedModules()
            {
                this.LoadedModules = new ObservableCollection<ILoadableModule>(Utility.LoadedModules);
            }
            #endregion Helper methods
        } // class MainWindowViewModel
    } // namespace ViewModels
} // namespace PriceListEditor