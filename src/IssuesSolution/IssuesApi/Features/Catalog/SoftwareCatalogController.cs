namespace IssuesApi.Features.Catalog;

// Before we got here, ASP.NET CORE create a scope, created our controller with it, and the softwarecatalog manager, and the datacontext
public class SoftwareCatalogController(SoftwareCatalogManager catalog) : ControllerBase
{

    [HttpGet("/software")]
    public async Task<ActionResult> GetAllSoftwareAsync(CancellationToken token)
    {
        var data = await catalog.GetAllCurrentSoftwareAsync(token);
        return Ok(data);
    }

    [HttpPost("/software")]
    public async Task<ActionResult> AddSoftwareItemAsync([FromBody] SoftwareItemRequestModel request, CancellationToken token)
    {
        // todo: 1) validate it. 2) save it to the database 3) send a response.
        SoftwareCatalogSummaryResponseItem response = await catalog.AddSoftwareItemAsync(request, token);

        return Ok(response);
    }

    [HttpGet("/software/{id}")]
    public async Task<ActionResult> GetSoftwareItemByIdAsync(Guid id, CancellationToken token)
    {
        SoftwareCatalogSummaryResponseItem? item = await catalog.GetItemByIdAsync(id, token);

        if (item is not null)
        {
            return Ok(item);
        }
        else
        {
            return NotFound();
        }
    }
}
