// --------------------------------------------------------------------------
// <copyright file="ILogService.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.1.28">Created</change>
// </history>

namespace Fanex.ConnectionString.Core.Service.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Fanex.ConnectionString.Domain;
    using Fanex.ConnectionString.Model;

    /// <summary>
    /// Log service interface.
    /// </summary>
    public interface ILogService
    {
        IQueryable<LogExecSp> SearchLog(
          int pageIndex,
          int pageSize,
          ref int totalRows,
          string name,
          string username,
          DateTime from,
          DateTime to,
          int filterBy = 0);
    }
}
