namespace EducaFacil.Application.ViewModel
{
    public class MatriculaViewModel
    {
        public Guid Id { get; set; }
        public DateTime DataMatricula { get; set; }
        public Guid AlunoId { get; set; }
        public Guid SerieId { get; set; }
        public Guid ResponsavelId { get; set; }
    }
}
