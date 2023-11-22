using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers;

[ApiController, Route("api/[controller]")]
public class FilesController : ControllerBase
{
    private readonly FileManager _fileManager;

    public FilesController()
    {
        _fileManager = new FileManager();
    }

    [HttpGet("flash-drive")]
    public IActionResult CheckFlashDrive()
    {
        bool hasFlashDrive = _fileManager.CheckFlashDrive();
        return Ok(hasFlashDrive);
    }

    [HttpGet("files")]
    public IActionResult GetFilesInDirectory([FromQuery] string path)
    {
        string[] files = _fileManager.GetFilesInDirectory(path);
        return Ok(files);
    }

    [HttpGet("filtered-files")]
    public IActionResult GetFilteredFiles([FromQuery] string path)
    {
        string[] filteredFiles = _fileManager.GetFilteredFiles(path);
        return Ok(filteredFiles);
    }

    [HttpGet("file-base64")]
    public IActionResult GetFileAsBase64([FromQuery] string filePath)
    {
        string fileBase64 = _fileManager.GetFileAsBase64(filePath);
        return Ok(fileBase64);
    }
}
