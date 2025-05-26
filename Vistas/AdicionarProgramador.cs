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
        private bool QueroEditar = false; 


        public AdicionarProgramador() // contrutor para criar programador vazio
        {
            InitializeComponent();

            EnumsDinamicos();
        }
        public AdicionarProgramador(Programador Programador) : this() // contrutor quando edita - recebe a informação já preenchida
        {
            QueroEditar = true;
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
            return this.Programador; // TODO
        }


        private void EnumsDinamicos()
        {
            cbNivelProg.DataSource = Enum.GetValues(typeof(NivelExperiencia));
            using (ITaskContext context = new ITaskContext())
            {
                List<Gestor> gestores = context.Gestores.ToList();
                cbGestorProg.DataSource = gestores;
      

            }

        }

        private void btOKProg_Click(object sender, EventArgs e) // botão OK
        {

            NivelExperiencia nivelExperiencia;
            if (!Enum.TryParse(cbNivelProg.SelectedItem.ToString(), out nivelExperiencia))
            {
                MessageBox.Show("Selecione um nível de experiência válido.");
                return;
            }

            Gestor gestorSelecionado = cbGestorProg.SelectedItem as Gestor;
            if (gestorSelecionado == null)
            {
                MessageBox.Show("Por favor selecione um gestor da lista.");
                return;
            }

            //se quiser editar os dados do programador 
            if (QueroEditar)
            {
                // Atualiza os campos do programador já existente
                this.Programador.Nome = txtNomeProg.Text;
                this.Programador.Username = txtUsernameProg.Text;
                this.Programador.Password = txtPasswordProg.Text;
                this.Programador.nivelExperiencia = nivelExperiencia;
                this.Programador.IdGestor = gestorSelecionado; 


                try
                {
                    utilizadorControlador.EditarUtilizador(this.Programador);//adiciona o programador alterado
                    MessageBox.Show("Programador atualizado com sucesso!");
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                Programador novoProgramador = new Programador(nivelExperiencia, gestorSelecionado, txtNomeProg.Text, txtUsernameProg.Text, txtPasswordProg.Text);
                try
                {
                    // AO CARREGAR NO BOTAO OK DO ADICIONARPROGRAMADOR - se a funcao chamada é criarUtilizador
                    // se der erro nao cria e lança mensagem de erro definida no controlador utilizador
                    // (username já existe)
                    utilizadorControlador.CriarUtilizador(novoProgramador);

                    this.Programador = novoProgramador;

                    MessageBox.Show("Programador criado com sucesso!");
                    SetId(this.Programador.Id);

                    this.Close(); // fecha o formulário
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }


        }
    }
}
