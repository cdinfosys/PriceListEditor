using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace PriceListEditor
{
    namespace Interfaces
    {
        public interface ILoadableModule
        {
            #region Public properties
            /// <summary>
            ///     Get the character that represents the module's icon in the menu.
            /// </summary>
            String IconCharacter { get; }

            /// <summary>
            ///     Get the name of the module as it is displayed in the menu.
            /// </summary>
            String ModuleName { get; }

            /// <summary>
            ///     Longer descriptive text for the module, shown in a tooltip when the mouse hovers over the item.
            /// </summary>
            String ModuleDescription { get; }

            /// <summary>
            ///     Gets the index of the module in the menu.
            /// </summary>
            Int32 MenuIndex { get; }

            /// <summary>
            ///     A flag to indicate if the module is enabled or disabled in the main window.
            /// </summary>
            Boolean IsModuleEnabled { get; }

            /// <summary>
            ///     Gets the main view for the module.
            /// </summary>
            Object ModuleView { get; }
            #endregion Public properties

            #region Public accessor methods
            /// <summary>
            ///     This method is called after the module has been loaded.
            /// </summary>
            /// <param name="container">
            ///     An instance of a Unity container that the module can use to register its types.
            /// </param>
            void InitialiseModule(IUnityContainer container);

            /// <summary>
            ///     This method is called by the framework when the user activates the module.
            /// </summary>
            void ActivateModule();

            /// <summary>
            ///     This method is called by the framework when the user activates another module
            /// </summary>
            void DeactivateModule();

            /// <summary>
            ///     This method is called by the framework when the user closes the program.
            /// </summary>
            void ProgramClosing();
            #endregion Public accessor methods
        } // interface ILoadableModule
    } // namespace Interfaces
} // namespace PriceListEditor
