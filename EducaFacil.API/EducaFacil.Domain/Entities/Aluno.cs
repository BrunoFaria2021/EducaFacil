using System.ComponentModel.DataAnnotations.Schema;

namespace EducaFacil.Domain.Entities
{
    public class Aluno
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Sobrenome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Sexo { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public string Observacao { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime DataCriacao { get; set; }

        [ForeignKey("ResponsavelId")]
        public Guid ResponsavelId { get; set; }
        public Responsavel Responsavel { get; set; }
        public List<Nota> Notas { get; set; }
        [ForeignKey("MatriculaId")]
        public Guid MatriculaId { get; set; }
        public Matricula Matricula { get; set; }
    }
}
