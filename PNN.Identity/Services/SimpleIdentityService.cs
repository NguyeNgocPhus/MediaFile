using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PNN.Identity.Abstraction;
namespace PNN.Identity.Services;

public class SimpleIdentityService : IIdentityService
{

    private readonly IHttpContextAccessor _httpContextAccessor;

    public SimpleIdentityService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public T GenerateToken<U, T>(U payload)
    {
        if (payload != null)
        {
            var token = payload.ToString();
            return JsonConvert.DeserializeObject<T>(token);
        }
       
        return default;
    }

    public T? GetToken<T>()
    {
        var request = _httpContextAccessor?.HttpContext?.Request;

        if (request != null && request.Headers.TryGetValue(SimpleAuthenticationOptions.DefaultTokenHeader, out var value) && !string.IsNullOrEmpty(value))
        {
            return JsonConvert.DeserializeObject<T>(value.ToString());
        }

        return default;
    }

    public T ValidateToken<T>(string token)
    {
        return JsonConvert.DeserializeObject<T>(token);
    }
}
