using Microsoft.EntityFrameworkCore;
using Tarefas.Domain.Entities;

namespace Tarefas.Data.Context
{
    public class TarefasContext : DbContext
    {
        public DbSet<TarefasDomain> Tarefa { get; set; }

        public TarefasContext(DbContextOptions<TarefasContext> options) : base(options)
        {

        }
    }
}
