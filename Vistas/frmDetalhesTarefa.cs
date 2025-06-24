using iTasks.Controlador;
using iTasks.Modelos;
using iTasks.Vistas;
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
        private Utilizador utilizadoratual;

        TarefaControlador controladorT = new TarefaControlador();
      
        private Tarefa tarefaAtual;
        private bool modoReadOnly;

        public frmDetalhesTarefa(Tarefa tarefa, Utilizador utilizador, bool forcarModoReadyOnly =false)
        {
            InitializeComponent();
            this.utilizadoratual = utilizador;
            if (tarefa == null)
            {
                // Criar nova tarefa se parâmetro for null
                tarefaAtual = new Tarefa();

                if (utilizadoratual is Gestor gestorCriador)
                {
                    tarefaAtual.IdGestor = gestorCriador.Id;
                }
            }

            else
            {
                tarefaAtual = controladorT.CarregarTarefa(tarefa.Id);

                if (tarefaAtual == null)
                {
                    return;
                }
            }

            preencherDados(tarefaAtual);


            if (forcarModoReadyOnly) // utilizar o modo forcar modo realyonly quando se chama , caso contratrio verifica o utilizador para saber se coloca nesse estado ou não
            {
                modoReadOnly = true;
            
            }
            else if (utilizadoratual is Gestor gestorAtual)
            {
                if (tarefa == null || tarefaAtual.Id == 0)
                {
                    // Nova tarefa – pode editar
                    modoReadOnly = false;
                }
                else
                {
                    // Só pode editar se a tarefa for dele
                    modoReadOnly = tarefaAtual.IdGestor != gestorAtual.Id;
                }
            }
            else if (utilizadoratual is Programador)
            {
                modoReadOnly = true;
            }
            else
            {
                modoReadOnly = true; // por segurança
            }

            AplicarModoReadOnly();
        }

       
        //METODO PARA PREENCHER DADOS AUTOMATICOS
        private void preencherDados(Tarefa tarefaAtual) 
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

                escondercampos(tarefaAtual,txtDataRealini, txtdataRealFim);  // VAI CHAMAR metodo para esconder as datas que foram incializadas com a data atual - nomeadamente datarealinicio e datarealfim


                // Após preencher dados, setar os ComboBoxes com os valores atuais
                cbProgramador.SelectedValue = tarefaAtual.IdProgramador;
                cbTipoTarefa.SelectedValue = tarefaAtual.IdTipoTarefa;
            }

        }

        //BOTAO CRIAR DETALHES TAREFA
        private void btGravar_Click(object sender, EventArgs e)
        {
             if (tarefaAtual == null)
             {
                 
                if (utilizadoratual is Gestor gestorCriador) 
                {
                    tarefaAtual = new Tarefa();
                    tarefaAtual.IdGestor = gestorCriador.Id;// associar tarefa ao id do gestor
                }
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

            if (dtInicio.Value.Date < DateTime.Today)
            {
                MessageBox.Show("A data de início não pode ser anterior à data atual.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtInicio.Focus();
                return;
            }
            tarefaAtual.DataPrevistaInicio = dtInicio.Value;

            if (dtFim.Value.Date < dtInicio.Value.Date)
            {
                MessageBox.Show("A data de fim não pode ser anterior à data de início.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtFim.Focus();
                return;
            }
            tarefaAtual.DataPrevistaFim = dtFim.Value;

            tarefaAtual.estadoatual = EstadoAtual.ToDo;

            // Guarda
            controladorT.GuardaTarefa(tarefaAtual);

            FecharJanelaAposDelay();

            txtDesc.Enabled = false;
            txtOrdem.Enabled = false;
            txtStoryPoints.Enabled = false;
            dtInicio.Enabled = false;
            dtFim.Enabled = false;


        }

        //FECHAR FORM AO FIM DE ALGUM TEMPO
        async void FecharJanelaAposDelay() 
        {
            await Task.Delay(1500); // espera pouco mais de 1 segundo antes de fechar
            this.DialogResult = DialogResult.OK;// retorna que o utilizador confirmou ok após o show.dialog e retorna esse resultado - quando devolver ok no geretipo tarefas vai atualizar a lista
            this.Close();           // fecha o formulário
        }


        private void frmDetalhesTarefa_Activated(object sender, EventArgs e)
        {
            if (utilizadoratual is Gestor gestor)
            {
                var listaProgramadores = controladorT.ListaProgramadoresPorGestor(gestor.Id);

                if (!listaProgramadores.Any())
                {
                    MessageBox.Show("Não existem programadores associados a este gestor. Será necessário criar um antes de continuar.",
                                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                    return;
                }

                cbProgramador.DataSource = listaProgramadores;
                cbProgramador.DisplayMember = "Nome";
                cbProgramador.ValueMember = "Id";
            }

            cbTipoTarefa.DataSource = controladorT.ListaTiposTarefa();
            cbTipoTarefa.DisplayMember = "Nome";
            cbTipoTarefa.ValueMember = "Id";

            if (tarefaAtual != null)
            {
                cbProgramador.SelectedValue = tarefaAtual.IdProgramador;
                cbTipoTarefa.SelectedValue = tarefaAtual.IdTipoTarefa;
            }
        }


        private void escondercampos(Tarefa tarefa, TextBox dataRi, TextBox dataRf)
        {
            if (tarefa.estadoatual == EstadoAtual.ToDo)
            {
                dataRi.Visible = false;
                dataRf.Visible = false;
            }
            else if (tarefa.estadoatual == EstadoAtual.Doing)
            {
                dataRi.Visible = true;
                dataRf.Visible = false;
            }
            else
            {
                dataRi.Visible = true;
                dataRf.Visible = true;
            }
        }

        private void AplicarModoReadOnly()
        {
            if (!modoReadOnly)
                return;

            txtDesc.ReadOnly = true;
            txtOrdem.ReadOnly = true;
            txtStoryPoints.ReadOnly = true;
            dtInicio.Enabled = false;
            dtFim.Enabled = false;
            cbProgramador.Enabled = false;
            cbTipoTarefa.Enabled = false;

            btGravar.Enabled = false;
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
