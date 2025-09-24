using System;

namespace DashboardAdminService.Audit;

public class AuditLogger
{
    public void Log(string action, string adminUser)
    {
        // Write to audit log (file, DB, or external system)
        Console.WriteLine($"{DateTime.UtcNow}: {adminUser} - {action}");
    }
}
