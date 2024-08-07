using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.OpenApi.Models;
using Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PetHealthDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 39))));

builder.Services.AddControllers();

// Adiciona o Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PetHealth API", Version = "v1" });
    
    // Configuração para renomear esquemas de tipos
    c.CustomSchemaIds(type => type.FullName);
});

var app = builder.Build();

app.MapControllers();
app.UseSwagger();

// Habilita a interface do usuário do Swagger
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PetHealth V1");
});

app.Run();

