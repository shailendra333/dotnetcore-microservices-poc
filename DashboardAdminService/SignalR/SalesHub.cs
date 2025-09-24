using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace DashboardAdminService.SignalR;

public class SalesHub : Hub
{
    public async Task NotifySalesUpdate(object result)
    {
        await Clients.All.SendAsync("SalesUpdated", result);
    }
}
