// --------------------------------------------------------------------------
// <copyright file="ConnectionStringWatcher.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.1.31">Created</change>
// </history>

namespace Fanex.ConnectionString.Client.ConnectionWatcher
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Xml.Linq;
    using Fanex.ConnectionString.Client.Cache;
    using Fanex.ConnectionString.Client.Configuration;

    /// <summary>
    /// The connection string watcher class.
    /// </summary>
    internal static class ConnectionStringWatcher
    {
        #region Member

        private static readonly string _CommandText = "bodb_ConnectionString.dbo.Connection_ClientGet";
        private static readonly string _SqlConnection = ConnectionSettings.Settings.Connection;
        private static readonly int _CurrentSiteId = ConnectionSettings.Settings.SiteId;
        private static ConnectionStringDataAccess _connectionStringDataAccess;
        private static string _filePath = ConnectionSettings.Settings.FilePath;

        #endregion

        /// <summary>
        /// Start SQL dependency.
        /// </summary>
        public static void Start()
        {
            _filePath = GetResourcePath(_filePath);

            // Build the command object we want to monitor (don't include a SqlConnection)
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand(_CommandText);
            cmd.CommandType = CommandType.StoredProcedure;

            // Setup the SQLWatcher
            _connectionStringDataAccess = new ConnectionStringDataAccess(_SqlConnection, cmd, SqlWatcherNotificationType.Blocking);
            _connectionStringDataAccess.OnChange += new ConnectionStringDataAccess.SqlWatcherEventHandler(QueueSQLWatcher_OnChange);
            _connectionStringDataAccess.Start();
        }

        /// <summary>
        /// Generates the connection string file.
        /// </summary>
        /// <param name="collection">The collection.</param>
        public static void GenerateConnectionStringFile(ConnectionStringSettingsCollection collection)
        {
            try
            {
                var document = new XDocument();
                var elementRoot = new XElement("connectionStrings");

                foreach (ConnectionStringSettings item in collection)
                {
                    var elementConnection = new XElement("add");
                    var attributeName = new XAttribute("name", item.Name.ToLower());
                    var attributeConnectionString = new XAttribute("connectionString", item.ConnectionString);
                    var attributeProvider = new XAttribute("providerName", "System.Data.SqlClient");

                    elementConnection.Add(attributeName);
                    elementConnection.Add(attributeConnectionString);
                    elementConnection.Add(attributeProvider);

                    elementRoot.Add(elementConnection);
                }

                document.Add(elementRoot);

                var hasChange = false;

                if (File.Exists(_filePath))
                {
                    var configDocument = XDocument.Load(_filePath);

                    hasChange = !string.Equals(document.ToString(), configDocument.ToString(), StringComparison.OrdinalIgnoreCase);
                }
                else
                {
                    hasChange = true;
                }

                if (hasChange)
                {
                    document.Save(_filePath);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Stop SQL dependency.
        /// </summary>
        public static void Stop()
        {
            _connectionStringDataAccess.Dispose();
        }

        /// <summary>
        /// Queues the SQL watcher on change.
        /// </summary>
        /// <param name="reader">The reader.</param>
        [SuppressMessage("StyleCop.CSharp.Nexcel.NexcelCustomRules", "SP2101:MethodMustNotContainMoreLinesThan", Justification = "Reviewed. Suppression is OK here.")]
        private static void QueueSQLWatcher_OnChange(IDataReader reader)
        {
            try
            {
                var collection = new ConnectionStringSettingsCollection();
                var allConnection = new Dictionary<int, string>();

                while (reader.Read())
                {
                    var connectionId = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"].ToString()) : 0;
                    var name = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : string.Empty;
                    var serverIp = reader["ServerIP"] != DBNull.Value ? reader["ServerIP"].ToString() : string.Empty;
                    var databaseName = reader["DatabaseName"] != DBNull.Value ? reader["DatabaseName"].ToString() : string.Empty;
                    var loginName = reader["LoginName"] != DBNull.Value ? reader["LoginName"].ToString() : string.Empty;
                    var password = reader["Password"] != DBNull.Value ? reader["Password"].ToString() : string.Empty;
                    var freeText = reader["FreeText"] != DBNull.Value ? reader["FreeText"].ToString() : string.Empty;
                    var siteId = reader["SiteId"] != DBNull.Value ? Convert.ToInt32(reader["SiteId"].ToString()) : 0;

                    var connectionString = string.Format(
                                                            ConnectionStringConstant.CONNECTIONFORMAT,
                                                            serverIp,
                                                            databaseName,
                                                            loginName,
                                                            password);

                    if (!string.IsNullOrWhiteSpace(freeText))
                    {
                        connectionString += ";" + freeText;
                    }

                    if (_CurrentSiteId != 0)
                    {
                        if (siteId == _CurrentSiteId)
                        {
                            collection.Add(new ConnectionStringSettings
                            {
                                Name = name,
                                ConnectionString = connectionString,
                                ProviderName = ConnectionStringConstant.PROVIDERNAME
                            });
                        }
                    }
                    else
                    {
                        if (!allConnection.ContainsKey(connectionId))
                        {
                            allConnection.Add(connectionId, name);

                            collection.Add(new ConnectionStringSettings
                            {
                                Name = name,
                                ConnectionString = connectionString,
                                ProviderName = ConnectionStringConstant.PROVIDERNAME
                            });
                        }
                    }
                }

                CacheManager.Cache.Set(ConnectionStringConstant.PREKEY, collection);

                GenerateConnectionStringFile(collection);
            }
            catch
            {
                throw;
            }
            finally
            {
                reader.Close();
            }
        }

        /// <summary>
        /// Gets the resource path.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>The file resource full path.</returns>
        /// <exception cref="System.NullReferenceException">Throw exception when file path is null.</exception>
        [SuppressMessage("StyleCop.CSharp.Nexcel.NexcelCustomRules", "SP2100:CodeLineMustNotBeLongerThan", Justification = "Reviewed. Suppression is OK here.")]
        private static string GetResourcePath(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new NullReferenceException("File path has not been set yet!");
            }

            // Check root path http://msdn.microsoft.com/query/dev10.query?appId=Dev10IDEF1&l=EN-US&k=k%28SYSTEM.IO.PATH.ISPATHROOTED%29;k%28SOLUTIONITEMSPROJECT%29;k%28TargetFrameworkMoniker-%22.NETFRAMEWORK%2cVERSION%3dV4.0%22%29;k%28DevLang-CSHARP%29&rd=true
            if (!Path.IsPathRooted(filePath))
            {
                if (filePath.StartsWith("~"))
                {
                    if (System.Web.HttpContext.Current != null)
                    {
                        filePath = System.Web.HttpContext.Current.Server.MapPath(filePath);
                    }
                }
                else
                {
                    // if got the problem with window service
                    // see http://haacked.com/archive/2004/06/29/706.aspx
                    filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
                }
            }

            return filePath;
        }
    }
}
