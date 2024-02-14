namespace EducaFacil.Application.DTOs
{
    public class AlunoDTO
    {       
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CPF { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public string Genero { get; set; }
        public string Observacao { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid ResponsavelId { get; set; }        
    }
}
