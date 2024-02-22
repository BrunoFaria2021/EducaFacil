namespace EducaFacil.Application.DTOs
{
    public class EscolaDTO
    {
        public string Nome { get; set; }
        public string Localizacao { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public List<AlunoDTO> Alunos { get; set; }
        public List<ProfessorDTO> Professores { get; set; }
    }
}