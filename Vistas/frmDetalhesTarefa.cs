using iTasks.Controlador;
using iTasks.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTasks
{
    public partial class frmDetalhesTarefa : Form
    {

        TarefaControlador controladorT = new TarefaControlador();
        private Tarefa tarefaAtual;

        public frmDetalhesTarefa(Tarefa tarefa)
        {
            InitializeComponent();
            this.tarefaAtual = tarefa;      
            tarefaAtual = controladorT.CarregarTarefa(tarefaAtual.Id);
            preencherDados(tarefaAtual);

        }

        private void preencherDados(Tarefa tarefaAtual) // metodo para preencher dados automaticos
        {
            if (tarefaAtual == null)
            {
                txtId.Text = "--";
                txtDataCriacao.Text = "--/--/--";
                txtDataRealini.Text = "--/--/--";
                txtdataRealFim.Text = "--/--/--";

            }
            else
            {
                txtId.Text = tarefaAtual.Id.ToString();
                txtDesc.Text = tarefaAtual.Descricao;
                txtOrdem.Text = tarefaAtual.OrdemExecucao.ToString();
                txtStoryPoints.Text = tarefaAtual.StoryPoints.ToString();

                if (tarefaAtual.DataCriacao != null)
                    txtDataCriacao.Text = tarefaAtual.DataCriacao.ToString("dd/MM/yy");
                else
                    txtDataCriacao.Text = "--/--/--";

                if (tarefaAtual.DataRealInicio != DateTime.MinValue)
                    txtDataRealini.Text = tarefaAtual.DataRealInicio.ToString("dd/MM/yy");
                else
                    txtDataRealini.Text = "--/--/--";

                if (tarefaAtual.DataRealFim != DateTime.MinValue)
                    txtdataRealFim.Text = tarefaAtual.DataRealFim.ToString("dd/MM/yy");
                else
                    txtdataRealFim.Text = "--/--/--";

                txtEstado.Text = tarefaAtual.estadoatual.ToString();

                dtInicio.Value = tarefaAtual.DataPrevistaInicio;
                dtFim.Value = tarefaAtual.DataPrevistaFim;

            }

        }

        // Botão gravar, com verificações para que os campos a preencher não vão vazios
        private void btGravar_Click(object sender, EventArgs e)
        {
            if (tarefaAtual == null)
            {
                tarefaAtual = new Tarefa();
            }

            // Verifica descrição
            if (string.IsNullOrWhiteSpace(txtDesc.Text))
            {
                MessageBox.Show("Descrição é obrigatória.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDesc.Focus();
                return;
            }
            tarefaAtual.Descricao = txtDesc.Text;

            // Tipo de Tarefa
            if (cbTipoTarefa.SelectedValue != null && int.TryParse(cbTipoTarefa.SelectedValue.ToString(), out int idTipoTarefa))
            {
                tarefaAtual.IdTipoTarefa = idTipoTarefa;
            }
            else
            {
                MessageBox.Show("Selecione um Tipo de Tarefa válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbTipoTarefa.Focus();
                return;
            }

            // Programador
            if (cbProgramador.SelectedValue != null && int.TryParse(cbProgramador.SelectedValue.ToString(), out int idProgramador))
            {
                tarefaAtual.IdProgramador = idProgramador;
            }
            else
            {
                MessageBox.Show("Selecione um Programador válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbProgramador.Focus();
                return;
            }

            // Ordem Execução
            if (!int.TryParse(txtOrdem.Text, out int ordemExecucao) || ordemExecucao <= 0)
            {
                MessageBox.Show("Ordem de execução deve ser um número inteiro positivo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOrdem.Focus();
                return;
            }
            tarefaAtual.OrdemExecucao = ordemExecucao;

            //Regra 17
            // Verificar se já existe uma tarefa com a mesma ordem para este programador
            bool ordemRepetida = controladorT.VerificarOrdemTarefas(ordemExecucao, tarefaAtual.IdProgramador, tarefaAtual.Id); 

            if (ordemRepetida)
            {
                MessageBox.Show("Já existe uma tarefa com essa ordem para este programador.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOrdem.Focus();
                return;
            }

            // Story Points
            if (!int.TryParse(txtStoryPoints.Text, out int storyPoints) || storyPoints < 0)
            {
                MessageBox.Show("Story Points deve ser um número inteiro não negativo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStoryPoints.Focus();
                return;
            }
            tarefaAtual.StoryPoints = storyPoints;

            // Datas
            tarefaAtual.DataPrevistaInicio = dtInicio.Value;
            tarefaAtual.DataPrevistaFim = dtFim.Value;
            tarefaAtual.estadoatual = EstadoAtual.ToDo;

            // Guarda
            controladorT.GuardaTarefa(tarefaAtual);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmDetalhesTarefa_Activated(object sender, EventArgs e)
        {
            cbProgramador.DataSource = controladorT.ListaProgramadores();
            cbProgramador.DisplayMember = "Nome"; // o que será mostrado na lista
            cbProgramador.ValueMember = "Id";     // o valor interno enviado ao objeto

            cbTipoTarefa.DataSource = controladorT.ListaTiposTarefa();
            cbTipoTarefa.DisplayMember = "Nome"; // o que será mostrado na lista
            cbTipoTarefa.ValueMember = "Id";     // o valor interno enviado ao objeto
        }

        private void dtInicio_ValueChanged(object sender, EventArgs e)
        {

        }
    }
    }
