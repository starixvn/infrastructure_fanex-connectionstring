// --------------------------------------------------------------------------
// <copyright file="AliasDatabaseService.cs" company="Nexcel Solutions Vietnam">
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
    using Fanex.ConnectionString.Core.Repository.Impl;
    using Fanex.ConnectionString.Core.Repository.Interface;
    using Fanex.ConnectionString.Core.Service.Interface;
    using Fanex.ConnectionString.Domain;
    using Fanex.NAP.Core.Criteria.Misc;
    using Fanex.NAP.Framework.Data;
    using Fanex.ConnectionString.Core.Criteria.Database;

    public class DatabaseService : BaseService, IDatabaseService
    {
        private readonly IDatabaseRepository _aliasDatabaseRepository = new DatabaseRepository();

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

                return _aliasDatabaseRepository.Fetch(criteria);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return list;
        }

        public ICommandResult InsertOrUpdate(ICriteria criteria)
        {
            // check parameters
            Check.Argument.IsNotNull(criteria, "criteria");

            LogExecSpCriteria logCriteria = GetLogExecSpCriteria();

            if (criteria.IsValid() && logCriteria.IsValid())
            {
                return _aliasDatabaseRepository.InsertOrUpdate(criteria, logCriteria);
            }

            return null;
        }

        public Database GetById(int id)
        {
            var aliasDatabase = new Database();

            try
            {
                aliasDatabase = _aliasDatabaseRepository.Get(new DatabaseGetByIdCriteria { DatabaseId = id });
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return aliasDatabase;
        }


        public IEnumerable<Database> GetByDbServerId(int id)
        {
            IEnumerable<Database> list = null;

            try
            {
                list = _aliasDatabaseRepository.Fetch(new DatabaseServerGetByDbServerIdCriteria { DbServerId = id });
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return list;
        }
    }
}
