// --------------------------------------------------------------------------
// <copyright file="IConnectionRepository.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.1.22">Created</change>
// </history>

namespace Fanex.ConnectionString.Core.Repository.Interface
{
    using Fanex.ConnectionString.Domain;
    using Fanex.NAP.Framework.Data;

    public interface IConnectionRepository : IBaseRepository, IReadonlyRepository<Connection>
    {
    }
}
