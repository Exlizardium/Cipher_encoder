using Cipher.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton<ReversingProcessor>();
builder.Services.AddSingleton<BrailleProcessor>();
builder.Services.AddSingleton<JumbleProcessor>();
builder.Services.AddSingleton<DebrailleProcessor>();
builder.Services.AddSingleton<DejumbleProcessor>();

var app = builder.Build();

app.UseDefaultFiles(new DefaultFilesOptions
{
    DefaultFileNames = new List<string> { "index.html" }
});
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();