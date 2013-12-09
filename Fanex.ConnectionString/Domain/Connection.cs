// --------------------------------------------------------------------------
// <copyright file="ConnectionString.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.1.11">Created</change>
// </history>

namespace Fanex.ConnectionString.Domain
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Fanex.ConnectionString.Constant;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    public class Connection : Entity
    {
        public string LoginName { get; set; }

        public string Password { get; set; }

        public string FreeText { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ConnectionString
        {
            get
            {
                if (!ReferenceEquals(DatabaseServer, null) && DatabaseServer.ServerIP != string.Empty)
                {
                    string tempConnection = string.Format(ConnectionStringConstant.CONNECTIONFORMAT,
                                                                DatabaseServer.ServerIP,
                                                                DatabaseServer.Name,
                                                                LoginName,
                                                                Password,
                                                                FreeText);
                    return tempConnection;
                }

                return string.Empty;
            }
        }

        public Users Creator { get; set; }

        public Users Modifier { get; set; }

        public DatabaseServer DatabaseServer { get; set; }

        public Database Database { get; set; }
    }
}
