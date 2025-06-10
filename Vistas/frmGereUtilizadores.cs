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
            
            var form = new AdicionarGestor();// cria nova instancia de adicionar gestor (porque se limpa)
            form.ResetFormularioGestor();// vai buscar ao formAdicionarGestor a funcao reseat 

            
            var result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                // só atualiza a lista depois que o formulário for fechado
                atualizaListaGestores();
               
            }
            
            


        }
        //evento do formúlario, para que preencha as opçoes no combobox
       
        private void lstListaGestores_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstListaGestores.SelectedIndex;
            if (index == -1)
            {
                return;
            }
            //guarda na variavel global selecionagestor a posiçao que está na lista 
            SelecionaGestor = listaGestores[index];

        }

        //este botao é para atualizar/editar o gestor
        private void BotaoEditarG(object sender, EventArgs e)
        {
            //se nao houver nenhum gestor selecionado apresenta uma mensagem
            if (SelecionaGestor == null)
            {
                MessageBox.Show("Selecione um gestor para editar.");
                return;
            }

            // Passar o gestor selecionado para o formulário
            AdicionarGestor formEditar = new AdicionarGestor(SelecionaGestor);
            if (formEditar.ShowDialog() == DialogResult.OK)
            {
                //vai buscar o gestor que foi gerado 
                Gestor gestorEditado = formEditar.GetGestor();

                utilizadorControlador.EditarUtilizador(gestorEditado);
             
                atualizaListaGestores();
            }


        }

        //botão para apagar gestor
        private void buttonApagarGestor_Click(object sender, EventArgs e)
        {
            if (SelecionaGestor == null)
            {
                MessageBox.Show("Selecione um gestor!");
                return;
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



        //-------------------------------------PROGRAMADOR ---------------------------------------------

        //botão para gravar programador
        private void btCriarProg_Click(object sender, EventArgs e)
        {
          
            var form = new AdicionarProgramador();// cria nova instancia de adicionar gestor (porque se limpa)
          
            form.ResetFormularioProgramador();// vai buscar ao formAdicionarGestor a funcao reseat 
            RecarregarGestores(); // atualizar a lista de gestores sempre 


            var result = form.ShowDialog();//(showDialog - janela pai fica bloqueada até fechar)

            if (result == DialogResult.OK)
            {
                // só atualiza a lista depois que o formulário for fechado
                atualizaListaProgramador();
            }

        }


        private void atualizaListaProgramador()
        {
            using (ITaskContext context = new ITaskContext())
            {

                listaProgramadores = context.Programadores.ToList();

                // Atualiza a lista local
                lstListaProgramadores.DataSource = null;
                lstListaProgramadores.DataSource = listaProgramadores;
                lstListaProgramadores.DisplayMember = "Username";  // mostra só o nome do programador
            }


        }

        private void RecarregarGestores()
        {
            using (var context = new ITaskContext())
            {
                AdicionarProgramador prog = new AdicionarProgramador();
                var gestores = context.Gestores.ToList();
                
                prog.cbGestorProg.DataSource = null; // limpa os dados antigos
                prog.cbGestorProg.DataSource = gestores;
                prog.cbGestorProg.DisplayMember = "Username"; // ou a propriedade que quer mostrar
                
            }
        }

        private void lstListaProgramadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstListaProgramadores.SelectedIndex;
            
            if(index== -1)
            {
               
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



        //botão apagar programador 
        private void buttonApagarProg_Click(object sender, EventArgs e)
        {
            if (SelecionaProgramador == null)
            {
                MessageBox.Show("Selecione um programador!");
            }

            var confirmar = MessageBox.Show($"Tem certeza que quer apagar o programador '{SelecionaProgramador}'?", "Confirmar Apagar", MessageBoxButtons.YesNo);

            if (confirmar == DialogResult.Yes)
            {
                utilizadorControlador.ApagarUtilizador(SelecionaProgramador);
                atualizaListaProgramador();
                SelecionaProgramador = null;
                MessageBox.Show("Programador apagado com sucesso.");
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
