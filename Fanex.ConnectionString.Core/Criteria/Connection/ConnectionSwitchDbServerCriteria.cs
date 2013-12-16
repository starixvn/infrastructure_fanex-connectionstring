// --------------------------------------------------------------------------
// <copyright file="ConnectionSwitchDbServerCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.12.10">Created</change>
// </history>

namespace Fanex.ConnectionString.Core.Criteria.Connection
{
    using System;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// The connection switch database server criteria class.
    /// </summary>
    internal class ConnectionSwitchDbServerCriteria : CriteriaBase
    {
        public string ConnectionIds { get; set; }

        public int ToDbServerId { get; set; }

        public int Modifier { get; set; }

        public DateTime ModifiedDate { get; set; }

        public override string GetSettingKey()
        {
            return "ConnectionString_Connection_SwitchDbServer";
        }

        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(ConnectionIds);
        }
    }
}
