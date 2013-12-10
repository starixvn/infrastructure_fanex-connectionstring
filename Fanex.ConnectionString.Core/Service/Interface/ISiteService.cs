// --------------------------------------------------------------------------
// <copyright file="ISiteService.cs" company="Nexcel Solutions Vietnam">
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
    /// Site service interface.
    /// </summary>
    public interface ISiteService
    {
        Site GetById(int id);

        IEnumerable<Site> GetAll(string name = "", bool? isActive = null);

        IEnumerable<Site> GetByConnectionId(int connectionId);

        ICommandResult Insert(Site site);

        ICommandResult Update(Site site);

        ICommandResult UpdateStatus(int id, bool isActive);
    }
}
