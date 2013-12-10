// --------------------------------------------------------------------------
// <copyright file="ISiteRepository.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.1.21">Created</change>
// </history>

namespace Fanex.ConnectionString.Core.Repository.Interface
{
    using Fanex.ConnectionString.Domain;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// Site repository interface.
    /// </summary>
    public interface ISiteRepository : IBaseRepository, IReadonlyRepository<Site>
    {
    }
}
