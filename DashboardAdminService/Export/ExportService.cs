using System;
using System.Text;

namespace DashboardAdminService.Export;

public class ExportService
{
    public ExportFile Export(object data, string format)
    {
        // Implement CSV and PDF export logic
        if (format == "csv")
        {
            var content = Encoding.UTF8.GetBytes("csv,data,here\n"); // Replace with actual CSV generation
            return new ExportFile { Content = content, ContentType = "text/csv", FileName = "report.csv" };
        }
        else if (format == "pdf")
        {
            var content = Encoding.UTF8.GetBytes("PDF data here"); // Replace with actual PDF generation
            return new ExportFile { Content = content, ContentType = "application/pdf", FileName = "report.pdf" };
        }
        return null;
    }
}

public class ExportFile
{
    public byte[] Content { get; set; }
    public string ContentType { get; set; }
    public string FileName { get; set; }
}
