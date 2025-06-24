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
        TipoTarefa TipoTarefa;
        TipoTarefaControlador tipoTarefaControlador = new TipoTarefaControlador();
        private bool QueroEditar = false;

        public AdicionarTipoTarefa()
        {
            InitializeComponent();
          
        }
        public AdicionarTipoTarefa(TipoTarefa TipoTarefa):this()// contrutor quando edita - recebe a informação já preenchida
        {
            QueroEditar = true;
            this.TipoTarefa = TipoTarefa;
            txtDesc.Text = this.TipoTarefa.Nome;
            txtId.Text = this.TipoTarefa.Id.ToString();
        }

     
        public void SetIdTT(int id) 
        {
            txtId.Text = id.ToString();
        }


        public TipoTarefa GetTipoTarefa()
        {
            return this.TipoTarefa;
        }



        //BOTAO OK DO FORM
        private void butOkTT_Click(object sender, EventArgs e)
        {//se quiser editar a descrição da tarefa 
            if (QueroEditar)
            {
                // Atualiza os campos da tarefa já existente
                
                this.TipoTarefa.Nome = txtDesc.Text;


                try
                {
                    if (string.IsNullOrWhiteSpace(txtDesc.Text))
                    {
                        MessageBox.Show("Campo vazio!");
                        return;
                    }

                    tipoTarefaControlador.EditarTipoTarefa(this.TipoTarefa);//adiciona o tarefa alterada
                    MessageBox.Show("Tipo de Tarefa atualizado com sucesso!");
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else { 
                TipoTarefa novoTipoTarefas = new TipoTarefa(txtDesc.Text);

                try
                {
                    if (string.IsNullOrWhiteSpace(txtDesc.Text))
                    {
                        MessageBox.Show("Campo vazio!");
                        return;
                    }
                    // AO CARREGAR NO BOTAO OK DO ADICIONATIPOTAREFA - se a funcao chamada é criarTipotarefa
                    // se der erro nao cria e lança mensagem de erro definida no controlador TipoTarefa

                    tipoTarefaControlador.CriarTipoTarefa(novoTipoTarefas); // chama o controlador criar tipo tarefa e passa o parametro com a descricao

                    this.TipoTarefa = novoTipoTarefas;

                    MessageBox.Show("Tipo de Tarefa criado com sucesso!");
                    SetIdTT(this.TipoTarefa.Id);// Associada ID da tarefa - funcao especifica para ID
                    FecharJanelaAposDelay();// chama a funcao criada para fechar janela automatica
                    txtDesc.Enabled = false; // torna a txtDesc impossivel de alterar
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
             }   


            

            async void FecharJanelaAposDelay() //fechar os form apos um determinado tempo
            {
                await Task.Delay(1500); // espera pouco mais de 1 segundo antes de fechar
                this.DialogResult = DialogResult.OK;// retorna que o utilizador confirmou ok após o show.dialog e retorna esse resultado - quando devolver ok no geretipo tarefas vai atualizar a lista
                this.Close();           // fecha o formulário
            }

        }


        public void ResetFormulario()
        {
            txtDesc.Text = "";
            txtDesc.Enabled = true;
            txtId.Text = "";
        }

        //BOTAO CANCELAR DO FORM
        private void buttCancelarTT_Click(object sender, EventArgs e) // botao cancelar no criar tipo tarefa
        {
            this.Close();
        }
    }
}
