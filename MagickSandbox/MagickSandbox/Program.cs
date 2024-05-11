using ImageMagick;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapGet("/", () =>
{
    using var image = new MagickImage();
    return "Created image!";
});
app.Run();