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

                return Redirect("/Midia/Listar");
            }

            return View(videoViewModel);
        }

        // GET: Videos/Edit/5
        public ActionResult Editar(int id)
        {
            Unitunes.Models.ViewModel.VideoViewModel videoViewModel = new Models.ViewModel.VideoViewModel();
            
            var midiaRepo = Singleton<Unitunes.Models.ModelosApp.Midia>.Instance();
            
            videoViewModel.midia = (Video)midiaRepo.GetById(id);


            return View(videoViewModel);
        }

        // POST: Videos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Unitunes.Models.ViewModel.VideoViewModel videoViewModel)
        {
            var midiaRepo = Singleton<Unitunes.Models.ModelosApp.Midia>.Instance();

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

                    }
                }

                //nao esquecer academicoID
                videoViewModel.midia.Ativo = true;
                videoViewModel.midia.AcademicoId = Unitunes.Models.ModelosApp.Academico.getId();
                midiaRepo.Update(videoViewModel.midia);

                return Redirect("/Midia/Listar");
            }
            return View(videoViewModel);


 
        }

        public ActionResult Visualizar(int id)
        {
            Unitunes.Models.ViewModel.VideoViewModel videoViewModel = new Models.ViewModel.VideoViewModel();

            var midiaRepo = Singleton<Unitunes.Models.ModelosApp.Midia>.Instance();

            videoViewModel.midia = (Video)midiaRepo.GetById(id);


            return View(videoViewModel);

        }

        // GET: Videos/Delete/5
        public ActionResult Deletar(int id)
        {
            Unitunes.Models.ViewModel.VideoViewModel videoViewModel = new Models.ViewModel.VideoViewModel();

            var midiaRepo = Singleton<Unitunes.Models.ModelosApp.Midia>.Instance();

            videoViewModel.midia = (Video)midiaRepo.GetById(id);


            return View(videoViewModel);

        }

        // POST: Videos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deletar(Unitunes.Models.ViewModel.VideoViewModel videoViewModel)
        {
            var midiaRepo = Singleton<Unitunes.Models.ModelosApp.Midia>.Instance();
            videoViewModel.midia.Ativo = false;

            midiaRepo.Update(videoViewModel.midia);
            return Redirect("/Midia/Listar");
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
