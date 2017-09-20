using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
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
            public IEnumerable<ILoadableModule> LoadedModules
            {
                get { return Utility.LoadedModules; }
            }
            #endregion Public properties

            #region Helper methods
            private void DisplayLoadedModules()
            {
                OnPropertyChanged("LoadedModules");
            }
            #endregion Helper methods
        } // class MainWindowViewModel
    } // namespace ViewModels
} // namespace PriceListEditor