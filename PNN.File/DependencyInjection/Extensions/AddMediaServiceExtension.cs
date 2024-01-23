using Microsoft.Extensions.DependencyInjection;
using PNN.File.Abstraction;
using PNN.File.Databases;
using PNN.File.Services;
using PNN.File.Storage;

namespace PNN.File.DependencyInjection.Extensions;
public static class AddMediaServiceExtension
{
    public static IServiceCollection AddMediaFile(this IServiceCollection services)
    {
        services.AddScoped<IMediaStorageProvider, FileSystemMediaStorageProvider>();
        services.AddScoped<MediaFileDbContext, MediaFileDbContext>();
        services.AddScoped<IMediaService, MediaFileService>();
        services.AddScoped<IFolderService, FolderService>();
        services.AddScoped<IMediaTypeResolver, MediaTypeResolver>();
        services.AddScoped<MediaHelper>();
        services.AddScoped<IMediaUrlGenerator, MediaUrlGenerator>();
        return services;
    }
}
