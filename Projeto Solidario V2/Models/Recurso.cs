using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto_Solidario_V2.Models
{
    public class Recurso
    {
        [Key]
        public int id { get; set; }

        public String Nome { get; set; }

        public virtual TipoRecurso TipoRecurso { get; set; }
        public int TipoRecursoid { get; set;}



        //Para ajudar o Entity com chaves estrangeiras
        public virtual IList<Doacao> Doacoes { get; set; }
    }
}