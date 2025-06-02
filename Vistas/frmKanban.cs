using iTasks.Controlador;
using iTasks.Modelos;
using iTasks.Vistas;
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
    public partial class frmKanban : Form
    {
        Utilizador Utilizador;
        TarefaControlador controladorT = new TarefaControlador();
      
        public frmKanban()
        {
            InitializeComponent();
        }

        public frmKanban(Utilizador utilizador) : this()
        {
            this.Utilizador = utilizador;
            AtualizarNomeUtilizador();
            VerificarUtilizador();
        }

        private void AtualizarNomeUtilizador()
        {
            label1.Text =  "Bem-Vindo: "+ Utilizador.Nome;
           
        }

        private void VerificarUtilizador()
        {
            //se for um programador
            if (Utilizador is Programador)
            {
                utilizadoresToolStripMenuItem.Visible = false;
                btNova.Visible = false;

            }
            if (Utilizador is Gestor)
            {

                
            }
        }

        private void gerirUtilizadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form segundoForm = new frmGereUtilizadores();
            segundoForm.Show();
        }

        private void gerirTiposDeTarefasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form segundoForm = new frmGereTiposTarefas();
            segundoForm.Show();
        }

        private void tarefasTerminadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form segundoForm = new frmConsultarTarefasConcluidas();
            segundoForm.Show();
        }

        private void tarefasEmCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form segundoForm = new frmConsultaTarefasEmCurso();
            segundoForm.Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tem certeza que deseja sair?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btNova_Click(object sender, EventArgs e)
        {
            var proximoId = controladorT.IdTarefa();
            controladorT.CriarTarefa(proximoId);
            // Crie a janela passando o ID
            Form detalhesTarefaForm = new frmDetalhesTarefa(proximoId);
            detalhesTarefaForm.ShowDialog();
            this.AtualizarListas();
        }


        private void frmKanban_Activated(object sender, EventArgs e)
        {
            lstTodo.DataSource = null;
            lstTodo.DataSource = controladorT.ListaToDo();
            lstTodo.DisplayMember = "Descricao";
            lstTodo.ValueMember = "Id";

            lstDoing.DataSource = null;
            lstDoing.DataSource = controladorT.ListaDoing();
            lstDoing.DisplayMember = "Descricao";
            lstDoing.ValueMember = "Id";

            lstDone.DataSource = null;
            lstDone.DataSource = controladorT.ListaDone();
            lstDone.DisplayMember = "Descricao";
            lstDone.ValueMember = "Id";
        }

        private void AtualizarListas()
        {
            lstTodo.DataSource = null;
            lstTodo.DataSource = controladorT.ListaToDo();
            lstTodo.DisplayMember = "Descricao";
            lstTodo.ValueMember = "Id";

            lstDoing.DataSource = null;
            lstDoing.DataSource = controladorT.ListaDoing();
            lstDoing.DisplayMember = "Descricao";
            lstDoing.ValueMember = "Id";

            lstDone.DataSource = null;
            lstDone.DataSource = controladorT.ListaDone();
            lstDone.DisplayMember = "Descricao";
            lstDone.ValueMember = "Id";
        }

        private void btSetDoing_Click(object sender, EventArgs e)
        {
            int tarefaId = -1;

            // Verifica se há alguma tarefa selecionada na coluna "To Do"
            if (lstTodo.SelectedItem != null)
            {
                Tarefa tarefaSelecionada = (Tarefa)lstTodo.SelectedItem;
                tarefaId = tarefaSelecionada.Id;
            }
            // Caso não tenha, verifica na coluna "Doing"
            else if (lstDoing.SelectedItem != null)
            {
                Tarefa tarefaSelecionada = (Tarefa)lstDoing.SelectedItem;
                tarefaId = tarefaSelecionada.Id;
            }
            // Caso não tenha, verifica na coluna "Done"
            else if (lstDone.SelectedItem != null)
            {
                Tarefa tarefaSelecionada = (Tarefa)lstDone.SelectedItem;
                tarefaId = tarefaSelecionada.Id;
            }

            if (tarefaId != -1)
            {
                controladorT.AtualizarEstadoTarefa(tarefaId);
            }
            else
            {
                MessageBox.Show("Não deu");
            }
            this.AtualizarListas();
        }

        private void btSetDone_Click(object sender, EventArgs e)
        {
            int tarefaId = -1;

            // Verifica se há alguma tarefa selecionada na coluna "To Do"
            if /*(lstTodo.SelectedItem != null)
            {
                Tarefa tarefaSelecionada = (Tarefa)lstTodo.SelectedItem;
                tarefaId = tarefaSelecionada.Id;
            }
            // Caso não tenha, verifica na coluna "Doing"
            else if */(lstDoing.SelectedItem != null)
            {
                Tarefa tarefaSelecionada = (Tarefa)lstDoing.SelectedItem;
                tarefaId = tarefaSelecionada.Id;
            }
            // Caso não tenha, verifica na coluna "Done"
            else if (lstDone.SelectedItem != null)
            {
                Tarefa tarefaSelecionada = (Tarefa)lstDone.SelectedItem;
                tarefaId = tarefaSelecionada.Id;
            }

            if (tarefaId != -1)
            {
                controladorT.AtualizarEstadoTarefa(tarefaId);
            }
            else
            {
                MessageBox.Show("Não deu");
            }
            this.AtualizarListas();
        }

        private void btSetTodo_Click(object sender, EventArgs e)
        {
            int tarefaId = -1;

            // Verifica se há alguma tarefa selecionada na coluna "To Do"
            if /*(lstTodo.SelectedItem != null)
            {
                Tarefa tarefaSelecionada = (Tarefa)lstTodo.SelectedItem;
                tarefaId = tarefaSelecionada.Id;
            }
            // Caso não tenha, verifica na coluna "Doing"
            else if (lstDoing.SelectedItem != null)
            {
                Tarefa tarefaSelecionada = (Tarefa)lstDoing.SelectedItem;
                tarefaId = tarefaSelecionada.Id;
            }
            // Caso não tenha, verifica na coluna "Done"
            else if */(lstDone.SelectedItem != null)
            {
                Tarefa tarefaSelecionada = (Tarefa)lstDone.SelectedItem;
                tarefaId = tarefaSelecionada.Id;
            }

            if (tarefaId != -1)
            {
                controladorT.AtualizarEstadoTarefa(tarefaId);
            }
            else
            {
                MessageBox.Show("Não deu");
            }
            this.AtualizarListas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tarefaId = -1;

            // Verifica se há alguma tarefa selecionada na coluna "To Do"
            if /*(lstTodo.SelectedItem != null)
            {
                Tarefa tarefaSelecionada = (Tarefa)lstTodo.SelectedItem;
                tarefaId = tarefaSelecionada.Id;
            }
            // Caso não tenha, verifica na coluna "Doing"
            else if */(lstDoing.SelectedItem != null)
            {
                Tarefa tarefaSelecionada = (Tarefa)lstDoing.SelectedItem;
                tarefaId = tarefaSelecionada.Id;
            }
            // Caso não tenha, verifica na coluna "Done"
            else if (lstDone.SelectedItem != null)
            {
                Tarefa tarefaSelecionada = (Tarefa)lstDone.SelectedItem;
                tarefaId = tarefaSelecionada.Id;
            }

            if (tarefaId != -1)
            {
                //Abre o formulário com o ID da tarefa selecionada
                Form detalhesTarefaForm = new frmDetalhesTarefa(tarefaId);
                detalhesTarefaForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma tarefa para editar.");
            }
            this.AtualizarListas();

        }
    }
}

