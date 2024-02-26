// public static void Main(string[] args)

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. "Container is an Inversion of Control (IOC) Container"

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Use reflection at runtime to document your API with an openapi3.0 spec.

// Above this line is "setup" configuration. 
var app = builder.Build();
// Everything after this line is actually mapping requests coming in to code.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // that "AddSwaggerGen" thing above? This makes it available through a URL.
    app.UseSwaggerUI(); // Makes a web page available at /swagger/index.html that reads the above open api spec and shows a UI.
}

app.UseAuthorization();

app.MapControllers();


app.Run(); // Blocking Call. This is the webserver (kestrel) running and listing as long as the application runs..

