// --------------------------------------------------------------------------
// <copyright file="DatabaseServer.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.1.11">Created</change>
// </history>

namespace Fanex.ConnectionString.Domain
{
    using System;

    /// <summary>
    /// The database server class.
    /// </summary>
    public class DatabaseServer : Entity
    {
        public string ServerIP { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public Users Creator { get; set; }

        public DateTime CreatedDate { get; set; }

        public Users Modifier { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
