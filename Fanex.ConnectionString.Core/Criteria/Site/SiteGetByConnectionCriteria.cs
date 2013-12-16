// --------------------------------------------------------------------------
// <copyright file="SiteGetByConnectionCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.12.10">Created</change>
// </history>

namespace Fanex.ConnectionString.Core.Criteria.Site
{
    using System;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// The site get by connection criteria class.
    /// </summary>
    internal class SiteGetByConnectionCriteria : CriteriaBase
    {
        public int ConnectionId { get; set; }

        public override string GetSettingKey()
        {
            return "ConnectionString_Site_GetByConnection";
        }

        public override bool IsValid()
        {
            return ConnectionId > 0;
        }
    }
}
