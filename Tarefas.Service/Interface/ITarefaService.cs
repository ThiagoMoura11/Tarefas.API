using Tarefas.Domain.Entities;
using Tarefas.Domain.ViewModels;

namespace Tarefas.Service.Interface
{
    public interface ITarefaService
    {
        Task<IEnumerable<TarefasDomain>> GetTarefas();
    }
}
