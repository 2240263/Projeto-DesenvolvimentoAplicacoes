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

        /*Vai inicializar os campos que são necessários para preencher, neste caso como estende de utilizador
       não necessita de inicializar novamente os 3 campos do utilizador, apenas tem de chamar esses mesmos
       campos com o :base */
        public Gestor(bool gereUtilizadores, Departamentos departamento,string nome, string username, string password): base(nome, username, password)
        {
            this.GereUtilizadores = gereUtilizadores;

            this.Departamento = departamento;

           
        }

        public override string ToString()
        {
            return Username;
        }
    }
}
