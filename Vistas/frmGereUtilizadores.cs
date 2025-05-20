using iTasks.Controlador;
using iTasks.Modelos;
using iTasks.Vistas;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace iTasks
{
    public partial class frmGereUtilizadores : Form

    {
        //criar e inicializar os objetos dos forms, para os puder usar 
        private AdicionarProgramador FormAdicionarProgramador = new AdicionarProgramador();
        private AdicionarGestor FormAdicionarGestor = new AdicionarGestor();

        //variaveis "globais"
        private Gestor SelecionaGestor;
        private Programador SelecionaProgramador;

        //listas 
        private List<Gestor> listaGestores = new List<Gestor>();
        private List<Programador> listaProgramadores = new List<Programador>();

        //NEW CONTROLADORES UTILIZADORES
        private UtilizadorControlador utilizadorControlador = new UtilizadorControlador();



        public frmGereUtilizadores()
        {
            InitializeComponent();
            atualizaListaGestores();
            atualizaListaProgramador();

          

            /*int index = lstListaGestores.SelectedIndex;
            if (index != -1)
            {
                using (ITaskContext context = new ITaskContext())
                {
                    Gestor gestor = context.Gestores.ToList()[index];
                    
                }
            }*/
        }


        //método para atualizar a lstListaGestores com os dados da base de dados
        private void atualizaListaGestores()
        {
            using(ITaskContext context = new ITaskContext())
            {

                listaGestores = context.Gestores.ToList();

                // Atualiza a lista local
                lstListaGestores.DataSource = null;
                lstListaGestores.DataSource = listaGestores;
            }



        }
        //quando clico no botao criar gestor vai abrir o form do gestor 
        private void btGravarGestor_Click(object sender, EventArgs e)
        {

            FormAdicionarGestor.ShowDialog();// espera até o utilizador fechar o form

            // só atualiza a lista depois que o formulário for fechado
            atualizaListaGestores();



        }
        //evento do formúlario, para que preencha as opçoes no combobox
       
        private void lstListaGestores_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstListaGestores.SelectedIndex;
            if (index == -1)
            {
               
                MessageBox.Show("Selecione um Gestor !");
                return;
            }
            //guarda na variavel global selecionagestor a posiçao que está na lista 
            SelecionaGestor = listaGestores[index];

        }

        //botão para gravar programador
        private void btCriarProg_Click(object sender, EventArgs e)
        {
            FormAdicionarProgramador.ShowDialog(); // abrir formulario adicionar programador
            atualizaListaProgramador();
        }


        private void atualizaListaProgramador()
        {
            using (ITaskContext context = new ITaskContext())
            {

                listaProgramadores = context.Programadores.ToList();

                // Atualiza a lista local
                lstListaProgramadores.DataSource = null;
                lstListaProgramadores.DataSource = listaProgramadores;
                lstListaProgramadores.DisplayMember = "Nome";  // mostra só o nome do programador
            }


        }

        private void lstListaProgramadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstListaProgramadores.SelectedIndex;
            
            if(index== -1)
            {
                MessageBox.Show("Selecione um programador");
                return;
            }

            Programador programador = listaProgramadores[index];
            if (programador == SelecionaProgramador)
            {
                SelecionaProgramador = null;
                lstListaProgramadores.SelectedIndex = -1;

                return;
            }

            SelecionaProgramador = programador;

        }
        //este botao é para atualizar/editar o gestor
        private void button1_Click(object sender, EventArgs e) // MUDARRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR BOTAO ERRADO
        {
            //se nao houver nenhum gestor selecionado apresenta uma mensagem
            if (SelecionaGestor == null)
            {
                MessageBox.Show("Selecione um gestor para editar.");
                return;
            }

            // Passar o gestor selecionado para o formulário
            AdicionarGestor formEditar = new AdicionarGestor(SelecionaGestor);
            if(formEditar.ShowDialog() == DialogResult.OK) { 
                //vai buscar o gestor que foi gerado 
                Gestor gestorEditado = formEditar.GetGestor();

                utilizadorControlador.EditarUtilizador(gestorEditado);
                MessageBox.Show("Gestor atualizado com sucesso!");
                atualizaListaGestores();
            }
            
            
        }

        private void buttonAtualizarProgramador_Click(object sender, EventArgs e) //atualizar
        {
            if (SelecionaProgramador == null)
            {
                MessageBox.Show("Selecione um programador para editar.");
                return;
            }
            AdicionarProgramador adicionar = new AdicionarProgramador(SelecionaProgramador);
            adicionar.ShowDialog();

            SelecionaProgramador = adicionar.GetProgramador(); // ia buscar o programador gerado

            utilizadorControlador.EditarUtilizador(SelecionaProgramador);
            atualizaListaProgramador();
    }
        //botão para apagar gestor
        private void buttonApagarGestor_Click(object sender, EventArgs e)
        {
            if(SelecionaGestor== null)
            {
                MessageBox.Show("Selecione um gestor!");
            }

            var confirmar = MessageBox.Show($"Tem certeza que quer apagar o gestor '{SelecionaGestor.Nome}'?", "Confirmar Apagar", MessageBoxButtons.YesNo);

            if (confirmar == DialogResult.Yes)
            {
                utilizadorControlador.ApagarUtilizador(SelecionaGestor);
                atualizaListaGestores();
                SelecionaGestor = null;
                MessageBox.Show("Gestor apagado com sucesso.");
            }
        }

        //botão apagar programador 
        private void buttonApagarProg_Click(object sender, EventArgs e)
        {
            if (SelecionaProgramador == null)
            {
                MessageBox.Show("Selecione um programador!");
            }

            var confirmar = MessageBox.Show($"Tem certeza que quer apagar o programador '{SelecionaProgramador.Nome}'?", "Confirmar Apagar", MessageBoxButtons.YesNo);

            if (confirmar == DialogResult.Yes)
            {
                utilizadorControlador.ApagarUtilizador(SelecionaProgramador);
                atualizaListaProgramador();
                SelecionaProgramador = null;
                MessageBox.Show("Programador apagado com sucesso.");
            }
        }
    }
}
