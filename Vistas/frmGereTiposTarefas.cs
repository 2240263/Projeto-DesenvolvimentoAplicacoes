using iTasks.Controlador;
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
    public partial class frmGereTiposTarefas : Form
    {
        private TipoTarefa SelecionaTipoTarefa { get; set; }
        private List<TipoTarefa> ListTipoTarefas { get; set; }

        TipoTarefaControlador tipoTarefaControlador = new TipoTarefaControlador();
        AdicionarTipoTarefa FormadicionarTipoTarefa = new AdicionarTipoTarefa();


        public frmGereTiposTarefas()
        {
            InitializeComponent();
            ListTipoTarefas = new List<TipoTarefa>();
            atualizarListaTiposTarefas();
        }

        private void btCriarTT_Click(object sender, EventArgs e)
        {
            FormadicionarTipoTarefa.Show();
            
        }

        
           

        private void atualizarListaTiposTarefas()
        {
            using (ITaskContext context = new ITaskContext())
            {
                ListTipoTarefas = context.TipoTarefas.ToList();

                lstLista.DataSource = null;
                lstLista.DataSource = ListTipoTarefas;


            }    

        }

        private void lstLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstLista.SelectedIndex;

            if( index == -1)
            {
                return;
            }


            SelecionaTipoTarefa = ListTipoTarefas[index];

        }

        private void ButApagar_Click(object sender, EventArgs e)
        {

            if(SelecionaTipoTarefa == null)
            {
                MessageBox.Show("Tipo de tarefa não está selecionada");
                return;
            }


            tipoTarefaControlador.ApagarTipoTarefa(SelecionaTipoTarefa);
            atualizarListaTiposTarefas();
            textlimpa();
        }

        private void textlimpa()
        {
            //txtDesc.Text = "";
        }
    }
}


// controladorUtilizador.ApagarUtilizador(SelecionaProgramador);
