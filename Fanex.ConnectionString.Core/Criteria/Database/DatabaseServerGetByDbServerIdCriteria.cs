// --------------------------------------------------------------------------
// <copyright file="DatabaseServerGetByDbServerIdCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.12.9">Created</change>
// </history>

namespace Fanex.ConnectionString.Core.Criteria.Database
{
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// The database server get by database server identifier criteria class.
    /// </summary>
    internal class DatabaseServerGetByDbServerIdCriteria : CriteriaBase
    {
        public int DbServerId { get; set; }

        public override bool IsValid()
        {
            return DbServerId >= 0;
        }

        public override string GetSettingKey()
        {
            return "ConnectionString_Database_GetByDbServerId";
        }
    }
}
