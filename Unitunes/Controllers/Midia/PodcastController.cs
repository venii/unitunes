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
using Unitunes.Models.Repositorios;
namespace Unitunes.Controllers.Midia
{
    public class PodcastController : Controller
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
        public ActionResult Criar(Unitunes.Models.ViewModel.PodcastViewModel podcastViewModel)
        {
            if (ModelState.IsValid)
            {
                if (podcastViewModel.arquivoUpload != null)
                {
                    if (podcastViewModel.arquivoUpload.ContentLength > 0)
                    {

                        var fileName = Path.GetFileName(podcastViewModel.arquivoUpload.FileName);
                        var path = Path.Combine(Server.MapPath("~/App_Data/midias"), fileName);
                        //salva no servidor
                        podcastViewModel.arquivoUpload.SaveAs(path);

                        podcastViewModel.midia.Caminho = path;
                        //relaciona o id do acadamico na sessao e relaciona na media

                    }

                }

                podcastViewModel.midia.AcademicoId = Unitunes.Models.Servicos.Academico.getId();
                podcastViewModel.midia.Ativo = true;

                var midiaRepo = Singleton<Unitunes.Models.Repositorios.Midia>.Instance();
                midiaRepo.Save(podcastViewModel.midia);

                return Redirect("/Midia/Listar");
            }

            return View(podcastViewModel);
        }

        // GET: Videos/Edit/5
        public ActionResult Editar(int id)
        {
            Unitunes.Models.ViewModel.PodcastViewModel podcastViewModel = new Models.ViewModel.PodcastViewModel();

            var midiaRepo = Singleton<Unitunes.Models.Repositorios.Midia>.Instance();

            podcastViewModel.midia = (Podcast)midiaRepo.GetById(id);


            return View(podcastViewModel);
        }

        // POST: Videos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Unitunes.Models.ViewModel.PodcastViewModel podcastViewModel)
        {
            var midiaRepo = Singleton<Unitunes.Models.Repositorios.Midia>.Instance();

            if (ModelState.IsValid)
            {
                if (podcastViewModel.arquivoUpload != null)
                {
                    if (podcastViewModel.arquivoUpload.ContentLength > 0)
                    {

                        var fileName = Path.GetFileName(podcastViewModel.arquivoUpload.FileName);
                        var path = Path.Combine(Server.MapPath("~/App_Data/midias"), fileName);
                        //salva no servidor
                        podcastViewModel.arquivoUpload.SaveAs(path);


                        podcastViewModel.midia.Caminho = path;

                    }
                }

                //nao esquecer academicoID
                podcastViewModel.midia.Ativo = true;
                podcastViewModel.midia.AcademicoId = Unitunes.Models.Servicos.Academico.getId();
                midiaRepo.Update(podcastViewModel.midia);

                return Redirect("/Midia/Listar");
            }
            return View(podcastViewModel);


 
        }

        public ActionResult Visualizar(int id)
        {
            Unitunes.Models.ViewModel.PodcastViewModel podcastViewModel = new Models.ViewModel.PodcastViewModel();

            var midiaRepo = Singleton<Unitunes.Models.Repositorios.Midia>.Instance();

            podcastViewModel.midia = (Podcast)midiaRepo.GetById(id);

            ViewBag.id = podcastViewModel.midia.Id;
            return View(podcastViewModel);

        }

        // GET: Videos/Delete/5
        public ActionResult Deletar(int id)
        {
            Unitunes.Models.ViewModel.PodcastViewModel podcastViewModel = new Models.ViewModel.PodcastViewModel();

            var midiaRepo = Singleton<Unitunes.Models.Repositorios.Midia>.Instance();

            podcastViewModel.midia = (Podcast)midiaRepo.GetById(id);


            return View(podcastViewModel);

        }

        // POST: Videos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deletar(Unitunes.Models.ViewModel.PodcastViewModel podcastViewModel)
        {
            var midiaRepo = Singleton<Unitunes.Models.Repositorios.Midia>.Instance();
            podcastViewModel.midia.Ativo = false;

            midiaRepo.Update(podcastViewModel.midia);
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
