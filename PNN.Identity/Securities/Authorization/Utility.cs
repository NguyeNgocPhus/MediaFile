using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Authorization;
using PNN.Identity.Securities.Authorization.Requirements;

namespace PNN.Identity.Securities.Authorization;

/// <summary>
/// Utility class for [Permission] attribute
/// </summary>
[ExcludeFromCodeCoverage]
public static class Utility
{
    /// <summary>
    /// Mark an authorization request as success
    /// </summary>
    /// <param name="context"></param>
    /// <param name="identifier"></param>
    public static void Succeed(AuthorizationHandlerContext context, Guid identifier)
    {
        var groupedRequirements = context.Requirements.Where(r => (r as IIdentifiable)?.Identifier == identifier);

        foreach (var requirement in groupedRequirements)
        {
            context.Succeed(requirement);
        }
    }
}
