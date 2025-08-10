using TrainReservationApi.Data;
using Microsoft.EntityFrameworkCore;
using TrainReservationApi.services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// CORS politikasý ekleme
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// JSON döngüsel referans sorununu çözmek için
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Train Reservation API",
        Version = "v1"
    });
});

// PostgreSQL baðlantýsý
builder.Services.AddDbContext<ReservationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("TrainReservationDb"));
    // Development ortamýnda detaylý hata mesajlarý için
    if (builder.Environment.IsDevelopment())
    {
        options.EnableSensitiveDataLogging();
        options.EnableDetailedErrors();
    }
});

builder.Services.AddScoped<IRezervasyonService, RezervasyonService>();

var app = builder.Build();

// Swagger her ortamda kullanýlabilir olsun
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Train Reservation API V1");
});

app.UseCors();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Veritabaný migration'larý otomatik uygula
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ReservationDbContext>();
    db.Database.Migrate();
}

app.Run();

