using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Solidario_V2.Models.dao
{
    public class ParticipaCampanhaDao
    {
        public void Adicionar(ParticipaCampanha participacampanha)
        {
            using (var context = new AjudaDigitalContext())
            {
                context.participacampanha.Add(participacampanha); //adicionando o objeto afinidade da classeAjudaDigitalContext
                context.SaveChanges();
            }
        }

        public void Excluir(ParticipaCampanha participacampanha)
        {
            using (var context = new AjudaDigitalContext())
            {
                context.participacampanha.Remove(participacampanha); //adicionando o objeto afinidade da classeAjudaDigitalContext
                context.SaveChanges();
            }
        }

        public IList<ParticipaCampanha> Listar()
        {
            using (var contexto = new AjudaDigitalContext())
            {
                return contexto.participacampanha.ToList();
            }
        }

        public ParticipaCampanha BuscarPorId(int id)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                return contexto.participacampanha.Find(id);
            }
        }

        public void Atualizar(ParticipaCampanha participacampanha)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                contexto.Entry(participacampanha).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public bool ParticipodaCampanha(Campanha campanha, Voluntario voluntario)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                //Busca dados do banco incluindo o objeto afinidade
                var busca = from p in contexto.participacampanha
                            where p.Voluntarioid == voluntario.id && p.Campanhaid == campanha.id
                            select p;

                IList<ParticipaCampanha> participacampanhas = busca.ToList();

                if (participacampanhas.Count() == 0)
                {
                    return false;
                }

                return true;
            }
        }

        public bool ParticipodaCampanha(Campanha campanha, Entidade entidade)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                //Busca dados do banco incluindo o objeto afinidade
                var busca = from p in contexto.participacampanha
                            where p.Entidadeid == entidade.id && p.Campanhaid == campanha.id
                            select p;

                IList<ParticipaCampanha> participacampanhas = busca.ToList();

                if (participacampanhas.Count() == 0)
                {
                    return false;
                }

                return true;
            }
        }

        public void Excluir(Campanha campanha, Voluntario voluntario)
        {
            using (var contexto = new AjudaDigitalContext())
            {

                //Busca dados do banco incluindo o objeto afinidade
                var busca = from p in contexto.participacampanha
                            where p.Voluntarioid == voluntario.id && p.Campanhaid == campanha.id
                            select p;

                IList<ParticipaCampanha> participacampanhas = busca.ToList();

                if (participacampanhas.Count() != 0)
                {
                    contexto.participacampanha.Remove(participacampanhas[0]); //adicionando o objeto afinidade da classeAjudaDigitalContext
                    contexto.SaveChanges();
                }
                

            }
        }

        public void Excluir(Campanha campanha, Entidade entidade)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                //Busca dados do banco incluindo o objeto afinidade
                var busca = from p in contexto.participacampanha
                            where p.Entidadeid == entidade.id && p.Campanhaid == campanha.id
                            select p;

                IList<ParticipaCampanha> participacampanhas = busca.ToList();

                if (participacampanhas.Count() != 0)
                {
                    contexto.participacampanha.Remove(participacampanhas[0]); //adicionando o objeto afinidade da classeAjudaDigitalContext
                    contexto.SaveChanges();
                }
            }
        }

        public ParticipaCampanha BuscarPorCampanhaeVoluntario(Campanha campanha, Voluntario voluntario)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                //Busca dados do banco incluindo o objeto afinidade
                var busca = from p in contexto.participacampanha
                            where p.Voluntarioid == voluntario.id && p.Campanhaid == campanha.id
                            select p;

                IList<ParticipaCampanha> participacampanhas = busca.ToList();

                if (participacampanhas.Count() == 0)
                {
                    return null;
                }

                return participacampanhas[0];
            }
        }

        public ParticipaCampanha BuscarPorCampanhaeEntidade(Campanha campanha, Entidade entidade)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                //Busca dados do banco incluindo o objeto afinidade
                var busca = from p in contexto.participacampanha
                            where p.Entidadeid == entidade.id && p.Campanhaid == campanha.id
                            select p;

                IList<ParticipaCampanha> participacampanhas = busca.ToList();

                if (participacampanhas.Count() == 0)
                {
                    return null;
                }

                return participacampanhas[0];
            }
        }


    }
}