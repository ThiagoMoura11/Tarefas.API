using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tarefas.Data.Context;
using Tarefas.Domain.Entities;
using Tarefas.Domain.Interface;

namespace Tarefas.Data.Repositories
{
    public class TarefaRepository : ITarefasRepository
    {
        private readonly TarefasContext _context;
        public TarefaRepository(TarefasContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TarefasDomain>> GetTarefas()
        {
            return await _context.Tarefa.ToListAsync();
        }

        public async Task<TarefasDomain> GetTarefaById(Guid id)
        {
            return await _context.Tarefa.FindAsync(id);
        }

        public async Task<TarefasDomain> AddTarefa(TarefasDomain tarefa)
        {
            _context.Tarefa.Add(tarefa);
            await _context.SaveChangesAsync();
            return tarefa;
        }

        public async Task<TarefasDomain> UpdateTarefa(TarefasDomain tarefa)
        {
            _context.Entry(tarefa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return tarefa;
        }

        public async Task<bool> DeleteTarefa(Guid id)
        {
            var tarefa = await _context.Tarefa.FindAsync(id);
            if (tarefa == null)
                return false;

            _context.Tarefa.Remove(tarefa);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
