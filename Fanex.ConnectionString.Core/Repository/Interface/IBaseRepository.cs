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
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using Fanex.NAP.Framework.Data;

    public interface IBaseRepository
    {
        IEnumerable<S> Fetch<S>(
            ICriteria criteria,
            Func<IDataReader, S> mapObjectFunction) where S : class;

        ICommandResult InsertOrUpdate(ICriteria criteria, ICriteria logCriteria);

        CommandResult GetCommandResult(Hashtable hash);
    }
}
