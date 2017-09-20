using System;
using Microsoft.Practices.Unity;
using PriceListEditor.Interfaces;
using PriceListEditor.Module.Suppliers.Interfaces;
using PriceListEditor.Module.Suppliers.ViewModels;
using PriceListEditor.Module.Suppliers.Views;
using PriceListEditor.Utilities.Properties;

namespace PriceListEditor
{
    namespace Module
    {
        namespace Suppliers
        {
            public class SuppliersModule : ILoadableModule
            {
                #region Private data members
                /// <summary>
                ///     Main view of the module.
                /// </summary>
                private SuppliersModuleMainView mMainView = null;

                /// <summary>
                ///     Unity container.
                /// </summary>
                private IUnityContainer mUnityContainer = null;
                #endregion // Private data members

                /// <summary>
                ///     Return an icon of a chap with a plus sign
                /// </summary>
                public String IconCharacter => "\uE1E2";

                public Boolean IsModuleEnabled => true;

                public Int32 MenuIndex => 0x8000;

                public String ModuleDescription => Resources.SuppliersModuleDescription;

                public String ModuleName => Resources.SuppliersModuleName;

                /// <summary>
                ///     Gets the main view object of the module.
                /// </summary>
                public Object ModuleView => mMainView ?? (mMainView = mUnityContainer.Resolve<ISuppliersModuleMainView>() as SuppliersModuleMainView);

                public void ActivateModule()
                {
                }

                public void DeactivateModule()
                {
                }

                public void InitialiseModule(IUnityContainer container)
                {
                    this.mUnityContainer = container;

                    container.RegisterType<ISuppliersModuleMainView, SuppliersModuleMainView>(new ContainerControlledLifetimeManager());
                    container.RegisterType<ISuppliersModuleMainViewModel, SuppliersModuleMainViewModel>(new ContainerControlledLifetimeManager());
                }

                public void ProgramClosing()
                {
                }

                #region Private properties
                private IUnityContainer UnityContainer => this.mUnityContainer;
                #endregion Private properties
            }
        } // namespace Suppliers
    } // namespace Module
} // namespace PriceListEditor
