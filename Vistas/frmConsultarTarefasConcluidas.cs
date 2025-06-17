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
        //private int _idGestorAutenticado;
        private Utilizador utilizadorAutenticado;

        public frmConsultarTarefasConcluidas(Utilizador utilizadorAutenticado)
        {
            InitializeComponent();
            this.utilizadorAutenticado = utilizadorAutenticado;
        }


        private void frmConsultarTarefasConcluidas_Load(object sender, EventArgs e)
        {
            CarregarTarefasConcluidas();
            atualizaLabel();

        }
       
        private void CarregarTarefasConcluidas()
        {
            // Obter a lista de todas as tarefas concluídas (estado Done)
            var listaDone = controlador.ListaDone();
            List<Tarefa> listaFiltradaPorUtilizador;

            // Filtrar as tarefas com base no tipo de utilizador autenticado
            if (utilizadorAutenticado is Gestor gestor)
            {
                // Se for um Gestor, mostra as tarefas concluídas que ele tem
                listaFiltradaPorUtilizador = listaDone
                                                .Where(t => t.IdGestor == gestor.Id)
                                                .ToList();
            }
            else if (utilizadorAutenticado is Programador programador)
            {
                // Se for um Programador, mostra apenas as tarefas concluídas que lhe foram atribuídas
                listaFiltradaPorUtilizador = listaDone
                                                .Where(t => t.IdProgramador == programador.Id)
                                                .ToList();
            }
            else
            {
               
                listaFiltradaPorUtilizador = new List<Tarefa>();
            }






            var dadosParaExibir = listaFiltradaPorUtilizador.Select(t =>
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

            if(listaFiltradaPorUtilizador.Count== 0)
            {
                string tipo = "";
                if(utilizadorAutenticado is Gestor)
                {
                    tipo = "Gestor";
                }
                else if(utilizadorAutenticado is Programador)
                {
                    tipo = "Programador";
                }
                MessageBox.Show("Não existem tarefas concluídas associadas a este " + tipo + "!",
                    "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

           
            

            if (utilizadorAutenticado is Gestor)
            {
                
                gvTarefasConcluidas.Columns["TempoDemorado"].Visible = true;
                gvTarefasConcluidas.Columns["TempoPrevisto"].Visible = true;
                gvTarefasConcluidas.Columns["Id"].Visible = false;
                gvTarefasConcluidas.Columns["IdTipoTarefa"].Visible = false;
                gvTarefasConcluidas.Columns["DataCriacao"].Visible = false;
                gvTarefasConcluidas.Columns["IdGestor"].Visible = false;
                gvTarefasConcluidas.Columns["OrdemExecucao"].Visible = false;
            }
            else if (utilizadorAutenticado is Programador)
            {
                gvTarefasConcluidas.Columns["TempoDemorado"].Visible = true;
                gvTarefasConcluidas.Columns["TempoPrevisto"].Visible = false;
                gvTarefasConcluidas.Columns["Id"].Visible = false;
                gvTarefasConcluidas.Columns["IdTipoTarefa"].Visible = false;
                gvTarefasConcluidas.Columns["DataCriacao"].Visible = false;
                gvTarefasConcluidas.Columns["IdGestor"].Visible = true;
                gvTarefasConcluidas.Columns["IdProgramador"].Visible = false;
            }

            // Ajusta o tamanho das colunas
            gvTarefasConcluidas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void gvTarefasConcluidas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)// para abrir os detalhes da tarefa
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

        private void gvTarefasConcluidas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // aplicar a formatção 1 vez só 1x por linha
            if (e.RowIndex < 0 || gvTarefasConcluidas.Rows[e.RowIndex].DataBoundItem == null)
                return;

            var row = gvTarefasConcluidas.Rows[e.RowIndex];

            // Verifica se as colunas existem ns GridView
            if (!gvTarefasConcluidas.Columns.Contains("DataPrevistaFim") || !gvTarefasConcluidas.Columns.Contains("DataRealFim"))
                return;

            // Tenta converter os valores das células em datas
            if (DateTime.TryParse(row.Cells["DataPrevistaFim"].Value?.ToString(), out DateTime dataPrevistaFim) &&
                DateTime.TryParse(row.Cells["DataRealFim"].Value?.ToString(), out DateTime dataRealFim))
            {
                if (dataRealFim <= dataPrevistaFim)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(232, 255, 232); ; // Concluído a tempo
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230); // Fora do prazo
                }
            }
        }



        public void atualizaLabel()
        {
            labelCorConcluida.Text = "Verde: Tarefas Concluídas dentro do prazo previsto. \nVermelho: Tarefas Concluídas fora do prazo previsto.";;
        }
    }


}


