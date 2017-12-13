using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Solidario_V2.Models.dao
{
    public class VoluntarioDao
    {
        public void Adicionar(Voluntario voluntario)
        {
            using (var context = new AjudaDigitalContext())
            {
                context.voluntario.Add(voluntario); //adicionando o objeto afinidade da classeAjudaDigitalContext
                context.SaveChanges();
            }
        }

        public void Excluir(Voluntario voluntario)
        {
            using (var context = new AjudaDigitalContext())
            {
                context.voluntario.Remove(voluntario); //adicionando o objeto afinidade da classeAjudaDigitalContext
                context.SaveChanges();
            }
        }

        public IList<Voluntario> Listar()
        {
            using (var contexto = new AjudaDigitalContext())
            {
                return contexto.voluntario.ToList();
            }
        }

        public Voluntario BuscarPorId(int id)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                Voluntario voluntario = contexto.voluntario.Find(id);

                return voluntario;
            }
        }

        public void Atualizar(Voluntario voluntario)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                contexto.Entry(voluntario).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public Voluntario BuscaVoluntarioporLogin(Login login)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                var busca = from v in contexto.voluntario
                            where v.Loginid == login.id
                            select v;

                IList<Voluntario> voluntarios = busca.ToList();

                if (voluntarios.Count() == 0)
                {
                    return null;
                }


                Voluntario voluntario = voluntarios[0];
                return voluntario;
            }
        }

    }

}