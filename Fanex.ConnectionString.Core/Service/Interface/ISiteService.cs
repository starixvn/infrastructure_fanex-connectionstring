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
        IEnumerable<Site> GetAll(string name = "", bool? isActive = null);

        Site GetById(int id);

        ICommandResult InsertOrUpdate(ICriteria criteria);
    }
}
