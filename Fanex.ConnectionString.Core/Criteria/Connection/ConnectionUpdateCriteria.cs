// --------------------------------------------------------------------------
// <copyright file="ConnectionUpdateCriteria.cs" company="Nexcel Solutions Vietnam">
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
    /// Update connection criteria.
    /// </summary>
    internal class ConnectionUpdateCriteria : CriteriaBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DbServerId { get; set; }

        public int DatabaseId { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }

        public string FreeText { get; set; }

        public bool IsActive { get; set; }

        public int Modifier { get; set; }

        public DateTime ModifiedDate { get; set; }

        public override bool IsValid()
        {
            return true;
        }

        public override string GetSettingKey()
        {
            return "ConnectionString_Connection_Update";
        }
    }
}
