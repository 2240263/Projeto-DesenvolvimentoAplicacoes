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

namespace iTasks
{
    public partial class frmGereTiposTarefas : Form
    {
        private TipoTarefa SelecionaTipoTarefa { get; set; }
        private List<TipoTarefa> ListTipoTarefas { get; set; }

        TipoTarefaControlador tipoTarefaControlador = new TipoTarefaControlador();


        public frmGereTiposTarefas()
        {
            InitializeComponent();
            ListTipoTarefas = new List<TipoTarefa>();
            atualizarListaTiposTarefas();
        }

        private void btGravar_Click(object sender, EventArgs e)
        {

            using (ITaskContext context = new ITaskContext())
            {
                string descricao = txtDesc.Text;
                TipoTarefa TipoTarefas = new TipoTarefa(descricao);

                context.TipoTarefas.Add(TipoTarefas);
                context.SaveChanges();
                txtId.Text = TipoTarefas.Id.ToString();
                atualizarListaTiposTarefas();

                MessageBox.Show("Tipo de tarefa criada com suceso");
            }
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
            txtDesc.Text = "";
        }
    }
}


// controladorUtilizador.ApagarUtilizador(SelecionaProgramador);
