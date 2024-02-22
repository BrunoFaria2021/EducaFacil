using System.ComponentModel.DataAnnotations.Schema;

namespace EducaFacil.Domain.Entities
{
    public class Disciplina
    {
        public Guid Id {get; set;}
        public string Nome {get; set;}
        public List<DisciplinaSerie> DisciplinasSeries { get; set; }
    }
}
