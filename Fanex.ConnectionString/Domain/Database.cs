// --------------------------------------------------------------------------
// <copyright file="Database.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.12.5">Created</change>
// </history>

namespace Fanex.ConnectionString.Domain
{
    using System;

    /// <summary>
    /// The database class.
    /// </summary>
    public class Database : Entity
    {
        public string ServerAlias { get; set; }

        public DatabaseServer DatabaseServer { get; set; }

        public bool IsActive { get; set; }

        public Users Creator { get; set; }

        public DateTime CreatedDate { get; set; }

        public Users Modifier { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
