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
        private Gestor SelecionaGestor;
        private Programador SelecionaProgramador;
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
        private void btGravarGestor_Click(object sender, EventArgs e)
        {
            //inicializar base de dados
            using(ITaskContext context = new ITaskContext())
            {
                string nome = txtNomeGestor.Text;
                string username = txtUsernameGestor.Text;

                /*Vai ver à base dados, na tabela gestores o 1º elemento que tenha o username igual ao inserido*/
                Gestor gestorexistente = context.Gestores.FirstOrDefault(gestor => gestor.Username == username);
                //se o gestorexistente já existir então não faz nada.
                if(gestorexistente !=null)
                {
                    MessageBox.Show("Já existe um gestor com este username!");
                    
                    return;
                }

                string password = txtPasswordGestor.Text;

                Departamentos departamento;

                if (!Enum.TryParse(cbDepartamento.SelectedItem.ToString(), out departamento))
                {
                    MessageBox.Show("Selecione um departamento válido!");
                    return; 
                }

                bool gereUtilizadores = chkGereUtilizadores.Checked;

                //criar objeto gestor
                Gestor novoGestor = new Gestor(gereUtilizadores, departamento, nome, username, password);
                //adicionar À tabela gestores o novo gestor
                context.Gestores.Add(novoGestor);
                context.SaveChanges();
                // Mostrar o ID no campo txtIdGestor
                txtIdGestor.Text = novoGestor.Id.ToString(); 

                MessageBox.Show("Gestor gravado com sucesso!");
                atualizaListaGestores();
              
            }
        }
        //evento do formúlario, para que preencha as opçoes no combobox
        private void frmGereUtilizadores_Load(object sender, EventArgs e)
        { //getvalues retorna todos os elementos do tipo departamentos
            
            cbDepartamento.DataSource = Enum.GetValues(typeof(Departamentos));
            cbNivelProg.DataSource = Enum.GetValues(typeof(NivelExperiencia));
            using (ITaskContext context = new ITaskContext())
            {
                List<Gestor> gestores = context.Gestores.ToList();
                cbGestorProg.DataSource = gestores;
                cbGestorProg.DisplayMember = "Nome";   // ou outro campo que queira mostrar
                
            }

        }
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
        private void btGravarProg_Click(object sender, EventArgs e)
        {
            using (ITaskContext context = new ITaskContext())
            {
                string nome = txtNomeProg.Text;
                string username = txtUsernameProg.Text;

                Programador progexistente = context.Programadores.FirstOrDefault(prog => prog.Username == username);
                if (progexistente != null)
                {
                    MessageBox.Show("Já existe um Programador com este username!");
                    
                    return;
                }

                string password = txtPasswordProg.Text;

                NivelExperiencia nivelExperiencia;
                if (!Enum.TryParse(cbNivelProg.SelectedItem?.ToString(), out nivelExperiencia))
                {
                    MessageBox.Show("Selecione um nível de experiência válido.");
                    return;
                }

                Gestor gestorselecionado = cbGestorProg.SelectedItem as Gestor;
                if (gestorselecionado == null)
                {
                    MessageBox.Show("Por favor selecione um gestor da lista.");
                    return;
                }

                Programador novoprogramador = new Programador
                {
                    Nome = nome,
                    Username = username,
                    Password = password,
                    nivelExperiencia = nivelExperiencia,
                    IdGestor = gestorselecionado
                };

                context.Programadores.Add(novoprogramador);
                context.SaveChanges();
                // Mostrar o ID no campo txtIdProg
                txtIdProg.Text = novoprogramador.Id.ToString();

                MessageBox.Show("Programador gravado com sucesso!");
              
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

                txtNomeProg.Text = "";
                txtUsernameProg.Text = "";
                return;
            }

            SelecionaProgramador = programador;
            txtNomeProg.Text = SelecionaProgramador.Nome;
            txtUsernameProg.Text = SelecionaProgramador.Username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdicionarProgramador adicionar = new AdicionarProgramador();
            adicionar.ShowDialog();

            SelecionaProgramador = adicionar.GetProgramador(); // ia buscar o programador gerado

            //utilizadorControlador.CriarProgramador(SelecionaProgramador);

        }

        private void buttonAtualizarProgramador_Click(object sender, EventArgs e) //atualizar
        {
            AdicionarProgramador adicionar = new AdicionarProgramador(SelecionaProgramador);
            adicionar.ShowDialog();

            SelecionaProgramador = adicionar.GetProgramador(); // ia buscar o programador gerado

            utilizadorControlador.EditarUtilizador(SelecionaProgramador);
    }
    }
}
