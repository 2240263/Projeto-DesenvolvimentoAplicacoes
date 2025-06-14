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
            AtualizarListas();
            AtualizarNomeUtilizador();
            VerificarUtilizador();

        }

        private void AtualizarNomeUtilizador()
        {
            label1.Text = "Bem-Vindo: " + Utilizador.Nome;

        }

        private void VerificarUtilizador()
        {
            //se for um programador
            if (Utilizador is Programador)
            {
                tarefasEmCursoToolStripMenuItem.Visible = false; //opção tarefas em curso
                utilizadoresToolStripMenuItem.Visible = false; //menu acesso as tarefas
                btNova.Visible = false; //botao novatarefa
                buttonApagarTarefa.Visible = false;
                buttonEditarTarefa.Visible = false;
                exportarParaCSVToolStripMenuItem.Visible = false; // botao converter em csv
                btPrevisao.Visible = false; // botao previsao


            }
            if (Utilizador is Gestor)
            {
                btSetDoing.Visible = false;
                btSetDone.Visible = false;
                btSetTodo.Visible = false;


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
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------










        private void tarefasEmCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Utilizador is Gestor gestorAutenticado)
            {
                Form segundoForm = new frmConsultaTarefasEmCurso(gestorAutenticado.Id);
                segundoForm.Show();
            }
           

           // Form segundoForm = new frmConsultaTarefasEmCurso();
            //segundoForm.Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tem certeza que deseja sair?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // BUTÃO PARA CRIAR NOVAS TAREFAS - a funcionar
        //-----------------------------------------------------------------------------------------------------

        private void btNova_Click(object sender, EventArgs e)
        {
            // Cria um novo objeto Tarefa, mas ainda não salva no BD
            Tarefa novaTarefa = new Tarefa();

            // Abre o formulário de detalhes, passando a nova tarefa
            Form detalhesTarefaForm = new frmDetalhesTarefa(novaTarefa, Utilizador);

            var resultado = detalhesTarefaForm.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                // para atualizar as listas 
                AtualizarListas();

            }

        }

        //BUTÃO PARA EDITAR TAREFAS - a funcionar
        //-----------------------------------------------------------------------------------------------------

        private void btnEditar(object sender, EventArgs e)
        {
            Tarefa tarefaSelecionada = null;
            int tarefaId = -1;

            // Verifica se há alguma tarefa selecionada na coluna "To Do"
            if (lstTodo.SelectedItem != null)
            {
                tarefaSelecionada = (Tarefa)lstTodo.SelectedItem;
                tarefaId = tarefaSelecionada.Id;
            }
            // Caso não tenha, verifica na coluna "Doing"
            else if (lstDoing.SelectedItem != null)
            {
                tarefaSelecionada = (Tarefa)lstDoing.SelectedItem;
                tarefaId = tarefaSelecionada.Id;
            }
            // Caso não tenha, verifica na coluna "Done"
            else if (lstDone.SelectedItem != null)
            {
                tarefaSelecionada = (Tarefa)lstDone.SelectedItem;
                tarefaId = tarefaSelecionada.Id;
            }

            if (tarefaSelecionada != null)
            {

                //Abre o formulário com o ID da tarefa selecionada
                Form detalhesTarefaForm = new frmDetalhesTarefa(tarefaSelecionada, Utilizador);
                var resultado = detalhesTarefaForm.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    AtualizarListas();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma tarefa para editar.");
            }

        }

        // BUTÃO PARA APAGAR TAREFAS - a funcionar
        //-----------------------------------------------------------------------------------------------------

        private void buttonApagarTarefa_Click(object sender, EventArgs e)
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
                //Abre o formulário com o ID da tarefa selecionada
                controladorT.ApagarTarefa(tarefaId);
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma tarefa para editar.");
            }
            this.AtualizarListas();


        }


        //  MÉTODOS PARA ATUALIZAR OS ESTADOS DAS TAREFAS - a funcionar 
        //-----------------------------------------------------------------------------------------------------


        // Passar para Doing, regras : 15 Duas tarefas em Doing, 16 Passar por Ordem de Execução
        private void btSetDoing_Click(object sender, EventArgs e)
        {
            // Verifica se há alguma tarefa selecionada na coluna "To Do"
            if (lstTodo.SelectedItem != null)
            {
                Tarefa tarefaSelecionada = (Tarefa)lstTodo.SelectedItem;

                // Regra 15
                int tarefasEmDoing = controladorT.TarefasEmDoing(Utilizador.Id);

                if (tarefasEmDoing < 2)
                {
                    // Regra 16
                    bool ordemTarefasCerta = controladorT.VerificarTarefaPrioritariaToDo(tarefaSelecionada, Utilizador.Id);

                    if (ordemTarefasCerta)
                    {
                        if (tarefaSelecionada.Id != -1)
                        {
                            controladorT.AtualizarEstadoTarefa(tarefaSelecionada.Id);

                        }
                        else
                        {
                            MessageBox.Show("Erro ao atualizar Estado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Tem de executar as tarefas pela ordem de execução.");
                        return; // sai do método
                    }
                }
                else
                {
                    MessageBox.Show("Limite de tarefas em estado Doing.");
                    return;
                }

            }
            // Caso não tenha envia mensagem
            else
            {
                MessageBox.Show("Por favor, selecione uma tarefa da lista To Do.");
            }
            this.AtualizarListas();
        }

        private void btSetDone_Click(object sender, EventArgs e)
        {
            // Verifica na coluna "Doing" se algo está selecionado
            if (lstDoing.SelectedItem != null)
            {
                Tarefa tarefaSelecionada = (Tarefa)lstDoing.SelectedItem;

                // Regra 16
                bool ordemTarefasCerta = controladorT.VerificarTarefaPrioritariaDoing(tarefaSelecionada, Utilizador.Id);

                if (ordemTarefasCerta)
                {
                    if (tarefaSelecionada.Id != -1)
                    {
                        controladorT.AtualizarEstadoTarefa(tarefaSelecionada.Id);
                    }
                    else
                    {
                        MessageBox.Show("Erro ao atualizar Estado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Tem de executar as tarefas pela ordem de execução.");
                    return; // sai do método
                }
            }

            // Caso não tenha envia mensagem
            else
            {
                MessageBox.Show("Por favor, selecione uma tarefa da lista Doing.");
            }

            this.AtualizarListas();
        }

        private void btSetTodo_Click(object sender, EventArgs e)
        {
            int tarefaId = -1;

            // Verifica se há alguma tarefa selecionada na coluna "Doing"
            if (lstDoing.SelectedItem != null)
            {
                Tarefa tarefaSelecionada = (Tarefa)lstDoing.SelectedItem;
                tarefaId = tarefaSelecionada.Id;
            }
            // Caso não tenha envia mensagem
            else
            {
                MessageBox.Show("Por favor, selecione uma tarefa da lista Doing.");
            }

            if (tarefaId != -1)
            {
                controladorT.ReverterEstadoTarefa(tarefaId);
            }
            else
            {
                MessageBox.Show("Erro ao atualizar Estado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.AtualizarListas();
        }


        // METODO PARA ATUALIZAR AS LISTAS NO KANBAN - a funcionar
        //-----------------------------------------------------------------------------------------------------

        public void AtualizarListas()
        {
            TarefaControlador controladorNovo = new TarefaControlador(); // resolve o problema da edição não atualizar
            lstTodo.DataSource = null;
            lstTodo.DataSource = controladorNovo.ListaToDo();
            lstTodo.DisplayMember = "Descricao";
            lstTodo.ValueMember = "Id";

            lstTodo.ClearSelected();

            lstDoing.DataSource = null;
            lstDoing.DataSource = controladorNovo.ListaDoing();
            lstDoing.DisplayMember = "Descricao";
            lstDoing.ValueMember = "Id";

            lstDoing.ClearSelected();

            lstDone.DataSource = null;
            lstDone.DataSource = controladorNovo.ListaDone();
            lstDone.DisplayMember = "Descricao";
            lstDone.ValueMember = "Id";

            lstDone.ClearSelected();

        }


        // MÉTODO QUE CARREGA AS LISTAS QUANDO O FORM É ATIVADO - se retirar não atualiza no  início mes chamando a função
        //-----------------------------------------------------------------------------------------------------
        private void frmKanban_Activated(object sender, EventArgs e)
        {
            lstTodo.DataSource = null;
            lstTodo.DataSource = controladorT.ListaToDo();
            lstTodo.DisplayMember = "Descricao";
            lstTodo.ValueMember = "Id";

            lstTodo.ClearSelected();

            lstDoing.DataSource = null;
            lstDoing.DataSource = controladorT.ListaDoing();
            lstDoing.DisplayMember = "Descricao";
            lstDoing.ValueMember = "Id";

            lstDoing.ClearSelected();

            lstDone.DataSource = null;
            lstDone.DataSource = controladorT.ListaDone();
            lstDone.DisplayMember = "Descricao";
            lstDone.ValueMember = "Id";

            lstDone.ClearSelected();
        }

        private void lstTodo_MouseDoubleClick(object sender, MouseEventArgs e) // para abrir detalhes de tarefa clicando duas vezes - ToDo
        {


            ListBox lista = sender as ListBox;

            if (lista.SelectedItem != null && lista.SelectedItem is Tarefa tarefaSelecionada)
            {
                Form detalhesTarefaForm = new frmDetalhesTarefa(tarefaSelecionada, Utilizador);
                var resultado = detalhesTarefaForm.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    AtualizarListas();
                }
            }
        }

        private void lstDoing_MouseDoubleClick(object sender, MouseEventArgs e)// para abrir detalhes de tarefa clicando duas vezes - Doing
        {
            ListBox lista = sender as ListBox;

            if (lista.SelectedItem != null && lista.SelectedItem is Tarefa tarefaSelecionada)
            {
                Form detalhesTarefaForm = new frmDetalhesTarefa(tarefaSelecionada, Utilizador);
                var resultado = detalhesTarefaForm.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    AtualizarListas();
                }
            }
        }

        private void lstDone_MouseDoubleClick(object sender, MouseEventArgs e) // neste caso chama o forcar realy only, pois já não é possivel alterar nada
        {
            ListBox lista = sender as ListBox;

            if (lista.SelectedItem != null && lista.SelectedItem is Tarefa tarefaSelecionada)
            {
                // Só força modo só leitura quando abrir a partir desta listbox
                Form detalhesTarefaForm = new frmDetalhesTarefa(tarefaSelecionada, Utilizador, forcarModoReadyOnly: true);
                var resultado = detalhesTarefaForm.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    AtualizarListas();
                }
            }

        }
    }
}


