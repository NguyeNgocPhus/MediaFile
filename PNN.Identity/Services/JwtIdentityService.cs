using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PNN.Identity.Abstraction;
namespace PNN.Identity.Services;

public class JwtIdentityService : IIdentityService
{
    private readonly string CookieName = "cw_conversation";
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public JwtIdentityService(IConfiguration appContext, IHttpContextAccessor httpContextAccessor)
    {
        _configuration = appContext;
        _httpContextAccessor = httpContextAccessor;
    }

    public T GenerateToken<U, T>(U payload)
    {
        throw new NotImplementedException();
    }

    public T GetToken<T>()
    {
        throw new NotImplementedException();
    }

    public T ValidateToken<T>(string token)
    {
        throw new NotImplementedException();
    }

    //public string GenerateContactToken(string inbox_id, string source_id)
    //{
    //    var tokenHandler = new JwtSecurityTokenHandler();
    //    var key = Encoding.ASCII.GetBytes(_configuration["Smartstore:JwtSecret"]);
    //    var tokenDescriptor = new SecurityTokenDescriptor
    //    {
    //        Subject = new ClaimsIdentity(new[] { new Claim("inbox_id", inbox_id), new Claim("source_id", source_id) }),
    //        Expires = DateTime.UtcNow.AddDays(100),
    //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    //    };
    //    var token = tokenHandler.CreateToken(tokenDescriptor);
    //    return tokenHandler.WriteToken(token);
    //}

    //public string GetJwt()
    //{
    //    var request = _httpContextAccessor?.HttpContext?.Request;

    //    if (request != null && request.Cookies.TryGetValue(CookieName, out var value1) && value1.HasValue())
    //    {
    //        return value1;
    //    }
    //    if (request != null && request.Headers.TryGetValue("X-Auth-Token", out var value2) && value2.ToString().HasValue())
    //    {
    //        return value2.ToString();
    //    }
    //    return null;
    //}

    //public PayloadJwt ValidateToken(string token)
    //{
    //    if (token == null)
    //        return null;

    //    var tokenHandler = new JwtSecurityTokenHandler();
    //    var key = Encoding.ASCII.GetBytes(_configuration["Smartstore:JwtSecret"]);
    //    try
    //    {
    //        tokenHandler.ValidateToken(token, new TokenValidationParameters
    //        {
    //            ValidateIssuerSigningKey = true,
    //            IssuerSigningKey = new SymmetricSecurityKey(key),
    //            ValidateIssuer = false,
    //            ValidateAudience = false,
    //            // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
    //            ClockSkew = TimeSpan.Zero
    //        }, out SecurityToken validatedToken);

    //        var jwtToken = (JwtSecurityToken)validatedToken;
    //        var inbox_id = int.Parse(jwtToken.Claims.First(x => x.Type == "inbox_id").Value);
    //        var source_id = jwtToken.Claims.First(x => x.Type == "source_id").Value.ToString();

    //        // return user id from JWT token if validation successful
    //        return new PayloadJwt()
    //        {
    //            inbox_id = inbox_id,
    //            source_id = source_id
    //        };
    //    }
    //    catch
    //    {
    //        // return null if validation fails
    //        return null;
    //    }

    //}

}
