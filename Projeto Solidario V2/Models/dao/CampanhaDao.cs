using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Solidario_V2.Models.dao
{
    public class CampanhaDao
    {
        public void Adicionar(Campanha campanha)
        {
            using (var context = new AjudaDigitalContext())
            {
                context.campanha.Add(campanha); //adicionando o objeto afinidade da classeAjudaDigitalContext
                context.SaveChanges();
            }
        }

        public void Excluir(Campanha campanha)
        {
            using (var context = new AjudaDigitalContext())
            {
                context.campanha.Remove(campanha); //adicionando o objeto afinidade da classeAjudaDigitalContext
                context.SaveChanges();
            }
        }

        public IList<Campanha> Listar()
        {
            using (var contexto = new AjudaDigitalContext())
            {
                return contexto.campanha.ToList();
            }
        }

        public Campanha BuscarPorId(int id)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                return contexto.campanha.Find(id);
            }
        }

        public void Atualizar(Campanha campanha)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                contexto.Entry(campanha).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public IList<Campanha> BuscaporEntidade(Entidade entidade)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                //Busca dados do banco incluindo o objeto afinidade
                var busca = from c in contexto.campanha
                            where c.Entidadeid == entidade.id
                            select c;

                IList<Campanha> campanhas = busca.ToList();

                if (campanhas.Count() == 0)
                {
                    return null;
                }
                return campanhas;
            }
        }
    }
}