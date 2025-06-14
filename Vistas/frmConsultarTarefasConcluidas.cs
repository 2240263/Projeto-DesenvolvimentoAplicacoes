using iTasks.Controlador;
using iTasks.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTasks
{
    public partial class frmConsultarTarefasConcluidas : Form
    {
        private TarefaControlador controlador = new TarefaControlador();
        private int _idGestorAutenticado;
        public frmConsultarTarefasConcluidas(int idGestorAutenticado)
        {
            InitializeComponent();
            _idGestorAutenticado = idGestorAutenticado;
        }


        //EVENTOOOOOOOOOOOOOOOOOOOOOOOOOOO
        private void frmConsultarTarefasConcluidas_Load(object sender, EventArgs e)
        {
            CarregarTarefasConcluidas();

        }
       
        private void CarregarTarefasConcluidas()
        {
            // Obter a lista de tarefas concluídas (estado Done)
            var listaDone = controlador.ListaDone();

            // Filtrar as tarefas pelo ID do gestor autenticado
            var listaFiltradaPorGestor = listaDone
                                            .Where(t => t.IdGestor == _idGestorAutenticado)
                                            .ToList();

            var dadosParaExibir = listaFiltradaPorGestor.Select(t =>
            {
                
                int DiasUtilizados = (t.DataRealFim != DateTime.MinValue && t.DataRealInicio != DateTime.MinValue && t.DataRealFim >= t.DataRealInicio)
                                ? (int)Math.Ceiling((t.DataRealFim - t.DataRealInicio).TotalDays)
                                : -1; // Usar -1 para indicar "N/A" 

                // Calcular os dias previstos
                int DiasPrevistos = (t.DataPrevistaFim != DateTime.MinValue && t.DataPrevistaInicio != DateTime.MinValue && t.DataPrevistaFim >= t.DataPrevistaInicio)
                                  ? (int)Math.Ceiling((t.DataPrevistaFim - t.DataPrevistaInicio).TotalDays)
                                  : -1; // Usar -1 para indicar "N/A" 

                return new
                {
                    t.Id,
                    t.IdProgramador,
                    t.Descricao,
                    t.OrdemExecucao,
                    t.StoryPoints,
                    t.estadoatual,
                    t.DataCriacao,
                    t.DataPrevistaInicio,
                    t.DataPrevistaFim,
                    t.DataRealInicio,
                    t.DataRealFim,
                    t.IdTipoTarefa,
                    t.IdGestor,

                    // --- Novas Colunas Calculadas ---

                    TempoEmFalta = t.estadoatual == EstadoAtual.Done // 
                                       ? "Concluída"
                                       : (t.DataPrevistaFim.Date > DateTime.Now.Date
                                          ? $"Faltam {(int)(t.DataPrevistaFim.Date - DateTime.Now.Date).TotalDays}dias"
                                          : "0 dias"), // 

                    // Tempo Demorado: Diferença em dias entre DataRealFim e DataRealInicio

                    TempoDemorado = (t.DataRealFim != DateTime.MinValue && t.DataRealInicio != DateTime.MinValue && t.DataRealFim >= t.DataRealInicio)
                                        ? $"{(int)Math.Ceiling((t.DataRealFim - t.DataRealInicio).TotalDays)} dias"
                                        : "N/A", 

                    // Tempo Previsto: Diferença em dias entre DataPrevistaFim e DataPrevistaInicio

                    TempoPrevisto = (t.DataPrevistaFim != DateTime.MinValue && t.DataPrevistaInicio != DateTime.MinValue && t.DataPrevistaFim >= t.DataPrevistaInicio)
                                        ? $"{(int)Math.Ceiling((t.DataPrevistaFim - t.DataPrevistaInicio).TotalDays)} dias"
                                       : "N/A"
                };
        })
            // Ordena as tarefas,pela DataRealFim 
            .OrderByDescending(t => t.DataRealFim).ToList();

            // Atribui a lista de objetos  ao DataSource do DataGridView
            gvTarefasConcluidas.DataSource = dadosParaExibir;

           
            gvTarefasConcluidas.Columns["Id"].Visible = false;
            gvTarefasConcluidas.Columns["IdTipoTarefa"].Visible = false;
            gvTarefasConcluidas.Columns["DataCriacao"].Visible = false;
            gvTarefasConcluidas.Columns["IdGestor"].Visible = false;
            gvTarefasConcluidas.Columns["OrdemExecucao"].Visible = false;

            // Ajusta o tamanho das colunas
            gvTarefasConcluidas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }





        //EVENTOOOOOOOOOOOOOOOOOOOOOOOOOOO
        private void gvTarefasConcluidas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                var itemAnonimo = gvTarefasConcluidas.Rows[e.RowIndex].DataBoundItem;
                if (itemAnonimo != null)
                {
                    var taskIdProp = itemAnonimo.GetType().GetProperty("Id");
                    if (taskIdProp != null)
                    {
                        int taskId = (int)taskIdProp.GetValue(itemAnonimo);

                        // Recarregue a tarefa original do controlador para passar ao frmDetalhesTarefa

                        Tarefa tarefaSelecionada = controlador.CarregarTarefa(taskId);

                        if (tarefaSelecionada != null)
                        {
                            // Abre os detalhes da tarefa em modo somente leitura para tarefas concluídas
                            var formDetalhes = new frmDetalhesTarefa(tarefaSelecionada, null, forcarModoReadyOnly: true);
                            formDetalhes.ShowDialog();
                        }


                    }
                }

            }
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        
    }
}


