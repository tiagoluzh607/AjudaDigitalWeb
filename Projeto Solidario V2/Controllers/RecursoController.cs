using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projeto_Solidario_V2.Models;
using Projeto_Solidario_V2.Models.dao;
using System.Data.Entity;

namespace Projeto_Solidario_V2.Controllers
{
    public class RecursoController : Controller
    {
        private  AjudaDigitalContext db = new AjudaDigitalContext();

        // GET: Recurso
        public ActionResult Index()
        {
            return View(db.recurso.ToList());
        }

        // GET: Recurso/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recurso recurso = db.recurso.Find(id);
            if (recurso == null)
            {
                return HttpNotFound();
            }
            return View(recurso);
        }

        // GET: Recurso/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recurso/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descricao,id_tipo_recurso")] Recurso recurso)
        {
            if (ModelState.IsValid)
            {
                db.recurso.Add(recurso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recurso);
        }

        // GET: Recurso/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recurso recurso = db.recurso.Find(id);
            if (recurso == null)
            {
                return HttpNotFound();
            }
            return View(recurso);
        }

        // POST: Recurso/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descricao,id_tipo_recurso")] Recurso recurso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recurso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recurso);
        }

        // GET: Recurso/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recurso recurso = db.recurso.Find(id);
            if (recurso == null)
            {
                return HttpNotFound();
            }
            return View(recurso);
        }

        // POST: Recurso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recurso recurso = db.recurso.Find(id);
            db.recurso.Remove(recurso);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult Cadastrar(Recurso recurso, TipoRecurso tiporecurso)// entidade login recebe o que o usuario digitou
        {

            RecursoDao recursodao = new RecursoDao();
            recurso.TipoRecurso = tiporecurso; // estamos passando o que o usuario digitou para o login da entidade
            recursodao.Adicionar(recurso); // adicionando ao banco todos os campos digitados pelo usuario

            return RedirectToAction("Index","Recurso");
        }



    }
}
