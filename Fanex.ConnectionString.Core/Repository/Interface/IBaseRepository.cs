// --------------------------------------------------------------------------
// <copyright file="IBaseRepository.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.12.5">Created</change>
// </history>

namespace Fanex.ConnectionString.Core.Repository.Interface
{
    using System.Collections;
    using Fanex.NAP.Framework.Data;

    public interface IBaseRepository
    {
        ICommandResult InsertOrUpdate(ICriteria criteria, ICriteria logCriteria);

        CommandResult GetCommandResult(Hashtable hash);
    }
}
