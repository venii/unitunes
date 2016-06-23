using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Unitunes.Models;

namespace Unitunes.Controllers
{
    public class TransacaoController : Controller
    {
        private dbEntities db = new dbEntities();

        // GET: Transacao
        public ActionResult Index()
        {
            

            var idAcademico = Unitunes.Models.Servicos.Academico.getId();
            var academicos = db.AcademicoSet;
            // pega obj para referencia a nova transacao
            var academicoObj = academicos.Find(idAcademico);

            return View(db.TransacaoSet.Where(t => t.AcademicoDaTransacao.Id == idAcademico).ToList());
        }

        // GET: Transacao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacao transacao = db.TransacaoSet.Find(id);
            if (transacao == null)
            {
                return HttpNotFound();
            }
            return View(transacao);
        }

        // GET: Transacao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Valor,Ativo")] Transacao transacao)
        {
            if (ModelState.IsValid)
            {
                db.TransacaoSet.Add(transacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transacao);
        }

        // GET: Transacao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacao transacao = db.TransacaoSet.Find(id);
            if (transacao == null)
            {
                return HttpNotFound();
            }
            return View(transacao);
        }

        // POST: Transacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Valor,Ativo")] Transacao transacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transacao).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transacao);
        }

        // GET: Transacao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacao transacao = db.TransacaoSet.Find(id);
            if (transacao == null)
            {
                return HttpNotFound();
            }
            return View(transacao);
        }

        // POST: Transacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transacao transacao = db.TransacaoSet.Find(id);
            db.TransacaoSet.Remove(transacao);
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
