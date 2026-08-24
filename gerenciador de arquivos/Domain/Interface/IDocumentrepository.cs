using Domain.Enum.TypeDocuments;
using Domain.Enum.StatusDocument;
using Domain.Models;

namespace Domain.Interface.IDocumentrepository;

public interface IDocumentrepository
{
    Task<List<Document>> GetAllAsync(); 
    Task<List<Document>> GetByUserIdAsync(int userId); 
    Task<List<Document>> GetByTypeAsync(TypeDocuments type); 
    Task<Document?> GetByIdAsync(int id);
    Task<Document> CreateAsync(Document document); 
    Task<int> UpdateStatusAsync(int id, StatusDocument newStatus); 
    Task<int> DeleteAsync(int id); 
}