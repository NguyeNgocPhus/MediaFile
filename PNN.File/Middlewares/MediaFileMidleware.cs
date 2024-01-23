using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PNN.File.Abstraction;

namespace PNN.File.Middlewares;
public class MediaFileMidleware
{

    private readonly RequestDelegate _next;

    public MediaFileMidleware(
        RequestDelegate next)
    {
        _next = next;

    }
    public async Task Invoke(
           HttpContext context)
    {
        await context.Response.WriteAsync("jajajajajajajaa");
    }
}
