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

namespace Unitunes.Controllers
{
    [Authorize]
    public class TransacaoController : Controller
    {
        private dbEntities db = new dbEntities();


        // GET: Transacao fileResult
        public FileResult Download(int idTransacao, int idMedia)
        {


            var idAcademico = Unitunes.Models.Servicos.Academico.getId();
            var academicos = db.AcademicoSet;
            // pega obj para referencia a nova transacao
            var academicoObj = academicos.Find(idAcademico);
            var resultado = (Transacao)null;
            var caminho = (Media)null;
            
            if (!User.IsInRole("Administrador"))
            {
                resultado = db.TransacaoSet.Where(t => t.AcademicoDaTransacao.Id == idAcademico).First();
                if (resultado != null)
                {
                    try
                    {
                         caminho = resultado.MediasTransacao.Where(m => m.Id == idMedia).First();

                        byte[] fileBytes = System.IO.File.ReadAllBytes(@caminho.Caminho);
                        string fileName = Path.GetFileNameWithoutExtension(@caminho.Caminho);
                        return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            }
            else
            {
                try
                {
                    resultado = db.TransacaoSet.Where(t => t.Id == idTransacao).First();
                    caminho = resultado.MediasTransacao.Where(m => m.Id == idMedia).First();

                    byte[] fileBytes = System.IO.File.ReadAllBytes(@caminho.Caminho);
                    string fileName = Path.GetFileNameWithoutExtension(@caminho.Caminho);
                    return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
                }
                catch (Exception)
                {
                    return null;
                }
            }

            return null;
        }

        // GET: Transacao
        public ActionResult Index()
        {
            

            var idAcademico = Unitunes.Models.Servicos.Academico.getId();
            var academicos = db.AcademicoSet;
            // pega obj para referencia a nova transacao
            var academicoObj = academicos.Find(idAcademico);
            
            if (!User.IsInRole("Administrador")) { 
                return View(db.TransacaoSet.Where(t => t.AcademicoDaTransacao.Id == idAcademico).ToList());
            }
            else
            {
                return View(db.TransacaoSet.ToList());
            }
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



        // Adiciona credito / apenas admin
        [Authorize(Roles="Administrador")]
        public ActionResult AdicionaCredito(int? id)
        {
            var academicos = db.AcademicoSet;
            // pega obj para referencia a nova transacao
            ViewBag.academicos = academicos.ToList();
            return View();
        }

        // Adiciona credito / apenas admin
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult AdicionaCredito(double credito,int academico)
        {
            try { 
                var contas = db.ContaAcademicoSet;

                var conta = contas.Find(academico);
                conta.Credito = credito;

                db.Entry(conta).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {

            }
            return Redirect("/Login/Principal");
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
