namespace EducaFacil.CrossCutting.Extensions
{
    public static class HashSenha
    {

        public static string HashSenhaUsuario(string senha)
        {
            string hash = BCrypt.Net.BCrypt.EnhancedHashPassword(senha, 13);

            return hash;
        }

        public static bool VerificarSenha(string senhaFornecida, string senha)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(senhaFornecida, senha);
        }

    }
}
