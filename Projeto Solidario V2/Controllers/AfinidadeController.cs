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
    public class AfinidadeController : Controller
    {
        private  AjudaDigitalContext db = new AjudaDigitalContext();

        // GET: Afinidade
        public ActionResult Index()
        {
            return View(db.afinidade.ToList());
        }

        // GET: Afinidade/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Afinidade afinidade = db.afinidade.Find(id);
            if (afinidade == null)
            {
                return HttpNotFound();
            }
            return View(afinidade);
        }

        // GET: Afinidade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Afinidade/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descricao")] Afinidade afinidade)
        {
            if (ModelState.IsValid)
            {
                db.afinidade.Add(afinidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(afinidade);
        }

        // GET: Afinidade/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Afinidade afinidade = db.afinidade.Find(id);
            if (afinidade == null)
            {
                return HttpNotFound();
            }
            return View(afinidade);
        }

        // POST: Afinidade/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descricao")] Afinidade afinidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(afinidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(afinidade);
        }

        // GET: Afinidade/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Afinidade afinidade = db.afinidade.Find(id);
            if (afinidade == null)
            {
                return HttpNotFound();
            }
            return View(afinidade);
        }

        // POST: Afinidade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Afinidade afinidade = db.afinidade.Find(id);
            db.afinidade.Remove(afinidade);
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
