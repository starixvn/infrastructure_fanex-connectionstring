// --------------------------------------------------------------------------
// <copyright file="DatabaseUpdateStatusCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.12.5">Created</change>
// </history>

namespace Fanex.ConnectionString.Core.Criteria.AliasDatabase
{
    using System;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// The database update status criteria class.
    /// </summary>
    internal class DatabaseUpdateStatusCriteria : CriteriaBase
    {
        public int DatabaseId { get; set; }
        
        public bool IsActive { get; set; }

        public int Modifier { get; set; }

        public DateTime ModifiedDate { get; set; }

        public override string GetSettingKey()
        {
            return "ConnectionString_Database_UpdateStatus";
        }

        public override bool IsValid()
        {
            return DatabaseId > 0;
        }
    }
}
