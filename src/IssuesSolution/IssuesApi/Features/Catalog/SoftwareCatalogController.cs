namespace IssuesApi.Features.Catalog;

public class SoftwareCatalogController(SoftwareCatalogManager catalog) : ControllerBase
{

    [HttpGet("/software")]
    public async Task<ActionResult> GetAllSoftwareAsync(CancellationToken token)
    {
        var data = await catalog.GetAllCurrentSoftwareAsync(token);
        return Ok(data);
    }
}
