using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PriceListEditor.Module.Suppliers.Interfaces;
using Prism.Events;

namespace PriceListEditor.Module.Suppliers.Views
{
    /// <summary>
    /// Interaction logic for SuppliersModuleMainView.xaml
    /// </summary>
    public partial class SuppliersModuleMainView : UserControl, ISuppliersModuleMainView
    {
        #region Private data members
        /// <summary>
        ///     View model object for this view.
        /// </summary>
        private ISuppliersModuleMainViewModel mViewModel;

        /// <summary>
        ///     Event aggregator for the program.
        /// </summary>
        private IEventAggregator mEventAggregator;
        #endregion Private data members

        #region Construction
        /// <summary>
        ///     Construct a new view.
        /// </summary>
        /// <param name="eventAggregator">
        ///     Event aggregator for the program.
        /// </param>
        /// <param name="viewModel">
        ///     View model attached to this view
        /// </param>
        public SuppliersModuleMainView(IEventAggregator eventAggregator, ISuppliersModuleMainViewModel viewModel)
        {
            this.mViewModel = viewModel;
            this.mEventAggregator = eventAggregator;
            InitializeComponent();
            this.DataContext = viewModel;
        }
        #endregion Construction

        #region Private properties
        /// <summary>
        ///     Gets the view model object for this view.
        /// </summary>
        private ISuppliersModuleMainViewModel ViewModel => this.mViewModel;

        /// <summary>
        ///     Gets the event aggregator object used by the program.
        /// </summary>
        private IEventAggregator EventAggregator => this.mEventAggregator;
        #endregion // Private properties
    } // class SuppliersModuleMainView
} // namespace PriceListEditor.Module.Suppliers.Views
