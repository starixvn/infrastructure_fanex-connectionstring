// --------------------------------------------------------------------------
// <copyright file="DatabaseServerUpdateCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.1.21">Created</change>
// </history>

namespace Fanex.ConnectionString.Core.Criteria.DatabaseServer
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// Update database server criteria.
    /// </summary>
    internal class DatabaseServerUpdateCriteria : CriteriaBase
    {
        private string _name;

        private string _serverIp;

        private string _description;

        public int DbServerId { get; set; }
        
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = !string.IsNullOrWhiteSpace(value) ? value.Trim() : string.Empty;
            }
        }
        
        public string ServerIp
        {
            get
            {
                return _serverIp;
            }

            set
            {
                _serverIp = !string.IsNullOrWhiteSpace(value) ? value.Trim() : string.Empty;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = !string.IsNullOrWhiteSpace(value) ? value.Trim() : string.Empty;
            }
        }

        public bool IsActive { get; set; }

        public int Modifier { get; set; }

        public DateTime ModifiedDate { get; set; }

        public override bool IsValid()
        {
            return true;
        }

        public override string GetSettingKey()
        {
            return "ConnectionString_DatabaseServer_Update";
        }
    }
}
