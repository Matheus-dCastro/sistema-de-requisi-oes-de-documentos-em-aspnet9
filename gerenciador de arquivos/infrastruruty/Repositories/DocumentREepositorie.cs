using Domain.Enum.StatusDocument;
using Domain.Enum.TypeDocuments;
using Domain.Interface.IDocumentrepository;
using Domain.Models;
using infrastruruty.Data;
using Microsoft.EntityFrameworkCore;

namespace infrastruruty.Repositories;

public class DocumentRepository : IDocumentrepository
{
    private readonly AppDbContext _context;

    // Recebe a conexão com o banco via injeção de dependência
    public DocumentRepository(AppDbContext context)
    {
        _context = context;
    }

    // 1. Cadastrar novo documento
    public async Task<Document> CreateAsync(Document document)
    {
        await _context.Documents.AddAsync(document);
        await _context.SaveChangesAsync();
        return document;
    }

    public async Task<List<Document>> GetAllAsync()
    {
        return await _context.Documents
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Document?> GetByIdAsync(int id)
    {
        return await _context.Documents
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.DocumentId == id);
    }

    public async Task<List<Document>> GetByUserIdAsync(int userId)
    {
        return await _context.Documents
            .AsNoTracking()
            .Where(d => d.UserId == userId)
            .ToListAsync();
    }
    public async Task<int> DeleteAsync(int id)
    {
        var doc = await _context.Documents.FirstOrDefaultAsync(d => d.DocumentId == id);
        if (doc is null)
            return 0;

        _context.Documents.Remove(doc);
        return await _context.SaveChangesAsync();
    }
    public async Task<List<Document>> GetByTypeAsync(TypeDocuments type)
    {
        return await _context.Documents
            .AsNoTracking()
            .Where(d => d.DocumentType == type)
            .ToListAsync();
    }
    public async Task<int> UpdateStatusAsync(int id, StatusDocument newStatus)
    {
        return await _context.Documents
            .Where(d => d.DocumentId == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(d => d.Status, newStatus)
            );
    }

}