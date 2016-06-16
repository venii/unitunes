using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unitunes.Models.ModelosApp
{
    public class Academico
    {
        public static bool adicionarAcademico(Unitunes.Models.Academico academico)
        {
            var ctx = new dbEntities();
            
            try { 
                ctx.AcademicoSet.Add(academico);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public static bool isAcademicoExists(Unitunes.Models.Academico academico)
        {
            var ctx = new dbEntities();
            var login = ctx.AcademicoSet;

            var existeUsuario = from u in login where u.Email == academico.Email & u.Password == academico.Password select u;

            if (existeUsuario.Count() > 0)
            {
                return true;

            }

            return false;
        }

        public static bool autenticar(Unitunes.Models.Academico academico)
        {
            if (Academico.isAcademicoExists(academico))
            {
                //authentica
                System.Web.Security.FormsAuthentication.SetAuthCookie(academico.Email, false);
                //grava academico no session
                HttpContext.Current.Session["Academico"] = academico;
                return true;
            }
            return false;
        }

        public static bool logoff()
        {
            if (Academico.isAutenticado())
            {
                //authentica
                System.Web.Security.FormsAuthentication.SignOut();
                //grava academico no session
                HttpContext.Current.Session["Academico"] = null;
                return true;
            }
            return false;
        }


        public static bool isAutenticado()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }
 
    }


}