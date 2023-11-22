using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers;

/// <summary>
/// Represents a controller for managing printers.
/// </summary>
[ApiController, Route("api/[controller]")]
public class PrintersController : ControllerBase
{
    private readonly PrinterManager _printerManager;

    public PrintersController()
    {
        _printerManager = new PrinterManager();
    }

    /// <summary>
    /// Retrieves a list of installed and available printers along with their statuses.
    /// </summary>
    /// <remarks>This endpoint returns a list of printers containing their names and statuses.</remarks>
    /// <returns>A list of printers.</returns>
    [HttpGet]
    [SwaggerOperation(Summary = "Get printers")]
    [ProducesResponseType(200, Type = typeof(List<Printer>))]
    public IActionResult GetPrinters()
    {
        List<Printer> printers = _printerManager.GetPrinters();
        return Ok(printers);
    }
}
