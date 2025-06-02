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
        public string DescricaoTarefa { get; set; }


        TarefaControlador controladorT = new TarefaControlador();
        UtilizadorControlador controladorU = new UtilizadorControlador();
        private int idTarefa; // variável para guardar o id 
        private Tarefa tarefaAtual;

        public frmDetalhesTarefa(int idTarefa)
        {
            InitializeComponent();
            this.idTarefa = idTarefa; // guarda o ID na variável       
            tarefaAtual = controladorT.CarregarTarefa(idTarefa);
            preencherDados(tarefaAtual);

        }

        private void preencherDados(Tarefa tarefaAtual) // metodo para preencher dados automaticos
        {
            if (tarefaAtual == null)
            {
                txtId.Text = idTarefa.ToString();
                txtDesc.Text = DescricaoTarefa;
                txtDataCriacao.Text = DateTime.Now.ToString();
                txtDataRealini.Text = "--/--/--";
                txtdataRealFim.Text = "--/--/--";

            }
            else
            {
                txtId.Text = idTarefa.ToString();
                txtDesc.Text = tarefaAtual.Descricao;
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

            }

        }

        private void btGravar_Click(object sender, EventArgs e)
        {

            if (tarefaAtual == null)
            {
                // Caso não tenha sido carregada, pode criar uma nova
                tarefaAtual = new Tarefa();
                this.tarefaAtual.DataCriacao = DateTime.Now;
            }


            tarefaAtual.Descricao = txtDesc.Text;

            // Converte e atribui o Tipo de Tarefa
            if (cbTipoTarefa.SelectedValue != null && int.TryParse(cbTipoTarefa.SelectedValue.ToString(), out int idTipoTarefa))
            {
                tarefaAtual.IdTipoTarefa = (int)cbTipoTarefa.SelectedValue; ;
            }
            else
            {
                // Opcional: tratar erro ou definir valor padrão
                tarefaAtual.IdTipoTarefa = 0;
            }

            // Converte e atribui o Programador
            if (cbProgramador.SelectedValue != null && int.TryParse(cbProgramador.SelectedValue.ToString(), out int idProgramador))
            {
                tarefaAtual.IdProgramador = (int)cbProgramador.SelectedValue; ;
            }
            else
            {
                // Opcional: tratar erro ou definir valor padrão
                tarefaAtual.IdProgramador = 0;
            }

            // Converte e atribui a Ordem de Execução
            if (int.TryParse(txtOrdem.Text,out int ordem))
            {
                tarefaAtual.OrdemExecucao = ordem;
            }
            else
            {
                tarefaAtual.OrdemExecucao = 0; // valor padrão
            }

            // Converte e atribui os StoryPoints
            if (int.TryParse(txtStoryPoints.Text, out int storyPoints))
            {
                tarefaAtual.StoryPoints = storyPoints;
            }
            else
            {
                tarefaAtual.StoryPoints = 0; // valor padrão
            }

            // Atribui as datas
            tarefaAtual.DataPrevistaInicio = dtInicio.Value;
            tarefaAtual.DataPrevistaFim = dtFim.Value;
            tarefaAtual.estadoatual = EstadoAtual.ToDo;

            // Envie para salvar
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
    }
    }
