using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.Modelos
{
    public class Utilizador
    {

        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string  Username { get; set; }
        public string Password { get; set; }

         public Utilizador()
         {

         }

        public Utilizador(string nome, string username, string password)
        {
            Nome = nome;
            Username = username;
            Password = password;
        }
    }
}
