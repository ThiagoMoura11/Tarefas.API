using System;
using Tarefas.Domain.Entities;

namespace Tarefas.Domain.ViewModels
{
    public class TarefasViewModel
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataConclusao { get; set; }
        public TarefasDomain.PrioridadeTarefa Prioridade { get; set; }
        public bool Concluida { get; set; }
    }
}
