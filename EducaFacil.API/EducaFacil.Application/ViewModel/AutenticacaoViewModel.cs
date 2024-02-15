namespace EducaFacil.Application.ViewModel
{
    public class AutenticacaoViewModel
    {
        public TokenAcesso TokenAcesso { get; set; } = new TokenAcesso();
        public RefreshTokenAcesso RefreshTokenAcesso { get; set; } = new RefreshTokenAcesso();

    }


    public class TokenAcesso
    {
        public dynamic Token { get; set; } = string.Empty;
        public DateTime ExpiracaoToken { get; set; }
    }


    public class RefreshTokenAcesso
    {
        public dynamic RefreshToken { get; set; } = string.Empty;
        public DateTime ExpiracaoRefreshToken { get; set; }
    }
}
