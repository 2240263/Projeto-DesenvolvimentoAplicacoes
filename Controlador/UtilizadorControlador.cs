using iTasks.Modelos;
using Org.BouncyCastle.Crypto.Digests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace iTasks.Controlador
{
    internal class UtilizadorControlador
    {
        public ITaskContext Context { get; set; }

       
        public UtilizadorControlador()
        {
            Context = new ITaskContext();

        }

      
        //apagar um gestor 
        public void ApagarUtilizador(Gestor gestor)
        {

            var gestorExistente = Context.Gestores.FirstOrDefault(g => g.Id == gestor.Id);
            if (gestorExistente != null)
            {
                Context.Gestores.Remove(gestorExistente);
                Context.SaveChanges();
            }
        }
        //apagar um programador
        public void ApagarUtilizador(Programador programador)
        {
            var programadorExistente = Context.Programadores.FirstOrDefault(p => p.Id == programador.Id);
            if (programadorExistente != null)
            {
                Context.Programadores.Remove(programadorExistente);
                Context.SaveChanges();
            }
        }

        //metodo para editar um utilizador que é um programador
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

        //metodo para criar um utilizador que é especificamente um programador
        public void CriarUtilizador(Programador programador)
        {
            Programador progexistente = Context.Programadores.FirstOrDefault(prog => prog.Username == programador.Username);
            if (progexistente != null)
            {
                throw new InvalidOperationException("Já existe um Programador com este username!");
            }

            Context.Programadores.Add(programador);
            Context.SaveChanges();
        }

        //metodo para criar um utilizador que é especificamente um gestor
        public void CriarUtilizador(Gestor gestor)
        {
            Gestor gestorexistente = Context.Gestores.FirstOrDefault(g => g.Username == gestor.Username);
            if (gestorexistente != null)
            {
                throw new InvalidOperationException("Já existe um Gestor com este username!");
            }

            Context.Gestores.Add(gestor);
            Context.SaveChanges();

        }

        //metodo para editar um utilizador que é um programador
        public void EditarUtilizador(Gestor gestor)
        {
            var GestorExiste = Context.Gestores.FirstOrDefault(u => u.Id == gestor.Id);

            if (GestorExiste != null)
            {
                GestorExiste.Nome = gestor.Nome;
                GestorExiste.Username = gestor.Username;
                GestorExiste.Password = gestor.Password;
                GestorExiste.Departamento = gestor.Departamento;
         

            }

            Context.SaveChanges();
        }
    }
}
