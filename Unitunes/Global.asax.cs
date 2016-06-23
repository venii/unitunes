using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Unitunes
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //seed do db
            

            AreaRegistration.RegisterAllAreas();

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
            
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
    }
}
