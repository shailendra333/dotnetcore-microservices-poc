using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DashboardAdminService.DataAccess.Elastic;
using DashboardAdminService.Export;
using DashboardAdminService.Audit;
using System.Threading.Tasks;
using System;

namespace DashboardAdminService.Controllers;

[ApiController]
[Route("api/reports")]
[Authorize(Roles = "ADMIN")]
public class ReportsController : ControllerBase
{
    private readonly SalesAggregationRepository salesRepo;
    private readonly ExportService exportService;
    private readonly AuditLogger auditLogger;

    public ReportsController(SalesAggregationRepository salesRepo, ExportService exportService, AuditLogger auditLogger)
    {
        this.salesRepo = salesRepo;
        this.exportService = exportService;
        this.auditLogger = auditLogger;
    }

    [HttpGet("sales")]
    public async Task<IActionResult> GetSystemSales([FromQuery] DateTime from, [FromQuery] DateTime to)
    {
        auditLogger.Log("Admin accessed system-wide sales report", User.Identity.Name);
        var result = await salesRepo.GetSystemWideSalesAsync(from, to);
        return Ok(result);
    }

    [HttpGet("sales/export")]
    public async Task<IActionResult> ExportSystemSales([FromQuery] DateTime from, [FromQuery] DateTime to, [FromQuery] string format)
    {
        auditLogger.Log($"Admin exported sales report as {format}", User.Identity.Name);
        var result = await salesRepo.GetSystemWideSalesAsync(from, to);
        var file = exportService.Export(result, format);
        return File(file.Content, file.ContentType, file.FileName);
    }

    [HttpGet("agents")]
    public async Task<IActionResult> GetAgentPerformance([FromQuery] DateTime from, [FromQuery] DateTime to)
    {
        auditLogger.Log("Admin accessed agent performance report", User.Identity.Name);
        var result = await salesRepo.GetAgentPerformanceAsync(from, to);
        return Ok(result);
    }

    [HttpGet("agents/export")]
    public async Task<IActionResult> ExportAgentPerformance([FromQuery] DateTime from, [FromQuery] DateTime to, [FromQuery] string format)
    {
        auditLogger.Log($"Admin exported agent performance report as {format}", User.Identity.Name);
        var result = await salesRepo.GetAgentPerformanceAsync(from, to);
        var file = exportService.Export(result, format);
        return File(file.Content, file.ContentType, file.FileName);
    }

    [HttpGet("products")]
    public async Task<IActionResult> GetProductSales([FromQuery] DateTime from, [FromQuery] DateTime to)
    {
        auditLogger.Log("Admin accessed product sales analytics", User.Identity.Name);
        var result = await salesRepo.GetProductSalesAnalyticsAsync(from, to);
        return Ok(result);
    }

    [HttpGet("products/export")]
    public async Task<IActionResult> ExportProductSales([FromQuery] DateTime from, [FromQuery] DateTime to, [FromQuery] string format)
    {
        auditLogger.Log($"Admin exported product sales analytics as {format}", User.Identity.Name);
        var result = await salesRepo.GetProductSalesAnalyticsAsync(from, to);
        var file = exportService.Export(result, format);
        return File(file.Content, file.ContentType, file.FileName);
    }

    [HttpGet("trends")]
    public async Task<IActionResult> GetPaymentPolicyTrends([FromQuery] DateTime from, [FromQuery] DateTime to)
    {
        auditLogger.Log("Admin accessed payment and policy trend analysis", User.Identity.Name);
        var result = await salesRepo.GetPaymentPolicyTrendsAsync(from, to);
        return Ok(result);
    }

    [HttpGet("trends/export")]
    public async Task<IActionResult> ExportPaymentPolicyTrends([FromQuery] DateTime from, [FromQuery] DateTime to, [FromQuery] string format)
    {
        auditLogger.Log($"Admin exported payment and policy trend analysis as {format}", User.Identity.Name);
        var result = await salesRepo.GetPaymentPolicyTrendsAsync(from, to);
        var file = exportService.Export(result, format);
        return File(file.Content, file.ContentType, file.FileName);
    }
}
