using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Solidario_V2.Models.dao
{
    public class RecursoDao
    {
        public void Adicionar(Recurso recurso)
        {
            using (var context = new AjudaDigitalContext())
            {
                context.recurso.Add(recurso); //adicionando o objeto afinidade da classeAjudaDigitalContext
                context.SaveChanges();
            }
        }

        public void Excluir(Recurso recurso)
        {
            using (var context = new AjudaDigitalContext())
            {
                context.recurso.Remove(recurso); //adicionando o objeto afinidade da classeAjudaDigitalContext
                context.SaveChanges();
            }
        }

        public IList<Recurso> Listar()
        {
            using (var contexto = new AjudaDigitalContext())
            {
                return contexto.recurso.ToList();
            }
        }

        public Recurso BuscarPorId(int id)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                return contexto.recurso.Find(id);
            }
        }

        public void Atualizar(Recurso recurso)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                contexto.Entry(recurso).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }
    }
}