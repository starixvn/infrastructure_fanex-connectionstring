// --------------------------------------------------------------------------
// <copyright file="ConnectionGetAllCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.1.22">Created</change>
// </history>

namespace Fanex.ConnectionString.Core.Criteria.Connection
{
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// Get connection by ID criteria.
    /// </summary>
    internal class ConnectionGetAllCriteria : CriteriaBase
    {
        public int DbServerId { get; set; }

        public override bool IsValid()
        {
            return DbServerId >= 0;
        }

        public override string GetSettingKey()
        {
            return "ConnectionString_Connection_GetAll";
        }
    }
}
