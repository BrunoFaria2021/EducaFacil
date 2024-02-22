namespace EducaFacil.Domain.Entities
{
    public class DisciplinaSerie
    {
        public Guid? DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }

        public Guid? SerieId { get; set; }
        public Serie Serie { get; set; }
    }
}
