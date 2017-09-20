using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using PriceListEditor.Module.Suppliers.Interfaces;
using PriceListEditor.Utilities;
using PriceListEditor.Utilities.CDInfoSys.PriceList;
using PriceListEditor.ViewModels;
using Prism.Events;

namespace PriceListEditor.Module.Suppliers.ViewModels
{
    public class SuppliersModuleMainViewModel : ViewModelBase, ISuppliersModuleMainViewModel
    {
        #region Private data members
        /// <summary>
        ///     Backing data member for the Suppliers property.
        /// </summary>
        private ObservableCollection<SupplierDTO> mSuppliers;
        #endregion // Private data members

        #region Construction
            /// <summary>
            ///     Construct a view model for the main view of the suppliers module.
            /// </summary>
            /// <param name="container">
            ///     Unity container object.
            /// </param>
            /// <param name="eventAggregator">
            ///     Event aggregator for the program.
            /// </param>
            public SuppliersModuleMainViewModel
            (
                IUnityContainer container,
                IEventAggregator eventAggregator
            )
                :   base(container, eventAggregator)
            {
            }
        #endregion Construction

        #region Public properties
        public ObservableCollection<SupplierDTO> Suppliers
        {
            get
            {
                return this.mSuppliers ?? (mSuppliers = LoadSuppliers());
            }

            set
            {
                SetProperty<ObservableCollection<SupplierDTO>>(ref this.mSuppliers, value);
            }
        }
        #endregion Public properties
        private ObservableCollection<SupplierDTO> LoadSuppliers()
        {
            var data = Utility.PriceListService.GetSuppliersAsync().Result;
            return new ObservableCollection<SupplierDTO>(data.Suppliers);
        }

    } // class SuppliersModuleMainViewModel
} // namespace PriceListEditor.Module.Suppliers.ViewModels
