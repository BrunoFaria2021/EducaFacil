using EducaFacil.Application.DTOs;
using EducaFacil.Application.ViewModel;
using EducaFacil.CrossCutting.Extensions;

namespace EducaFacil.Application.Interfaces
{
    public interface IAutenticacaoAppService
    {
        Task<RetornoApi<AutenticacaoViewModel>> Login(LoginDTO loginDTO);

        RetornoApi<TokenAcesso> RefreshToken(string refreshToken);
    }
}
