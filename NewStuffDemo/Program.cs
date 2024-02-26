Console.WriteLine("Hello, World!");

var bob = new Employee()
{
    FirstName = "Robert",
    LastName = "Smith"
};

//Console.WriteLine(bob.GetFormattedName());

var fn = bob.GetFormattedName();
Console.WriteLine($"{fn.FullName} has {fn.Length} letter");



Console.WriteLine($"The Salary is {bob.Salary:c} and the birthdate is {bob.Birthdate}");

Console.WriteLine($"First Name is {bob.FirstName.ToUpper()}");


bob.Manager = new Employee
{
    FirstName = "Sue",
    LastName = "Jones"
};

bob.Manager.FirstName = "Diane";



if (bob.Manager is not null)
{
    Console.WriteLine($"The manager is {bob.Manager.FirstName}");
}
else
{
    Console.WriteLine("Bob must be the boss? No manager");
}


var d1 = new Pet
{
    Name = "Fido",
    Breed = "Cairn Terrier"
};

var d2 = new Pet("Sue")
{

    Name = "Fido",
    Breed = "Yorkshire Terrier"
};


var d3 = new Pet("Joe")
{
    Name = "Bailey",
    Breed = "Bailnese"
};



if (d1 == d2)
{
    Console.WriteLine("They are the same");
}
else
{
    Console.WriteLine("They are different");
}