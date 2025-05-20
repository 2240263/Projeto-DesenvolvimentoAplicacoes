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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace iTasks.Vistas
{
    public partial class AdicionarGestor: Form
    {
        Gestor Gestor;

        UtilizadorControlador utilizadorControlador = new UtilizadorControlador();
        private bool QueroEditar = false;
        public AdicionarGestor()
        {
            InitializeComponent();
            EnumsDinamicosGestor();
        }
        public AdicionarGestor(Gestor Gestor) : this() // construtor quando edita - recebe a informação já preenchida
        {
            QueroEditar = true;

            EnumsDinamicosGestor();
            this.Gestor = Gestor;
            // carregar os dados
            txtNomeGestor.Text = this.Gestor.Nome;
            txtUsernameGestor.Text = this.Gestor.Username;
            txtPasswordGestor.Text = this.Gestor.Password;
            cbDepartamento.SelectedItem = this.Gestor.Departamento;

        }
        public void SetId(int id) 
        {
            txtIdGestor.Text = id.ToString();
        }



        public Gestor GetGestor()
        {
            return this.Gestor; // TODO
        }

        private void EnumsDinamicosGestor()
        {
            cbDepartamento.DataSource = Enum.GetValues(typeof(Departamentos));

        }

        private void btOkGestor_Click(object sender, EventArgs e)
        {
            Departamentos departamento;

            if (!Enum.TryParse(cbDepartamento.SelectedItem.ToString(), out departamento))
            {
                MessageBox.Show("Selecione um departamento válido!");
                return;
            }
            //se for para editar o gestor 
            if (QueroEditar)
            {
                // Atualiza os campos do programador já existente
                this.Gestor.Nome = txtNomeGestor.Text;
                this.Gestor.Username = txtUsernameGestor.Text;
                this.Gestor.Password = txtPasswordGestor.Text;
                this.Gestor.Departamento = departamento;
             
                try
                {
                    utilizadorControlador.EditarUtilizador(this.Gestor);//adiciona o gestor alterado
                    MessageBox.Show("Gestor atualizado com sucesso!");
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else { 
                bool gereUtilizadores = chkGereUtilizadores.Checked;

                //criar objeto gestor
                Gestor novoGestor = new Gestor(gereUtilizadores, departamento, txtNomeGestor.Text, txtUsernameGestor.Text, txtPasswordGestor.Text);
                try
                {
                    // AO CARREGAR NO BOTAO OK DO ADICIONARGESTOR - se a funcao chamada é criarUtilizador
                    // se der erro nao cria e lança mensagem de erro definida no controlador utilizador
                    // (username já existe)
                    utilizadorControlador.CriarUtilizador(novoGestor);
                    this.Gestor = novoGestor;

                    MessageBox.Show("Gestor criado com sucesso!");
                    SetId(this.Gestor.Id);

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
