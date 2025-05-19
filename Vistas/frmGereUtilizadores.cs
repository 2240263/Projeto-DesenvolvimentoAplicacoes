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
    public partial class frmGereUtilizadores : Form
    {
        public frmGereUtilizadores()
        {
            InitializeComponent();
            atualizaListaGestores();
        }


        //método para atualizar a lstListaGestores com os dados da base de dados
        private void atualizaListaGestores()
        {
            using(ITaskContext context = new ITaskContext())
            {
                lstListaGestores.DataSource = null;
                lstListaGestores.DataSource = context.Gestores.ToList();
            }
        }
        private void btGravarGestor_Click(object sender, EventArgs e)
        {
            //inicializar base de dados
            using(ITaskContext context = new ITaskContext())
            {
                string nome = txtNomeGestor.Text;
                string username = txtUsernameGestor.Text;

                /*Vai ver à base dados, na tabela gestores o 1º elemento que tenha o username igual ao inserido*/
                Gestor gestorexistente = context.Gestores.FirstOrDefault(gestor => gestor.Username == username);
                //se o gestorexistente já existir então não faz nada.
                if(gestorexistente !=null)
                {
                    MessageBox.Show("Já existe um gestor com este nome!");
                    return;
                }

                string password = txtPasswordGestor.Text;

                Departamentos departamento;

                if (Enum.TryParse(cbDepartamento.SelectedItem.ToString(), out departamento))
                {
                    return; 
                }

                bool gereUtilizadores = chkGereUtilizadores.Checked;

                //criar objeto gestor
                Gestor novoGestor = new Gestor(gereUtilizadores, departamento, nome, username, password);
                //adicionar À tabela gestores o novo gestor
                context.Gestores.Add(novoGestor);
                context.SaveChanges();


                MessageBox.Show("Gestor gravado com sucesso!");
            }
        }
        //evento do formúlario, para que preencha as opçoes no combobox
        private void frmGereUtilizadores_Load(object sender, EventArgs e)
        { //getvalues retorna todos os elementos do tipo departamentos
            
            cbDepartamento.DataSource = Enum.GetValues(typeof(Departamentos));
            cbGestorProg.DataSource = Enum.GetValues(typeof(NivelExperiencia));
        }

        private void btGravarProg_Click(object sender, EventArgs e)
        {

        }
    }
}
