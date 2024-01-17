using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PNN.File.Abstraction;
using PNN.File.Databases;
using PNN.File.Enums;
using PNN.Identity.Abstraction;
using PNN.Identity.Securities.Authorization;

namespace TestMediaFile.Controllers;


[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class MediaController : ControllerBase
{

    private readonly ILogger<MediaController> _logger;
    private readonly IMediaService _mediaService;
    private readonly IMediaTypeResolver _mediaTypeResolver;
    private readonly MediaFileDbContext _mediaFileDbContext;
    private readonly IIdentityService _identityService;
    public MediaController(ILogger<MediaController> logger, IMediaService mediaService, IMediaTypeResolver mediaTypeResolver, MediaFileDbContext mediaFileDbContext, IIdentityService identityService)
    {
        _logger = logger;
        _mediaService = mediaService;
        _mediaTypeResolver = mediaTypeResolver;
        _mediaFileDbContext = mediaFileDbContext;
        _identityService = identityService;
    }

    [Permissions(Permissions = new[] { "weather:*:*" })]
    [HttpPost]
    public async Task<IActionResult> GetFile()
    {
        var a = _identityService.GetToken<int>();
        var b = _identityService.GenerateToken<int, int>(123);
        return Ok("haloo");
    }
    [HttpPost]
    public async Task<IActionResult> Upload(
        [FromQuery] string path,
        [FromForm] string[] typeFilter = null,
        [FromQuery] bool isTransient = false,
        [FromQuery] DuplicateFileHandling duplicateFileHandling = DuplicateFileHandling.ThrowError
        //string directory = ""

        )
    {

        var numFiles = Request.Form.Files.Count;
        var result = new List<object>(numFiles);

        for (int i = 0; i < numFiles; i++)
        {

            var uploadFile = Request.Form.Files[i];
            var fileName = uploadFile.FileName;
            var filePath = _mediaService.CombinePaths(path, fileName);
            try
            {

                var extension = Path.GetExtension(fileName).TrimStart('.').ToLower();

                if (typeFilter != null && typeFilter.Length > 0)
                {
                    // validate extension
                    var mediaTypeExtensions = _mediaTypeResolver.ParseTypeFilter(typeFilter);
                    if (!mediaTypeExtensions.Contains(extension))
                    {

                    }
                }

                var mediaFile = await _mediaService.SaveFileAsync(filePath, uploadFile.OpenReadStream(), isTransient, duplicateFileHandling);


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        return Ok("ok");

    }
}
