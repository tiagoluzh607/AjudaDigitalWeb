using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto_Solidario_V2.Models
{
    public class Doacao
    {
        [Key]
        public int id { get; set; }

        public DateTime Data { get; set; }

        public int Quantidade { get; set; }

        public virtual ParticipaCampanha ParticipaCampanha { get; set; }
        public int ParticipaCampanhaid { get; set; }

        public virtual Recurso Recurso { get; set; }
        public int Recursoid { get; set; }

    }
}