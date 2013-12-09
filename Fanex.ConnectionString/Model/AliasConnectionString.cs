// --------------------------------------------------------------------------
// <copyright file="AliasConnectionString.cs" company="Nexcel Solutions Vietnam">
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
    /// Alias connection string.
    /// </summary>
    public class AliasConnectionString
    {
        public int NumOfSite { get; set; }

        public Connection ConnectionString { get; set; }      
    }
}
