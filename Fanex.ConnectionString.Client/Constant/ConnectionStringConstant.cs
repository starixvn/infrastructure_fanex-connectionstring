// --------------------------------------------------------------------------
// <copyright file="ConnectionStringConstant.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.1.11">Created</change>
// </history>

namespace Fanex.ConnectionString.Client
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The connection string constant.
    /// </summary>
    internal static class ConnectionStringConstant
    {
        /// <summary>
        /// The get all.
        /// </summary>
        public const int GETALL = 0;

        /// <summary>
        /// The prefix cache key.
        /// </summary>
        public const string PREKEY = "Fanex_ConnectionString_";

        /// <summary>
        /// The connection string format.
        /// </summary>
        public const string CONNECTIONFORMAT = "packet size=4096; Data Source={0};Initial Catalog={1};integrated security=false; User ID={2};Password={3}";

        /// <summary>
        /// The provider name.
        /// </summary>
        public const string PROVIDERNAME = "System.Data.SqlClient";
    }
}
