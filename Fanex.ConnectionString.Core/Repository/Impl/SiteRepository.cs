// --------------------------------------------------------------------------
// <copyright file="SiteRepository.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.1.21">Created</change>
// </history>

namespace Fanex.ConnectionString.Core.Repository.Impl
{
    using System.Collections.Generic;
    using System.Linq;
    using Fanex.ConnectionString.Core.Repository.Interface;
    using Fanex.ConnectionString.Domain;
    using Fanex.Data;
    using NAP.Framework.Data;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class SiteRepository : BaseRepository<Site>, ISiteRepository
    {
        /// <summary>
        /// Fetch site.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>List of site.</returns>
        public override IEnumerable<Site> Fetch(ICriteria criteria)
        {
            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                return db.Query<Site, Users, Site>(
                    (s, u) => { s.Modifier = u; return s; },
                    "ModifierUserId",
                    criteria.GetSpParams()).OrderBy(x => x.Name).ToList();
            }
        }

        /// <summary>
        /// Get site object.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>Site object.</returns>
        public override Site Get(ICriteria criteria)
        {
            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                return db.QueryEntity<Site>(criteria.GetSpParams());
            }
        }
    }
}