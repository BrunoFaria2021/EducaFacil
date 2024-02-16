using EducaFacil.CrossCutting.Extensions;
using EducaFacil.Domain.Entities;

namespace EducaFacil.Infrastructure.Data.Interfaces
{
    public interface INotificacaoRepository
    {
        RetornoApi<List<Notificacao>> BuscarTodasAsNotificacoesAluno(Guid alunoId);
        RetornoApi<List<Notificacao>> BuscarTodasAsNotificacoesProfessor(Guid professorId);
        RetornoApi<Notificacao> BuscarNotificacao(Guid id);
        RetornoApi<Notificacao> CriarNotificacao(Notificacao notificacao);
        RetornoApi<Notificacao> EditarNotificacao(Guid id, Notificacao notificacao);
        RetornoApi<Notificacao> DeletarNotificacao(Guid id);
    }
}
