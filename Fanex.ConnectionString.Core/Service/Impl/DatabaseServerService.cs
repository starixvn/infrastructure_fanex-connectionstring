// --------------------------------------------------------------------------
// <copyright file="DatabaseServerService.cs" company="Nexcel Solutions Vietnam">
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
    using Fanex.ConnectionString.Core.Criteria.DatabaseServer;
    using Fanex.ConnectionString.Core.Repository.Impl;
    using Fanex.ConnectionString.Core.Repository.Interface;
    using Fanex.ConnectionString.Core.Service.Interface;
    using Fanex.ConnectionString.Domain;
    using Fanex.ConnectionString.Model;
    using Fanex.NAP.Core.Criteria.Misc;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// Database server service.
    /// </summary>
    public class DatabaseServerService : BaseService, IDatabaseServerService
    {
        #region Member

        private readonly IDatabaseServerRepository _databaseServerRepository;

        #endregion

        #region Ctor

        public DatabaseServerService()
            : this(null)
        {
        }

        public DatabaseServerService(IDatabaseServerRepository databaseServerRepository)
        {
            _databaseServerRepository = databaseServerRepository ?? new DatabaseServerRepository();
        }

        #endregion

        /// <summary>
        /// Get all database server.
        /// </summary>
        /// <returns>List of database server.</returns>
        public IEnumerable<DatabaseServer> GetAll(string name = "", bool? isActive = null)
        {
            var criteria = new DatabaseServerGetAllCriteria
            {
                Name = name,
                IsActive = isActive
            };

            if (criteria.IsValid())
            {
                return _databaseServerRepository.Fetch(criteria);
            }

            return null;
        }

        /// <summary>
        /// Insert or update database server.
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
                return _databaseServerRepository.InsertOrUpdate(criteria, logCriteria);
            }

            return null;
        }

        /// <summary>
        /// Update database server status.
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
                return _databaseServerRepository.InsertOrUpdate(criteria, logCriteria);
            }

            return null;
        }

        /// <summary>
        /// Get database server by ID.
        /// </summary>
        /// <param name="id">DB server ID.</param>
        /// <returns>Database server.</returns>
        public DatabaseServer GetById(int id)
        {
            var criteria = new DatabaseServerGetByIdCriteria
            {
                DbServerId = id
            };

            if (criteria.IsValid())
            {
                return _databaseServerRepository.Get(criteria);
            }

            return null;
        }


        public IEnumerable<DatabaseServer> GetAllHasDatabase()
        {
            var criteria = new DatabaseServerGetHasDatabaseCriteria();

            if (criteria.IsValid())
            {
                return _databaseServerRepository.Fetch(criteria);
            }

            return null;
        }
    }
}
