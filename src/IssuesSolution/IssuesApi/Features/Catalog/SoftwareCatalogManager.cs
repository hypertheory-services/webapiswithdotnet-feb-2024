using AutoMapper;
using AutoMapper.QueryableExtensions;
using IssuesApi.Services;
using Microsoft.EntityFrameworkCore;

namespace IssuesApi.Features.Catalog;

public class SoftwareCatalogManager(IssuesDataContext context, IMapper mapper, MapperConfiguration mapperConfig)
{

    public async Task<CollectionResponse<SoftwareCatalogSummaryResponseItem>> GetAllCurrentSoftwareAsync(CancellationToken token)
    {
        var results = await context.SoftwareCatalog.Where(s => s.DateRetired == null)
            .ProjectTo<SoftwareCatalogSummaryResponseItem>(mapperConfig)
            .ToListAsync(token);


        return new CollectionResponse<SoftwareCatalogSummaryResponseItem>(results);
    }

    public async Task<SoftwareCatalogSummaryResponseItem> AddSoftwareItemAsync(SoftwareItemRequestModel request, CancellationToken token)
    {
        var newItem = mapper.Map<SoftwareItem>(request);
        context.SoftwareCatalog.Add(newItem);
        await context.SaveChangesAsync(); // some weird entity framework object reference magic here.


        return mapper.Map<SoftwareCatalogSummaryResponseItem>(newItem);

    }

    public async Task<SoftwareCatalogSummaryResponseItem?> GetItemByIdAsync(Guid id, CancellationToken token)
    {
        var response = await context
            .SoftwareCatalog
            .Where(item => item.Id == id && item.DateRetired == null)
            .ProjectTo<SoftwareCatalogSummaryResponseItem>(mapperConfig)
            .SingleOrDefaultAsync();

        return response;
    }
}
