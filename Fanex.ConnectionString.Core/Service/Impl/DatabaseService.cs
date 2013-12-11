// --------------------------------------------------------------------------
// <copyright file="DatabaseService.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.12.5">Created</change>
// </history>

namespace Fanex.ConnectionString.Core.Service.Impl
{
    using System;
    using System.Collections.Generic;
    using Fanex.Common.Helper;
    using Fanex.ConnectionString.Core.Criteria.AliasDatabase;
    using Fanex.ConnectionString.Core.Criteria.Database;
    using Fanex.ConnectionString.Core.Repository.Impl;
    using Fanex.ConnectionString.Core.Repository.Interface;
    using Fanex.ConnectionString.Core.Service.Interface;
    using Fanex.ConnectionString.Domain;
    using Fanex.NAP.Core.Criteria.Misc;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// Database service class.
    /// </summary>
    public class DatabaseService : BaseService, IDatabaseService
    {
        private readonly IDatabaseRepository _databaseRepository = new DatabaseRepository();

        /// <summary>
        /// Gets the database by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The database information.</returns>
        public Database GetById(int id)
        {
            Check.Argument.IsNotNegativeOrZero(id, "id");

            var aliasDatabase = new Database();

            try
            {
                aliasDatabase = _databaseRepository.Get(new DatabaseGetByIdCriteria { DatabaseId = id });
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return aliasDatabase;
        }

        /// <summary>
        /// Gets all database information.
        /// </summary>
        /// <param name="databaseId">The database identifier.</param>
        /// <param name="isActive">The is active.</param>
        /// <returns>Database collection.</returns>
        public IEnumerable<Database> GetAll(int databaseId = 0, bool? isActive = null)
        {
            IEnumerable<Database> list = null;

            try
            {
                var criteria = new DatabaseGetAllCriteria
                {
                    DbServerId = databaseId,
                    IsActive = isActive
                };

                return _databaseRepository.Fetch(criteria);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return list;
        }

        /// <summary>
        /// Gets the database by database server identifier.
        /// </summary>
        /// <param name="id">The database server identifier.</param>
        /// <returns>Database collection.</returns>
        public IEnumerable<Database> GetByDbServerId(int id)
        {
            IEnumerable<Database> list = null;

            try
            {
                list = _databaseRepository.Fetch(new DatabaseServerGetByDbServerIdCriteria { DbServerId = id });
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return list;
        }

        /// <summary>
        /// Inserts the specified database.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <returns>The status of command.</returns>
        public ICommandResult Insert(Database database)
        {
            Check.Argument.IsNotNull(database, "database");
            Check.Argument.IsNotEmpty(database.Name, "Name");
            Check.Argument.IsNotNegativeOrZero(database.DatabaseServer.Id, "DBServerId");
            Check.Argument.IsNotEmpty(database.ServerAlias, "ServerAlias");

            LogExecSpCriteria logCriteria = GetLogExecSpCriteria();

            var criteria = new DatabaseInsertCriteria
            {
                CreatedDate = DateTime.Now,
                Creator = ServiceContext.UserId,
                DbServerId = database.DatabaseServer.Id,
                DatabaseId = database.Id,
                IsActive = database.IsActive,
                Name = database.Name,
                ServerAlias = database.ServerAlias
            };

            if (criteria.IsValid() && logCriteria.IsValid())
            {
                return _databaseRepository.InsertOrUpdate(criteria, logCriteria);
            }

            return new CommandResult { Code = -1 };
        }

        /// <summary>
        /// Updates the specified database.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <returns>The status of command.</returns>
        public ICommandResult Update(Database database)
        {
            Check.Argument.IsNotNull(database, "database");
            Check.Argument.IsNotEmpty(database.Name, "Name");
            Check.Argument.IsNotNegativeOrZero(database.Id, "Id");
            Check.Argument.IsNotNegativeOrZero(database.DatabaseServer.Id, "DBServerId");
            Check.Argument.IsNotEmpty(database.ServerAlias, "ServerAlias");

            LogExecSpCriteria logCriteria = GetLogExecSpCriteria();

            var criteria = new DatabaseUpdateCriteria
            {
                ModifiedDate = DateTime.Now,
                Modifier = ServiceContext.UserId,
                DbServerId = database.DatabaseServer.Id,
                DatabaseId = database.Id,
                IsActive = database.IsActive,
                Name = database.Name,
                ServerAlias = database.ServerAlias
            };

            if (criteria.IsValid() && logCriteria.IsValid())
            {
                return _databaseRepository.InsertOrUpdate(criteria, logCriteria);
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

            var criteria = new DatabaseUpdateStatusCriteria
            {
                DatabaseId = id,
                IsActive = isActive,
                ModifiedDate = DateTime.Now,
                Modifier = this.ServiceContext.UserId
            };

            LogExecSpCriteria logCriteria = GetLogExecSpCriteria();

            if (criteria.IsValid() && logCriteria.IsValid())
            {
                return _databaseRepository.InsertOrUpdate(criteria, logCriteria);
            }

            return new CommandResult { Code = -1 };
        }
    }
}
