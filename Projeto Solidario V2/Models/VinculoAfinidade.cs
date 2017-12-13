using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto_Solidario_V2.Models
{
    public class VinculoAfinidade
    {
        [Key]
        public int id { get; set; }


        public virtual Afinidade Afinidade { get; set; }
        public int Afinidadeid { get; set; }

        public virtual Voluntario Voluntario { get; set; }
        public int? Voluntarioid { get; set; }

        public virtual Entidade Entidade { get; set; }
        public int? Entidadeid { get; set; }

        public virtual Campanha Campanha { get; set; }
        public int? Campanhaid { get; set; }







    }
}