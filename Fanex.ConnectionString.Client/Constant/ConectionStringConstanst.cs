// --------------------------------------------------------------------------
// <copyright file="ConectionStringConstanst.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.1.11">Created</change>
// </history>

namespace Fanex.ConnectionString.Client
{
    using System.Diagnostics.CodeAnalysis;
    
    internal static class ConnectionStringConstant
    {
        public const int GETALL = 0;

        public const string PREKEY = "Fanex_ConnectionString_";

        public const string CONNECTIONFORMAT = "packet size=4096; Data Source={0};Initial Catalog={1}; integrated security=false; User ID={2}; Password={3}; {4}";

        public const string PROVIDERNAME = "System.Data.SqlClient";
    }
}
