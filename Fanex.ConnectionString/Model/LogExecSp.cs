// --------------------------------------------------------------------------
// <copyright file="LogExecSp.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.1.28">Created</change>
// </history>

namespace Fanex.ConnectionString.Model
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;
    using Fanex.ConnectionString.Domain;

    /// <summary>
    /// The log execute stored procedure model.
    /// </summary>
    public class LogExecSp
    {
        public long Id { get; set; }

        public DateTime LogDate { get; set; }

        public string Name { get; set; }

        public string Modifier { get; set; }

        public string ActionName { get; set; }

        public int ActionId { get; set; }

        public string OldData { get; set; }

        public string Data { get; set; }

        public int ActionTypeId { get; set; }

        /// <summary>
        /// Converts string XML format to database server.
        /// </summary>
        /// <param name="xmlValue">The XML value.</param>
        /// <returns>The database server object.</returns>
        public DatabaseServer ConvertToDatabaseServer(string xmlValue)
        {
            var databaseServer = new DatabaseServer();

            if (!string.IsNullOrWhiteSpace(xmlValue))
            {
                var root = XDocument.Parse(xmlValue);
                var elementDatabaseServer = root.Descendants("z");

                foreach (var item in elementDatabaseServer)
                {
                    databaseServer.Name = item.Attribute("n") != null ? item.Attribute("n").Value : string.Empty;
                    databaseServer.ServerIP = item.Attribute("ip") != null ? item.Attribute("ip").Value : string.Empty;
                    databaseServer.Description = item.Attribute("d") != null ? item.Attribute("d").Value : string.Empty;
                    databaseServer.IsActive = item.Attribute("s") != null ? item.Attribute("s").Value == "1" : false;
                }
            }

            return databaseServer;
        }

        /// <summary>
        /// Converts string XML format to database.
        /// </summary>
        /// <param name="xmlValue">The XML value.</param>
        /// <returns>The database object.</returns>
        public Database ConvertToDatabase(string xmlValue)
        {
            var database = new Database();

            if (!string.IsNullOrWhiteSpace(xmlValue))
            {
                var root = XDocument.Parse(xmlValue);
                var elementDatabase = root.Descendants("z");

                foreach (var item in elementDatabase)
                {
                    database.Name = item.Attribute("n") != null ? item.Attribute("n").Value : string.Empty;
                    database.DatabaseServer = new DatabaseServer
                    {
                        Name = item.Attribute("ds") != null ? item.Attribute("ds").Value : string.Empty
                    };
                    database.ServerAlias = item.Attribute("sa") != null ? item.Attribute("sa").Value : string.Empty;
                    database.IsActive = item.Attribute("s") != null ? item.Attribute("s").Value == "1" : false;
                }
            }

            return database;
        }

        /// <summary>
        /// Converts string XML format to site.
        /// </summary>
        /// <param name="xmlValue">The XML value.</param>
        /// <returns>The site object.</returns>
        public Site ConvertToSite(string xmlValue)
        {
            var site = new Site();

            if (!string.IsNullOrWhiteSpace(xmlValue))
            {
                var root = XDocument.Parse(xmlValue);
                var elementSite = root.Descendants("z");

                foreach (var item in elementSite)
                {
                    site = ConvertToSite(item);
                }
            }

            return site;
        }

        /// <summary>
        /// Converts string XML format to list site.
        /// </summary>
        /// <param name="xmlValue">The XML value.</param>
        /// <returns>Collection of site object.</returns>
        public List<Site> ConvertToListSite(string xmlValue)
        {
            var sites = new List<Site>();

            if (!string.IsNullOrWhiteSpace(xmlValue))
            {
               var root = XDocument.Parse(xmlValue);
                var elementSite = root.Descendants("z");

                foreach (var item in elementSite)
                {
                    var site = ConvertToSite(item);

                    sites.Add(site);
                }
            }

            return sites;
        }

        /// <summary>
        /// Converts string XML format to connection.
        /// </summary>
        /// <param name="xmlValue">The XML value.</param>
        /// <returns>The connection object.</returns>
        public Connection ConvertToConnection(string xmlValue)
        {
            var connection = new Connection();

            if (!string.IsNullOrWhiteSpace(xmlValue))
            {
               var root = XDocument.Parse(xmlValue);
                var elementConnection = root.Descendants("z");

                foreach (var item in elementConnection)
                {
                    connection = ConvertToConnection(item);
                }
            }

            return connection;
        }

        /// <summary>
        /// Converts string XML format to list connection.
        /// </summary>
        /// <param name="xmlValue">The XML value.</param>
        /// <returns>Collection of connection object.</returns>
        public List<Connection> ConvertToListConnection(string xmlValue)
        {
            var connections = new List<Connection>();

            if (!string.IsNullOrWhiteSpace(xmlValue))
            {
              var root = XDocument.Parse(xmlValue);
                var elementConnection = root.Descendants("z");

                foreach (var item in elementConnection)
                {
                    var connection = ConvertToConnection(item);
                    connections.Add(connection);
                }
            }

            return connections;
        }

        /// <summary>
        /// Converts XELEMENT to connection.
        /// </summary>
        /// <param name="item">The XELEMENT item.</param>
        /// <returns>The connection object.</returns>
        private Connection ConvertToConnection(XElement item)
        {
            var connection = new Connection();

            connection.Name = item.Attribute("n") != null ? item.Attribute("n").Value : string.Empty;
            connection.DatabaseServer = new DatabaseServer
            {
                Name = item.Attribute("ds") != null ? item.Attribute("ds").Value : string.Empty
            };
            connection.Database = new Database
            {
                Name = item.Attribute("d") != null ? item.Attribute("d").Value : string.Empty,
                ServerAlias = item.Attribute("sa") != null ? item.Attribute("sa").Value : string.Empty
            };
            connection.LoginName = item.Attribute("ln") != null ? item.Attribute("ln").Value : string.Empty;
            connection.Password = item.Attribute("p") != null ? item.Attribute("p").Value : string.Empty;
            connection.FreeText = item.Attribute("ft") != null ? item.Attribute("ft").Value : string.Empty;
            connection.IsActive = item.Attribute("s") != null ? item.Attribute("s").Value == "1" : false;

            return connection;
        }

        /// <summary>
        /// Converts XELEMENT to site.
        /// </summary>
        /// <param name="item">The XELEMENT item.</param>
        /// <returns>The site object.</returns>
        private Site ConvertToSite(XElement item)
        {
            var site = new Site();

            site.Name = item.Attribute("n") != null ? item.Attribute("n").Value : string.Empty;
            site.Description = item.Attribute("d") != null ? item.Attribute("d").Value : string.Empty;
            site.IsActive = item.Attribute("s") != null ? item.Attribute("s").Value == "1" : false;

            return site;
        }
    }
}
