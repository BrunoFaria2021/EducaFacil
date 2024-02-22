namespace EducaFacil.Domain.Entities
{
    public class Escola
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Localizacao { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public List<Aluno> Alunos { get; set; }
        public List<Professor> Professores { get; set; }
    }
}
