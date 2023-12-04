using MediaFile.Abstraction;
using MediaFile.Enums;
using Microsoft.AspNetCore.Mvc;

namespace TestMediaFile.Controllers;



[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IMediaService _mediaService;
    private readonly IMediaTypeResolver _mediaTypeResolver;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediaService mediaService, IMediaTypeResolver mediaTypeResolver)
    {
        _logger = logger;
        _mediaService = mediaService;
        _mediaTypeResolver = mediaTypeResolver;
    }

    [HttpPost]
    public async Task<IActionResult> Upload(
        string path,
        string[] typeFilter = null,
        bool isTransient = false,
        DuplicateFileHandling duplicateFileHandling = DuplicateFileHandling.ThrowError,
        string directory = ""

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

                if(typeFilter !=null && typeFilter.Length > 0)
                {

                    var mediaTypeExtensions = _mediaTypeResolver.ParseTypeFilter(typeFilter);
                    if (!mediaTypeExtensions.Contains(extension))
                    {
                        throw new Exception("");
                    }
                }
                else
                {

                }

            }catch(Exception ex)
            {

            }

        }
        return Ok();

    }
}