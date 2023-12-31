﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebApi.Services;

namespace WebApi.Controllers;

/// <summary>
/// Represents a controller for managing files and directories.
/// </summary>
[ApiController, Route("api/[controller]")]
public class FilesController : ControllerBase
{
    private readonly FileManager _fileManager;

    public FilesController()
    {
        _fileManager = new FileManager();
    }

    /// <summary>
    /// Checks if a removable flash drive is connected.
    /// </summary>
    /// <returns>
    /// 200 OK with the drive name if a removable drive is found,
    /// 404 Not Found if no removable drives are found.
    /// </returns>
    [HttpGet("flash-drive")]
    [ProducesResponseType(200, Type = typeof(string))]
    [ProducesResponseType(404)]
    [SwaggerOperation(Summary = "Checks if a removable flash drive is connected.")]
    public IActionResult CheckFlashDrive()
    {

        var fileManager = new FileManager();
        var drive = fileManager.GetRemovableDrive();

        if (drive != null)
        {
            return Ok(drive.Name);
        }

        return NotFound();

    }

    /// <summary>
    /// Returns a list of files in the specified directory.
    /// </summary>
    /// <param name="path">The path to the directory.</param>
    /// <remarks>This endpoint returns a list of files in the specified directory.</remarks>
    /// <returns>An array of strings representing the paths to all the files in the directory.</returns>
    [HttpGet("files")]
    [SwaggerOperation(Summary = "Get files in a directory")]
    [ProducesResponseType(200, Type = typeof(string[]))]
    public IActionResult GetFiles(string path = "D:\\")
    {
        try
        {
            var files = _fileManager.GetFilesInDirectory(path);
            return Ok(files);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Returns a filtered list of files in the specified directory.
    /// </summary>
    /// <param name="path">The path to the directory.</param>
    /// <remarks>This endpoint returns a filtered list of files in the specified directory based on allowed file extensions.</remarks>
    /// <returns>An array of strings representing the paths to the filtered files in the directory.</returns>
    [HttpGet("filtered-files")]
    [SwaggerOperation(Summary = "Get filtered files in a directory")]
    [ProducesResponseType(200, Type = typeof(string[]))]
    public IActionResult GetFilteredFiles([FromQuery] string path = "D:\\")
    {
        var filteredFiles = _fileManager.GetFilteredFiles(path);

        return Ok(filteredFiles);
    }

    /// <summary>
    /// Returns the content of the selected file in Base64 format along with metadata.
    /// </summary>
    /// <param name="filePath">The path to the file.</param>
    /// <remarks>This endpoint returns the content of the selected file in Base64 format along with metadata.</remarks>
    /// <returns>A string containing the file name, extension, size, and the file content in Base64 format.</returns>
    [HttpGet("file-base64")]
    [SwaggerOperation(Summary = "Get file content as Base64")]
    [ProducesResponseType(200, Type = typeof(string))]
    public IActionResult GetFileAsBase64([FromQuery] string filePath = "D:\\\\photo5339347014623803472 (1).jpg")
    {
        string fileBase64 = _fileManager.GetFileAsBase64(filePath);
        return Ok(fileBase64);
    }
}
