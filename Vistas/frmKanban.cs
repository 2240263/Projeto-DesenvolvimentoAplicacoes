using iTasks.Controlador;
using iTasks.Modelos;
using iTasks.Vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

            // ativar o draw mode para podermos usar cores e associar as ListBoxs
            lstTodo.DrawMode = DrawMode.OwnerDrawFixed;
            lstDoing.DrawMode = DrawMode.OwnerDrawFixed;
            lstDone.DrawMode = DrawMode.OwnerDrawFixed;

            lstTodo.DrawItem += LstTodo_DrawItem;
            lstDoing.DrawItem += LstDoing_DrawItem;
            lstDone.DrawItem += LstDone_DrawItem;
        }



        public frmKanban(Utilizador utilizador) : this()
        {
            this.Utilizador = utilizador;
            AtualizarListas();
            AtualizarNomeUtilizador();
            VerificarUtilizador();

        }
        private bool TarefaPertenceAoUtilizador(Tarefa tarefa)
        {
            if (Utilizador is Gestor gestor)
                return tarefa.IdGestor == gestor.Id;

            if (Utilizador is Programador prog)
                return tarefa.IdProgramador == prog.Id;

            // Se for daquela equipa, pode mudar as tarefas de estado
            return true;
        }

        private void AtualizarNomeUtilizador()
        {
            string tipo;

            if (Utilizador is Gestor)
            {
                tipo = "Gestor";
            }
            else if (Utilizador is Programador)
            {
                tipo = "Programador";
            }
            else
            {
                tipo = "Utilizador";
            }

            label1.Text = "Bem-Vindo: " + Utilizador.Nome + " (" + tipo + ")";
         

        }

        //Verificar campos visiveis para cada utilizador
        private void VerificarUtilizador()
        {
            //se for um programador
            if (Utilizador is Programador)
            {

                utilizadoresToolStripMenuItem.Visible = false; //menu acesso as tarefas
                btNova.Visible = false; //botao novatarefa
                buttonApagarTarefa.Visible = false;
                buttonEditarTarefa.Visible = false;
                exportarParaCSVToolStripMenuItem.Visible = false; // botao converter em csv
                btPrevisao.Visible = false; // botao previsao
                tarefasEmCursoToolStripMenuItem.Visible = false;

            }
            if (Utilizador is Gestor)
            {
                btSetDoing.Visible = false;
                btSetDone.Visible = false;
                btSetTodo.Visible = false;


            }
        }
        //------------------------------------ Menu -------------------------------------------------------
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
            frmConsultarTarefasConcluidas segundoForm = new frmConsultarTarefasConcluidas(this.Utilizador);
            segundoForm.Show();


        }

        private void tarefasEmCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Utilizador is Gestor gestorAutenticado)
            {
                Form segundoForm = new frmConsultaTarefasEmCurso(gestorAutenticado.Id);
                segundoForm.Show();
            }


        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tem certeza que deseja sair?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

     
        //------------------------------------ BOTÃO PARA CRIAR NOVAS TAREFAS  -----------------------------------------
        private void btNova_Click(object sender, EventArgs e)
        {
            Gestor gestorAtual = Utilizador as Gestor;

            if (gestorAtual == null)
            {
                MessageBox.Show("Apenas gestores podem criar tarefas.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool tarefaCriada = false;

            while (!tarefaCriada)
            {
                Tarefa novaTarefa = new Tarefa();
                frmDetalhesTarefa formTarefa = new frmDetalhesTarefa(novaTarefa, gestorAtual);

                var resultado = formTarefa.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    AtualizarListas();
                    tarefaCriada = true;
                }
                else if (resultado == DialogResult.Abort)
                {
                    // Abre formulário para criar programador
                    AdicionarProgramador formAdicionarProg = new AdicionarProgramador(gestorAtual);
                    var resultadoCriarProg = formAdicionarProg.ShowDialog();

                    if (resultadoCriarProg != DialogResult.OK)
                    {
                        // O utilizador cancelou, parar tudo
                        break;
                    }

                    // Depois de criar programador, reabre o form de tarefa para criar a tarefa.
                }
                else
                {
                    // Sai do formulário de tarefa
                    break;
                }
            }
        }

        //------------------------------------BOTÃO PARA EDITAR TAREFAS ---------------------------------------------
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
                MessageBox.Show("Não pode editar tarefas em execução.");
                return;
            }
            // Caso não tenha, verifica na coluna "Done"
            else if (lstDone.SelectedItem != null)
            {
                MessageBox.Show("Não pode editar tarefas concluidas.");
                return;
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

        //------------------------------------ BOTÃO PARA APAGAR TAREFAS ---------------------------------------------
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
                 try
                 {
                    
                    var tarefa = controladorT.CarregarTarefa(tarefaId);

                    if (tarefa == null)
                    {
                        MessageBox.Show("A tarefa não foi encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Verifica se o utilizador atual é o gestor
                    if (Utilizador is Gestor gestorAtual)
                    {
                  
                        if (tarefa.IdGestor != gestorAtual.Id)
                        {
                            MessageBox.Show("Não pode apagar tarefas de outros gestores.",
                                            "Sem Acesso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    controladorT.ApagarTarefa(tarefaId, Utilizador.Id);
                    MessageBox.Show("Tarefa apagada com sucesso.","Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma tarefa para apagar.");
            }
            this.AtualizarListas();


        }

        //--------------------------MÉTODOS PARA ATUALIZAR OS ESTADOS DAS TAREFAS------------------------------

        // Passar para Doing, regras : 15 Duas tarefas em Doing, 16 Passar por Ordem de Execução
        private void btSetDoing_Click(object sender, EventArgs e)
        {
            // Verifica se há alguma tarefa selecionada na coluna "To Do"
            if (lstTodo.SelectedItem != null)
            {
                Tarefa tarefaSelecionada = (Tarefa)lstTodo.SelectedItem;
                // Se for gestor, só pode alterar tarefas dele
                if (!TarefaPertenceAoUtilizador(tarefaSelecionada))
                {
                    MessageBox.Show("Não pode mover tarefas de outros programadores.",
                                    "Acesso negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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
                            controladorT.AtualizarEstadoTarefa(tarefaSelecionada.Id, Utilizador.Id);
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


                if (!TarefaPertenceAoUtilizador(tarefaSelecionada))
                {
                    MessageBox.Show("Não pode concluir tarefas de outros gestores.",
                                    "Acesso negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                // Regra 16
                bool ordemTarefasCerta = controladorT.VerificarTarefaPrioritariaDoing(tarefaSelecionada, Utilizador.Id);

                if (ordemTarefasCerta)
                {
                    if (tarefaSelecionada.Id != -1)
                    {
                        controladorT.AtualizarEstadoTarefa(tarefaSelecionada.Id, Utilizador.Id);

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

                if (!TarefaPertenceAoUtilizador(tarefaSelecionada))
                {
                    MessageBox.Show("Não pode alterar tarefas de outros gestores.",
                                    "Sem Acesso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                tarefaId = tarefaSelecionada.Id;
            }
            // Caso não tenha envia mensagem
            else
            {
                MessageBox.Show("Não é possível reverter tarefas em estado 'Done'");
            }
          

            if (tarefaId != -1)
            {
                controladorT.ReverterEstadoTarefa(tarefaId);
            }
   
            this.AtualizarListas();
        }

        //----------------------------- CORES DAS TAREFAS CONSUANTE UTILIZADOR E PRAZO--------------------------------- 
   
        private void LstTodo_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            var tarefa = (Tarefa)lstTodo.Items[e.Index];
            Color corTexto = Color.Gray;

            //aqui definimos as cores(propriedades) para cada tarefa  
            if (Utilizador is Gestor gestor)
            {
                if (tarefa.IdGestor == gestor.Id)
                    corTexto = tarefa.DataPrevistaFim < DateTime.Now ? Color.Red : Color.Green;
            }
            else if (Utilizador is Programador prog)
            {
                if (tarefa.IdProgramador == prog.Id)
                    corTexto = tarefa.DataPrevistaFim < DateTime.Now ? Color.Red : Color.Green;
            }

            // implementa/aplica as cores que defenimos antes
            e.DrawBackground();
            using (Brush brush = new SolidBrush(corTexto))
            {
                e.Graphics.DrawString(tarefa.Descricao, e.Font, brush, e.Bounds);
            }
            e.DrawFocusRectangle(); // este é para a tarefa continuar a aparecer a "selecionada" quando a selecionamos
        }

        private void LstDoing_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            var tarefa = (Tarefa)lstDoing.Items[e.Index];
            Color corTexto = Color.Gray;

            //aqui definimos as cores(propriedades) para cada tarefa  
            if (Utilizador is Gestor gestor)
            {
                if (tarefa.IdGestor == gestor.Id)
                    corTexto = tarefa.DataPrevistaFim < DateTime.Now ? Color.Red : Color.Green;
            }
            else if (Utilizador is Programador prog)
            {
                if (tarefa.IdProgramador == prog.Id)
                    corTexto = tarefa.DataPrevistaFim < DateTime.Now ? Color.Red : Color.Green;
            }

            // implementa/aplica as cores que defenimos antes
            e.DrawBackground();
            using (Brush brush = new SolidBrush(corTexto))
            {
                e.Graphics.DrawString(tarefa.Descricao, e.Font, brush, e.Bounds);
            }
            e.DrawFocusRectangle(); // este é para a tarefa continuar a aparecer a "selecionada" quando a selecionamos
        }

        private void LstDone_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            //aqui definimos as cores(propriedades) para cada tarefa  
            var tarefa = (Tarefa)lstDone.Items[e.Index];
            Color corTexto = Color.Gray;

            if (Utilizador is Gestor gestor)
            {
                if (tarefa.IdGestor == gestor.Id)
                    corTexto = tarefa.DataPrevistaFim < tarefa.DataRealFim ? Color.Red : Color.Green;
            }
            else if (Utilizador is Programador prog)
            {
                if (tarefa.IdProgramador == prog.Id)
                    corTexto = tarefa.DataPrevistaFim < tarefa.DataRealFim ? Color.Red : Color.Green;
            }

            // implementa/aplica as cores que defenimos antes
            e.DrawBackground();
            using (Brush brush = new SolidBrush(corTexto))
            {
                e.Graphics.DrawString(tarefa.Descricao, e.Font, brush, e.Bounds);
            }
            e.DrawFocusRectangle(); // este é para a tarefa continuar a aparecer a "selecionada" quando a selecionamos
        }


        // --------------------------------METODO PARA ATUALIZAR AS LISTAS NO KANBAN-----------------------------------
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


        // ------------------------MÉTODO QUE CARREGA AS LISTAS QUANDO O FORM É ATIVADO---------------------------------
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
                Form detalhesTarefaForm = new frmDetalhesTarefa(tarefaSelecionada, Utilizador, forcarModoReadyOnly: true);
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

        private void btPrevisao_Click(object sender, EventArgs e)
        {
            if (Utilizador is Gestor gestor)
            {
                TimeSpan previsao = controladorT.CalcularTempoPrevistoTarefasToDo(gestor.Id);
               string mensagem = $"Estimativa de tempo para concluir todas as tarefas 'ToDo': " +
                           $"{previsao.Days} dias, {previsao.Hours} horas e {previsao.Minutes} minutos.";
                MessageBox.Show(mensagem, "Previsão de Tempo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("Ups.","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }


        }

       
        //----------------------------------------------MENU EXPORTAR---------------------------------------------------
        private void exportarParaCSVToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // não verificamos se é gestor, porque a funcionalidade só é acedivel a ele

            try
            {
                // Obtem tarefas concluidas
                var todasTarefas = controladorT.ListaDone();

                if (!todasTarefas.Any())
                {
                    MessageBox.Show("Não existem tarefas para exportar.", "Exportar CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Preparar os lookups para Programador e Tipo de Tarefa
                var programadores = controladorT.ListaProgramadores().ToDictionary(p => p.Id, p => p.Nome);
                var tiposTarefa = controladorT.ListaTiposTarefa().ToDictionary(tt => tt.Id, tt => tt.Nome);

                //  Configurar o SaveFileDialog
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                saveFileDialog.FileName = "Tarefas_Exportadas.csv";
                saveFileDialog.Title = "Guardar Tarefas como CSV";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8))
                    {
                        // primeira linha conforme enunciado
                        sw.WriteLine("Programador;Descricao;DataPrevistaInicio;DataPrevistaFim;TipoTarefa;DataRealInicio;DataRealFim");

                        // Escrever os dados das tarefas
                        foreach (var tarefa in todasTarefas)
                        {
                            string programadorNome = programadores.TryGetValue(tarefa.IdProgramador, out string pName) ? pName : "Programador eliminado ";
                            string tipoTarefaNome = tiposTarefa.TryGetValue(tarefa.IdTipoTarefa, out string ttName) ? ttName : "Sem dados";

                            string dataPrevistaInicio = tarefa.DataPrevistaInicio != DateTime.MinValue ? tarefa.DataPrevistaInicio.ToString("dd/MM/yyyy") : "";
                            string dataPrevistaFim = tarefa.DataPrevistaFim != DateTime.MinValue ? tarefa.DataPrevistaFim.ToString("dd/MM/yyyy") : "";
                            string dataRealInicio = tarefa.DataRealInicio != DateTime.MinValue ? tarefa.DataRealInicio.ToString("dd/MM/yyyy") : "";
                            string dataRealFim = tarefa.DataRealFim != DateTime.MinValue ? tarefa.DataRealFim.ToString("dd/MM/yyyy") : "";

                            string linha = $"{programadorNome};{tarefa.Descricao};{dataPrevistaInicio};{dataPrevistaFim};{tipoTarefaNome};{dataRealInicio};{dataRealFim}";
                            sw.WriteLine(linha);
                        }
                    }
                    MessageBox.Show("Tarefas exportadas com sucesso para CSV!", "Exportar CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao exportar as tarefas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


