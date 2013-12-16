// --------------------------------------------------------------------------
// <copyright file="IDatabaseRepository.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.12.5">Created</change>
// </history>

namespace Fanex.ConnectionString.Core.Repository.Interface
{
    using Fanex.ConnectionString.Domain;
    using Fanex.NAP.Framework.Data;

    public interface IDatabaseRepository : IBaseRepository, IReadonlyRepository<Database>
    {
    }
}
