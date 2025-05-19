using iTasks.Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.Modelos
{
    
    public class TipoTarefa
    {
        
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }


        public TipoTarefa()
        {
        }

        public TipoTarefa(string nome)
        {
            this.Nome = nome;
        }

        public override string ToString()
        {
            return Nome;
        }
    }   

}
