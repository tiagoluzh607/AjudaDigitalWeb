using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Solidario_V2.Models.dao
{
    public class CidadeDao
    {
        public void Adicionar(Cidade cidade)
        {
            using (var context = new AjudaDigitalContext())
            {
                context.cidade.Add(cidade); //adicionando o objeto afinidade da classeAjudaDigitalContext
                context.SaveChanges();
            }
        }

        public void Excluir(Cidade cidade)
        {
            using (var context = new AjudaDigitalContext())
            {
                context.cidade.Remove(cidade); //adicionando o objeto afinidade da classeAjudaDigitalContext
                context.SaveChanges();
            }
        }

        public void ExcluirTudo()
        {
            using (var context = new AjudaDigitalContext())
            {
                context.cidade.RemoveRange(Listar()); //deletando tudo
            }
        }

        public IList<Cidade> Listar()
        {
            using (var contexto = new AjudaDigitalContext())
            {

                var busca = from cidade in contexto.cidade
                            orderby cidade.Nome
                            select cidade;

                return busca.ToList();
            }
        }

        public Cidade BuscarPorId(int id)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                return contexto.cidade.Find(id);
            }
        }

        public void Atualizar(Cidade cidade)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                contexto.Entry(cidade).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }
    }
}