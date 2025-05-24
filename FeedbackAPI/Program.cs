using FeedbackAPI.Models; // Ajusta según tu namespace
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar CORS para permitir solicitudes desde el frontend (NewsPortal)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowNewsPortal", policy =>
    {
        policy.WithOrigins("https://localhost:5002") // Cambia el puerto si tu frontend corre en otro
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Agregar DbContext con SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=feedback.db"));

// Agregar controladores
builder.Services.AddControllers();

var app = builder.Build();

// Usar CORS
app.UseCors("AllowNewsPortal");

// Mapear controladores
app.MapControllers();

app.Run();
