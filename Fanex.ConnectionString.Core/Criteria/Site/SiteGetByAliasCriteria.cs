// --------------------------------------------------------------------------
// <copyright file="SiteGetByAliasCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.1.21">Created</change>
// </history>

namespace Fanex.ConnectionString.Core.Criteria.Site
{
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// Get site by alias criteria.
    /// </summary>
    internal class SiteGetByAliasCriteria : CriteriaBase
    {
        public int AliasId { get; set; }

        public override bool IsValid()
        {
            return true;
        }

        public override string GetSettingKey()
        {
            return "ConnectionString_Site_GetByAlias";
        }
    }
}
