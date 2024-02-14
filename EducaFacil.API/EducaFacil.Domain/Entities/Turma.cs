using EducaFacil.CrossCutting.Util.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducaFacil.Domain.Entities
{
    public class Turma
    {
        public Guid Id { get; set;}
        public string Nome { get; set; } = string.Empty;
        public EnumTipoTurno Tipo { get; set; }
        [ForeignKey("CursoId")]
        public Guid CursoId { get; set;}
        //public List<Aluno> Alunos { get; set; } = new List<Aluno>();
        [ForeignKey("DisciplinaId")]
        public Guid DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }
        [ForeignKey("ProfessorId")]
        public Guid ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public List<Matricula> Matriculas { get; set; }
    }
}
