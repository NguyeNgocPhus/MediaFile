using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using PNN.Identity.Securities.Authorization.Requirements;

namespace PNN.Identity.Securities.Authorization.Handlers;

public class MinimumAgeHandler : AuthorizationHandler<MinimumAgeRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
    {
        var a = requirement.MinimumAge;// role
        var dateOfBirthClaim = context.User.Claims;
        context.Succeed(requirement);
        // if (dateOfBirthClaim is null)
        // {
        //     return Task.CompletedTask;
        // }
        //
        // var dateOfBirth = Convert.ToDateTime(dateOfBirthClaim.Value);
        // int calculatedAge = DateTime.Today.Year - dateOfBirth.Year;
        // if (dateOfBirth > DateTime.Today.AddYears(-calculatedAge))
        // {
        //     calculatedAge--;
        // }
        //
        // if (calculatedAge >= requirement.MinimumAge)
        // {
        //     context.Succeed(requirement);
        // }

        return Task.CompletedTask;
    }
}