using System.ComponentModel.DataAnnotations.Schema;

namespace EducaFacil.Domain.Entities
{
    public class Aluno
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Sobrenome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public int Idade { get; set; } = int.MaxValue;
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
        public ResponsavelContratante Responsavel { get; set; } = new ResponsavelContratante();
        //[ForeignKey("SerieId")]
        //public Guid SerieId { get; set; }
        //public Serie Serie { get; set; }

        public List<AlunoMatricula> AlunoMatriculas { get; set; } = new List<AlunoMatricula>();
        public List<Matricula> Matriculas { get; set; } = new List<Matricula>();
        public List<Notificacao> Notificacoes { get; set;} = new List<Notificacao>();
        public List<BilhetesPresenca> BilhetesPresencas { get; set;} = new List<BilhetesPresenca>();
    }
}
