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
        NivelExperiencia nivelExperiencia;

        public Programador()
        {
            nivelExperiencia = NivelExperiencia.Junior;
        }


    }
}
