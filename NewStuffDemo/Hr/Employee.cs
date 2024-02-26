

namespace NewStuffDemo.Hr;

internal class Employee
{


    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public Employee? Manager { get; set; }
    public decimal? Salary { get; set; } = null;

    public DateTime? Birthdate { get; set; } = null;

    public IReadOnlyList<DateTime> UpcomingPtoDates { get; set; } = [new DateTime(2024, 12, 25)];

    public FormattedNameResponse GetFormattedName()
    {
        var fullName = $"{LastName}, {FirstName}";
        return new FormattedNameResponse(fullName, fullName.Length);

    }

}


internal record FormattedNameResponse(string FullName, int Length);


public record Pet(string vetName)
{



    public required string Name { get; init; } = string.Empty;
    public required string Breed { get; init; } = string.Empty;

    public string VetName { get; private set; } = vetName;
}