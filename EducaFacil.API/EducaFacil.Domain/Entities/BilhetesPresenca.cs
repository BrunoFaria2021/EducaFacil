using System.ComponentModel.DataAnnotations.Schema;

namespace EducaFacil.Domain.Entities
{
    public class BilhetesPresenca
    {
        public int Id { get; set; }
        public bool Presente { get; set; }
        public DateTime Data { get; set; }

        [ForeignKey("AlunoId")]
        public Guid AlunoId { get; set; }
    }
}