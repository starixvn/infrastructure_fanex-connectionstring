// --------------------------------------------------------------------------
// <copyright file="SiteGetAllCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.1.21">Created</change>
// </history>

namespace Fanex.ConnectionString.Core.Criteria.Site
{
    using System.ComponentModel.DataAnnotations;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// Get all site criteria.
    /// </summary>
    internal class SiteGetAllCriteria : CriteriaBase
    {
        private string _name;

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

        public bool? IsActive { get; set; }

        public override bool IsValid()
        {
            return true;
        }

        public override string GetSettingKey()
        {
            return "ConnectionString_Site_GetAll";
        }
    }
}
