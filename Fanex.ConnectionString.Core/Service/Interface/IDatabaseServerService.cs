// --------------------------------------------------------------------------
// <copyright file="IDatabaseServerService.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.1.21">Created</change>
// </history>

namespace Fanex.ConnectionString.Core.Service.Interface
{
    using System.Collections.Generic;
    using Fanex.ConnectionString.Domain;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// Database server service interface.
    /// </summary>
    public interface IDatabaseServerService
    {
        DatabaseServer GetById(int id);

        IEnumerable<DatabaseServer> GetAll(string name = "", bool? isActive = null);

        IEnumerable<DatabaseServer> GetDatabaseServerHasDatabases();

        ICommandResult Insert(DatabaseServer databaseServer);

        ICommandResult Update(DatabaseServer databaseServer);

        ICommandResult UpdateStatus(int id, bool isActive);
    }
}
