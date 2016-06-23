using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unitunes.Models;
using Unitunes.Models.Servicos;

namespace Unitunes.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        // GET: Checkout
        public ActionResult Index()
        {
            var errMsg = TempData["ErrorMessage"] as string;

            if(errMsg != null)
                ModelState.AddModelError("error", errMsg);


            var idAcademico = Unitunes.Models.Servicos.Academico.getId();
            var credito = Unitunes.Models.Servicos.Academico.getSaldo(idAcademico);

            ViewBag.credito = credito;

            var listaIds = (List<int>)Checkout.getMedias();
            if (listaIds != null)
            {
                var arrayListaId = listaIds.ToArray();

                var ctx = new dbEntities();

                var medias = ctx.MediaSet;
                //like usando arraylistaid e contains d media iD
                var resultado = from m in medias
                                 
                                 where arrayListaId.Contains(m.Id) && m.Ativo == true
                                 select m;

                return View(resultado);
            }

           

            return View();
        }


        public ActionResult Add(int id)
        {
            Checkout.addMedia(id);
            return Redirect("/Checkout");
        }

        public ActionResult Remove(int id)
        {
            Checkout.removeMedia(id);
            return Redirect("/Checkout");
        }



        // GET: Checkout

        [HttpPost]
        public ActionResult Finalizar(double total)
        {
            if (Checkout.getMedias().Count == 0)
            {
                return Redirect("/Checkout");
            }

            var listaIds = (List<int>)Checkout.getMedias();
            if (listaIds != null)
            {
                var arrayListaId = listaIds.ToArray();

                var ctx = new dbEntities();

                var medias = ctx.MediaSet;

                //like usando arraylistaid e contains d media iD
                var listaMedias = from m in medias

                                where arrayListaId.Contains(m.Id) && m.Ativo == true
                                select m;


                //verifica creditos
                var idAcademico = Unitunes.Models.Servicos.Academico.getId();
                var credito = Unitunes.Models.Servicos.Academico.getSaldo(idAcademico);

                if (credito > total)
                {
                   
                    var novoCredito = credito - total;
                    Unitunes.Models.Servicos.Academico.setSaldo(idAcademico,novoCredito);
                    
                    //add 15% ao admin total
                    var novoCreditoAdmin = Unitunes.Models.Servicos.Academico.getSaldo(1)+((total * 15) / 100);
                    Unitunes.Models.Servicos.Academico.setSaldo(1, novoCreditoAdmin);

                    ViewBag.credito = novoCredito;
                   
                    
                    var academicos = ctx.AcademicoSet;
                    // pega obj para referencia a nova transacao
                    var academicoObj = academicos.Find(idAcademico);



                    var transacao = ctx.TransacaoSet;
                    //cria nova transacao para inserir
                    var novaTransacao = new Transacao { AcademicoDaTransacao = academicoObj, Ativo = true, MediasTransacao = listaMedias.ToList(), Valor = total };
                    //cria transacao
                    transacao.Add(novaTransacao);
                    ctx.SaveChanges();
                    //da 15% pro admin e o resto pro autor

                    Checkout.clearCheckout();
                }
                else
                {
                    TempData["ErrorMessage"] = "Credito insuficiente";
                    
                    return Redirect("/Checkout");
                }


                return View(listaMedias);
            }
            return View();
        }

    }
}