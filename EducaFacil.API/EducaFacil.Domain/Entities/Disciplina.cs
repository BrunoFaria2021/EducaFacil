using System.ComponentModel.DataAnnotations.Schema;

namespace EducaFacil.Domain.Entities
{
    public class Disciplina
    {
        public Guid Id {get; set;}
        public string Nome {get; set;}

        [ForeignKey("CursoId")]
        public Guid CursoId {get; set;}
        public Curso Curso {get; set;}
        public List<Turma> Turmas {get; set;}
    }
}
