namespace Domain.Enum.TypeDocuments;

public enum TypeDocuments
{
    // Documentos Pessoais e de Habilitação (CNH)
    RG = 1,
    CPF = 2,
    CNH = 3,
    ComprovanteResidencia = 4,
    LaudoMedico = 5, // Exame médico/psicotécnico da CNH

    // Documentos de Veículos
    CRLV = 6, // Licenciamento do veículo (CRLV-e)
    CRV_DUT = 7, // Documento de transferência (recibo de compra e venda)
    LaudoVistoria = 8, // Vistoria veicular
    NotaFiscal = 9, // Nota fiscal de compra (veículo zero km)

    // Infrações, Recursos e Outros
    RecursoInfracao = 10, // Formulário/defesa prévia de multa
    NotificacaoAutuacao = 11, // Notificação da multa recebida
    Procuracao = 12, // Caso seja despachante ou advogado
    Outros = 99 // Qualquer outro documento anexo
}
