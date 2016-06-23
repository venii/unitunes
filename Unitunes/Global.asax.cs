using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Unitunes.Models;
using Unitunes.Initializer;
using System.Web.Security;
using System.Data.Entity.Core.Objects;

namespace Unitunes
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //seed do db
            

            AreaRegistration.RegisterAllAreas();

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Database.SetInitializer<dbEntities>(new Unitunes.Initializer.Initializer());
            
        }
        
        void Application_EndRequest(object sender, System.EventArgs e)
        {



            // redireciona para login se nao tiver autorizado
            if (Response.StatusCode == 401)
            {
                Response.ClearContent();
                Response.Redirect("/Login/Login");
            }
            if (Response.StatusCode == 404)
            {
                Response.ClearContent();
                Response.Redirect("/Login/Registrar");
            }
        }


        protected void FormsAuthentication_OnAuthenticate(Object sender, FormsAuthenticationEventArgs e)
        {
            if (FormsAuthentication.CookiesSupported == true)
            {
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    try
                    {
                        //let us take out the username now                
                        string username = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                        string roles = string.Empty;

                        using (dbEntities entities = new dbEntities())
                        {
                            Academico user = entities.AcademicoSet.Where(a => a.Email == username).First();
                            //pega o nome da classe pelo proxy e coloca como role
                            roles = ObjectContext.GetObjectType(user.GetType()).Name+";";
                        }
                        //let us extract the roles from our own custom cookie


                        //Let us set the Pricipal with our user specific details
                        e.User = new System.Security.Principal.GenericPrincipal(new System.Security.Principal.GenericIdentity(username, "Forms"), roles.Split(';'));
                    }
                    catch (Exception)
                    {
                        //somehting went wrong
                    }
                }
            }
        }

    }
}
