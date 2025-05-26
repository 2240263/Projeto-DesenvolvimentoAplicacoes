using iTasks.Controlador;
using iTasks.Modelos;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTasks.Vistas
{
    public partial class AdicionarTipoTarefa : Form
    {
        TipoTarefaControlador tipoTarefaControlador = new TipoTarefaControlador();

    
        public AdicionarTipoTarefa()
        {
            InitializeComponent();


           
        }

        public void SetIdTT(int id) // 
        {
            txtId.Text = id.ToString();
        }
         

       


        

        private void butOkTT_Click(object sender, EventArgs e)
        {

            using (ITaskContext context = new ITaskContext())
            {
                string descricao = txtDesc.Text;
                TipoTarefa TipoTarefas = new TipoTarefa(descricao);

                tipoTarefaControlador.CriarTipoTarefa(TipoTarefas); // chama o controlador criar tipo tarefa e passa o parametro com a descricao

                MessageBox.Show("Tipo de tarefa criada com suceso");
                SetIdTT(TipoTarefas.Id);// Associada ID da tarefa - funcao especifica para ID
                FecharJanelaAposDelay();// chama a funcao criada para fechar janela automatica
                txtDesc.Enabled = false; // torna a txtDesc impossivel de alterar
                


            }

            async void FecharJanelaAposDelay() //fechar os form apos um determinado tempo
            {
                await Task.Delay(1500); // espera pouco mais de 1 segundo antes de fechar
                this.DialogResult = DialogResult.OK;// retorna que o utilizador confirmou ok após o show.dialog e retorna esse resultado - quando devolver ok no geretipo tarefas vai atualizar a lista
                this.Close();           // fecha o formulário
            }

        }

        public void ReseatFormulario()
        {
            txtDesc.Text = "";
            txtDesc.Enabled = true;
            txtId.Text = "";
        }

        private void buttCancelarTT_Click(object sender, EventArgs e) // botao cancelar no criar tipo tarefa
        {
            this.Close();
        }
    }
}
