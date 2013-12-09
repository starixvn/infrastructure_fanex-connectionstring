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
    using System.Collections.Generic;
    using Fanex.Common.Helper;
    using Fanex.ConnectionString.Core.Criteria.Connection;
    using Fanex.ConnectionString.Core.Repository.Impl;
    using Fanex.ConnectionString.Core.Repository.Interface;
    using Fanex.ConnectionString.Core.Service.Interface;
    using Fanex.ConnectionString.Domain;
    using Fanex.ConnectionString.Model;
    using Fanex.NAP.Core.Criteria.Misc;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// Connection service.
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
        /// Get connection by ID.
        /// </summary>
        /// <param name="id">Connection ID.</param>
        /// <returns>Connection string.</returns>
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
    }
}