
namespace IssuesApi.Controllers;

public class DemoController : ControllerBase
{
    // GET /demo
    [HttpGet("/demo")] // hey, if I get an GET request to /Demo, run this.
    public ActionResult<DemoResponse> GetTheDemo()
    {
        var response = new DemoResponse("Looks Good!", DateTimeOffset.Now);
        return Ok(response);
    }


    // OData
    [HttpGet("/employees")]
    public ActionResult GetEmployees([FromQuery] string department = "All", [FromQuery] decimal minimalSalary = 0)
    {
        var employees = new List<EmployeeResponse>
        {
            new EmployeeResponse(Guid.NewGuid(), "Leland Palmer", "DEV" ),
            new EmployeeResponse(Guid.NewGuid(), "Harry S. Truman","Law" )
        };
        if (department == "All")
        {
            var response = new CollectionResponse<EmployeeResponse>(employees);
            return Ok(response);
        }
        else
        {
            var filteredEmployees = employees.Where(e => e.Department == department).ToList();
            var response = new CollectionResponse<EmployeeResponse>(filteredEmployees);
            return Ok(response);
        }
    }

    [HttpGet("/employees/{employeeId}")]
    public ActionResult GetAnEmployee(int employeeId)
    {
        if (employeeId % 2 == 0)
        {
            return Ok(new EmployeeResponse(Guid.NewGuid(), "Bob Smith", "DEV"));
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost("/employees")]
    public ActionResult HireAnEmployee([FromBody] EmployeeHireRequest request)
    {
        // validate the thing...
        // save it to the database..

        var response = new EmployeeResponse(Guid.NewGuid(), request.Name, request.Department);
        return Ok(response);
    }

}

public record EmployeeHireRequest(string Name, string Department);

public record DemoResponse(string Message, DateTimeOffset CreatedAt);

public record EmployeeResponse(Guid Id, string Name, string Department);


public record CollectionResponse<T>(List<T> Data);