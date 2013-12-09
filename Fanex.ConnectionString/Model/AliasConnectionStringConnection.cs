// --------------------------------------------------------------------------
// <copyright file="AliasConnectionStringConnection.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.1.17">Created</change>
// </history>

namespace Fanex.ConnectionString.Model
{
    using Fanex.ConnectionString.Domain;

    /// <summary>
    /// Alias connection string connection.
    /// </summary>
    public class AliasConnectionStringConnection
    {
        public Connection FromConnectionString { get; set; }

        public Connection ToConnectionString { get; set; }
    }
}
