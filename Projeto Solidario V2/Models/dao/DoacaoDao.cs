using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Solidario_V2.Models.dao
{
    public class DoacaoDao
    {
        public void Adicionar(Doacao doacao)
        {
            using (var context = new AjudaDigitalContext())
            {
                context.doacao.Add(doacao); //adicionando o objeto afinidade da classeAjudaDigitalContext
                context.SaveChanges();
            }
        }

        public void Excluir(Doacao doacao)
        {
            using (var context = new AjudaDigitalContext())
            {
                if (context.Entry(doacao).State != null)
                {
                    context.Entry(doacao).State = EntityState.Deleted;
                }
                context.doacao.Remove(doacao); //adicionando o objeto afinidade da classeAjudaDigitalContext
                context.SaveChanges();
            }
        }

        public IList<Doacao> Listar()
        {
            using (var contexto = new AjudaDigitalContext())
            {
                return contexto.doacao.ToList();
            }
        }

        public Doacao BuscarPorId(int id)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                return contexto.doacao.Find(id);
            }
        }

        public void Atualizar(Doacao doacao)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                contexto.Entry(doacao).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public IList<Doacao> BuscaporCampanha(ParticipaCampanha participacampanha)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                //Busca dados do banco incluindo o objeto afinidade
                var busca = from d in contexto.doacao.Include(d => d.Recurso)
                            where d.ParticipaCampanhaid == participacampanha.id
                            select d;

                IList<Doacao> doacaos = busca.ToList();

                if (doacaos.Count() == 0)
                {
                    return null;
                }

                return doacaos;
            }
        }


    }
}