using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Adiciona o Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PetHealth API", Version = "v1" });
});
var app = builder.Build();

app.MapControllers();
app.UseSwagger();

// Habilita a interface do usuário do Swagger
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("v1/swagger.json", "PetHealth V1");
});

app.Run();
