using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using PriceListEditor.Interfaces;
using PriceListEditor.Module.Settings.Properties;
using PriceListEditor.Module.Settings.Views;

namespace PriceListEditor
{
    namespace Module
    {
        namespace Settings
        {
            public class SettingsModule : ILoadableModule
            {
                #region Private data members
                /// <summary>
                ///     Stores a reference to a Unity container object.
                /// </summary>
                private IUnityContainer mUnityContainer;

                /// <summary>
                ///     The only instance of the main view.
                /// </summary>
                private SettingsModuleMainView mMainView = null;
                #endregion Private data members

                #region ILoadableModule implementation
                /// <summary>
                ///     Return an icon of a gear
                /// </summary>
                public String IconCharacter => "\uE2F9";// "\u2699";

                /// <summary>
                ///     The module is always enabled.
                /// </summary>
                public Boolean IsModuleEnabled => true;

                /// <summary>
                ///     Module should always be at the end of the menu.
                /// </summary>
                public Int32 MenuIndex => 0x7FFFF000;

                /// <summary>
                ///     Gets a string of text that describes the module.
                /// </summary>
                public String ModuleDescription => Resources.ModuleDescription;

                /// <summary>
                ///     Label of the item in the menu.
                /// </summary>
                public String ModuleName => Resources.ModuleTitle;

                /// <summary>
                ///     Gets the main view for the module.
                /// </summary>
                public Object ModuleView => mMainView ?? (mMainView = new SettingsModuleMainView());

                /// <summary>
                ///     Called when the module is loaded into memory.
                /// </summary>
                /// <param name="container">
                ///     An instance of a Unity container object.
                /// </param>
                public void InitialiseModule(IUnityContainer container)
                {
                    this.mUnityContainer = container;
                }

                public void ActivateModule()
                {
                }

                public void DeactivateModule()
                {
                }

                /// <summary>
                ///     Called when the program is shutting down.
                /// </summary>
                public void ProgramClosing()
                {
                    // Release the reference to the unity container object.
                    this.mUnityContainer = null;
                }
                #endregion ILoadableModule implementation
            } // class SettingsModule
        } // namespace Settings
    } // namespace Module
} // namespace PriceListEditor
