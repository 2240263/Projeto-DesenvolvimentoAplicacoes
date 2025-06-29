﻿using iTasks.Controlador;
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
    public partial class frmConsultaTarefasEmCurso : Form
    {
        private TarefaControlador controlador = new TarefaControlador();
        private int _idGestorAutenticado;
        public frmConsultaTarefasEmCurso(int idGestorAutenticado)
        {
            InitializeComponent();
           
            _idGestorAutenticado = idGestorAutenticado;

        }


        private void frmConsultaTarefasEmCurso_Load(object sender, EventArgs e)
        {
            carregarTarefasemCurso();
            atualizaLabel();
        }


        //METODO PARA VISUALIZAR TODOS OS DADOS NA GRELHA
        private void carregarTarefasemCurso()
        {

            // Obter as listas separadas das tarefas
            var listaToDo = controlador.ListaToDo();
            var listaDoing = controlador.ListaDoing();

            // Combinar as listas numa só
            var listaCombinada = listaToDo.Concat(listaDoing).ToList();

            //filtrar as tarefas pelo ID do gestor autenticado
            var listaFiltradaPorGestor = listaCombinada
                                           .Where(t => t.IdGestor == _idGestorAutenticado)
                                           .ToList();

            if (listaFiltradaPorGestor.Count == 0)
            {
                MessageBox.Show("Não existem tarefas em curso associadas a este gestor.",
                                "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            var dadosParaExibir = listaFiltradaPorGestor.Select(t =>
            {
       
                // Calcular os dias restantes. Estas variáveis são locais a este bloco 'Select'.
                int DiasRestantes = (int)(t.DataPrevistaFim.Date - DateTime.Now.Date).TotalDays;
                int DiasEmAtraso = (int)(DateTime.Now.Date-t.DataPrevistaFim.Date).TotalDays;
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
                    TempoEmFalta = t.estadoatual == EstadoAtual.Done // Se a tarefa está concluída
                                      ? "Concluída" 
                                      : (DiasRestantes > 0 // Se a data prevista de fim ainda não passou
                                         ? $"Faltam {DiasRestantes} {(DiasRestantes == 1 ? "dia" : "dias")}"
                                         : "0 dias"), 

                   
                    TempoEmAtraso = t.estadoatual == EstadoAtual.Done || t.DataPrevistaFim.Date >= DateTime.Now.Date 
                                      ? "No Prazo" 
                                      : $"Atrasada em {DiasEmAtraso} {(DiasEmAtraso == 1 ? "dia" : "dias")}" 
                };

            })
                .OrderBy(t => t.estadoatual).ToList();// ordenada os dados pelo estado atual
            gvTarefasEmCurso.DataSource = dadosParaExibir;
           

            gvTarefasEmCurso.Columns["Id"].Visible = false;
            gvTarefasEmCurso.Columns["idTipoTarefa"].Visible = false;
            gvTarefasEmCurso.Columns["DataCriacao"].Visible = false;
            gvTarefasEmCurso.Columns["idGestor"].Visible = false;
            gvTarefasEmCurso.Columns["StoryPoints"].Visible = false;

            gvTarefasEmCurso.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        //EVENTO PARA FORMATAR A DATAGRIDVIEW
        private void gvTarefasEmCurso_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)  
        {
            gvTarefasEmCurso.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            gvTarefasEmCurso.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;


            
            // Obter o DataBoundItem de forma segura
            object rowDataObj = gvTarefasEmCurso.Rows[e.RowIndex].DataBoundItem;

            if (rowDataObj == null)
                return;

            var estadoAtualProp = rowDataObj.GetType().GetProperty("estadoatual");

            EstadoAtual estadoatual;

            if (estadoAtualProp != null && estadoAtualProp.PropertyType == typeof(EstadoAtual))
            {
                estadoatual = (EstadoAtual)estadoAtualProp.GetValue(rowDataObj);
            }
            else
            {
                estadoatual = EstadoAtual.ToDo;
            }


            // Lê a DataPrevistaFim
            var dtPrevFimProp = rowDataObj.GetType().GetProperty("DataPrevistaFim");
            DateTime? dataPrevistaFim;

            if (dtPrevFimProp != null)
            {
                dataPrevistaFim = (DateTime?)dtPrevFimProp.GetValue(rowDataObj);
            }
            else
            {
                dataPrevistaFim = null;
            }
            if (estadoatual != EstadoAtual.Done && dataPrevistaFim.HasValue)
            {

                double diasRestantes = (dataPrevistaFim.Value.Date - DateTime.Now.Date).TotalDays;
                if (diasRestantes == 1)
                {
                    // Amarelo muito claro
                    gvTarefasEmCurso.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 204);
                }
             
            }
            string coluna = gvTarefasEmCurso.Columns[e.ColumnIndex].Name;
            //DataRealInicio em branco se o estado for ToDo
            if (coluna == "DataRealInicio" && estadoatual == EstadoAtual.ToDo)
            {
                e.Value = "";
                e.FormattingApplied = true;
            }

            //DataRealFim em branco se o estado for ToDo ou Doing
            if (coluna == "DataRealFim" && (estadoatual == EstadoAtual.ToDo || estadoatual == EstadoAtual.Doing))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        //EVENTO PARA ABRIR OS DETALHES SÓ EM MODO LEITURA
        private void gvTarefasEmCurso_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                var itemAnonimo = gvTarefasEmCurso.Rows[e.RowIndex].DataBoundItem;
                if (itemAnonimo != null)
                {
                    // Recupere o ID da tarefa do item anónimo 
                    var taskIdProp = itemAnonimo.GetType().GetProperty("Id");
                    if (taskIdProp != null)
                    {
                        int taskId = (int)taskIdProp.GetValue(itemAnonimo);

                        // Carregue a tarefa original novamente do controlador para passar ao frmDetalhesTarefa
                        Tarefa tarefaSelecionada = controlador.CarregarTarefa(taskId);

                        if (tarefaSelecionada != null)
                        {
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

        //DESCRICAO CORES
        public void atualizaLabel()
        {
            labelCorEmCurso.Text = "Amarelo: Falta apenas 1 dia para terminar esta tarefa.";
        }
    }
}
