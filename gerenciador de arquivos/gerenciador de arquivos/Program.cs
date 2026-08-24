using Domain.Enum.StatusDocument;
using Domain.Enum.TypeDocuments;
using Domain.Interface;
using Domain.Interface.IDocumentrepository;
using Domain.Models;
using infrastruruty;
using infrastruruty.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuração do DbContext com PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Injeção de Dependências dos Repositórios
builder.Services.AddScoped<UserRepository, UserRepositorie>();
builder.Services.AddScoped<IDocumentrepository, DocumentRepository>();

// 3. Configuração do OpenAPI / Swagger
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// ==========================================
// ROTAS DE USUÁRIOS (/api/users)
// ==========================================
app.MapGet("/api/users", async (UserRepository repo) =>
{
    var users = await repo.GetUsersAsync();
    return Results.Ok(users);
});

app.MapGet("/api/users/{id:int}", async (int id, UserRepository repo) =>
{
    var user = await repo.GetByIdAsync(id);
    return user is not null ? Results.Ok(user) : Results.NotFound(new { message = "Usuário não encontrado." });
});

app.MapPost("/api/users", async (User user, UserRepository repo) =>
{
    var created = await repo.CreateAsync(user);
    return Results.Created($"/api/users/{created.UserId}", created);
});

app.MapDelete("/api/users/{id:int}", async (int id, UserRepository repo) =>
{
    var deleted = await repo.DeleteAsync(id);
    return deleted > 0 ? Results.Ok(new { message = "Usuário excluído com sucesso." }) : Results.NotFound(new { message = "Usuário não encontrado." });
});

// ==========================================
// ROTAS DE DOCUMENTOS (/api/documents)
// ==========================================
app.MapGet("/api/documents", async (IDocumentrepository repo) =>
{
    var docs = await repo.GetAllAsync();
    return Results.Ok(docs);
});

app.MapGet("/api/documents/{id:int}", async (int id, IDocumentrepository repo) =>
{
    var doc = await repo.GetByIdAsync(id);
    return doc is not null ? Results.Ok(doc) : Results.NotFound(new { message = "Documento não encontrado." });
});

app.MapGet("/api/documents/user/{userId:int}", async (int userId, IDocumentrepository repo) =>
{
    var docs = await repo.GetByUserIdAsync(userId);
    return Results.Ok(docs);
});

app.MapGet("/api/documents/type/{type}", async (TypeDocuments type, IDocumentrepository repo) =>
{
    var docs = await repo.GetByTypeAsync(type);
    return Results.Ok(docs);
});

app.MapPost("/api/documents", async (Document doc, IDocumentrepository repo) =>
{
    var created = await repo.CreateAsync(doc);
    return Results.Created($"/api/documents/{created.DocumentId}", created);
});

app.MapPatch("/api/documents/{id:int}/status", async (int id, StatusDocument status, IDocumentrepository repo) =>
{
    var updated = await repo.UpdateStatusAsync(id, status);
    return updated > 0 ? Results.Ok(new { message = "Status atualizado com sucesso." }) : Results.NotFound(new { message = "Documento não encontrado." });
});

app.MapDelete("/api/documents/{id:int}", async (int id, IDocumentrepository repo) =>
{
    var deleted = await repo.DeleteAsync(id);
    return deleted > 0 ? Results.Ok(new { message = "Documento excluído com sucesso." }) : Results.NotFound(new { message = "Documento não encontrado." });
});

app.Run();
