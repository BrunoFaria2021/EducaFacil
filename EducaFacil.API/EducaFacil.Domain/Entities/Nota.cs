using System.ComponentModel.DataAnnotations.Schema;

namespace EducaFacil.Domain.Entities
{
    public class Nota
    {
        public Guid Id { get; set; }
        public float ValorNota { get; set; }
        public string Disciplina { get; set; }

        //Relacionamento

        [ForeignKey("AlunoId")]
        public Guid AlunoId { get; set; }
        public Aluno Aluno { get; set; }
    }
}
