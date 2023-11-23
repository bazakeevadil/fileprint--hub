namespace WebApi.Models;

public class FileInfoModel
{
    public string? Name { get; set; }
    public string? Path { get; set; }
    public string? Extension { get; set; }
    public long Size { get; set; }
    public string? Base64 { get; set; }
}
