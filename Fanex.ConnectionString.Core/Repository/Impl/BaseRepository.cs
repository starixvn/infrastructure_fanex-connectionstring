// --------------------------------------------------------------------------
// <copyright file="BaseRepository.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2012.10.8">Created</change>
//   <change who="Ricky.Nguyen" date="2012.10.9">Add Fetchm, Get Datatable Function</change>
// </history>

namespace Fanex.ConnectionString.Core.Repository.Impl
{
    using System;
    using System.Collections;
    using Fanex.ConnectionString.Core.Repository.Interface;
    using Fanex.Data;
    using Fanex.NAP.Core.Criteria.Misc;
    using Fanex.NAP.Framework.Command;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// Base repository.
    /// </summary>
    /// <typeparam name="T">The element type of the class.</typeparam>
    public class BaseRepository<T> : ReadonlyRepository<T>, IBaseRepository
    {
        /// <summary>
        /// Inserts the or update.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <param name="logCriteria">The log criteria.</param>
        /// <returns>Status of command.</returns>
        public ICommandResult InsertOrUpdate(ICriteria criteria, ICriteria logCriteria)
        {
            Hashtable hash = criteria.GetSpParams();

            hash = logCriteria.AddSpParams(hash);
            hash = (new ResultCriteria()).AddSpParams(hash);

            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                db.ExecuteNonQuery(hash);

                return GetCommandResult(hash);
            }
        }

        /// <summary>
        /// Get command result.
        /// </summary>
        /// <param name="hash">Hash command result.</param>
        /// <returns>Command result.</returns>
        public CommandResult GetCommandResult(Hashtable hash)
        {
            var errCode = hash["errcode"];
            var errMsg = hash["errmsg"];

            return new CommandResult
            {
                Code = (errCode is DBNull) ? 0 : Convert.ToInt32(errCode),
                Message = (errMsg is DBNull) ? string.Empty : Convert.ToString(errMsg)
            };
        }
    }
}