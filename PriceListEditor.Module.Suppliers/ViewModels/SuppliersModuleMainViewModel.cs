using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using Microsoft.Practices.Unity;
using PriceListEditor.Module.Suppliers.Interfaces;
using PriceListEditor.Utilities;
using PriceListEditor.Utilities.CDInfoSys.PriceList;
using PriceListEditor.ViewModels;
using Prism.Commands;
using Prism.Events;
using PriceListEditor.Classes;
using LocalSupplierDTO = PriceListEditor.DTO.SupplierDTO;
using SupplierRec = PriceListEditor.Classes.DataStorageItem<PriceListEditor.DTO.SupplierDTO>;
using System.Collections.Generic;

namespace PriceListEditor.Module.Suppliers.ViewModels
{
    public class SuppliersModuleMainViewModel : ViewModelBase, ISuppliersModuleMainViewModel
    {
        #region Private data members
        /// <summary>
        ///     Backing data member for the Suppliers property.
        /// </summary>
        private ObservableCollection<SupplierRec> mSuppliers;
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
        public ICommand OnRowDeleteButtonClickedCommand
        {
            get
            {
                return new DelegateCommand<Object>
                (
                    (boxedSupplierID) => { DeleteSupplier(Convert.ToInt32(boxedSupplierID)); }
                );
            }
        }

        public ICommand OnRowEditButtonClickedCommand
        {
            get
            {
                return new DelegateCommand<Object>
                (
                    (boxedSupplierID) => { EditSupplier(Convert.ToInt32(boxedSupplierID)); }
                );
            }
        }

        public IEnumerable<LocalSupplierDTO> GridSuppliers
        {
            get
            {
                if (this.Suppliers == null)
                {
                    yield break;
                }

                foreach (SupplierRec rec in this.Suppliers)
                {
                    if (!rec.Deleted)
                    {
                        yield return rec.Data;
                    }
                }
            }
        }

        public ObservableCollection<SupplierRec> Suppliers
        {
            get
            {
                return this.mSuppliers ?? (mSuppliers = LoadSuppliers());
            }

            set
            {
                if (SetProperty(ref this.mSuppliers, value))
                {
                    OnPropertyChanged(nameof(GridSuppliers));
                }
            }
        }
        #endregion Public properties

        private void EditSupplier(Int32 supplierID)
        {
            //Suppliers.First(u => u.Data.SupplierID == supplierID).Deleted = true;
            OnPropertyChanged(nameof(GridSuppliers));
        }

        private void DeleteSupplier(Int32 supplierID)
        {
            Suppliers.First(u => u.Data.SupplierID == supplierID).Deleted = true;
            OnPropertyChanged(nameof(GridSuppliers));
        }

        private ObservableCollection<SupplierRec> LoadSuppliers()
        {
            GetSuppliersRequest request = new GetSuppliersRequest()
            {
                ClientUtcTime = DateTime.UtcNow,
                SessionToken = String.Empty // TODO replace with security system value.
            };

            var data = Utility.PriceListService.GetSuppliersAsync(request).Result;
            if (data.Suppliers == null)
            {
                return new ObservableCollection<SupplierRec>();
            }
            else
            {
                ObservableCollection<SupplierRec> result = new ObservableCollection<SupplierRec>();
                foreach (var rec in data.Suppliers)
                {
                    result.Add
                    (
                        new SupplierRec
                        (
                            new LocalSupplierDTO()
                            {
                                SupplierID = rec.SupplierID,
                                Code = rec.Code,
                                Descr = rec.Descr,
                                Address = String.Join(Environment.NewLine, rec.Address)
                            }
                        )
                    );
                }

                return result;
            }
        }

    } // class SuppliersModuleMainViewModel
} // namespace PriceListEditor.Module.Suppliers.ViewModels
