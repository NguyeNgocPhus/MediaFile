using Microsoft.AspNetCore.Authorization;
namespace PNN.Identity.Securities.Authorization;

public class MinimumAgeAuthorizeAttribute : AuthorizeAttribute
{
    public const string PermissionsGroup = "Permissions";
    public MinimumAgeAuthorizeAttribute(int[] age) => Age = age;
    public int[] Age
    {
        get => Age;
        set => Policy = $"{PermissionsGroup}{value.ToString()}";
    }
}
