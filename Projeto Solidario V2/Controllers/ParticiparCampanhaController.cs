using Projeto_Solidario_V2.Models;
using Projeto_Solidario_V2.Models.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto_Solidario_V2.Controllers
{
    public class ParticiparCampanhaController : Controller
    {
        // GET: ParticiparCampanha
        public ActionResult Index()
        {
            //conexoes com o banco
            VinculoAfinidadeDao vinculoafinidadedao = new VinculoAfinidadeDao();
            ParticipaCampanhaDao participacampanhadao = new ParticipaCampanhaDao();

            //Instanciando as listas
            IList<Campanha> campanhasdisponiveis = new List<Campanha>();
            IList<Campanha> campanhasparticipantes = new List<Campanha>();

            //verifica se é entidade ou voluntario para preenche as campanhas participantes e disponiveis
            if (Session["Entidade"] != null)
            {
                Entidade entidadesessao = (Entidade)Session["Entidade"];
                IList<Afinidade> afinidades = vinculoafinidadedao.BuscaAfinidadesporEntidade(entidadesessao);
                IList<Campanha> campanhas = vinculoafinidadedao.BuscaCampanhaporAfinidades(afinidades);

                foreach (var campanha in campanhas)
                {
                    //Verifica se participa ou nao da campanha para preencher a lista correspondente
                    if (participacampanhadao.ParticipodaCampanha(campanha, entidadesessao))
                    {
                        campanhasparticipantes.Add(campanha);
                    }
                    else
                    {
                        campanhasdisponiveis.Add(campanha);
                    }
                }

            }
            else if (Session["Voluntario"] != null)
            {
                Voluntario voluntariosessao = (Voluntario)Session["Voluntario"];
                IList<Afinidade> afinidades = vinculoafinidadedao.BuscaAfinidadesporVoluntario(voluntariosessao);
                IList<Campanha> campanhas = vinculoafinidadedao.BuscaCampanhaporAfinidades(afinidades);

                foreach (var campanha in campanhas) {
                    //Verifica se participa ou nao da campanha para preencher a lista correspondente
                    if (participacampanhadao.ParticipodaCampanha(campanha, voluntariosessao))
                    {
                        campanhasparticipantes.Add(campanha);
                    }
                    else
                    {
                        campanhasdisponiveis.Add(campanha);
                    }
                }
            }


            if(campanhasdisponiveis.Count() > 0)
            {
                ViewBag.CampanhasDisponiveis = campanhasdisponiveis;
            }
            
            if(campanhasparticipantes.Count > 0)
            {
                ViewBag.CampanhasParticipantes = campanhasparticipantes;
            }
            
            
            return View();
        }

        public ActionResult Colaborar(int id)
        {
            DoacaoDao doacaodao = new DoacaoDao();
            ParticipaCampanhaDao participacampanhadao = new ParticipaCampanhaDao();
            CampanhaDao campanhadao = new CampanhaDao();

            ParticipaCampanha participacampanha = new ParticipaCampanha();
            Campanha campanha = campanhadao.BuscarPorId(id);

            if (Session["Entidade"] != null)
            {
                Entidade entidadesessao = (Entidade)Session["Entidade"];
                participacampanha = participacampanhadao.BuscarPorCampanhaeEntidade(campanha, entidadesessao);
            }
            else if (Session["Voluntario"] != null)
            {
                Voluntario voluntariosessao = (Voluntario)Session["Voluntario"];
                participacampanha = participacampanhadao.BuscarPorCampanhaeVoluntario(campanha, voluntariosessao);
            }

            //Lista Doacoes ja feitas para campanha
            ViewBag.Doacaos = doacaodao.BuscaporCampanha(participacampanha);


            RecursoDao recursodao = new RecursoDao();
            ViewBag.Recursos = recursodao.Listar();
            ViewBag.ParticipaCampanhaId = participacampanha.id;
            ViewBag.Campanhaid = id;
            return View();
        }

        public ActionResult Details(int id)
        {
            CampanhaDao campanhadao = new CampanhaDao();
            ViewBag.Campanha = campanhadao.BuscarPorId(id);

            return View();
        }

        public ActionResult ParticiparCampanha(int id)
        {
            CampanhaDao campanhadao = new CampanhaDao();
            ParticipaCampanhaDao participacampanhadao = new ParticipaCampanhaDao();

            ParticipaCampanha participacampanha = new ParticipaCampanha();
            participacampanha.Campanhaid = id;

            if (Session["Entidade"] != null)
            {
                Entidade entidadesessao = (Entidade)Session["Entidade"];
                participacampanha.Entidadeid = entidadesessao.id;
            }
            else if (Session["Voluntario"] != null)
            {
                Voluntario voluntariosessao = (Voluntario)Session["Voluntario"];
                participacampanha.Voluntarioid = voluntariosessao.id;
            }

                participacampanhadao.Adicionar(participacampanha);
                return RedirectToAction("Index","ParticiparCampanha");
        }

        public ActionResult SairCampanha(int id)
        {

            CampanhaDao campanhadao = new CampanhaDao();
            ParticipaCampanhaDao participacampanhadao = new ParticipaCampanhaDao();

            ParticipaCampanha participacampanha = new ParticipaCampanha();
            Campanha campanha = campanhadao.BuscarPorId(id);

            if (Session["Entidade"] != null)
            {
                Entidade entidadesessao = (Entidade)Session["Entidade"];
                participacampanhadao.Excluir(campanha, entidadesessao);
            }
            else if (Session["Voluntario"] != null)
            {
                Voluntario voluntariosessao = (Voluntario)Session["Voluntario"];
                participacampanhadao.Excluir(campanha, voluntariosessao);
            }

            return RedirectToAction("Index", "ParticiparCampanha");
        }

        [HttpPost]
        public ActionResult Adicionar(Doacao doacao, int id)
        {
            DoacaoDao doacaodao = new DoacaoDao();
            doacaodao.Adicionar(doacao);

            return RedirectToAction("Colaborar", new { id = id });
        }

        public ActionResult Deletar(int id, int Campanhaid)
        {
            DoacaoDao doacaodao = new DoacaoDao();
            Doacao doacao = doacaodao.BuscarPorId(id);
            doacaodao.Excluir(doacao);

            return RedirectToAction("Colaborar", new { id = Campanhaid });
        }
    }
}