using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;

namespace PriceListEditor
{
    namespace Events
    {
        /// <summary>
        ///     Event raised when the modules are ready for displaying in the main window.
        /// </summary>
        public class DisplayLoadedModulesEvent : PubSubEvent 
        {
        }
    } // namespace Events
} // namespace PriceListEditor
