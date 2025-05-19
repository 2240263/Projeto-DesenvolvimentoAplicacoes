using iTasks.Modelos;
using Org.BouncyCastle.Crypto.Digests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace iTasks.Controlador
{
    internal class UtilizadorControlador
    {
        public ITaskContext Context { get; set; }
        public UtilizadorControlador()
        {
            Context = new ITaskContext();

        }

       public void ApagarUtilizador(Utilizador utilizador) 
        {
            Context.Utilizadores.Remove(utilizador);
            Context.SaveChanges();
        }

        public void EditarUtilizador(Programador programador)
        {
            var ProgramadorExiste = Context.Programadores.FirstOrDefault(u => u.Id == programador.Id);

            if(ProgramadorExiste != null)
            {
                ProgramadorExiste.Nome = programador.Nome;
                ProgramadorExiste.Username = programador.Username;
                ProgramadorExiste.Password = programador.Password;
                ProgramadorExiste.nivelExperiencia = programador.nivelExperiencia;
                ProgramadorExiste.IdGestor = programador.IdGestor;

            }
           
            Context.SaveChanges();
        }



    }
}
