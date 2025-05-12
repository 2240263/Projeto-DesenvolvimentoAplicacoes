using iTasks.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace iTasks
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
   
          
            using (ITaskContext context = new ITaskContext())
            {
                if (context.Utilizadores.Count() == 0)
                {
                    Utilizador utilizadorgestor = new Gestor(true,0,"administrador", "admin", "123");
                    Utilizador utilizadorprogramador = new Programador(0, 0, "Programador1", "prog", "123");
                    context.Utilizadores.Add(utilizadorgestor); //adiciona o utilizador à base de dados
                    context.Utilizadores.Add(utilizadorprogramador);
                    context.SaveChanges();
                }
               
                
                
            }
            
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
    }
}
