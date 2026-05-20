using Microsoft.EntityFrameworkCore;
using RestAspNorthwind.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("NorthwindDatabase") ?? "Host=localhost;Port=5432;Database=northwind;Username=postgres;Password=postgres";

builder.Services.AddDbContext<NorthwindDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Northwind API v1");
        c.RoutePrefix = "swagger";
    });
    // Отключить HTTPS редирект в Development для локального тестирования
}
else
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

// Переадресация с корневого пути на Swagger
app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger/index.html", permanent: false);
    return Task.CompletedTask;
});

app.Run();