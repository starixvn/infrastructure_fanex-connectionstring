// --------------------------------------------------------------------------
// <copyright file="AliasDatabaseRepository.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.12.5">Created</change>
// </history>

namespace Fanex.ConnectionString.Core.Repository.Impl
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Fanex.ConnectionString.Core.Repository.Interface;
    using Fanex.ConnectionString.Domain;
    using Fanex.Data;
    using Fanex.NAP.Framework.Data;
    using System.Linq;

    public class DatabaseRepository : BaseRepository<Database>, IDatabaseRepository
    {
        public override Database Get(ICriteria criteria)
        {
            try
            {
                var list = this.Fetch(criteria);

                if (!ReferenceEquals(list, null))
                {
                    return list.ToList().FirstOrDefault();
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override IEnumerable<Database> Fetch(ICriteria criteria)
        {
            try
            {
                IEnumerable<Database> list = null;

                using (ObjectDb objDb = new ObjectDb(criteria.GetSettingKey()))
                {
                    list = objDb.Query<Database, Users, Users, DatabaseServer, Database>(
                        func: (a, uc, um, d) => { a.Creator = uc; a.Modifier = um; a.DatabaseServer = d; return a; },
                        splitOn: "CreatorId,ModifierId,DbServerId",
                        parameterValues: criteria.GetSpParams());
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
