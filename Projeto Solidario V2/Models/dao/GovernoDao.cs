using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Solidario_V2.Models.dao
{
    public class GovernoDao
    {
        public void Adicionar(Governo governo)
        {
            using (var context = new AjudaDigitalContext())
            {
                context.governo.Add(governo); //adicionando o objeto afinidade da classeAjudaDigitalContext
                context.SaveChanges();
            }
        }

        public void Excluir(Governo governo)
        {
            using (var context = new AjudaDigitalContext())
            {
                context.governo.Remove(governo); //adicionando o objeto afinidade da classeAjudaDigitalContext
                context.SaveChanges();
            }
        }

        public IList<Governo> Listar()
        {
            using (var contexto = new AjudaDigitalContext())
            {
                return contexto.governo.ToList();
            }
        }

        public Governo BuscarPorId(int id)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                return contexto.governo.Find(id);
            }
        }

        public void Atualizar(Governo governo)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                contexto.Entry(governo).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public Governo BuscaGovernoporLogin(Login login)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                var busca = from v in contexto.governo
                            where v.Loginid == login.id
                            select v;

                IList<Governo> governos = busca.ToList();

                if (governos.Count() == 0)
                {
                    return null;
                }

                Governo governo = governos[0];
                return governo;
            }
        }

    }
}