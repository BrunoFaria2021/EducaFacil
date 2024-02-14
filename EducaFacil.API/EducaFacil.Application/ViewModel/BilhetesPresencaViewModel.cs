namespace EducaFacil.Application.ViewModel
{
    public class BilhetesPresencaViewModel
    {
        public int Id { get; set; }
        public bool Presente { get; set; }
        public DateTime Data { get; set; }
        public Guid AlunoId { get; set; }
    }
}

