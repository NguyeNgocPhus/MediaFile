﻿namespace PNN.File.Abstraction;
public interface IMediaStorageProvider
{
    /// <summary>
    /// Gets a value indicating whether the provider saves data in a remote cloud storage (e.g. Azure)
    /// </summary>
    bool IsCloudStorage { get; }

    /// <summary>
    /// Gets the size of the media item in bytes.
    /// </summary>
    /// <param name="mediaFile">Media file item</param>
    Task<long> GetLengthAsync(Domain.MediaFile mediaFile);

    /// <summary>
    /// Opens the media item for reading
    /// </summary>
    /// <param name="mediaFile">Media file item</param>
    Stream? OpenRead(Domain.MediaFile mediaFile);

    /// <inheritdoc cref="OpenRead(MediaFile)"/>
    Task<Stream?> OpenReadAsync(Domain.MediaFile mediaFile);

    /// <summary>
    /// Asynchronously loads media item data
    /// </summary>
    /// <param name="mediaFile">Media file item</param>
    Task<byte[]?> LoadAsync(Domain.MediaFile mediaFile);

    /// <summary>
    /// Asynchronously saves media item data
    /// </summary>
    /// <param name="mediaFile">Media file item</param>
    /// <param name="item">The source item</param>
    Task SaveAsync(Domain.MediaFile mediaFile, IImage item);

    /// <summary>
    /// Remove media storage item(s)
    /// </summary>
    /// <param name="mediaFiles">Media file items</param>
    Task RemoveAsync(params Domain.MediaFile[] mediaFiles);

    /// <summary>
    /// Changes the extension of the stored file if the provider supports
    /// </summary>
    /// <param name="mediaFile">Media file item</param>
    /// <param name="extension">The nex file extension</param>
    Task ChangeExtensionAsync(Domain.MediaFile mediaFile, string extension);

}
