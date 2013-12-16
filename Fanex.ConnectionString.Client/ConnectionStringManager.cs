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
    using System;
    using System.Configuration;
    using System.Diagnostics.CodeAnalysis;
    using Fanex.Caching;
    using Fanex.ConnectionString.Client.Configuration;
    using Fanex.ConnectionString.Client.ConnectionWatcher;

    /// <summary>
    /// The connection string manager class.
    /// </summary>
    public static class ConnectionStringManager
    {
        #region Member

        private static readonly ICache _Cache;

        private static ConnectionType _connectionStringType;

        private static int _siteId;

        #endregion

        static ConnectionStringManager()
        {
            _siteId = ConnectionSettings.Settings.SiteId;

            _connectionStringType = ConnectionSettings.Settings.IsLocal ? ConnectionType.Local : ConnectionType.Remote;

            if (_connectionStringType == ConnectionType.Remote)
            {
                ConnectionStringWatcher.Start();
            }

            _Cache = CacheService.CreateInstance(CacheType.MemoryCache);
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
                        collection = _Cache.Get<ConnectionStringSettingsCollection>(ConnectionStringConstant.PREKEY);
                    }
                    else
                    {
                        collection = ConfigurationManager.ConnectionStrings;
                    }

                    return collection;
                }
                catch (Exception ex)
                {
                    throw ex;
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
