using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto_Solidario_V2.Models
{
    public class Entidade
    {
        [Key]
        public int id { get; set; }

        public virtual Login Login { get; set; }

        public int Loginid { get; set; }

        public virtual Cidade Cidade { get; set; }
        public int Cidadeid { get; set; }

        public String Nome { get; set; }

        public String CnpjCpf { get; set; }

        public String Logradouro { get; set; }

        public int Numero { get; set; }

        public String Complemento { get; set; }

        public String Bairro { get; set; }

        public String TipoEntidade { get; set; }

        public String Estado { get; set; }

        public String Cep { get; set; }

        public String Telefone { get; set; }

        /**
        0 = Aguardando Liberação, 1 = Operando, 2 = Parada, 3 = Fechada, 4 = Recusada
        **/
        public int Status { get; set; }



        //Para ajudar o Entity com chaves estrangeiras
        public virtual IList<VinculoAfinidade> VinculoAfinidades { get; set; }
        public virtual IList<ParticipaCampanha> ParticipaCampanhas { get; set; }
        public virtual IList<Campanha> Campanhas { get; set; }
        public void Limpar()
        {
            id = 0;
            Nome = "";
            CnpjCpf = "";
            Logradouro = "";
            Numero = 0;
            Complemento = "";
            Bairro = "";
            Estado = "";
            Cep = "";
            Telefone = "";
            Status = 0;

        }

        public String getStatusDescricao()
        {
            switch (Status)
            {
                case 0:
                    return "Aguardando Liberação";
                    break;
                case 1:
                    return "Operando";
                    break;
                case 2:
                    return "Parada";
                    break;
                case 3:
                    return "Fechada";
                    break;
                case 4:
                    return "Recusada";
                    break;
            }
            //Caso não entre em nenhuma
            return "Não Definido";
        }
    }
}