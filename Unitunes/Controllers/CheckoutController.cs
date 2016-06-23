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
            var listaIds = (List<int>)Checkout.getMedias();
            if (listaIds != null)
            {
                var arrayListaId = listaIds.ToArray();

                var ctx = new dbEntities();

                var medias = ctx.MediaSet;
                var academico = ctx.AcademicoSet;
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
    }
}