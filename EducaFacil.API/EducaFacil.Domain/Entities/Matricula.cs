using System.ComponentModel.DataAnnotations.Schema;

namespace EducaFacil.Domain.Entities
{
    public class Matricula
    {
        public Guid Id { get; set; }
        [ForeignKey("AlunoId")]
        public Guid AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        [ForeignKey("TurmaId")]
        public Guid TurmaId { get; set; }
        public Turma Turma { get; set; }
    }
}
