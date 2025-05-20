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

namespace iTasks.Vistas
{
    public partial class AdicionarProgramador : Form
    {
        Programador Programador;
        UtilizadorControlador utilizadorControlador = new UtilizadorControlador();

        public AdicionarProgramador() // contrutor para criar programador vazio
        {
            InitializeComponent();
            
            EnumsDinamicos();
        }
        public AdicionarProgramador(Programador Programador) : this() // contrutor quando edita - recebe a informação já preenchida
        {
            EnumsDinamicos();
            this.Programador = Programador;
            // carregar os dados
            txtNomeProg.Text = this.Programador.Nome;
            txtUsernameProg.Text = this.Programador.Username;
            txtPasswordProg.Text = this.Programador.Password;
            cbNivelProg.SelectedItem = this.Programador.nivelExperiencia;
            cbGestorProg.SelectedItem = this.Programador.IdGestor;



        }

        public void SetId(int id) // 
        {
            txtIdProg.Text = id.ToString();
        }



        public Programador GetProgramador()
        {
            return Programador; // TODO
        }


        private void EnumsDinamicos()
        {
            cbNivelProg.DataSource = Enum.GetValues(typeof(NivelExperiencia));
            using (ITaskContext context = new ITaskContext())
            {
                List<Gestor> gestores = context.Gestores.ToList();
                cbGestorProg.DataSource = gestores;
                cbGestorProg.DisplayMember = "Nome";   // ou outro campo que queira mostrar
                
            }

        }

        private void btGravarProg_Click(object sender, EventArgs e) // botão OK
        {

            NivelExperiencia nivelExperiencia;
            if (!Enum.TryParse(cbNivelProg.SelectedItem.ToString(), out nivelExperiencia))
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
            
            Programador = new Programador(nivelExperiencia, gestorselecionado,txtNomeProg.Text,txtUsernameProg.Text,txtPasswordProg.Text);
            try
            {

                utilizadorControlador.CriarUtilizador(Programador); // AO CARREGAR NO BOTAO OK DO ADICIONARPROGRAMADOR - se a funcao chamada é criarUtilizador se der erro nao cria e lança mensagem de erro definida no controlador utilizador (username já existe)
                MessageBox.Show("Programador criado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


    }
}
