using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Unitunes.Models;
using Unitunes.Models.Abstratos;

namespace Unitunes.Controllers.Midia
{
    public class VideoController : Controller
    {
        private dbEntities db = new dbEntities();


        // GET: Videos/Create
        public ActionResult Criar()
        {
            return View();
        }

        // POST: Videos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(Unitunes.Models.ViewModel.VideoViewModel videoViewModel)
        {
            if (ModelState.IsValid)
            {
                if (videoViewModel.arquivoUpload != null)
                {
                    if (videoViewModel.arquivoUpload.ContentLength > 0)
                    {

                        var fileName = Path.GetFileName(videoViewModel.arquivoUpload.FileName);
                        var path = Path.Combine(Server.MapPath("~/App_Data/midias"), fileName);
                        //salva no servidor
                        videoViewModel.arquivoUpload.SaveAs(path);

                        videoViewModel.midia.Caminho = path;
                        //relaciona o id do acadamico na sessao e relaciona na media

                    }

                }

                videoViewModel.midia.AcademicoId = Unitunes.Models.ModelosApp.Academico.getId();
                videoViewModel.midia.Ativo = true;

                var midiaRepo = Singleton<Unitunes.Models.ModelosApp.Midia>.Instance();
                midiaRepo.Save(videoViewModel.midia);

                return Redirect("/Login/Principal");
            }

            return View(videoViewModel);
        }

        // GET: Videos/Edit/5
        public ActionResult Edit(int? id)
        {
           /* if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.MediaSet.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }*/
            return View();
        }

        // POST: Videos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Descricao,Publicado,Preco,Categoria,DataCriacao,Caminho,AcademicoId,Ativo,Duracao")] Video video)
        {/*
            if (ModelState.IsValid)
            {
                db.Entry(video).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }*/
            return View(video);
        }

        // GET: Videos/Delete/5
        public ActionResult Delete(int? id)
        {/*
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.MediaSet.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }*/
            return View();
        }

        // POST: Videos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {/*
            Video video = db.MediaSet.Find(id);
            db.MediaSet.Remove(video);
            db.SaveChanges();*/
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
