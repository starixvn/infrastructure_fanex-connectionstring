// --------------------------------------------------------------------------
// <copyright file="ConnectionUpdateDefaultCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.1.22">Created</change>
// </history>

namespace Fanex.ConnectionString.Core.Criteria.Connection
{
    using System;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// Update default connection criteria.
    /// </summary>
    public class ConnectionUpdateStatusCriteria : CriteriaBase
    {
        public int Id { get; set; }

        public bool IsActive { get; set; }

        public int Modifier { get; set; }

        public DateTime ModifiedDate { get; set; }

        public override bool IsValid()
        {
            return true;
        }

        public override string GetSettingKey()
        {
            return "ConnectionString_Connection_UpdateStatus";
        }
    }
}
