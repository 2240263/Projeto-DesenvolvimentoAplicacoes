using iTasks.Controlador;
using iTasks.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.Controlador
{
    class TipoTarefaControlador
    {
        public ITaskContext Context { get; set; }
        public TipoTarefaControlador()
        {
            Context = new ITaskContext();
        }

        //------------------------------METODOS QUE VAO SER CHAMADOS NO FORM DO TIPO DE TAREFA-------------------------

        //METODO APAGAR TIPO TAREFA
        public void ApagarTipoTarefa(TipoTarefa tipoTarefa)
        {
            TipoTarefa tipo = Context.TipoTarefas.Find(tipoTarefa.Id); // Como o item vai ser apagado, necessitamos de fazer uma ligacao/referência à base de dados para saber o que vai apagar
           
            if (tipo == null) // para confirmar se o tipo de objeto existe, para nao gerar erro, caso nao exista.
            {
                throw new Exception("Tipo tarefa não encontrada");
            }
            Context.TipoTarefas.Remove(tipo);
            Context.SaveChanges();
        }

        //METODO CRIAR TIPO TAREFA
        public void CriarTipoTarefa(TipoTarefa tipoTarefa)
        {

            Context.TipoTarefas.Add(tipoTarefa);
            Context.SaveChanges();

        }

        //METODO EDITAR TIPO TAREFA
        public void EditarTipoTarefa(TipoTarefa tipoTarefa)
        {
            var TipoTarefaExiste = Context.TipoTarefas.FirstOrDefault(tt => tt.Id == tipoTarefa.Id); //Retorna através da comparacao da lista (FirstOrDefault) o primeiro item que corresponde ao critério id, ou null se não encontrar


            if (TipoTarefaExiste != null)
            {
                TipoTarefaExiste.Nome = tipoTarefa.Nome;


            }

            Context.SaveChanges();
        }

    }
}








