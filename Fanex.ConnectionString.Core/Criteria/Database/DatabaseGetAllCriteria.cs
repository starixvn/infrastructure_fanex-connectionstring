// --------------------------------------------------------------------------
// <copyright file="DatabaseGetAllCriteria.cs" company="Nexcel Solutions Vietnam">
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
    /// The database get all criteria class.
    /// </summary>
    internal class DatabaseGetAllCriteria : CriteriaBase
    {
        public int DbServerId { get; set; }

        public bool? IsActive { get; set; }

        public override string GetSettingKey()
        {
            return "ConnectionString_Database_GetAll";
        }

        public override bool IsValid()
        {
            return DbServerId >= 0;
        }
    }
}
