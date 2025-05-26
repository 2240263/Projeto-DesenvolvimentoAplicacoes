using iTasks.Controlador;
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

                tipoTarefaControlador.CriarTipoTarefa(TipoTarefas);

                MessageBox.Show("Tipo de tarefa criada com suceso");
                SetIdTT(TipoTarefas.Id);
                FecharJanelaAposDelay();
                txtDesc.Enabled = false; // torna a txtDesc impossivel de alterar
            }

            async void FecharJanelaAposDelay() //fechar os forms apos um determinado tempo
            {
                await Task.Delay(2000); // espera 2 segundos 
                this.Close();           // fecha o formulário
            }
        }
    }
}
