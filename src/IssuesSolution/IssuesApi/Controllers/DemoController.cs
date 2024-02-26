
namespace IssuesApi.Controllers;

public class DemoController : ControllerBase
{
    // GET /demo
    [HttpGet("/demo")] // hey, if I get an GET request to /Demo, run this.
    public ActionResult GetTheDemo()
    {
        return Ok();
    }

}
