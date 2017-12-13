using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Solidario_V2.Models.dao
{
    public class AfinidadeDao
    {
        public void Adicionar(Afinidade afinidade)
        {
            using (var context = new AjudaDigitalContext())
            {
                context.afinidade.Add(afinidade); //adicionando o objeto afinidade da classeAjudaDigitalContext
                context.SaveChanges();
            }
        }

        public void Excluir(Afinidade afinidade)
        {
            using (var context = new AjudaDigitalContext())
            {
                context.afinidade.Remove(afinidade); //adicionando o objeto afinidade da classeAjudaDigitalContext
                context.SaveChanges();
            }
        }

        public IList<Afinidade> Listar()
        {
            using (var contexto = new AjudaDigitalContext())
            {
                return contexto.afinidade.ToList();
            }
        }

        public Afinidade BuscarPorId(int id)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                return contexto.afinidade.Find(id);
            }
        }

        public void Atualizar(Afinidade afinidade)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                contexto.Entry(afinidade).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }

    }
}