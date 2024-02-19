using EducaFacil.CrossCutting.Util.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducaFacil.Domain.Entities
{
    public class Turma
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime Horario { get; set; }
        public bool Numero { get; set; }

        // Lista de alunos na turma
        public List<Aluno> Alunos { get; set; } = new List<Aluno>();

        // Lista de professores que ensinam na turma
        public List<Professor> Professores { get; set; } = new List<Professor>();

        // Lista de materias que são ensinadas na turma
        public List<Materia> Materias { get; set; } = new List<Materia>();
        public List<Matricula> Matriculas { get; set; } = new List<Matricula>();
    }

}
