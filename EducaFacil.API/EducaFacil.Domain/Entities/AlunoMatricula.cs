using System.ComponentModel.DataAnnotations.Schema;

namespace EducaFacil.Domain.Entities
{
    public class AlunoMatricula
    {
        [ForeignKey("AlunoId")]
        public Guid AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        [ForeignKey("MatriculaId")]
        public Guid MatriculaId { get; set; }
        public Matricula Matricula { get; set; }
    }
}
