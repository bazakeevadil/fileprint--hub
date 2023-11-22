using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers;

[ApiController, Route("api/[controller]")]
public class PrintersController : ControllerBase
{
    private readonly PrinterManager _printerManager;

    public PrintersController()
    {
        _printerManager = new PrinterManager();
    }

    [HttpGet]
    public IActionResult GetPrinters()
    {
        List<Printer> printers = _printerManager.GetPrinters();
        return Ok(printers);
    }
}
