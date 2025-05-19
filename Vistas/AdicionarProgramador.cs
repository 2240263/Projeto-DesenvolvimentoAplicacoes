using iTasks.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTasks.Vistas
{
    public partial class AdicionarProgramador : Form
    {
        Programador Programador;

        public AdicionarProgramador()
        {
            InitializeComponent();
            Programador = new Programador();
        }
        public AdicionarProgramador(Programador programador) : this()
        {
            Programador = programador;
            // carregar os dados
            txtNomeProg.Text = Programador.Nome;
            txtUsernameProg.Text = Programador.Username;

        }

        public Programador GetProgramador()
        {
            return new Programador(); // TODO
        }

        private void btGravarProg_Click(object sender, EventArgs e)
        {

        }
    }
}
