using infrastruruty;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);

//soeb a versao mais atual do projeto para a main

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
        options.RoutePrefix = "swagger";
    });
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();