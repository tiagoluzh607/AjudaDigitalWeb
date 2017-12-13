using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Solidario_V2.Models.dao
{
    public class TipoRecursoDao
    {
        public void Adicionar(TipoRecurso tiporecurso)
        {
            using (var context = new AjudaDigitalContext())
            {
                context.tiporecurso.Add(tiporecurso); //adicionando o objeto afinidade da classeAjudaDigitalContext
                context.SaveChanges();
            }
        }

        public void Excluir(TipoRecurso tiporecurso)
        {
            using (var context = new AjudaDigitalContext())
            {
                context.tiporecurso.Remove(tiporecurso); //adicionando o objeto afinidade da classeAjudaDigitalContext
                context.SaveChanges();
            }
        }

        public IList<TipoRecurso> Listar()
        {
            using (var contexto = new AjudaDigitalContext())
            {
                return contexto.tiporecurso.ToList();
            }
        }

        public TipoRecurso BuscarPorId(int id)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                return contexto.tiporecurso.Find(id);
            }
        }

        public void Atualizar(TipoRecurso tiporecurso)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                contexto.Entry(tiporecurso).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }
    }
}