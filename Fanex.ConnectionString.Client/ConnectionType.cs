// --------------------------------------------------------------------------
// <copyright file="ConnectionType.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.1.14">Created</change>
// </history>

namespace Fanex.ConnectionString.Client
{
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    internal enum ConnectionType
    {
        Local = 0,
        Remote = 1
    }

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    internal enum SqlWatcherNotificationType
    {
        Blocking = 0,
        Threaded = 1
    }
}
