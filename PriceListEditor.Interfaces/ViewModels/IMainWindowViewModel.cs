using System;

namespace PriceListEditor
{
    namespace Interfaces
    {
        namespace ViewModels
        {
            public interface IMainWindowViewModel
            {
                Object DefaultView { get; set; }
                Object ActiveView { get; set; }
            } // interface IMainWindowViewModel
        } // namespace ViewModels
    } // namespace Interfaces
} // namespace PriceListEditor
