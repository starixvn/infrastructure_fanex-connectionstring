// --------------------------------------------------------------------------
// <copyright file="SiteService.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.1.21">Created</change>
// </history>

namespace Fanex.ConnectionString.Core.Service.Impl
{
    using System.Collections.Generic;
    using Fanex.Common.Helper;
    using Fanex.ConnectionString.Core.Criteria.Site;
    using Fanex.ConnectionString.Core.Repository.Impl;
    using Fanex.ConnectionString.Core.Repository.Interface;
    using Fanex.ConnectionString.Core.Service.Interface;
    using Fanex.ConnectionString.Domain;
    using Fanex.ConnectionString.Model;
    using Fanex.NAP.Core.Criteria.Misc;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class SiteService : BaseService, ISiteService
    {
        #region Member

        private readonly ISiteRepository _siteRepository;

        #endregion

        #region Ctor

        public SiteService()
            : this(null)
        {
        }

        public SiteService(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository ?? new SiteRepository();
        }

        #endregion

        /// <summary>
        /// Get all sites.
        /// </summary>
        /// <param name="name">Site object name.</param>
        /// <param name="databaseServerId">Database server ID.</param>
        /// <returns>List of site.</returns>
        public IEnumerable<Site> GetAll(string name = "", bool? isActive = null)
        {
            var criteria = new SiteGetAllCriteria
            {
                Name = name,
                IsActive = isActive
            };

            if (criteria.IsValid())
            {
                return _siteRepository.Fetch(criteria);
            }

            return null;
        }

        /// <summary>
        /// Get site by ID.
        /// </summary>
        /// <param name="id">Site object ID.</param>
        /// <returns>Site object.</returns>
        public Site GetById(int id)
        {
            var criteria = new SiteGetByIdCriteria
            {
                SiteId = id
            };

            if (criteria.IsValid())
            {
                return _siteRepository.Get(criteria);
            }

            return null;
        }

        /// <summary>
        /// Insert or update site.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>Command result.</returns>
        public ICommandResult InsertOrUpdate(ICriteria criteria)
        {
            // check parameters
            Check.Argument.IsNotNull(criteria, "criteria");

            LogExecSpCriteria logCriteria = GetLogExecSpCriteria();

            if (criteria.IsValid() && logCriteria.IsValid())
            {
                return _siteRepository.InsertOrUpdate(criteria, logCriteria);
            }

            return null;
        }

        /// <summary>
        /// Update site status.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>Command result.</returns>
        public ICommandResult UpdateStatus(ICriteria criteria)
        {
            // check parameters
            Check.Argument.IsNotNull(criteria, "criteria");

            LogExecSpCriteria logCriteria = GetLogExecSpCriteria();

            if (criteria.IsValid() && logCriteria.IsValid())
            {
                return _siteRepository.InsertOrUpdate(criteria, logCriteria);
            }

            return null;
        }
    }
}
