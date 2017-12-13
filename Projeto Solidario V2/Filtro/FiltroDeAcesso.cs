using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Projeto_Solidario_V2.Filtro
{
    public class FiltroDeAcesso:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            object usuarioLogado = filterContext.HttpContext.Session["Voluntario"];
            if(usuarioLogado == null)
            {
                usuarioLogado = filterContext.HttpContext.Session["Entidade"];
                if (usuarioLogado == null)
                {
                    usuarioLogado = filterContext.HttpContext.Session["Governo"];
                }
            }


            if (usuarioLogado == null)
            {
                RouteValueDictionary dicionario = new RouteValueDictionary(new { action = "Index", Controller = "Login" });
                RedirectToRouteResult rotaRedirecionada = new RedirectToRouteResult(dicionario);

                filterContext.Result = rotaRedirecionada;
            }

        }
    
    
    }
}