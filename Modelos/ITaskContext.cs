using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.Modelos
{
    public class ITaskContext: DbContext
    {
        public DbSet<Utilizador> Utilizadores { get; set; }

        public DbSet<Gestor> Gestores { get; set; }

        public DbSet<Programador> Programadores { get; set; }

        public DbSet<Tarefa> Tarefas { get; set; }

        public DbSet<TipoTarefa> TipoTarefas { get; set; }
        public List<TipoTarefa> ListTipoTarefas { get; internal set; }

        public ITaskContext()
        {
           
        }
    }
}
