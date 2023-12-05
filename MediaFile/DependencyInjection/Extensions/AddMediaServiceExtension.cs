using Microsoft.Extensions.DependencyInjection;
using PNN.File.Abstraction;
using PNN.File.Services;

namespace PNN.File.DependencyInjection.Extensions;
public static class AddMediaServiceExtension
{
    public static IServiceCollection AddMediaFile(this IServiceCollection services)
    {
        services.AddScoped<IMediaService, MediaFileService>();
        services.AddScoped<IFolderService, FolderService>();
        services.AddScoped<IMediaTypeResolver, MediaTypeResolver>();

        return services;
    }
}
