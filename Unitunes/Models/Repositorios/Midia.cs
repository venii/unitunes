using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Unitunes.Models.Abstratos;
using Unitunes.Models.Contratos;
using Unitunes.Models.ModelosApp;


namespace Unitunes.Models.ModelosApp 
{
    public class Midia : Singleton<Midia>, IRepository<Media>
    {
        public Media GetById(int id)
        {
            var ctx = new dbEntities();
            var medias = ctx.MediaSet;

            var media = from m in medias where m.Id == id select m;
            if (media.Count() > 0)
            {
                return media.First<Media>();
            }
            return null;
        }
        //pega todas midias do academico
        public IQueryable<Media> GetByIdAcademico(int id)
        {
            var ctx = new dbEntities();
            
            var medias = ctx.MediaSet;
            var academico = ctx.AcademicoSet;

            //join academico x medias
            var minhaMidia      = from m in medias
                                join a in academico on m.AcademicoId equals a.Id
                                where a.Id == id && m.Ativo == true
                                select m;

            if (minhaMidia.Count() > 0)
            {
                return minhaMidia;
            }
            return null;
        }


        public IQueryable<Media> GetAll(Expression<Func<Media, bool>> filter)
        {
            var ctx = new dbEntities();
            var medias = ctx.MediaSet.Where(filter);

            return medias;
        }

        public bool Save(Media entity)
        {
            var ctx = new dbEntities();

            try
            {
                ctx.MediaSet.Add(entity);
                ctx.SaveChanges();

                return true;
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                {
                    // Get entry

                    DbEntityEntry entry = item.Entry;
                    string entityTypeName = entry.Entity.GetType().Name;

                    // Display or log error messages

                    foreach (DbValidationError subItem in item.ValidationErrors)
                    {
                        string message = string.Format("Error '{0}' occurred in {1} at {2}",
                                 subItem.ErrorMessage, entityTypeName, subItem.PropertyName);
                        System.Diagnostics.Debug.WriteLine(message);
                    }
                }
                return true;
            }
          
        }

        public bool Update(Media entity)
        {
            var ctx = new dbEntities();
            //var medias = ctx.MediaSet;
            try
            {


               ctx.Entry(entity).State = System.Data.Entity.EntityState.Modified;
               ctx.SaveChanges();

               return true;
                
            }
            catch (DbUpdateException ex)
            {
                var e1 = ex.Message;
                return false;
            }
           
            catch (Exception e)
            {
                return false;
            }
      
        }

        public int SaveModel(Media entity)
        {

            Save(entity);
            var ctx = new dbEntities();
            return ctx.MediaSet.Max(media => media.Id);
        }

        public bool Delete(int id)
        {

            return false;
        }

        public bool Delete(Media entity)
        {

            return false;
        }
    }
}