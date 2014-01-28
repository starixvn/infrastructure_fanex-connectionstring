// --------------------------------------------------------------------------
// <copyright file="Site.cs" company="Nexcel Solutions Vietnam">
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
    /// The site class.
    /// </summary>
    public class Site : Entity
    {
        public string Description { get; set; }

        public bool IsActive { get; set; }

        public Users Creator { get; set; }

        public DateTime CreatedDate { get; set; }

        public Users Modifier { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
