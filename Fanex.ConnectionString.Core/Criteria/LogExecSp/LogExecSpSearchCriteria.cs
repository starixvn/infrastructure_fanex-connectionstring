// --------------------------------------------------------------------------
// <copyright file="LogExecSpSearchCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.1.28">Created</change>
// </history>

namespace Fanex.ConnectionString.Core.Criteria.LogExecSp
{
    using System;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// Search execute SP log criteria.
    /// </summary>
    public class LogExecSpSearchCriteria : CriteriaBase
    {
        public string Username { get; set; }

        public string Name { get; set; }

        public int FilterType { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalRows { get; set; }

        public override string GetSettingKey()
        {
            return "ConnectionString_LogExecSp_Search";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
