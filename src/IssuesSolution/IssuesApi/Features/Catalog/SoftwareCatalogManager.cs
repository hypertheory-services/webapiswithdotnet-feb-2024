using IssuesApi.Services;
using Microsoft.EntityFrameworkCore;

namespace IssuesApi.Features.Catalog;

public class SoftwareCatalogManager(IssuesDataContext context)
{

    public async Task<IList<SoftwareItem>> GetAllCurrentSoftwareAsync()
    {
        var results = await context.SoftwareCatalog.Where(s => s.DateRetired == null).ToListAsync();
        return results;
    }
}
