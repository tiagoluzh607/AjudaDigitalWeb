using Projeto_Solidario_V2.Models;
using Projeto_Solidario_V2.Models.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto_Solidario_V2.Controllers
{
    public class CadastroEntidadeController : Controller
    {
        // GET: CadastroEntidade
        public ActionResult Index()
        {
            //Passa as Cidades
            CidadeDao cidadedao = new CidadeDao();
            ViewBag.Cidades = cidadedao.Listar();

            //Passa a Entidade
            Entidade entidade = new Entidade();

            if (Session["Entidade"] != null)
            {
                entidade = (Entidade)Session["Entidade"];
            }

            else
            {
                Login login = new Login();

                entidade.Limpar();
                login.Limpar();
                entidade.Login = login;
            }

            ViewBag.Entidade = entidade;
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Entidade entidade, Login login)// entidade login recebe o que o usuario digitou
        {

            EntidadeDao entidadedao = new EntidadeDao();
            entidade.Login = login;
            //Se O voluntario já existir atualiza os Dados
            if (entidade.id > 0)
            {
                LoginDao logindao = new LoginDao();
                logindao.Atualizar(login);

                entidade.Loginid = login.id;
                entidadedao.Atualizar(entidade);

                //Atualiza a sessao e redireciona para o menu principal
                entidade.Login = logindao.BuscarPorId(entidade.Loginid);
                Session["Entidade"] = entidade;
                return RedirectToAction("Index", "VinculoAfinidade");
            }

            //Caso contrario cria novo registro
            else
            {
                entidadedao.Adicionar(entidade);
            }

            return RedirectToAction("Index", "Login");

            //Adiciona ou atuliza o Objeto na sessão



        }
    }
}