using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
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
    public static IApplicationBuilder UseMediaFile(this IApplicationBuilder app  )
    {
       // var personAssembly = typeof(PersonComponent.Program).GetTypeInfo().Assembly;
        var personEmbeddedFileProvider = new EmbeddedFileProvider(
            assembly :Assembly.Load(new AssemblyName("PNN.File")),
            "PNN.File"
        );

        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider("D:\\leader\\LearnToLeader\\PNN.File\\wwwroot\\")
        });
        return app;
    }
}
