// --------------------------------------------------------------------------
// <copyright file="DatabaseServerGetHasDatabaseCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.12.9">Created</change>
// </history>

namespace Fanex.ConnectionString.Core.Criteria.DatabaseServer
{
    using System;
    using Fanex.NAP.Framework.Data;

    public class DatabaseServerGetHasDatabaseCriteria : CriteriaBase
    {
        public override string GetSettingKey()
        {
            return "ConnectionString_DatabaseServer_GetHasDatabase";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
