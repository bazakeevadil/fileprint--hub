namespace WebApi.Models;

/// <summary>
/// Represents a printer including its name and status.
/// </summary>
public class Printer
{
    /// <summary>
    /// Gets or sets the name of the printer.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the status of the printer.
    /// </summary>
    public string? Status { get; set; }
}
