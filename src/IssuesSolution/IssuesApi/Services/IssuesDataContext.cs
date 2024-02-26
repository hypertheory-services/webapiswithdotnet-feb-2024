using Microsoft.EntityFrameworkCore;

namespace IssuesApi.Services;

public class IssuesDataContext(DbContextOptions<IssuesDataContext> options) : DbContext(options)
{
    public DbSet<SoftwareItem> SoftwareCatalog { get; set; }
}

// "Entity" 
public class SoftwareItem
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty; // Excel
    public string Version { get; set; } = string.Empty;

    public DateTimeOffset DateAdded { get; set; }
    public DateTimeOffset? DateRetired { get; set; } = null;
}