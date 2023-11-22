using System.Management;
using WebApi.Models;

namespace WebApi.Services;

public class PrinterManager
{
    public List<Printer> GetPrinters()
    {
        List<Printer> printers = new List<Printer>();
        ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Printer");

        foreach (ManagementObject printer in searcher.Get())
        {
            string name = printer["Name"].ToString();
            string status = printer["PrinterStatus"].ToString(); // This will give you the status code, you may need to map it to "Готов", "Занят", "Недоступен"
            printers.Add(new Printer { Name = name, Status = status });
        }

        return printers;
    }
}
