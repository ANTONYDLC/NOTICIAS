var builder = WebApplication.CreateBuilder(args);

// Agregar servicios MVC
builder.Services.AddControllersWithViews();

// Registrar HttpClient para JsonPlaceholder
builder.Services.AddHttpClient("JsonPlaceholder", c =>
{
    c.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
});

// Registrar HttpClient para FeedbackAPI local
builder.Services.AddHttpClient("FeedbackAPI", c =>
{
    c.BaseAddress = new Uri("https://localhost:5155/");
})
.ConfigurePrimaryHttpMessageHandler(() =>
{
    return new HttpClientHandler
    {
        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
    };
});

var app = builder.Build();

// Pipeline configuración
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=News}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
