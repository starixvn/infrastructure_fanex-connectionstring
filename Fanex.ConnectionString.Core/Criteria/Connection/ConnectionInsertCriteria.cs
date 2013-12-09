// --------------------------------------------------------------------------
// <copyright file="ConnectionInsertCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.1.22">Created</change>
// </history>

namespace Fanex.ConnectionString.Core.Criteria.Connection
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// Insert connection criteria.
    /// </summary>
    public class ConnectionInsertCriteria : CriteriaBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DbServerId { get; set; }

        public int DatabaseId { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }

        public string FreeText { get; set; }

        public bool IsActive { get; set; }

        public int Creator { get; set; }

        public DateTime CreatedDate { get; set; }

        public override bool IsValid()
        {
            return true;
        }

        public override string GetSettingKey()
        {
            return "ConnectionString_Connection_Insert";
        }
    }
}
