namespace WebApi.Services;

/// <summary>
/// Provides methods for managing files and directories.
/// </summary>
public class FileManager
{
    /// <summary>
    /// Checks for the presence of a flash drive.
    /// </summary>
    /// <returns>True if at least one removable drive is found; otherwise, False.</returns>
    public bool CheckFlashDrive()
    {
        DriveInfo[] drives = DriveInfo.GetDrives();
        return drives.Any(drive => drive.DriveType == DriveType.Removable);
    }

    /// <summary>
    /// Returns a list of files in the specified directory.
    /// </summary>
    /// <param name="path">The path to the directory.</param>
    /// <returns>An array of strings representing the paths to all the files in the directory.</returns>
    public string[] GetFilesInDirectory(string path)
    {
        return Directory.GetFiles(path);
    }

    /// <summary>
    /// Returns a filtered list of files in the specified directory.
    /// </summary>
    /// <param name="path">The path to the directory.</param>
    /// <returns>An array of strings representing the paths to all the files in the directory, filtered by file extensions.</returns>
    public string[] GetFilteredFiles(string path)
    {
        string[] allowedExtensions = new string[] { ".doc", ".docx", ".xls", ".xlsx", ".pdf", ".jpg", ".png" };
        return Directory.GetFiles(path)
                        .Where(file => allowedExtensions.Contains(Path.GetExtension(file)))
                        .ToArray();
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
