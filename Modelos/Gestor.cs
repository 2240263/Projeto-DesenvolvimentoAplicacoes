using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.Modelos
{
    public class Gestor : Utilizador
    {

        public Departamentos Departamento { get; set; }

        public bool GereUtilizadores { get; set; }

        public Gestor()
        {
                      
        }

        public Gestor(bool gereUtilizadores, Departamentos departamento,string nome, string username, string password): base(nome, username, password)
        {
            this.GereUtilizadores = gereUtilizadores;

            this.Departamento = departamento;

           
        }


    }
}
