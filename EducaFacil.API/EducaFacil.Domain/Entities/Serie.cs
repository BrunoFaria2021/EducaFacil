namespace EducaFacil.Domain.Entities
{
    public class Serie
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        //Relacionamentos
        public List<DisciplinaSerie> DisciplinasSeries { get; set; }
    }
}
