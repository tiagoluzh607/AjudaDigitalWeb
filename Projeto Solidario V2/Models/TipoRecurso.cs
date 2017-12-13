using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto_Solidario_V2.Models
{
    public class TipoRecurso
    {
        [Key]
        public int id { get; set; }

        public String Nome { get; set; }

        //Se é serviço ou material
        public String Tipo { get; set; }




        //Para ajudar o Entity com chaves estrangeiras
        public virtual IList<Recurso> Recursos { get; set; }
    }
}