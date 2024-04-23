using Tarefas.Domain.Entities;
using Tarefas.Domain.ViewModels;

namespace Tarefas.Service.Interface
{
    public interface ITarefaService
    {
        Task<IEnumerable<TarefasDomain>> GetTarefas();
        TarefasDomain AddTarefa(TarefasViewModel tarefas);
        TarefasDomain UpdateTarefa(Guid id, TarefasDomain tarefas);
        TarefasDomain DeleteTarefa(Guid id);
    }
}
