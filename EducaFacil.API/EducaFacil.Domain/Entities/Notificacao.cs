using System.ComponentModel.DataAnnotations.Schema;

namespace EducaFacil.Domain.Entities
{
    public class Notificacao
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Mensagem { get; set; } = string.Empty;
        public DateTime DataEnvio { get; set; }
        // Outras propriedades relevantes para uma notificação

        [ForeignKey("ResponsavelId")]
        public Guid ResponsavelId { get; set; }
        public ResponsavelContratante Responsavel { get; set; }
    }
}
