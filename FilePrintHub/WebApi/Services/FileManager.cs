using WebApi.Models;

namespace WebApi.Services;

/// <summary>
/// Provides methods for managing files and directories.
/// </summary>
public class FileManager
{
    /// <summary>
    /// Gets the first removable drive in the system.
    /// </summary>
    /// <returns>A <see cref="DriveInfo"/> object representing the removable drive, or <c>null</c> if no removable drives are found.</returns>
    public DriveInfo GetRemovableDrive()
    {
        // Get all available drives
        var drives = DriveInfo.GetDrives();

        // Check if the DriveType enumeration contains Removable
        if (Enum.IsDefined(typeof(DriveType), DriveType.Removable))
        {
            // Return the first removable drive, if any
            return drives.FirstOrDefault(d => d.DriveType == DriveType.Removable);
        }

        // Throw an exception if DriveType.Removable is not defined
        throw new ArgumentException("Invalid drive type");
    }


    /// <summary>
    /// Gets a list of <see cref="FileInfoModel"/> objects representing files and directories in the specified path.
    /// </summary>
    /// <param name="path">The path of the directory to retrieve files and directories from.</param>
    /// <returns>A list of <see cref="FileInfoModel"/> objects.</returns>
    public List<FileInfoModel> GetFilesInDirectory(string path)
    {
        List<FileInfoModel> files = new List<FileInfoModel>();

        foreach (string dirPath in Directory.GetDirectories(path))
        {
            DirectoryInfo dir = new DirectoryInfo(dirPath);

            files.Add(new FileInfoModel()
            {
                Name = dir.Name,
                Path = dir.FullName,
                IsDirectory = true
            });

            files.AddRange(GetFilesInSubDirectory(dirPath));
        }

        files.AddRange(Directory.GetFiles(path)
          .Select(f => new FileInfo(f))
          .Select(f => new FileInfoModel
          {
              Name = f.Name,
              Path = f.FullName,
              Extension = f.Extension,
              Size = f.Length,
              IsDirectory = false
          }));

        return files;
    }

    /// <summary>
    /// Recursively gets a list of <see cref="FileInfoModel"/> objects representing files and directories in the specified subpath.
    /// </summary>
    /// <param name="subpath">The subpath of the directory to retrieve files and directories from.</param>
    /// <returns>A list of <see cref="FileInfoModel"/> objects.</returns>
    private List<FileInfoModel> GetFilesInSubDirectory(string subpath)
    {
        return Directory
          .GetDirectories(subpath)
          .SelectMany(d => GetFilesInDirectory(d))
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
              Extension = f.Extension,
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
