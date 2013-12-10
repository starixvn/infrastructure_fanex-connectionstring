// --------------------------------------------------------------------------
// <copyright file="ConnectionRemoveSiteCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.12.10">Created</change>
// </history>

namespace Fanex.ConnectionString.Core.Criteria.Connection
{
    using Fanex.NAP.Framework.Data;

    internal class ConnectionRemoveSiteCriteria : CriteriaBase
    {
        public int ConnectionId { get; set; }

        public int SiteId { get; set; }

        public override string GetSettingKey()
        {
            return "ConnectionString_Connection_RemoveSite";
        }

        public override bool IsValid()
        {
            return ConnectionId > 0 && SiteId > 0;
        }
    }
}
