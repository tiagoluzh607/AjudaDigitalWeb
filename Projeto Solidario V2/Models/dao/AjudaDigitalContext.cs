using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projeto_Solidario_V2.Models.dao
{
    public class AjudaDigitalContext: DbContext
    {
        public DbSet<Afinidade> afinidade { get; set;} //criar esse registro para todas as tabelas
                                                       //foi criado o objeto afinidade
        public DbSet<VinculoAfinidade> vinculoafinidade { get; set; }

        public DbSet<Cidade> cidade { get; set; } 

        public DbSet<Voluntario> voluntario { get; set; }
        
        public DbSet<Governo> governo { get; set; } 
        
        public DbSet<Entidade> entidade { get; set; } 
        
        public DbSet<Login> login { get; set; }

        public DbSet<Doacao> doacao { get; set; }

        public DbSet<Recurso> recurso { get; set; }

        public DbSet<TipoRecurso> tiporecurso { get; set; }

        public DbSet<Campanha> campanha { get; set; }

        public DbSet<ParticipaCampanha> participacampanha { get; set; }


    }
}