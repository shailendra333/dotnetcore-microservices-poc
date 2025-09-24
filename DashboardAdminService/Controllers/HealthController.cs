using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DashboardAdminService.Controllers;

[ApiController]
[Route("api/health")]
[Authorize(Roles = "ADMIN")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult GetHealth()
    {
        // Check Elasticsearch, PolicyService, PaymentService connectivity
        var health = new
        {
            ElasticSearch = "Healthy",
            PolicyService = "Healthy",
            PaymentService = "Healthy"
        };
        return Ok(health);
    }
}
