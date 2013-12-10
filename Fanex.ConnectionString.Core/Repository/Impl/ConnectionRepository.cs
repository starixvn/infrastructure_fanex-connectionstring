// --------------------------------------------------------------------------
// <copyright file="ConnectionRepository.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.1.22">Created</change>
// </history>

namespace Fanex.ConnectionString.Core.Repository.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Fanex.ConnectionString.Core.Repository.Interface;
    using Fanex.ConnectionString.Domain;
    using Fanex.Data;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// Connection repository.
    /// </summary>
    public class ConnectionRepository : BaseRepository<Connection>, IConnectionRepository
    {
        public override IEnumerable<Connection> Fetch(ICriteria criteria)
        {
            try
            {
                IEnumerable<Connection> list = null;

                using (ObjectDb objDb = new ObjectDb(criteria.GetSettingKey()))
                {
                    list = objDb.Query<Connection, Users, Users, DatabaseServer, Database, Connection>(
                        func: (c, uc, um, ds, d) => { c.Creator = uc; c.Modifier = um; c.DatabaseServer = ds; c.Database = d; return c; },
                        splitOn: "CreatorId,ModifierId,DbServerId,DatabaseId",
                        parameterValues: criteria.GetSpParams());
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override Connection Get(ICriteria criteria)
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
    }
}