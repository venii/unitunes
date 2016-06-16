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
 
    }


}