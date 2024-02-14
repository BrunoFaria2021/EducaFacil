namespace EducaFacil.Domain.Entities
{
    public class RefreshToken
    {
        public Guid Id { get; set; }

        public Guid UsuarioId { get; set; }

        public string Refresh_Token { get; set; } = string.Empty;

        public DateTime ExpiraEm { get; set; }

        public DateTime DataUltimoUso { get; set; }
    }
}
