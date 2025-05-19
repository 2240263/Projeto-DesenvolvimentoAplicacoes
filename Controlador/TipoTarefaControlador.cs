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

        public void ApagarTipoTarefa(TipoTarefa tipoTarefa)
        {
            TipoTarefa tipo = Context.TipoTarefas.Find(tipoTarefa.Id); // Como o item vai ser apagado, necessitamos de fazer uma ligacao/referência à base de dados para saber o que vai apagar
            //Context.Entry(tipoTarefa).State = System.Data.Entity.EntityState.Deleted; - Outra forma de fz referência à lista na base de dados que vai ser apagada

            Context.TipoTarefas.Remove(tipo);
            Context.SaveChanges();
        }

        public void EditarUtilizador(Utilizador tipoTarefa)
        {
            var utilizadorExiste = Context.Utilizadores.FirstOrDefault(u => u.Id == tipoTarefa.Id);

            if (utilizadorExiste != null)
            {
                utilizadorExiste.Nome = tipoTarefa.Nome;
                utilizadorExiste.Username = tipoTarefa.Username;
                utilizadorExiste.Password = tipoTarefa.Password;
            }

            Context.SaveChanges();
        }

    }


}






