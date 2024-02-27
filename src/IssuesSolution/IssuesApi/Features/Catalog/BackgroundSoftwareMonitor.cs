
using IssuesApi.Services;
using Microsoft.EntityFrameworkCore;

namespace IssuesApi.Features.Catalog;

public class BackgroundSoftwareMonitor(ILogger<BackgroundSoftwareMonitor> logger, IServiceProvider sp) : IHostedService, IDisposable
{
    private bool running = false;
    public void Dispose()
    {
        running = false;
        // nothing 
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        running = true;
        while (running)
        {
            await Task.Delay(5000);
            using (var scope = sp.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<IssuesDataContext>();

                var retired = await context.SoftwareCatalog
                    .Where(c => c.DateRetired != null && c.RetirementNotificationsSent == false)
                    .ToListAsync();
                foreach (var r in retired)
                {
                    using (logger.BeginScope("Retired Software"))
                    {
                        // remove it from the database, send an email, do whatever.
                        logger.LogInformation("Item {id} is Retired", r.Id);
                        // Do all that other work, notifying the user their issue has been cancelled, etc.
                        r.RetirementNotificationsSent = true;

                    }
                }
                await context.SaveChangesAsync(); // Pull the trigger. 
            }
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        running = false;
        return Task.CompletedTask;
    }
}
