// --------------------------------------------------------------------------
// <copyright file="DatabaseServerRepository.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.1.21">Created</change>
// </history>

namespace Fanex.ConnectionString.Core.Repository.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Fanex.ConnectionString.Core.Repository.Interface;
    using Fanex.ConnectionString.Domain;
    using Fanex.Data;
    using NAP.Framework.Data;

    /// <summary>
    /// The database server repository.
    /// </summary>
    public class DatabaseServerRepository : BaseRepository<DatabaseServer>, IDatabaseServerRepository
    {
        /// <summary>
        /// Get all database server.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>List of database server.</returns>
        public override IEnumerable<DatabaseServer> Fetch(ICriteria criteria)
        {
            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                return db.Query<DatabaseServer, Users, DatabaseServer>(
                    (d, u) => { d.Modifier = u; return d; },
                    "ModifierId",
                    criteria.GetSpParams());
            }
        }
        
        /// <summary>
        /// Get database server.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>Database server.</returns>
        public override DatabaseServer Get(ICriteria criteria)
        {
            var list = this.Fetch(criteria);

            if (!ReferenceEquals(list, null))
            {
                return list.ToList().FirstOrDefault();
            }

            return null;
        }
    }
}