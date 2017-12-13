using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto_Solidario_V2.Models
{
    public class Login
    {
        [Key]
        public int id { get; set; }

        public String Email { get; set; }

        public String Senha { get; set; }

        public Boolean Status { get; set; }


        //Para ajudar o Entity com chaves estrangeiras
        public virtual IList<Entidade> Entidades { get; set; }
        public virtual IList<Voluntario> Voluntarios { get; set; }
        public virtual IList<Governo> Governos { get; set; }

        public void Limpar()
        {
            id = 0;
            Email = "";
            Senha = "";
            Status = true;
        }
    }
}