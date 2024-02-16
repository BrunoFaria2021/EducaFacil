namespace EducaFacil.Application.DTOs
{
    public class AlunoUpdateDTO
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public string Genero { get; set; }
        public string Senha { get; set; }
        public string Observacao { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
