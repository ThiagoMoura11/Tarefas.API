namespace Tarefas.Domain.Entities
{
    using System;
    using System.Net.NetworkInformation;
    public class TarefasDomain
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; }
        public DateTime? DataConclusao { get; set; }
        public PrioridadeTarefa Prioridade { get; set; }
        public bool Concluida { get; set; }

        public TarefasDomain()
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;
            Titulo = string.Empty;
            Descricao = string.Empty;
        }

        public void ConcluirTarefa()
        {
            if (!Concluida)
            {
                Concluida = true;
                DataConclusao = DateTime.Now;
            }
        }

        public void ReabrirTarefa()
        {
            if (Concluida)
            {
                Concluida = false;
                DataConclusao = null;
            }
        }

        public enum PrioridadeTarefa
        {
            Baixa,
            Média,
            Alta
        }
    }
}
