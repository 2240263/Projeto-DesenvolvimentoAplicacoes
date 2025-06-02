using Google.Protobuf.WellKnownTypes;
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
            using(ITaskContext context = new ITaskContext())
            {
                if (context.Utilizadores.Count() == 0)
                {
                    buttonRegisto.Visible = false;
                }
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                // Procura utilizador com username e password correspondentes
                Utilizador utilizador = context.Utilizadores
                    .FirstOrDefault(u => u.Username == username);

                //validações para os campos vazios do login
                if (string.IsNullOrWhiteSpace (password) || string.IsNullOrWhiteSpace(username))
                {
                    MessageBox.Show("Campos vazios!");
                    return;
                }
                else { 
                    if (utilizador == null)
                    {
                    MessageBox.Show("Username ou password inválidos.");
                    return;
                    }   
                    //abrir novos formulários
                    Form segundoForm = new frmKanban(utilizador);

            
                    //só abre um form de cada vez 
                    //segundoForm.Show();     
            
           

                    Hide(); //para esconder a janela do login mas fica guardada em memória
                    // deixa ter varios forms ao mesmo tempo 
                    segundoForm.ShowDialog(); // so deixa abrir uma janela e bloqueia o resto

                }
                
                
            }

       
        }


        //botão registo do login
        private void buttonRegisto_Click(object sender, EventArgs e) //verrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr
        {
          

            // Abre o formulário de registo 
            frmGereUtilizadores frmRegisto = new frmGereUtilizadores();
            frmRegisto.ShowDialog();

            // Quando o registo for fechado, o utilizador volta ao login
            // limpa os dados do login
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

            // Chama o método para verificar se existem utilizadores
            bool temUtilizadores = VerificarSeHaUtilizadores();

            // Se houver utilizadores, esconde o botão de registo
            buttonRegisto.Visible = !temUtilizadores;

        }

        // Método auxiliar para verificar se há utilizadores na base de dados
        private bool VerificarSeHaUtilizadores()
        {
            using (ITaskContext context = new ITaskContext())
            {
                return context.Utilizadores.Any(); // retorna true se houver pelo menos um
            }
        }

    }
}
