namespace EducaFacil.Domain.Entities
{
    public class Curso
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        //Relacionamentos
        public List<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();
    }
}
