// --------------------------------------------------------------------------
// <copyright file="ILogRepository.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.1.28">Created</change>
// </history>

namespace Fanex.ConnectionString.Core.Repository.Interface
{
    using System.Collections.Generic;
    using Fanex.ConnectionString.Model;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// Log repository interface.
    /// </summary>
    public interface ILogRepository : IBaseRepository
    {
        IEnumerable<LogExecSp> Fetch(ICriteria criteria, out int totalRows);

        LogExecSp GetById(ICriteria criteria);
    }
}
