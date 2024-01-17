using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using PNN.Identity.Services;
using PNN.Identity.Abstraction;
using Microsoft.AspNetCore.Authorization;
using PNN.Identity.Securities.Authorization.Handlers;
using PNN.Identity.Securities.Authorization.PolicyProviders;


namespace PNN.Identity.DependencyInjection.Extensions;
public static class AddIdentityServiceExtension
{
    public static IServiceCollection AddJwtIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpContextAccessor();
        services.AddAuthentication(config =>
        {
            config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(config =>
        {
            config.RequireHttpsMetadata = false;
            config.SaveToken = true;
            config.TokenValidationParameters = new TokenValidationParameters()
            {
                ClockSkew = TimeSpan.Zero,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfiguration:SymmetricSecurityKey"]))
            };
            config.Events = new JwtBearerEvents()
            {
                OnMessageReceived = context =>
                {
                    var accessToken = context.Request.Query["access_token"];
                    var token = context.HttpContext.Request.Headers;
                    // If the request is for our hub...
                    var path = context.HttpContext.Request.Path;

                    return Task.CompletedTask;
                },
                OnTokenValidated = async context =>
                {
                    // To check token is valid and must be existing in the UserToken table in the database
                    // Once JWT is not existing in the UserToken table, the authentication process will be set as failed.

                    var userIdClaim =
                        context.Principal?.Claims.FirstOrDefault(claim => claim.Type == JwtClaimTypes.UserId);
                    if (userIdClaim == null)
                    {
                        context.Fail("JWT Token does not contain User Id Claim.");
                    }
                    var token = context.HttpContext.Request.Headers["Authorization"].ToString()
                        .Replace("Bearer ", "");
                    // If we cannot get token from header, try to use from querystring (for wss)

                    // context.Fail("JWT Token does not contain User Id Claim.");
                    Console.WriteLine(@"Token Validated OK");
                },
                OnChallenge = context =>
                {
                    context.HandleResponse();
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    context.Response.ContentType = "application/json";
                    // Ensure we always have an error and error description.
                    if (string.IsNullOrEmpty(context.Error))
                        context.Error = "invalid_token";
                    if (string.IsNullOrEmpty(context.ErrorDescription))
                    {
                        // Pass the message from OnTokenValidated on method context.Fail(<message>)
                        if (context.AuthenticateFailure != null &&
                            context.AuthenticateFailure.Message.Length > 0)
                        {
                            context.ErrorDescription = context.AuthenticateFailure.Message;
                        }
                        else
                        {
                            // If we dont have error message from OnTokenValidated, set a message
                            context.ErrorDescription =
                                "This request requires a valid JWT access token to be provided.";
                        }
                    }

                    // Add some extra context for expired tokens.
                    if (context.AuthenticateFailure != null && context.AuthenticateFailure.GetType() ==
                        typeof(SecurityTokenExpiredException))
                    {
                        var authenticationException =
                            context.AuthenticateFailure as SecurityTokenExpiredException;
                        context.Response.Headers.Add("WWW-Authenticate", "Bearer");
                        context.ErrorDescription = $"The token expired on {authenticationException?.Expires:o}";
                    }

                    return context.Response.WriteAsync(JsonSerializer.Serialize(new
                    {
                        status = 401,
                        error = context.Error,
                        errorDescription = context.ErrorDescription
                    }));
                }
            };
        });
        services.AddScoped<IIdentityService, JwtIdentityService>();
        return services;
    }
    public static IServiceCollection AddSimpleIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        var a = configuration;
        services.AddAuthentication(SimpleAuthenticationOptions.DefaultScheme)
        .AddScheme<SimpleAuthenticationOptions, SimpleAuthenticationHandler>(SimpleAuthenticationOptions.DefaultScheme, options =>
        {
        });

        services.AddSingleton<IAuthorizationPolicyProvider, PermissionsPolicyProvider>();
        services.AddSingleton<IAuthorizationHandler, PermissionsAuthorizationHandler>();
        services.AddSingleton<IAuthorizationHandler, RolesAuthorizationHandler>();
        services.AddSingleton<IAuthorizationHandler, ScopesAuthorizationHandler>();

        services.AddHttpContextAccessor();
        services.AddScoped<IIdentityService, SimpleIdentityService>();
        //services.AddAuthorization(option => { option.AddPolicy("AdminOnly", policy => policy.Requirements.Add(new MinimumAgeRequirement(0))); });
        return services;
    }
    public static IApplicationBuilder UseIdentity(this IApplicationBuilder app)
    {

        app.UseAuthentication();
        app.UseAuthorization();
        return app;
    }
}
