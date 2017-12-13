using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto_Solidario_V2.Models
{
    public class Governo
    {
        [Key]
        public int id { get; set; }

        public virtual Login Login { get; set; }
        public int Loginid { get; set; }

        public virtual Cidade Cidade { get; set; }
        public int Cidadeid { get; set; }

        public String Nome { get; set; }

        public int Ibge { get; set; }

        public String Cpf { get; set; }

        public String InscricaoEstadual { get; set; }

        public String Logradouro { get; set; }

        public int Numero { get; set; }

        public String Complemento { get; set; }

        public String Bairro { get; set; }

        public String Estado { get; set; }

        public String CEP { get; set; }

        public String Telefone { get; set; }

        public String Aniversario { get; set; }

    }
}