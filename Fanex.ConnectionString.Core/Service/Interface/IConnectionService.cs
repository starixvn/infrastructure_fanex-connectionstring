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
        Connection GetById(int id);

        IEnumerable<Connection> GetAll(int databaseServerId = 0);

        IEnumerable<Connection> GetBySiteId(int siteId);

        ICommandResult Insert(Connection connection);

        ICommandResult Update(Connection connection);

        ICommandResult UpdateStatus(int id, bool isActive);

        ICommandResult SwitchDbServer(string ids, int toDbServerId);

        ICommandResult AssignSite(int connectionId, int siteId);

        ICommandResult RemoveSite(int connectionId, int siteId);
    }
}
