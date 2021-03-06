﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Unitunes.Models.Servicos
{
    public class Academico
    {
        public static bool adicionarAcademico(Unitunes.Models.Academico academico)
        {
            var ctx = new dbEntities();
            
            try {
                academico.ContaAcademico = new ContaAcademico { Ativo = true, Credito = 0 };
                ctx.AcademicoSet.Add(academico);
                ctx.SaveChanges();

               
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    System.Diagnostics.Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
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

            var existeUsuario = from u in login where u.Email == academico.Email & u.Password == academico.Password select u ;

            if (existeUsuario.Count() > 0)
            {
                return true;

            }

            return false;
        }

        public static int getId(Unitunes.Models.Academico academico)
        {
            var ctx = new dbEntities();
            var login = ctx.AcademicoSet;

            var existeUsuario = from u in login where u.Email == academico.Email & u.Password == academico.Password select u;

            if (existeUsuario.Count() > 0)
            {
                return existeUsuario.First().Id;

            }

            return 0;
        }

        public static bool autenticar(Unitunes.Models.Academico academico)
        {
            if (Academico.isAcademicoExists(academico))
            {
                //authentica
                System.Web.Security.FormsAuthentication.SetAuthCookie(academico.Email, false);
                //grava academico no session
                var ctx = new dbEntities();
                var login = ctx.AcademicoSet;
                var existeUsuario = from u in login where u.Email == academico.Email & u.Password == academico.Password select u;

                if (existeUsuario.Count() > 0)
                {
                    
                    HttpContext.Current.Session["Id"] = existeUsuario.First().Id;
                    HttpContext.Current.Session["PrimeiroNome"] = existeUsuario.First().PrimeiroNome;
                    HttpContext.Current.Session["SegundoNome"] = existeUsuario.First().SegundoNome;

                }
                
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
                HttpContext.Current.Session["Id"] = null;
                HttpContext.Current.Session["PrimeiroNome"] = null;
                HttpContext.Current.Session["SegundoNome"] = null;
                return true;
            }
            return false;
        }


        public static bool isAutenticado()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }

        public static int getId()
        {

            return (int)HttpContext.Current.Session["Id"];
        }

        public static string getIdNome(){
            try { 
               
                string n1 = HttpContext.Current.Session["PrimeiroNome"].ToString();
                string n2 = HttpContext.Current.Session["SegundoNome"].ToString();
            
                return n1 + " " + n2;

            }
            catch (Exception)
            {
                Academico.logoff();
                return null;
            }
        }


        public static double getSaldo(int id)
        {
            
                
                var ctx = new dbEntities();

                var academico = ctx.AcademicoSet;
                var contaAcademico = ctx.ContaAcademicoSet;

                var conta = contaAcademico.Find(id);

                return conta.Credito;

        }


        public static void setSaldo(int id, double vl)
        {


            var ctx = new dbEntities();

            var academico = ctx.AcademicoSet;
            var contaAcademico = ctx.ContaAcademicoSet;

            var conta = contaAcademico.Find(id);
            conta.Credito = vl;
            
            ctx.Entry(conta).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();

        }
 
    }


}