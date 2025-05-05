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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            //abrir novos formulários
            Form segundoForm = new frmKanban();
            //só abre um form de cada vez 
            //segundoForm.Show();     

            Hide(); //para esconder a janela do login mas fica guardada em memória
            // deixa ter varios forms ao mesmo tempo 
            segundoForm.ShowDialog(); // so deixa abrir uma janela e bloqueia o resto
        }
    }
}
