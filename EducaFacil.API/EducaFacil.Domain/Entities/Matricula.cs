using System.ComponentModel.DataAnnotations.Schema;

namespace EducaFacil.Domain.Entities
{
    public class Matricula
    {
        public Guid Id { get; set; }
        public DateTime DataMatricula { get; set; }

        [ForeignKey("AlunoId")]
        public Guid AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        [ForeignKey("ResponsavelId")]
        public Guid ResponsavelId { get; set; }
        public ResponsavelContratante Responsavel { get; set; }

        [ForeignKey("SerieId")]
        public Guid SerieId { get; set; }
        public Serie Serie { get; set; }

        [ForeignKey("TurmaId")]
        public Guid TurmaId { get; set; }
        public Turma Turma { get; set; }

        public List<AlunoMatricula> AlunoMatriculas { get; set; }
    }

}
