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


            }
            if (Utilizador is Gestor)
            {

                btNova.Visible = false;
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
           
            Form detalhesTarefaForm = new frmDetalhesTarefa();
            detalhesTarefaForm.Show();
        }
    }
}
