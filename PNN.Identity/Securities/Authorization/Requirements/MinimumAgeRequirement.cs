using Microsoft.AspNetCore.Authorization;

namespace PNN.Identity.Securities.Authorization.Requirements;

public class MinimumAgeRequirement : IAuthorizationRequirement
{
    public MinimumAgeRequirement(int minimumAge) =>
        MinimumAge = minimumAge;

    public int MinimumAge { get; }
}