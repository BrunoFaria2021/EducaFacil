using System.ComponentModel.DataAnnotations.Schema;

namespace EducaFacil.Domain.Entities
{
    public class Materia
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        [ForeignKey("ProfessorId")]
        public Guid ProfessorId { get; set; }
        public Professor Professor { get; set; }       
    }
}
