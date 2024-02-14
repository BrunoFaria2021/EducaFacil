namespace EducaFacil.Domain.Entities
{
    public class ResponsavelContratante
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Sobrenome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string NumeroContato { get; set; } = string.Empty;
        public string WhatsApp { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string CodigoPostal { get; set; } = string.Empty;
        public string NumeroEndereco { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
        public string EstadoEndereco { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Observacao { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataVencimento { get; }

        //relacionamento
        public virtual List<Aluno> Alunos { get; set; } = new List<Aluno>();
    }
}
