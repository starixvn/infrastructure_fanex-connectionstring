// --------------------------------------------------------------------------
// <copyright file="ConnectionService.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.1.22">Created</change>
// </history>

namespace Fanex.ConnectionString.Core.Service.Impl
{
    using System;
    using System.Collections.Generic;
    using Fanex.Common.Helper;
    using Fanex.ConnectionString.Core.Criteria.Connection;
    using Fanex.ConnectionString.Core.Repository.Impl;
    using Fanex.ConnectionString.Core.Repository.Interface;
    using Fanex.ConnectionString.Core.Service.Interface;
    using Fanex.ConnectionString.Domain;
    using Fanex.NAP.Core.Criteria.Misc;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// Connection service class.
    /// </summary>
    public class ConnectionService : BaseService, IConnectionService
    {
        #region Member

        private readonly IConnectionRepository _connectionRepository;

        #endregion Member

        #region Ctor

        public ConnectionService()
            : this(null)
        {
        }

        public ConnectionService(IConnectionRepository connectionRepository)
        {
            _connectionRepository = connectionRepository ?? new ConnectionRepository();
        }

        #endregion Ctor

        /// <summary>
        /// Gets the connection by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Connection information.</returns>
        public Connection GetById(int id)
        {
            Check.Argument.IsNotNegativeOrZero(id, "id");

            var criteria = new ConnectionGetByIdCriteria
            {
                ConnectionId = id
            };

            if (criteria.IsValid())
            {
                return _connectionRepository.Get(criteria);
            }

            return null;
        }

        /// <summary>
        /// Gets connection by database server id.
        /// </summary>
        /// <param name="dbServerId">The database server identifier.</param>
        /// <returns>Connection collection.</returns>
        public IEnumerable<Connection> GetAll(int dbServerId = 0)
        {
            Check.Argument.IsNotNegative(dbServerId, "dbServerId");

            var criteria = new ConnectionGetAllCriteria
            {
                DbServerId = dbServerId
            };

            if (criteria.IsValid())
            {
                return _connectionRepository.Fetch(criteria);
            }

            return null;
        }

        /// <summary>
        /// Insert or update connection.
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
                return _connectionRepository.InsertOrUpdate(criteria, logCriteria);
            }

            return null;
        }


        /// <summary>
        /// Inserts the specified connection.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <returns>The status of command.</returns>
        public ICommandResult Insert(Connection connection)
        {
            Check.Argument.IsNotNull(connection, "connection");
            Check.Argument.IsNotEmpty(connection.Name, "Name");
            Check.Argument.IsNotNegativeOrZero(connection.DatabaseServer.Id, "DatabaseServer.Id");
            Check.Argument.IsNotNegativeOrZero(connection.Database.Id, "Database.Id");

            LogExecSpCriteria logCriteria = GetLogExecSpCriteria();

            var criteria = new ConnectionInsertCriteria
            {
                CreatedDate = DateTime.Now,
                Creator = ServiceContext.UserId,
                DatabaseId = connection.Database.Id,
                DbServerId = connection.DatabaseServer.Id,
                FreeText = connection.FreeText,
                Id = connection.Id,
                IsActive = connection.IsActive,
                LoginName = connection.LoginName,
                Name = connection.Name,
                Password = connection.Password
            };

            if (criteria.IsValid() && logCriteria.IsValid())
            {
                return _connectionRepository.InsertOrUpdate(criteria, logCriteria);
            }

            return new CommandResult { Code = -1 };
        }

        /// <summary>
        /// Updates the specified connection.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <returns>The status of command.</returns>
        public ICommandResult Update(Connection connection)
        {
            Check.Argument.IsNotNull(connection, "connection");
            Check.Argument.IsNotEmpty(connection.Name, "Name");
            Check.Argument.IsNotNegativeOrZero(connection.DatabaseServer.Id, "DatabaseServer.Id");
            Check.Argument.IsNotNegativeOrZero(connection.Database.Id, "Database.Id");

            LogExecSpCriteria logCriteria = GetLogExecSpCriteria();

            var criteria = new ConnectionUpdateCriteria
            {
                ModifiedDate = DateTime.Now,
                Modifier = ServiceContext.UserId,
                DatabaseId = connection.Database.Id,
                DbServerId = connection.DatabaseServer.Id,
                FreeText = connection.FreeText,
                Id = connection.Id,
                IsActive = connection.IsActive,
                LoginName = connection.LoginName,
                Name = connection.Name,
                Password = connection.Password
            };

            if (criteria.IsValid() && logCriteria.IsValid())
            {
                return _connectionRepository.InsertOrUpdate(criteria, logCriteria);
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

            var criteria = new ConnectionUpdateStatusCriteria
            {
                Id = id,
                IsActive = isActive,
                ModifiedDate = DateTime.Now,
                Modifier = this.ServiceContext.UserId
            };

            LogExecSpCriteria logCriteria = GetLogExecSpCriteria();

            if (criteria.IsValid() && logCriteria.IsValid())
            {
                return _connectionRepository.InsertOrUpdate(criteria, logCriteria);
            }

            return new CommandResult { Code = -1 };
        }

        /// <summary>
        /// Switches the database server of connection.
        /// </summary>
        /// <param name="ids">The array connection id.</param>
        /// <param name="toDbServerId">To database server identifier.</param>
        /// <returns>The status of command.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public ICommandResult SwitchDbServer(string ids, int toDbServerId)
        {
            Check.Argument.IsNotEmpty(ids, "ids");
            Check.Argument.IsNotNegativeOrZero(toDbServerId, "toDbServerId");

            var criteria = new ConnectionSwitchDbServerCriteria
            {
                ConnectionIds = ids,
                ToDbServerId = toDbServerId,
                ModifiedDate = DateTime.Now,
                Modifier = this.ServiceContext.UserId
            };

            LogExecSpCriteria logCriteria = GetLogExecSpCriteria();

            if (criteria.IsValid() && logCriteria.IsValid())
            {
                return _connectionRepository.InsertOrUpdate(criteria, logCriteria);
            }

            return new CommandResult { Code = -1 };
        }

        /// <summary>
        /// Assigns the site for connection.
        /// </summary>
        /// <param name="connectionId">The connection identifier.</param>
        /// <param name="siteId">The site identifier.</param>
        /// <returns>The status of command.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public ICommandResult AssignSite(int connectionId, int siteId)
        {
            Check.Argument.IsNotNegativeOrZero(connectionId, "connectionId");
            Check.Argument.IsNotNegativeOrZero(siteId, "siteId");

            var criteria = new ConnectionAssignSiteCriteria
            {
                ConnectionId = connectionId,
                SiteId = siteId
            };

            LogExecSpCriteria logCriteria = GetLogExecSpCriteria();

            if (criteria.IsValid() && logCriteria.IsValid())
            {
                return _connectionRepository.InsertOrUpdate(criteria, logCriteria);
            }

            return new CommandResult { Code = -1 };
        }


        public ICommandResult RemoveSite(int connectionId, int siteId)
        {
            Check.Argument.IsNotNegativeOrZero(connectionId, "connectionId");
            Check.Argument.IsNotNegativeOrZero(siteId, "siteId");

            var criteria = new ConnectionRemoveSiteCriteria
            {
                ConnectionId = connectionId,
                SiteId = siteId
            };

            LogExecSpCriteria logCriteria = GetLogExecSpCriteria();

            if (criteria.IsValid() && logCriteria.IsValid())
            {
                return _connectionRepository.InsertOrUpdate(criteria, logCriteria);
            }

            return new CommandResult { Code = -1 };
        }
    }
}