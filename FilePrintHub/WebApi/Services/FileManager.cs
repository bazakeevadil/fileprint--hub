using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApi.Models;

namespace WebApi.Services;

/// <summary>
/// Provides methods for managing files and directories.
/// </summary>
public class FileManager
{

    public DriveInfo GetRemovableDrive()
    {
        var drives = DriveInfo.GetDrives();

        if (Enum.IsDefined(typeof(DriveType), DriveType.Removable))
        {
            return drives.FirstOrDefault(d => d.DriveType == DriveType.Removable);
        }

        throw new ArgumentException("Invalid drive type");
    }


    /// <summary>
    /// Returns a list of files in the specified directory.
    /// </summary>
    /// <param name="path">The path to the directory.</param>
    /// <returns>An array of strings representing the paths to all the files in the directory.</returns>
    public List<FileInfoModel> GetFilesInDirectory(string path)
    {

        return Directory
          .GetFiles(path)
          .Select(f => new FileInfo(f))
          .Select(f => new FileInfoModel
          {
              Name = f.Name,
              Path = f.FullName,
              Size = f.Length
          })
          .ToList();

    }

    /// <summary>
    /// Returns a filtered list of files in the specified directory.
    /// </summary>
    /// <param name="path">The path to the directory.</param>
    /// <returns>An array of strings representing the paths to all the files in the directory, filtered by file extensions.</returns>
    public List<FileInfoModel> GetFilteredFiles(string path)
    {
        string[] allowedExtensions = { ".doc", ".docx", ".xls", ".xlsx", ".pdf", ".jpg", ".png" };

        return Directory
          .GetFiles(path)
          .Select(f => new FileInfo(f))
          .Where(f => allowedExtensions.Contains(f.Extension))
          .Select(f => new FileInfoModel
          {
              Name = f.Name,
              Path = f.FullName,
              Size = f.Length
          })
          .ToList();
    }

    /// <summary>
    /// Returns the content of the selected file in Base64 format along with metadata.
    /// </summary>
    /// <param name="filePath">The path to the file.</param>
    /// <returns>A string containing the file name, extension, size, and the file content in Base64 format.</returns>
    public string GetFileAsBase64(string filePath)
    {
        byte[] fileBytes = File.ReadAllBytes(filePath);
        string fileName = Path.GetFileName(filePath);
        string fileExtension = Path.GetExtension(filePath);
        long fileSize = new FileInfo(filePath).Length;

        return $"Name: {fileName}, Extension: {fileExtension}, Size: {fileSize}, Base64: {Convert.ToBase64String(fileBytes)}";
    }
}
