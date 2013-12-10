// --------------------------------------------------------------------------
// <copyright file="DatabaseServerGetAllCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.1.21">Created</change>
// </history>

namespace Fanex.ConnectionString.Core.Criteria.DatabaseServer
{
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// Get all database server criteria.
    /// </summary>
    internal class DatabaseServerGetAllCriteria : CriteriaBase
    {
        public string Name { get; set; }

        public bool? IsActive { get; set; }

        public override bool IsValid()
        {
            return true;
        }

        public override string GetSettingKey()
        {
            return "ConnectionString_DatabaseServer_GetAll";
        }
    }
}
