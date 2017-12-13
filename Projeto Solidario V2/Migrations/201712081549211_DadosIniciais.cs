namespace Projeto_Solidario_V2.Migrations
{
    using Models;
    using Models.dao;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    public partial class DadosIniciais : DbMigration
    {
        public override void Up()
        {
            InsertCidade();
        }
        
        public override void Down()
        {
            CidadeDao cidadedao = new CidadeDao();
            cidadedao.ExcluirTudo();
        }

        public void InsertCidade()
        {
            CidadeDao cidadedao = new CidadeDao();

            IList<String> cidades = new List<String>
            { "Novo Hamburgo",
              "Campo Bom",
             "São Leopoldo",
             "Sapiranga"};

            foreach (String nome in cidades)
            {
                Cidade cidade = new Cidade();
                cidade.Nome = nome;

                cidadedao.Adicionar(cidade);
            }

        }
    }
}
