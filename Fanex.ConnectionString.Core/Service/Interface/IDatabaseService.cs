// --------------------------------------------------------------------------
// <copyright file="IDatabaseService.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.12.5">Created</change>
// </history>

namespace Fanex.ConnectionString.Core.Service.Interface
{
    using System.Collections.Generic;
    using Fanex.ConnectionString.Domain;
    using Fanex.NAP.Framework.Command;

    public interface IDatabaseService
    {
        Database GetById(int id);

        IEnumerable<Database> GetAll(int databaseId = 0, bool? isActive = null);

        IEnumerable<Database> GetByDbServerId(int id);

        ICommandResult Insert(Database database);

        ICommandResult Update(Database database);

        ICommandResult UpdateStatus(int id, bool isActive);
    }
}
