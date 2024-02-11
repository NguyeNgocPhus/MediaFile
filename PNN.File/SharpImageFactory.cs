//using PNN.File.Abstraction;
//using SixLabors.ImageSharp;
//using SixLabors.ImageSharp.Formats;
//using SixLabors.ImageSharp.Memory;
//using SharpConfiguration = SixLabors.ImageSharp.Configuration;

//namespace PNN.File;

//public class SharpImageFactory : IImageFactory
//{
//    private readonly Timer _releaseMemTimer;

//    public SharpImageFactory(SmartConfiguration appConfig)
//    {
//        if (appConfig.ImagingMaxPoolSizeMB > 0)
//        {
//            SharpConfiguration.Default.MemoryAllocator = MemoryAllocator.Create(new MemoryAllocatorOptions
//            {
//                MaximumPoolSizeMegabytes = appConfig.ImagingMaxPoolSizeMB
//            });
//        }

//        // Release memory pool every 10 minutes
//        var releaseInterval = TimeSpan.FromMinutes(10);
//        _releaseMemTimer = new Timer(o => ReleaseMemory(), null, releaseInterval, releaseInterval);
//    }

//    public bool IsSupportedImage(string extension)
//    {
//        return FindInternalImageFormat(extension) != null;
//    }

//    public IImageFormat FindFormatByExtension(string extension)
//    {
//        var internalFormat = FindInternalImageFormat(extension);
//        if (internalFormat != null)
//        {
//            return ImageSharpUtility.CreateFormat(internalFormat);
//        }

//        return null;
//    }

//    public IImageFormat DetectFormat(Stream stream)
//    {
//        var internalFormat = Image.DetectFormat(stream);
//        if (internalFormat != null)
//        {
//            return ImageSharpUtility.CreateFormat(internalFormat);
//        }

//        return null;
//    }

//    public async Task<IImageFormat> DetectFormatAsync(Stream stream)
//    {
//        var internalFormat = await Image.DetectFormatAsync(stream);
//        if (internalFormat != null)
//        {
//            return ImageSharpUtility.CreateFormat(internalFormat);
//        }

//        return null;
//    }

   
   
//    internal static SixLabors.ImageSharp.Formats.IImageFormat FindInternalImageFormat(string extension)
//    {
//        if (extension.IsEmpty())
//        {
//            return null;
//        }

//        if (SharpConfiguration.Default.ImageFormatsManager.TryFindFormatByFileExtension(extension, out var format))
//        {
//            return format;
//        }

//        return null;
//    }

//    public void ReleaseMemory()
//        => SharpConfiguration.Default.MemoryAllocator.ReleaseRetainedResources();

//}
