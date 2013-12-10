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
    using System;
    using System.Collections.Generic;
    using Fanex.Common.Helper;
    using Fanex.ConnectionString.Core.Criteria.DatabaseServer;
    using Fanex.ConnectionString.Core.Repository.Impl;
    using Fanex.ConnectionString.Core.Repository.Interface;
    using Fanex.ConnectionString.Core.Service.Interface;
    using Fanex.ConnectionString.Domain;
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
        /// Gets the database server by identifier.
        /// </summary>
        /// <param name="id">The database server identifier.</param>
        /// <returns>The database server information.</returns>
        public DatabaseServer GetById(int id)
        {
            Check.Argument.IsNotNegativeOrZero(id, "id");

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

        /// <summary>
        /// Gets all the database information.
        /// </summary>
        /// <param name="name">The search name.</param>
        /// <param name="isActive">The is active.</param>
        /// <returns>Database server collection.</returns>
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
        /// Gets the database server has databases.
        /// </summary>
        /// <returns>Database server collection.</returns>
        public IEnumerable<DatabaseServer> GetDatabaseServerHasDatabases()
        {
            var criteria = new DatabaseServerGetHasDatabaseCriteria();

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
        /// Inserts the specified database server.
        /// </summary>
        /// <param name="databaseServer">The database server.</param>
        /// <returns>The status of command.</returns>
        public ICommandResult Insert(DatabaseServer databaseServer)
        {
            Check.Argument.IsNotNull(databaseServer, "databaseServer");
            Check.Argument.IsNotEmpty(databaseServer.Name, "Name");
            Check.Argument.IsNotEmpty(databaseServer.ServerIP, "ServerIP");

            LogExecSpCriteria logCriteria = GetLogExecSpCriteria();

            var criteria = new DatabaseServerInsertCriteria
            {
                CreatedDate = DateTime.Now,
                Creator = this.ServiceContext.UserId,
                DbServerId = databaseServer.Id,
                Description = databaseServer.Description,
                IsActive = databaseServer.IsActive,
                Name = databaseServer.Name,
                ServerIp = databaseServer.ServerIP
            };

            if (criteria.IsValid() && logCriteria.IsValid())
            {
                return _databaseServerRepository.InsertOrUpdate(criteria, logCriteria);
            }

            return new CommandResult { Code = -1 };
        }

        /// <summary>
        /// Updates the specified database server.
        /// </summary>
        /// <param name="databaseServer">The database server.</param>
        /// <returns>The status of command.</returns>
        public ICommandResult Update(DatabaseServer databaseServer)
        {
            Check.Argument.IsNotNull(databaseServer, "databaseServer");
            Check.Argument.IsNotEmpty(databaseServer.Name, "Name");
            Check.Argument.IsNotEmpty(databaseServer.ServerIP, "ServerIP");

            LogExecSpCriteria logCriteria = GetLogExecSpCriteria();

            var criteria = new DatabaseServerUpdateCriteria
            {
                ModifiedDate = DateTime.Now,
                Modifier = this.ServiceContext.UserId,
                DbServerId = databaseServer.Id,
                Description = databaseServer.Description,
                IsActive = databaseServer.IsActive,
                Name = databaseServer.Name,
                ServerIp = databaseServer.ServerIP
            };

            if (criteria.IsValid() && logCriteria.IsValid())
            {
                return _databaseServerRepository.InsertOrUpdate(criteria, logCriteria);
            }

            return new CommandResult { Code = -1 };
        }

        /// <summary>
        /// Updates the status.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="isActive">If set to <c>true</c> [is active].</param>
        /// <returns>The status of command.</returns>
        public ICommandResult UpdateStatus(int id, bool isActive)
        {
            Check.Argument.IsNotNegativeOrZero(id, "id");

            LogExecSpCriteria logCriteria = GetLogExecSpCriteria();

            var criteria = new DatabaseServerUpdateStatusCriteria
            {
                ModifiedDate = DateTime.Now,
                Modifier = this.ServiceContext.UserId,
                DbServerId = id,
                IsActive = isActive
            };

            if (criteria.IsValid() && logCriteria.IsValid())
            {
                return _databaseServerRepository.InsertOrUpdate(criteria, logCriteria);
            }

            return new CommandResult { Code = -1 };
        }
    }
}
