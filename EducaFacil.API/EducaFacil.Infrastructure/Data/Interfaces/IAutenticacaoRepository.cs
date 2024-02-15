using EducaFacil.CrossCutting.Extensions;
using EducaFacil.Domain.Entities;

namespace EducaFacil.Infrastructure.Data.Interfaces
{
    public interface IAutenticacaoRepository
    {
        RetornoApi<dynamic> BuscarUsuarioPorEmail(string login);
        RetornoApi<RefreshToken> BuscarRefreshToken(Guid usuarioId);
        RetornoApi<RefreshToken> SalvarRefreshToken(RefreshToken refreshToken);
        RetornoApi<RefreshToken> AtualizarRefreshToken(RefreshToken refreshToken);
    }
}
