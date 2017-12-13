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
    public class VinculoAfinidadeDao
    {
        public void Adicionar(VinculoAfinidade vinculoafinidade)
        {
            using (var context = new AjudaDigitalContext())
            {
                context.vinculoafinidade.Add(vinculoafinidade); //adicionando o objeto afinidade da classeAjudaDigitalContext
                context.SaveChanges();
            }
        }

        public void Excluir(VinculoAfinidade vinculoafinidade)
        {
            using (var context = new AjudaDigitalContext())
            {
                if(context.Entry(vinculoafinidade).State != null)
                {
                    context.Entry(vinculoafinidade).State = EntityState.Deleted;
                }
                context.vinculoafinidade.Remove(vinculoafinidade); //adicionando o objeto afinidade da classeAjudaDigitalContext
                context.SaveChanges();
            }
        }

        public IList<VinculoAfinidade> Listar()
        {
            using (var contexto = new AjudaDigitalContext())
            {
                return contexto.vinculoafinidade.ToList();
            }
        }

        public VinculoAfinidade BuscarPorId(int id)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                return contexto.vinculoafinidade.Find(id);
            }
        }

        public void Atualizar(VinculoAfinidade vinculoafinidade)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                contexto.Entry(vinculoafinidade).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public IList<VinculoAfinidade> BuscaporCampanha(Campanha campanha)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                //Busca dados do banco incluindo o objeto afinidade
                var busca = from v in contexto.vinculoafinidade.Include(v => v.Afinidade)
                            where v.Campanhaid == campanha.id
                            select v;

                IList<VinculoAfinidade> vinculoafinidades = busca.ToList();

                if (vinculoafinidades.Count() == 0)
                {
                    return null;
                }
                return vinculoafinidades;
            }
        }

        public IList<VinculoAfinidade> BuscaporEntidade(Entidade entidade)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                //Busca dados do banco incluindo o objeto afinidade
                var busca = from v in contexto.vinculoafinidade.Include(v => v.Afinidade)
                            where v.Entidadeid == entidade.id
                            select v;

                IList<VinculoAfinidade> vinculoafinidades = busca.ToList();

                if (vinculoafinidades.Count() == 0)
                {
                    return null;
                }

                return vinculoafinidades;
            }
        }

        public IList<VinculoAfinidade> BuscaporVoluntario(Voluntario voluntario)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                //Busca dados do banco incluindo o objeto afinidade
                var busca = from v in contexto.vinculoafinidade.Include(v => v.Afinidade)
                            where v.Voluntarioid == voluntario.id
                            select v;

                IList<VinculoAfinidade> vinculoafinidades = busca.ToList();

                if (vinculoafinidades.Count() == 0)
                {
                    return null;
                }

                return vinculoafinidades;
            }
        }


        public IList<Afinidade> BuscaAfinidadesporCampanha(Campanha campanha)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                //Busca dados do banco incluindo o objeto afinidade
                var busca = from v in contexto.vinculoafinidade.Include(v => v.Afinidade)
                            where v.Campanhaid == campanha.id
                            select v;

                IList<VinculoAfinidade> vinculoafinidades = busca.ToList();

                if (vinculoafinidades.Count() == 0)
                {
                    return null;
                }

                //Traz somente as afinidades
                IList<Afinidade> afinidades = new List<Afinidade>();

                foreach(var vinculo in vinculoafinidades)
                {
                    afinidades.Add(vinculo.Afinidade);
                }

                return afinidades;
            }
        }

        public IList<Afinidade> BuscaAfinidadesporEntidade(Entidade entidade)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                //Busca dados do banco incluindo o objeto afinidade
                var busca = from v in contexto.vinculoafinidade.Include(v => v.Afinidade)
                            where v.Entidadeid == entidade.id
                            select v;

                IList<VinculoAfinidade> vinculoafinidades = busca.ToList();

                if (vinculoafinidades.Count() == 0)
                {
                    return null;
                }

                //Traz somente as afinidades
                IList<Afinidade> afinidades = new List<Afinidade>();

                foreach (var vinculo in vinculoafinidades)
                {
                    afinidades.Add(vinculo.Afinidade);
                }

                return afinidades;
            }
        }

        public IList<Afinidade> BuscaAfinidadesporVoluntario(Voluntario voluntario)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                //Busca dados do banco incluindo o objeto afinidade
                var busca = from v in contexto.vinculoafinidade.Include(v => v.Afinidade)
                            where v.Voluntarioid == voluntario.id
                            select v;

                IList<VinculoAfinidade> vinculoafinidades = busca.ToList();

                if (vinculoafinidades.Count() == 0)
                {
                    return null;
                }

                //Traz somente as afinidades
                IList<Afinidade> afinidades = new List<Afinidade>();

                foreach (var vinculo in vinculoafinidades)
                {
                    afinidades.Add(vinculo.Afinidade);
                }

                return afinidades;
            }
        }



        public bool ExisteAfinidade(Voluntario voluntario)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                //Busca dados do banco incluindo o objeto afinidade
                var busca = from v in contexto.vinculoafinidade.Include(v => v.Afinidade)
                            where v.Voluntarioid == voluntario.id
                            select v;

                IList<VinculoAfinidade> vinculoafinidades = busca.ToList();

                if (vinculoafinidades.Count() == 0)
                {
                    return false;
                }

                return true;
            }
        }

        public bool ExisteAfinidade(Entidade entidade)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                //Busca dados do banco incluindo o objeto afinidade
                var busca = from v in contexto.vinculoafinidade.Include(v => v.Afinidade)
                            where v.Entidadeid == entidade.id
                            select v;

                IList<VinculoAfinidade> vinculoafinidades = busca.ToList();

                if (vinculoafinidades.Count() == 0)
                {
                    return false;
                }

                return true;
            }
        }


        public IList<Campanha> BuscaCampanhaporAfinidades(IList<Afinidade> afinidades)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                IList<Campanha> campanhas = new List<Campanha>();

                foreach (var afinidade in afinidades)
                {

                            //Busca dados do banco incluindo o objeto afinidade
                            var busca = from v in contexto.vinculoafinidade.Include(v => v.Campanha)
                                        where v.Afinidadeid == afinidade.id && v.Campanhaid > 0
                                        select v;

                            IList<VinculoAfinidade> vinculoafinidades = busca.ToList();

                            if (!(vinculoafinidades.Count() == 0))
                            {

                                foreach (var vinculo in vinculoafinidades)
                                {
                                    if (!campanhas.Contains(vinculo.Campanha))
                                    {
                                        campanhas.Add(vinculo.Campanha);
                                    }

                                }
                            }
                }


                if (campanhas.Count() == 0)
                {
                    return null;
                }

                return campanhas;
            }
        }


    }
}