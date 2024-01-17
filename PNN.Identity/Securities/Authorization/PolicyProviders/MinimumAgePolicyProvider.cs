using Microsoft.AspNetCore.Authorization;
using PNN.Identity.Securities.Authorization.Requirements;

namespace PNN.Identity.Securities.Authorization.PolicyProviders;

public class MinimumAgePolicyProvider : IAuthorizationPolicyProvider
{
    private const string POLICY_PREFIX = "MinimumAge";
    public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {


        var policyTokens = policyName.Split(';', StringSplitOptions.RemoveEmptyEntries);


        if (policyName.StartsWith(POLICY_PREFIX, StringComparison.OrdinalIgnoreCase) &&
            int.TryParse(policyName.Substring(POLICY_PREFIX.Length), out var age))
        {
            var policy = new AuthorizationPolicyBuilder();
            policy.AddRequirements(new MinimumAgeRequirement(age));
            return Task.FromResult(policy.Build());
        }

        return Task.FromResult<AuthorizationPolicy>(null);
    }

    public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
    {
        throw new NotImplementedException();
    }

    public Task<AuthorizationPolicy?> GetFallbackPolicyAsync()
    {
        throw new NotImplementedException();
    }
}
