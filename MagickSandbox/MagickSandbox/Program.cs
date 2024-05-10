var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.WebHost.UseUrls("http://0.0.0.0:8080");
builder.Services.AddControllers();

var app = builder.Build();
app.MapGet("/", () => "Hello there");
app.Run();