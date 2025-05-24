var builder = WebApplication.CreateBuilder(args);

// Agregar servicios MVC
builder.Services.AddControllersWithViews();

// Registrar HttpClient para JSONPlaceholder
builder.Services.AddHttpClient("JsonPlaceholder", c =>
{
    c.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
});

var app = builder.Build();

// Configuración pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

// Ruta por defecto con controlador News y acción Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=News}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
