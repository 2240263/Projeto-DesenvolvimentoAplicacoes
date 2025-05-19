using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace iTasks.Modelos
{
    public class Programador : Utilizador
    {
        //declarei o enum como um atributo
        public NivelExperiencia nivelExperiencia { get; set; }

        public Gestor IdGestor { get; set; }
   
        public Programador()
        {

        }

        /*Vai inicializar os campos que são necessários para preencher, neste caso como estende de utilizador
        não necessita de inicializar novamente os 3 campos do utilizador, apenas tem de chamar esses mesmos
        campos com o :base */
        public Programador(NivelExperiencia nivelExperiencia, Gestor idGestor, string nome, string username, string password):base(nome,username,password)
        {
            this.nivelExperiencia = nivelExperiencia;
            this.IdGestor = idGestor;
            
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
