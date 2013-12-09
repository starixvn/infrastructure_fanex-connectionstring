// --------------------------------------------------------------------------
// <copyright file="IConnectionService.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.1.22">Created</change>
// </history>

namespace Fanex.ConnectionString.Core.Service.Interface
{
    using System.Collections.Generic;
    using Fanex.ConnectionString.Domain;
    using Fanex.ConnectionString.Model;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// Connection service interface.
    /// </summary>
    public interface IConnectionService
    {
        IEnumerable<Connection> GetAll(int dbServerId = 0);

        Connection GetById(int id);

        ICommandResult InsertOrUpdate(ICriteria criteria);
    }
}
