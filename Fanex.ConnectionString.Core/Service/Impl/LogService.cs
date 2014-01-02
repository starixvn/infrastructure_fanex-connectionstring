// --------------------------------------------------------------------------
// <copyright file="LogService.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.1.28">Created</change>
// </history>

namespace Fanex.ConnectionString.Core.Service.Impl
{
    using System;
    using System.Linq;
    using Fanex.ConnectionString.Core.Criteria.LogExecSp;
    using Fanex.ConnectionString.Core.Repository.Impl;
    using Fanex.ConnectionString.Core.Repository.Interface;
    using Fanex.ConnectionString.Core.Service.Interface;
    using Fanex.ConnectionString.Model;

    /// <summary>
    /// The log service class.
    /// </summary>
    public class LogService : BaseService, ILogService
    {
        private readonly ILogRepository _logRepository;

        public LogService()
            : this(null)
        {
        }

        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository ?? new LogRepository();
        }

        /// <summary>
        /// Search execute SP log.
        /// </summary>
        /// <param name="pageIndex">Page index.</param>
        /// <param name="pageSize">Number of items per page.</param>
        /// <param name="totalRows">Number of rows.</param>
        /// <param name="name">Log name filter.</param>
        /// <param name="username">Username filter.</param>
        /// <param name="from">From DateTime.</param>
        /// <param name="to">To DateTime.</param>
        /// <param name="filterBy">Filter options.</param>
        /// <returns>List of execute SP log.</returns>
        public IQueryable<LogExecSp> SearchLog(
            int pageIndex,
            int pageSize,
            ref int totalRows,
            string name,
            string username,
            DateTime from,
            DateTime to,
            int filterBy = 0)
        {
            IQueryable<LogExecSp> logList = null;
            totalRows = 0;

            var criteria = new LogExecSpSearchCriteria
            {
                Username = username,
                Name = name,
                From = from,
                To = to,
                FilterType = filterBy,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            if (criteria.IsValid())
            {
                logList = _logRepository.Fetch(criteria, out totalRows).AsQueryable();
            }

            return logList;
        }
    }
}