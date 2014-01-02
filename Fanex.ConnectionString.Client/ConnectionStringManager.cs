// --------------------------------------------------------------------------
// <copyright file="ConnectionStringManager.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.1.11">Created</change>
// </history>

namespace Fanex.ConnectionString.Client
{
    using System.Configuration;
    using Fanex.ConnectionString.Client.Cache;
    using Fanex.ConnectionString.Client.Configuration;
    using Fanex.ConnectionString.Client.ConnectionWatcher;

    /// <summary>
    /// The connection string manager class.
    /// </summary>
    public static class ConnectionStringManager
    {
        #region Member

        private static ConnectionType _connectionStringType = ConnectionSettings.Settings.IsLocal ? ConnectionType.Local : ConnectionType.Remote;

        #endregion

        static ConnectionStringManager()
        {
            if (_connectionStringType == ConnectionType.Remote)
            {
                ConnectionStringWatcher.Start();
            }
        }

        public static ConnectionStringSettingsCollection ConnectionStrings
        {
            get
            {
                try
                {
                    var collection = new ConnectionStringSettingsCollection();

                    if (_connectionStringType == ConnectionType.Remote)
                    {
                        collection = CacheManager.Cache.Get<ConnectionStringSettingsCollection>(ConnectionStringConstant.PREKEY);
                    }
                    else
                    {
                        collection = ConfigurationManager.ConnectionStrings;
                    }

                    return collection;
                }
                catch
                {
                    throw;
                }
            }
        }

        public static void Start()
        {
            ConnectionStringWatcher.Stop();
            ConnectionStringWatcher.Start();
        }

        public static void Stop()
        {
            ConnectionStringWatcher.Stop();
        }
    }
}
