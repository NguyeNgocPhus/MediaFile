using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Authorization;

// ReSharper disable All

namespace PNN.Identity.Securities.Authorization.Requirements
{

    /// <inheritdoc />
    [ExcludeFromCodeCoverage]
    public class RolesRequirement : IAuthorizationRequirement, IIdentifiable
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="roles"></param>
        /// <param name="identifier"></param>
        public RolesRequirement(string roles, Guid identifier)
        {
            Roles = roles;
            Identifier = identifier;
        }

        /// <summary>
        /// Role
        /// </summary>
        public string Roles { get; }

        /// <summary>
        /// Role GUID
        /// </summary>
        public Guid Identifier { get; set; }
    }
}