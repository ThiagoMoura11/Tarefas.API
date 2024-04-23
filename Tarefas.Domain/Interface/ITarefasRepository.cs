using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tarefas.Domain.Entities;

namespace Tarefas.Domain.Interface
{
    public interface ITarefasRepository
    {
        Task<IEnumerable<TarefasDomain>> GetTarefas();
        Task<TarefasDomain> GetTarefaById(Guid id);
        Task<TarefasDomain> AddTarefa(TarefasDomain tarefa);
        Task<TarefasDomain> UpdateTarefa(TarefasDomain tarefa);
        Task<bool> DeleteTarefa(Guid id);
    }
}
