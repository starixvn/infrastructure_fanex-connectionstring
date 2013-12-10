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
    using System;
    using System.Collections.Generic;
    using Fanex.Common.Helper;
    using Fanex.ConnectionString.Core.Criteria.Site;
    using Fanex.ConnectionString.Core.Repository.Impl;
    using Fanex.ConnectionString.Core.Repository.Interface;
    using Fanex.ConnectionString.Core.Service.Interface;
    using Fanex.ConnectionString.Domain;
    using Fanex.NAP.Core.Criteria.Misc;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// Site service class.
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
        /// Gets the site by identifier.
        /// </summary>
        /// <param name="id">The site identifier.</param>
        /// <returns>The site information.</returns>
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
        /// Gets all site.
        /// </summary>
        /// <param name="name">The search site name.</param>
        /// <param name="isActive">The status of site need search.</param>
        /// <returns>The site collections.</returns>
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
        /// Inserts the specified site.
        /// </summary>
        /// <param name="site">The site information.</param>
        /// <returns>The status of command.</returns>
        public ICommandResult Insert(Site site)
        {
            Check.Argument.IsNotNull(site, "site");
            Check.Argument.IsNotEmpty(site.Name, "name");

            var criteria = new SiteInsertCriteria
            {
                Name = site.Name,
                Description = site.Description,
                IsActive = site.IsActive,
                CreatedDate = DateTime.Now,
                Creator = this.ServiceContext.UserId
            };

            LogExecSpCriteria logCriteria = GetLogExecSpCriteria();

            if (criteria.IsValid() && logCriteria.IsValid())
            {
                return _siteRepository.InsertOrUpdate(criteria, logCriteria);
            }

            return new CommandResult { Code = -1 };
        }

        /// <summary>
        /// Updates the specified site.
        /// </summary>
        /// <param name="site">The site.</param>
        /// <returns>The status of command.</returns>
        public ICommandResult Update(Site site)
        {
            Check.Argument.IsNotNull(site, "site");
            Check.Argument.IsNotNegativeOrZero(site.Id, "id");
            Check.Argument.IsNotEmpty(site.Name, "name");

            var criteria = new SiteUpdateCriteria
            {
                SiteId = site.Id,
                Name = site.Name,
                Description = site.Description,
                IsActive = site.IsActive,
                ModifiedDate = DateTime.Now,
                Modifier = this.ServiceContext.UserId
            };

            LogExecSpCriteria logCriteria = GetLogExecSpCriteria();

            if (criteria.IsValid() && logCriteria.IsValid())
            {
                return _siteRepository.InsertOrUpdate(criteria, logCriteria);
            }

            return new CommandResult { Code = -1 };
        }

        /// <summary>
        /// Updates the status of site.
        /// </summary>
        /// <param name="id">The site identifier.</param>
        /// <param name="isActive">If set to <c>true</c> [Site is active].</param>
        /// <returns>The status of command.</returns>
        public ICommandResult UpdateStatus(int id, bool isActive)
        {
            Check.Argument.IsNotNegativeOrZero(id, "id");

            var criteria = new SiteUpdateStatusCriteria
            {
                SiteId = id,
                IsActive = isActive,
                ModifiedDate = DateTime.Now,
                Modifier = this.ServiceContext.UserId
            };

            LogExecSpCriteria logCriteria = GetLogExecSpCriteria();

            if (criteria.IsValid() && logCriteria.IsValid())
            {
                return _siteRepository.InsertOrUpdate(criteria, logCriteria);
            }

            return new CommandResult { Code = -1 };
        }

        /// <summary>
        /// Gets the by connection identifier.
        /// </summary>
        /// <param name="connectionId">The connection identifier.</param>
        /// <returns></returns>
        public IEnumerable<Site> GetByConnectionId(int connectionId)
        {
            var criteria = new SiteGetByConnectionCriteria
            {
                ConnectionId = connectionId
            };

            if (criteria.IsValid())
            {
                return _siteRepository.Fetch(criteria);
            }

            return null;
        }
    }
}
