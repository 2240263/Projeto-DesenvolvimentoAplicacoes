using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.Modelos
{
    public class Tarefa
    {
        [Key]
        public int Id { get; set; }
        public int IdGestor { get; set; }
        public int IdProgramador { get; set; }
        public int OrdemExecucao { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPrevistaInicio { get; set; }
        public DateTime DataPrevistaFim { get; set; }
        public int IdTipoTarefa { get; set; }
        public int StoryPoints { get; set; }
        public DateTime DataRealInicio { get; set; }
        public DateTime DataRealFim { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        public EstadoAtual estadoatual { get; set; }

        public Tarefa()
        {
            DataCriacao = DateTime.Now;
            DataRealInicio = DateTime.Now;
            DataRealFim = DateTime.Now;
        }

        public Tarefa(int idGestor, int idProgramador, int ordemExecucao, string descricao, DateTime dataPrevistaInicio, DateTime dataPrevistaFim, int idTipoTarefa, int storyPoints)
        {
            this.IdGestor = idGestor;
            this.IdProgramador = idProgramador;
            this.OrdemExecucao = ordemExecucao;
            this.Descricao = descricao;
            this.DataPrevistaInicio = dataPrevistaInicio;
            this.DataPrevistaFim = dataPrevistaFim;
            this.IdTipoTarefa = idTipoTarefa;
            this.StoryPoints = storyPoints;
            DataCriacao = DateTime.Now;
            estadoatual = EstadoAtual.ToDo; //Vai assumir o To do por defeito
            DataRealInicio = DateTime.Now;
            DataRealFim = DateTime.Now;
        }
    }
}
