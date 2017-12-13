using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projeto_Solidario_V2.Models;
using Projeto_Solidario_V2.Models.dao;

namespace Projeto_Solidario_V2.Controllers
{
    public class TipoRecursoController : Controller
    {
        private  AjudaDigitalContext db = new AjudaDigitalContext();

        // GET: TipoRecurso
        public ActionResult Index()
        {
            return View(db.tiporecurso.ToList());
        }

        // GET: TipoRecurso/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoRecurso tipoRecurso = db.tiporecurso.Find(id);
            if (tipoRecurso == null)
            {
                return HttpNotFound();
            }
            return View(tipoRecurso);
        }

        // GET: TipoRecurso/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoRecurso/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descricao,tipo")] TipoRecurso tipoRecurso)
        {
            if (ModelState.IsValid)
            {
                db.tiporecurso.Add(tipoRecurso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoRecurso);
        }

        // GET: TipoRecurso/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoRecurso tipoRecurso = db.tiporecurso.Find(id);
            if (tipoRecurso == null)
            {
                return HttpNotFound();
            }
            return View(tipoRecurso);
        }

        // POST: TipoRecurso/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descricao,tipo")] TipoRecurso tipoRecurso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoRecurso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoRecurso);
        }

        // GET: TipoRecurso/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoRecurso tipoRecurso = db.tiporecurso.Find(id);
            if (tipoRecurso == null)
            {
                return HttpNotFound();
            }
            return View(tipoRecurso);
        }

        // POST: TipoRecurso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoRecurso tipoRecurso = db.tiporecurso.Find(id);
            db.tiporecurso.Remove(tipoRecurso);
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
    }
}
