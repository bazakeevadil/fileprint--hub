namespace WebApi.Services;

public class FileManager
{
    public bool CheckFlashDrive()
    {
        DriveInfo[] drives = DriveInfo.GetDrives();
        return drives.Any(drive => drive.DriveType == DriveType.Removable);
    }

    public string[] GetFilesInDirectory(string path)
    {
        return Directory.GetFiles(path);
    }

    public string[] GetFilteredFiles(string path)
    {
        string[] allowedExtensions = new string[] { ".doc", ".docx", ".xls", ".xlsx", ".pdf", ".jpg", ".png" };
        return Directory.GetFiles(path)
                        .Where(file => allowedExtensions.Contains(Path.GetExtension(file)))
                        .ToArray();
    }

    public string GetFileAsBase64(string filePath)
    {
        byte[] fileBytes = File.ReadAllBytes(filePath);
        string fileName = Path.GetFileName(filePath);
        string fileExtension = Path.GetExtension(filePath);
        long fileSize = new FileInfo(filePath).Length;

        return $"Name: {fileName}, Extension: {fileExtension}, Size: {fileSize}, Base64: {Convert.ToBase64String(fileBytes)}";
    }
}
