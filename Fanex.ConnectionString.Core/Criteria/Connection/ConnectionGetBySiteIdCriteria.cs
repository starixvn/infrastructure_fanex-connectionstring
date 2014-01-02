// --------------------------------------------------------------------------
// <copyright file="ConnectionGetBySiteIdCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.12.16">Created</change>
// </history>

namespace Fanex.ConnectionString.Core.Criteria.Connection
{
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// The connection get by site criteria class.
    /// </summary>
    public class ConnectionGetBySiteIdCriteria : CriteriaBase
    {
        public int SiteId { get; set; }

        public override string GetSettingKey()
        {
            return "ConnectionString_Connection_GetBySiteId";
        }

        public override bool IsValid()
        {
            return SiteId > 0;
        }
    }
}
