using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        public int IdGestor { get; set; } //É a chave estrangeira que vai fazer referencia ao id da tabela gestor

        [ForeignKey("IdGestor")]
        public virtual Gestor Gestor { get; set; } // Propriedade para conseguir criar a chave estrangeira

        public Programador()
        {

        }

        /*Vai inicializar os campos que são necessários para preencher, neste caso como estende de utilizador
        não necessita de inicializar novamente os 3 campos do utilizador, apenas tem de chamar esses mesmos
        campos com o :base */
        public Programador(NivelExperiencia nivelExperiencia, int idGestor, string nome, string username, string password):base(nome,username,password)
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
