using System;
using System.Collections.Generic;
using System.Windows;
using PriceListEditor.Interfaces.ViewModels;
using PriceListEditor.Interfaces.Views;
using Prism.Events;

namespace PriceListEditor
{
    namespace Views
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindowView : Window, IMainWindowView
        {
            #region Private data members
            /// <summary>
            ///     Stores a reference to an event aggregator object.
            /// </summary>
            private IEventAggregator mEventAggregator;

            /// <summary>
            ///     Stores a reference to the view model for this view.
            /// </summary>
            private IMainWindowViewModel mViewModel;
            #endregion Private data members

            /// <summary>
            ///     Construct a view for the main window.
            /// </summary>
            /// <param name="eventAggregator">
            ///     Event aggregator object
            /// </param>
            /// <param name="viewModel">
            ///     View model for this view.
            /// </param>
            public MainWindowView(IEventAggregator eventAggregator, IMainWindowViewModel viewModel)
            {
                this.mEventAggregator = eventAggregator;
                this.mViewModel = viewModel;

                InitializeComponent();

                mViewModel.ActiveView = mViewModel.DefaultView = new DefaultView();
                this.DataContext = mViewModel;
            }
        }
    }
}
