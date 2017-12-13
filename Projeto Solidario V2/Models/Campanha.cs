using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto_Solidario_V2.Models
{
    public class Campanha
    {
        [Key]
        public int id { get; set; }

        public String Nome { get; set; }

        public String Descricao { get; set; }

        public DateTime DataInicial { get; set; }

        public DateTime DataFinal { get; set; }

        public virtual Entidade Entidade { get; set; }// virtual é para saber que é chave primaria
        public int Entidadeid { get; set; }





        //Para ajudar o Entity com chaves estrangeiras
        public virtual IList<VinculoAfinidade> VinculoAfinidades { get; set; }
        public virtual IList<ParticipaCampanha> ParticipaCampanhas { get; set; }



    }
}