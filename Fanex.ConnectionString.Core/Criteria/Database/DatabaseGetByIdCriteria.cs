// --------------------------------------------------------------------------
// <copyright file="DatabaseGetByIdCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.12.5">Created</change>
// </history>

namespace Fanex.ConnectionString.Core.Criteria.AliasDatabase
{
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// The database get by identifier criteria class.
    /// </summary>
    internal class DatabaseGetByIdCriteria : CriteriaBase
    {
        public int DatabaseId { get; set; }

        public override string GetSettingKey()
        {
            return "ConnectionString_Database_Get";
        }

        public override bool IsValid()
        {
            return DatabaseId > 0;
        }
    }
}
