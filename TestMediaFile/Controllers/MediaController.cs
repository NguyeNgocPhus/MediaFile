using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PNN.File.Abstraction;
using PNN.File.Databases;
using PNN.File.Enums;

namespace TestMediaFile.Controllers;



[ApiController]
[Route("[controller]/[action]")]
public class MediaController : ControllerBase
{

    private readonly ILogger<MediaController> _logger;
    private readonly IMediaService _mediaService;
    private readonly IMediaTypeResolver _mediaTypeResolver;
    private readonly MediaFileDbContext _mediaFileDbContext;
    public MediaController(ILogger<MediaController> logger, IMediaService mediaService, IMediaTypeResolver mediaTypeResolver, MediaFileDbContext mediaFileDbContext)
    {
        _logger = logger;
        _mediaService = mediaService;
        _mediaTypeResolver = mediaTypeResolver;
        _mediaFileDbContext = mediaFileDbContext;
    }

    public async Task<IActionResult> TestPeforment1()
    {

        var mediaFiles = await _mediaFileDbContext.MediaFiles.AsNoTracking().ToListAsync();

        return Ok(mediaFiles);

    }
    public async Task<IActionResult> TestPeforment2()
    {

        var mediaFiles = await _mediaFileDbContext.MediaFiles.ToListAsync();

        return Ok(mediaFiles);

    }
    //public async Task<IActionResult> Test()
    //{

    //    IWebDriver driver = new ChromeDriver();
    //    try
    //    {

    //        driver.Navigate().GoToUrl("http://n8n.chatwoot.vn/signin");

    //        var emailElement = driver.FindElement(By.Name("email"));
    //        var passwordElement = driver.FindElement(By.Name("password"));

    //        emailElement.SendKeys("nguyenlong1091@gmail.com");

    //        passwordElement.SendKeys("g@$RFZc#zx#7yCz");

    //        var btnSubmit = driver.FindElement(By.ClassName("_button_1qczm_233"));
    //        btnSubmit.Click();

    //        driver.Navigate().GoToUrl("http://n8n.chatwoot.vn/settings/users");
    //        await Task.Delay(TimeSpan.FromSeconds(2));

    //        var invite = driver.FindElement(By.XPath("//button[@class='button _button_1qczm_233 _primary_1qczm_493 _large_1qczm_471']"));
    //        invite.Click();

    //        var inviteEmail = driver.FindElement(By.Name("emails"));
    //        inviteEmail.SendKeys("phunn@thgdx.vn");

    //        var btnInviteLink = driver.FindElement(By.XPath("//span[normalize-space()='Create invite link']"));
    //        btnInviteLink.Click();


    //        var iiii = driver.FindElement(By.XPath("//div[@data-test-id='user-list-item-phunn@thgdx.vn']"));
    //        var copyLink = iiii.FindElement(By.XPath("//li[normalize-space()='Copy Invite Link']"));

    //        await Task.Delay(TimeSpan.FromSeconds(2));
    //        driver.SwitchTo().Window(Keys.Control + "v");


    //    }
    //    finally
    //    {
    //       // driver.Quit();
    //    }
    //    return Ok("");
    //}
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
                else
                {

                }

                var mediaFile = await _mediaService.SaveFileAsync(filePath, uploadFile.OpenReadStream(), isTransient, duplicateFileHandling);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        return Ok();





    }
}
