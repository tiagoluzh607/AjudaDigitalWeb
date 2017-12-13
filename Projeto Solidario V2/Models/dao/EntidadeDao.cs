using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Solidario_V2.Models.dao
{
    public class EntidadeDao
    {

        public void Adicionar(Entidade entidade)
        {
            using (var context = new AjudaDigitalContext())
            {
                context.entidade.Add(entidade); //adicionando o objeto afinidade da classeAjudaDigitalContext
                context.SaveChanges();
            }
        }

        public void Excluir(Entidade entidade)
        {
            using (var context = new AjudaDigitalContext())
            {
                context.entidade.Remove(entidade); //adicionando o objeto afinidade da classeAjudaDigitalContext
                context.SaveChanges();
            }
        }

        public IList<Entidade> Listar()
        {
            using (var contexto = new AjudaDigitalContext())
            {
                return contexto.entidade.ToList();
            }
        }

        public Entidade BuscarPorId(int id)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                return contexto.entidade.Find(id);
            }
        }

        public void Atualizar(Entidade entidade)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                contexto.Entry(entidade).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public Entidade BuscaEntidadeporLogin(Login login)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                var busca = from v in contexto.entidade 
                            where v.Loginid == login.id 
                            select v;

                IList<Entidade> entidadeslista = busca.ToList();


                if (entidadeslista.Count() == 0) {
                    return null;
                }

                Entidade entidade = entidadeslista[0];
                return entidade;
            }
        }

        public IList<Entidade> ListaAguardandoLiberacao()
        {
            using (var contexto = new AjudaDigitalContext())
            {
                var busca = from v in contexto.entidade
                            where v.Status == 0
                            orderby v.Nome
                            select v;

                IList<Entidade> entidades = busca.ToList();


                if (entidades.Count() == 0)
                {
                    return null;
                }

                return entidades;
            }
        }

        public IList<Entidade> ListaNaoAguardandoLiberacao()
        {
            using (var contexto = new AjudaDigitalContext())
            {
                var busca = from v in contexto.entidade
                            where v.Status != 0
                            orderby v.Status,v.Nome
                            select v;

                IList<Entidade> entidades = busca.ToList();


                if (entidades.Count() == 0)
                {
                    return null;
                }

                return entidades;
            }
        }
    }
}