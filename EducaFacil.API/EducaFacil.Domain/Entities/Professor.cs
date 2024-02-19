namespace EducaFacil.Domain.Entities
{
    public class Professor
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Contato { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public List<Materia> Materias { get; set; } = new List<Materia>();
        public List<Turma> Turmas { get; set; } = new List<Turma>();
    }


}
