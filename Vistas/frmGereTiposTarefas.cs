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
           // FormadicionarTipoTarefa.Show();
            var form = new AdicionarTipoTarefa();
            FormadicionarTipoTarefa.ReseatFormulario(); // chama a funcao para colocar o formulario limpo e assim podermos criar novo tipo de tarefa sem fechar formulario
            var result = FormadicionarTipoTarefa.ShowDialog();
            if (result == DialogResult.OK) // se for ok a reposta, vai atualizar a lista de tipo de tarefas ( e o ok, vem no from adicionar tipo tarefas)
            {
                atualizarListaTiposTarefas();
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
            try
            {
                tipoTarefaControlador.ApagarTipoTarefa(SelecionaTipoTarefa);
                atualizarListaTiposTarefas();
                MessageBox.Show("Tipo de tarefa apagado com sucesso.");
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Erro ao apagar o tipo de tarefa: {ex.Message}");
            }

        }


            

       
    }
}


// controladorUtilizador.ApagarUtilizador(SelecionaProgramador);
