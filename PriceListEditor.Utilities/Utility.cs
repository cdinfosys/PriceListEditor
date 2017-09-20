using System;
using System.Collections.Generic;
using System.Threading;
using NLog;
using PriceListEditor.Interfaces;
using PriceListEditor.Utilities.CDInfoSys.PriceList;

namespace PriceListEditor
{
    namespace Utilities
    {
        /// <summary>
        ///     Utility routines and objects.
        /// </summary>
        public static class Utility 
        {
            #region Class members
            /// <summary>
            ///     Instance of the logger class.
            /// </summary>
            private static Logger mLogger;

            /// <summary>
            ///     List of modules loaded during startup
            /// </summary>
            private static List<ILoadableModule> mLoadedModules = new List<ILoadableModule>();
            #endregion // Class members

            /// <summary>
            ///     Cancellation token for the thread that loads program modules at startup.
            /// </summary>
            private static CancellationTokenSource mModuleLoadCancellationToken = new CancellationTokenSource();

            /// <summary>
            ///     Price list backend service connection.
            /// </summary>
            private static PriceListServiceClient mPriceListService = null;

            #region Construction
            static Utility()
            {
                mLogger = LogManager.GetCurrentClassLogger();
            }
            #endregion Construction

            #region Public properties
            /// <summary>
            ///     Gets the instance of the Logger.
            /// </summary>
            public static Logger EventLogger => Utility.mLogger;

            /// <summary>
            ///     Gets the list of modules loaded during startup.
            /// </summary>
            public static List<ILoadableModule> LoadedModules => Utility.mLoadedModules;

            /// <summary>
            ///     Gets the cancellation token for the module loader thread.
            /// </summary>
            public static CancellationTokenSource ModuleLoadCancellationToken => Utility.mModuleLoadCancellationToken;

            /// <summary>
            ///     Returns the object through which the backend WPF service can be contacted.
            /// </summary>
            public static PriceListServiceClient PriceListService => Utility.mPriceListService ?? (Utility.mPriceListService = new PriceListServiceClient());

            #endregion Public properties
        } // class Utilities
    } // namespace Utilities
} // namespace PriceListEditor
