namespace IssuesApi.Features.Catalog;

public class SoftwareCatalogController(SoftwareCatalogManager catalog) : ControllerBase
{

    [HttpGet("/software")]
    public async Task<ActionResult> GetAllSoftwareAsync()
    {
        var data = await catalog.GetAllCurrentSoftwareAsync();
        return Ok(data);
    }
}
