namespace EducaFacil.Application.DTOs
{
    public class AlunoDTO
    {      
        public string Nome { get; set; } = string.Empty;
        public string Sobrenome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string Sexo { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public string Observacao { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid ResponsavelId { get; set; }
        //public List<NotaDTO> Notas { get; set; }
    }
}