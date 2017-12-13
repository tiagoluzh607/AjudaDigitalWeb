using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto_Solidario_V2.Models
{
    public class Afinidade
    {
        [Key]
        public int id { get; set; }

        public String Descricao { get; set; }




        //Para ajudar o Entity com chaves estrangeiras
        public virtual IList<VinculoAfinidade> VinculoAfinidades { get; set; }
       
    }
}