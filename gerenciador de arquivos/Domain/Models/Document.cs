using Domain.Enum.TypeDocuments;
using Domain.Enum.StatusDocument;   
namespace Domain.Models;

public class Document
{
    public int DocumentId { get; set; }
    public TypeDocuments DocumentType { get; set; } 
    
    public string Title { get; set; } = string.Empty; 
    public string FilePath { get; set; } = string.Empty; // Caminho/URL do arquivo PDF/imagem
    public StatusDocument Status { get; set; } = StatusDocument.Pendente; // "Pendente", "Aprovado", "Rejeitado"
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Data do envio

    // Relacionamento: quem enviou o documento
    public int UserId { get; set; }
    public User? User { get; set; }
}