// --------------------------------------------------------------------------
// <copyright file="Entity.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.12.5">Created</change>
// </history>

namespace Fanex.ConnectionString.Domain
{
    public class Entity : IEntity<int, string>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
