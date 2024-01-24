using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PNN.File.Abstraction;
using PNN.File.Databases;
using PNN.File.Enums;
using PNN.Identity.Abstraction;
using PNN.Identity.Securities.Authorization;

namespace TestMediaFile.Controllers;


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
   
   [Permissions]
    [HttpPost]
    public async Task<IActionResult> GetFile()
    {
        var info = new FileInfo("D:\\leader\\LearnToLeader\\PNN.File\\App_data\\Logo-trang-ngang.png");
       
        var a = _identityService.GetToken<int>();
        var b = _identityService.GenerateToken<int, int>(123);
        return Ok("haloo");
    }
    [HttpGet]
    public async Task<IActionResult> CopyDirectories()
    {
        var dir = new DirectoryInfo("D:\\leader\\LearnToLeader\\TestMediaFile\\App_data\\Images");
        // Check if the source directory exists
        if (!dir.Exists)
            throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");
        // Cache directories before we start copying
        DirectoryInfo[] dirs = dir.GetDirectories();
        // Create the destination directory
        Directory.CreateDirectory("D:\\leader\\LearnToLeader\\TestMediaFile\\App_data\\Images_copy");
        foreach (FileInfo file in dir.GetFiles())
        {
            string targetFilePath = Path.Combine("D:\\leader\\LearnToLeader\\TestMediaFile\\App_data\\Images_copy", file.Name);
            file.CopyTo(targetFilePath);
        }

        return Ok("oke");
    }
    [HttpGet]
    public async Task<IActionResult> EnumerateDirectories()
    {
        // Set a variable to the My Documents path.
        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        List<string> dirs = new List<string>(Directory.EnumerateDirectories(docPath));

        foreach (var dir in dirs)
        {
            Console.WriteLine($"{dir.Substring(dir.LastIndexOf(Path.DirectorySeparatorChar) + 1)}");
        }
        Console.WriteLine($"{dirs.Count} directories found.");
        var files = from file in Directory.EnumerateFiles(docPath, "*.txt", SearchOption.AllDirectories)
                    from line in System.IO.File.ReadLines(file)
                    where line.Contains("Microsoft")
                    select new
                    {
                        File = file,
                        Line = line
                    };

        // copy file 
        string startDirectory = @"c:\Users\exampleuser\start";
        string endDirectory = @"c:\Users\exampleuser\end";

        foreach (string filename in Directory.EnumerateFiles(startDirectory))
        {
            using (FileStream sourceStream = System.IO.File.Open(filename, FileMode.Open))
            {
                using (FileStream destinationStream = System.IO.File.Create(Path.Combine(endDirectory, Path.GetFileName(filename))))
                {
                    await sourceStream.CopyToAsync(destinationStream);
                }
            }
        }
        return Ok("oke");
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
