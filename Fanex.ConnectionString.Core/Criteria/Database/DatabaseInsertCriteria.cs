// --------------------------------------------------------------------------
// <copyright file="AliasDatabaseInsertCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.12.5">Created</change>
// </history>

namespace Fanex.ConnectionString.Core.Criteria.AliasDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Fanex.NAP.Framework.Data;

    public class DatabaseInsertCriteria : CriteriaBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ServerAlias { get; set; }

        public int DbServerId { get; set; }

        public bool IsActive { get; set; }

        public int Creator { get; set; }

        public DateTime CreatedDate { get; set; }

        public override string GetSettingKey()
        {
            return "ConnectionString_Database_Insert";
        }

        public override bool IsValid()
        {
            return DbServerId > 0;
        }
    }
}
