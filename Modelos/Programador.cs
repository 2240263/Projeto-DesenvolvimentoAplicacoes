using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.Modelos
{
    public class Programador : Utilizador
    {
        //declarei o enum como um atributo
        public NivelExperiencia nivelExperiencia { get; set; }

        public int IdGestor { get; set; }

        public Programador()
        {
           
        }

        public Programador(NivelExperiencia nivelExperiencia, int idGestor, string nome, string username, string password):base(nome,username,password)
        {
            this.nivelExperiencia = nivelExperiencia;
            this.IdGestor = idGestor;
        }
    }
}
